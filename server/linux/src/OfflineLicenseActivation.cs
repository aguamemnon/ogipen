using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace OGIPEN.Core.Security;

/// <summary>
/// Exchange format for an air-gapped workstation. Requests contain ONLY a
/// non-secret public key, random nonce, software ID and major version.
/// No hostname, AD domain, username, IP, project or classified information.
/// </summary>
public static class OfflineLicenseActivation
{
    public const int MaxRequestBytes = 8192;
    public const int MaxLicenseBytes = 16384;
    public const int MaxOfflineDays = 365;

    public sealed record OfflineGrant(
        long LicenseId, long BeneficiaryId, long ActivationId,
        int SoftwareId, string SoftwareSlug, int MajorVersion,
        IReadOnlyList<int> ModuleIds, DateTimeOffset ExpiresUtc)
    {
        public bool IsDeviceBound => BeneficiaryId==0;
    }

    public static string CreateRequest(ECDsa deviceKey, int softwareId, int major,
                                       byte[] randomNonce)
    {
        if (softwareId < 1 || major < 1 || major > 999 ||
            randomNonce.Length != 32 || deviceKey.KeySize != 256)
            throw new ArgumentException("Paramètres de demande hors ligne invalides.");
        string publicKey = B64(deviceKey.ExportSubjectPublicKeyInfo());
        string nonce = B64(randomNonce);
        string canonical = RequestCanonical(softwareId, major, nonce, publicKey);
        byte[] signature = deviceKey.SignData(
            Encoding.UTF8.GetBytes(canonical), HashAlgorithmName.SHA256,
            DSASignatureFormat.Rfc3279DerSequence);
        return JsonSerializer.Serialize(new Dictionary<string, object>
        {
            ["type"] = "OGIPEN-OFFLINE-REQUEST", ["version"] = 1,
            ["software_id"] = softwareId, ["major"] = major,
            ["nonce"] = nonce, ["public_key_spki"] = publicKey, ["proof"] = B64(signature)
        });
    }

    public static string RequestCanonical(int softwareId, int major,
                                          string nonce, string publicKey) =>
        "OGIPEN-OFFLINE-REQUEST-v1\n" + softwareId + "\n" + major + "\n" +
        nonce + "\n" + publicKey + "\n";

    public static bool TryParseRequest(string json, out int softwareId,
                                       out int major, out string nonce,
                                       out string deviceFingerprint)
    {
        softwareId = major = 0;
        nonce = deviceFingerprint = "";
        if (string.IsNullOrWhiteSpace(json) ||
            Encoding.UTF8.GetByteCount(json) > MaxRequestBytes) return false;
        try
        {
            using var document = JsonDocument.Parse(json);
            var obj = document.RootElement;
            if (obj.ValueKind != JsonValueKind.Object ||
                Str(obj, "type") != "OGIPEN-OFFLINE-REQUEST" ||
                Long(obj, "version") != 1) return false;
            softwareId = checked((int)Long(obj, "software_id"));
            major = checked((int)Long(obj, "major"));
            nonce = Str(obj, "nonce") ?? "";
            string publicKey = Str(obj, "public_key_spki") ?? "";
            string proof = Str(obj, "proof") ?? "";
            if (softwareId <= 0 || major <= 0 || major > 999) return false;
            byte[] nonceData = Decode(nonce);
            byte[] publicBytes = Decode(publicKey);
            byte[] signature = Decode(proof);
            if (nonceData.Length != 32 || publicBytes.Length > 1024 ||
                signature.Length is < 64 or > 256) return false;
            using var ecdsa = ECDsa.Create();
            ecdsa.ImportSubjectPublicKeyInfo(publicBytes, out int read);
            if (read != publicBytes.Length || ecdsa.KeySize != 256 ||
                !ecdsa.VerifyData(
                    Encoding.UTF8.GetBytes(RequestCanonical(softwareId, major, nonce, publicKey)),
                    signature, HashAlgorithmName.SHA256,
                    DSASignatureFormat.Rfc3279DerSequence)) return false;
            deviceFingerprint = Convert.ToHexString(SHA256.HashData(publicBytes)).ToLowerInvariant();
            return true;
        }
        catch (Exception error) when (
            error is FormatException or JsonException or CryptographicException
            or ArgumentException or OverflowException or InvalidOperationException)
        {
            return false;
        }
    }

