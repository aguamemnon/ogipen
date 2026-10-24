using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Ogipen.Licensing;

// Portable .NET 10 helper - verification only. Subject binding and device identity checks belong to caller.
public static class OgipenLicenseVerifier
{
    public static JsonDocument Verify(string licenseJson, string publicKeyPem)
    {
        using var envelope = JsonDocument.Parse(licenseJson);
        var root = envelope.RootElement;
        if (root.GetProperty("format").GetString() != "ogipen-license-v1" ||
            root.GetProperty("alg").GetString() != "ES256")
            throw new CryptographicException("Unknown license format");

        static byte[] Decode(string s)
        {
            var raw = s.Replace('-', '+').Replace('_', '/');
            return Convert.FromBase64String(raw.PadRight((raw.Length + 3) / 4 * 4, '='));
        }
        byte[] payload = Decode(root.GetProperty("payload").GetString()!);
        byte[] signature = Decode(root.GetProperty("signature").GetString()!);
        using var ec = ECDsa.Create();
        ec.ImportFromPem(publicKeyPem);
        if (!ec.VerifyData(payload, signature, HashAlgorithmName.SHA256,
            DSASignatureFormat.Rfc3279DerSequence))
            throw new CryptographicException("Invalid license signature");
        var data = JsonDocument.Parse(payload);
        if (data.RootElement.GetProperty("schema").GetString() != "ogipen-entitlement-v1")
            throw new CryptographicException("Invalid schema");
        var date = DateTimeOffset.ParseExact(data.RootElement.GetProperty("expires_utc").GetString()!,
            "yyyy-MM-dd'T'HH:mm:ss'Z'", System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal);
        if (date < DateTimeOffset.UtcNow) throw new CryptographicException("Expired license");
        return data;
    }
}
