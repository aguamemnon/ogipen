using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace OGIPEN.Core.Security;

/// <summary>
/// Verified, server-issued rights for ONE software, ONE major version and ONE
/// WP-verified beneficiary. This is not a replacement for login or project ACLs.
/// </summary>
public sealed record VerifiedSoftwareEntitlement(
    long LicenseId,
    long BeneficiaryId,
    long PortalUserId,
    int SoftwareId,
    string SoftwareSlug,
    int MajorVersion,
    IReadOnlyList<int> ModuleIds,
    DateTimeOffset ExpiresUtc);

public static class SignedSoftwareEntitlement
{
    private const int MaxTokenLength = 8192;
    private const int MaxGrantSeconds = 3600;

    /// <summary>
    /// Verify ONLY against a public key pre-installed/pinned with the client,
    /// never against a key supplied alongside an untrusted token or fetched
    /// from the same unverified endpoint.
    ///
    /// Server format: base64url(header).base64url(claims).base64url(DER ECDSA).
    /// Signature encoding is RFC 3279 DER, NOT the raw R||S format of JWS ES256.
    /// </summary>
    public static bool TryVerify(
        string token,
        string pinnedP256PublicKeyPem,
        string expectedHttpsIssuer,
        int expectedSoftwareId,
        string expectedSoftwareSlug,
        int expectedMajorVersion,
        IReadOnlyCollection<int> requiredModuleIds,
        out VerifiedSoftwareEntitlement? entitlement,
        DateTimeOffset? utcNow = null)
    {
        entitlement = null;
        if (string.IsNullOrWhiteSpace(token) || token.Length > MaxTokenLength ||
            string.IsNullOrWhiteSpace(pinnedP256PublicKeyPem) ||
            string.IsNullOrWhiteSpace(expectedHttpsIssuer) ||
            !Uri.TryCreate(expectedHttpsIssuer, UriKind.Absolute, out var issuerUri) ||
            issuerUri.Scheme != Uri.UriSchemeHttps ||
            !string.IsNullOrEmpty(issuerUri.UserInfo) ||
            expectedSoftwareId < 1 || expectedMajorVersion < 1 ||
            string.IsNullOrWhiteSpace(expectedSoftwareSlug) || requiredModuleIds is null)
            return false;

        var parts = token.Split('.');
        if (parts.Length != 3)
            return false;

        try
        {
            var headerBytes = DecodeBase64Url(parts[0]);
            var payloadBytes = DecodeBase64Url(parts[1]);
            var signatureBytes = DecodeBase64Url(parts[2]);
            if (headerBytes.Length > 1024 || payloadBytes.Length > 4096 ||
                signatureBytes.Length > 256 || signatureBytes.Length < 64)
                return false;

            using var headerDoc = JsonDocument.Parse(headerBytes);
            using var payloadDoc = JsonDocument.Parse(payloadBytes);
            var header = headerDoc.RootElement;
            var claim = payloadDoc.RootElement;
            if (header.ValueKind != JsonValueKind.Object || claim.ValueKind != JsonValueKind.Object ||
                Text(header, "typ") != "SLMMS-ENT" ||
                Text(header, "alg") != "ES256-DER" ||
                Number(header, "v") != 1 ||
                string.IsNullOrWhiteSpace(Text(header, "kid")) ||
                Text(claim, "aud") != "slmms-desktop" ||
                Text(claim, "iss") != expectedHttpsIssuer.TrimEnd('/') ||
                Number(claim, "software_id") != expectedSoftwareId ||
                Text(claim, "software") != expectedSoftwareSlug ||
                Number(claim, "major") != expectedMajorVersion)
                return false;

            using var ecdsa = ECDsa.Create();
            ecdsa.ImportFromPem(pinnedP256PublicKeyPem);
            if (ecdsa.KeySize != 256 ||
                !ecdsa.VerifyData(
                    Encoding.ASCII.GetBytes(parts[0] + "." + parts[1]),
                    signatureBytes,
                    HashAlgorithmName.SHA256,
                    DSASignatureFormat.Rfc3279DerSequence))
                return false;

            var now = (utcNow ?? DateTimeOffset.UtcNow).ToUnixTimeSeconds();
            var issuedAt = Number(claim, "iat");
            var notBefore = Number(claim, "nbf");
            var expiresAt = Number(claim, "exp");
            if (issuedAt < 1 || issuedAt > now + 60 ||
                notBefore > now + 60 || notBefore < issuedAt ||
                expiresAt <= now || expiresAt <= issuedAt ||
                expiresAt - issuedAt > MaxGrantSeconds)
                return false;

            var licenseId = Number(claim, "lic");
            var beneficiaryId = Number(claim, "sub");
            var portalUserId = Number(claim, "uid");
            if (licenseId < 1 || beneficiaryId < 1 || portalUserId < 1 ||
                !claim.TryGetProperty("modules", out var moduleElement) ||
                moduleElement.ValueKind != JsonValueKind.Array ||
                moduleElement.GetArrayLength() > 200)
                return false;

            var granted = new HashSet<int>();
            foreach (var module in moduleElement.EnumerateArray())
            {
                if (module.ValueKind != JsonValueKind.Number ||
                    !module.TryGetInt32(out var id) || id < 1)
                    return false;
                granted.Add(id);
            }
            foreach (var requiredId in requiredModuleIds)
            {
                if (requiredId < 1 || !granted.Contains(requiredId))
                    return false;
            }

            entitlement = new VerifiedSoftwareEntitlement(
                licenseId, beneficiaryId, portalUserId,
                expectedSoftwareId, expectedSoftwareSlug, expectedMajorVersion,
                granted.OrderBy(id => id).ToArray(),
                DateTimeOffset.FromUnixTimeSeconds(expiresAt));
            return true;
        }
        catch (Exception error) when (
            error is FormatException or JsonException or ArgumentException or
            CryptographicException or OverflowException or InvalidOperationException)
        {
            return false;
        }
    }

    private static string? Text(JsonElement element, string property)
    {
        return element.TryGetProperty(property, out var value) &&
            value.ValueKind == JsonValueKind.String ? value.GetString() : null;
    }

    private static long Number(JsonElement element, string property)
    {
        return element.TryGetProperty(property, out var value) &&
            value.ValueKind == JsonValueKind.Number && value.TryGetInt64(out var number)
            ? number : -1;
    }

    private static byte[] DecodeBase64Url(string encoded)
    {
        if (encoded.Length == 0 || encoded.Any(c =>
            !((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') ||
              (c >= '0' && c <= '9') || c is '-' or '_')))
            throw new FormatException("Non canonical base64url segment.");
        var standard = encoded.Replace('-', '+').Replace('_', '/');
        standard += new string('=', (4 - standard.Length % 4) % 4);
        var bytes = Convert.FromBase64String(standard);
        if (Convert.ToBase64String(bytes).TrimEnd('=')
            .Replace('+', '-').Replace('/', '_') != encoded)
            throw new FormatException("Non canonical base64url encoding.");
        return bytes;
    }
}