    /// <summary>
    /// Verifies a signed offline license with an independently pinned issuer
    /// public key AND the still-present workstation private key. No network.
    /// </summary>
    public static bool TryImport(string licenseFileJson, ECDsa deviceKey,
        string pinnedIssuerPublicKeyPem, string expectedIssuer,
        int softwareId, string softwareSlug, int major,
        IReadOnlyCollection<int> requiredModules,
        out OfflineGrant? grant, DateTimeOffset? utcNow = null)
    {
        grant = null;
        if (string.IsNullOrWhiteSpace(licenseFileJson) ||
            Encoding.UTF8.GetByteCount(licenseFileJson) > MaxLicenseBytes ||
            deviceKey is null || deviceKey.KeySize != 256 ||
            string.IsNullOrWhiteSpace(pinnedIssuerPublicKeyPem) ||
            !Uri.TryCreate(expectedIssuer, UriKind.Absolute, out var issuerUri) ||
            issuerUri.Scheme != Uri.UriSchemeHttps ||
            softwareId < 1 || major < 1 || requiredModules is null) return false;

        try
        {
            using var document = JsonDocument.Parse(licenseFileJson);
            var file = document.RootElement;
            if (file.ValueKind != JsonValueKind.Object ||
                Str(file, "type") != "OGIPEN-OFFLINE-LICENSE" ||
                Long(file, "version") != 1) return false;
            string[] parts = (Str(file, "token") ?? "").Split('.');
            if (parts.Length != 3) return false;
            using var headerDoc = JsonDocument.Parse(Decode(parts[0]));
            using var claimDoc = JsonDocument.Parse(Decode(parts[1]));
            var header = headerDoc.RootElement;
            var payload = claimDoc.RootElement;
            if (Str(header, "alg") != "ES256-DER" ||
                Str(header, "typ") != "SLMMS-OFFLINE" ||
                Long(header, "v") != 1 ||
                Str(payload, "aud") != "ogipen-offline" ||
                Str(payload, "iss") != expectedIssuer.TrimEnd('/') ||
                Long(payload, "software_id") != softwareId ||
                Str(payload, "software") != softwareSlug ||
                Long(payload, "major") != major) return false;

            byte[] signature = Decode(parts[2]);
            using var issuerKey = ECDsa.Create();
            issuerKey.ImportFromPem(pinnedIssuerPublicKeyPem);
            if (issuerKey.KeySize != 256 ||
                !issuerKey.VerifyData(Encoding.ASCII.GetBytes(parts[0] + "." + parts[1]),
                    signature, HashAlgorithmName.SHA256,
                    DSASignatureFormat.Rfc3279DerSequence)) return false;

            string machineHash = Convert.ToHexString(
                SHA256.HashData(deviceKey.ExportSubjectPublicKeyInfo())).ToLowerInvariant();
            if (!CryptographicOperations.FixedTimeEquals(
                Encoding.ASCII.GetBytes(machineHash),
                Encoding.ASCII.GetBytes(Str(payload, "device_sha256") ?? ""))) return false;

            byte[] nonce = Decode(Str(payload, "nonce") ?? "");
            if (nonce.Length != 32) return false;
            long issued = Long(payload, "iat");
            long expires = Long(payload, "exp");
            long now = (utcNow ?? DateTimeOffset.UtcNow).ToUnixTimeSeconds();
            if (issued <= 0 || issued > now + 300 ||
                expires <= now || expires <= issued ||
                expires - issued > MaxOfflineDays * 86400L) return false;

            long licenseId = Long(payload, "lic");
            long beneficiaryId = Long(payload, "sub");
            long activationId = Long(payload, "activation");
            bool deviceBound=Str(payload,"binding")=="device";
            if (licenseId < 1 || (deviceBound?beneficiaryId!=0:beneficiaryId<1) || activationId < 1 ||
                !payload.TryGetProperty("modules", out var modules) ||
                modules.ValueKind != JsonValueKind.Array ||
                modules.GetArrayLength() > 200) return false;
            var allowed = new HashSet<int>();
            foreach (var module in modules.EnumerateArray())
            {
                if (!module.TryGetInt32(out int id) || id < 1) return false;
                allowed.Add(id);
            }
            if (requiredModules.Any(id => !allowed.Contains(id))) return false;
            grant = new OfflineGrant(
                licenseId, beneficiaryId, activationId,
                softwareId, softwareSlug, major,
                allowed.OrderBy(x => x).ToArray(),
                DateTimeOffset.FromUnixTimeSeconds(expires));
            return true;
        }
        catch (Exception error) when (
            error is FormatException or JsonException or CryptographicException
            or ArgumentException or OverflowException or InvalidOperationException)
        {
            return false;
        }
    }

    private static string? Str(JsonElement obj, string key) =>
        obj.TryGetProperty(key, out var val) && val.ValueKind == JsonValueKind.String
            ? val.GetString() : null;

    private static long Long(JsonElement obj, string key) =>
        obj.TryGetProperty(key, out var val) && val.ValueKind == JsonValueKind.Number &&
        val.TryGetInt64(out long value) ? value : -1;

    public static string B64(byte[] bytes) =>
        Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');

    private static byte[] Decode(string s)
    {
        if (s.Length == 0 || s.Any(c => !char.IsAsciiLetterOrDigit(c) && c is not '-' and not '_'))
            throw new FormatException("Encodage base64url invalide.");
        string padded = s.Replace('-', '+').Replace('_', '/') +
            new string('=', (4 - s.Length % 4) % 4);
        byte[] data = Convert.FromBase64String(padded);
        if (B64(data) != s) throw new FormatException("Encodage base64url non canonique.");
        return data;
    }
}
