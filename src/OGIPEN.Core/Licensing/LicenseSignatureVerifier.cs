using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OGIPEN.Core.Licensing;

/// <summary>
/// The WordPress issuer signs the exact UTF-8 JSON payload bytes (base64
/// encoded in the envelope) with ECDSA P-256/SHA-256, DER-encoded signature.
/// The client keeps only a trusted, application-pinned PUBLIC key.
/// Never accept a public key supplied by a license document.
/// </summary>
public sealed record SignedLicenseEnvelope(
    [property: JsonPropertyName("kid")] string KeyId,
    [property: JsonPropertyName("payload")] string PayloadBase64,
    [property: JsonPropertyName("signature")] string SignatureBase64);

public sealed record LicenseClaims(
    [property: JsonPropertyName("licenseId")] string LicenseId,
    [property: JsonPropertyName("organizationId")] string OrganizationId,
    [property: JsonPropertyName("maxUsers")] int MaxUsers,
    [property: JsonPropertyName("expiresOnUtc")] DateOnly ExpiresOnUtc,
    [property: JsonPropertyName("modules")] string[] Modules);

public static class LicenseSignatureVerifier
{
    // This verifies the document integrity and issuer identity, NOT the
    // user-seat membership or the progelec project permissions.
    public static bool TryVerify(
        SignedLicenseEnvelope? envelope,
        string trustedPublicKeyPem,
        string expectedKeyId,
        out LicenseClaims? claims)
    {
        claims = null;
        if (envelope is null || string.IsNullOrWhiteSpace(trustedPublicKeyPem) ||
            string.IsNullOrWhiteSpace(expectedKeyId) ||
            !string.Equals(envelope.KeyId, expectedKeyId, StringComparison.Ordinal))
            return false;

        try
        {
            byte[] payload = Convert.FromBase64String(envelope.PayloadBase64);
            byte[] signature = Convert.FromBase64String(envelope.SignatureBase64);
            if (payload.Length is 0 or > 16384 ||
                signature.Length is < 8 or > 512)
                return false;

            using var ec = ECDsa.Create();
            ec.ImportFromPem(trustedPublicKeyPem);
            if (ec.KeySize != 256 ||
                !ec.VerifyData(payload, signature, HashAlgorithmName.SHA256,
                    DSASignatureFormat.Rfc3279DerSequence))
                return false;

            var decoded = JsonSerializer.Deserialize<LicenseClaims>(payload);
            if (decoded is null ||
                string.IsNullOrWhiteSpace(decoded.LicenseId) ||
                string.IsNullOrWhiteSpace(decoded.OrganizationId) ||
                decoded.MaxUsers <= 0 ||
                decoded.Modules is null ||
                decoded.Modules.Any(m => string.IsNullOrWhiteSpace(m)))
                return false;
            claims = decoded;
            return true;
        }
        catch (Exception e) when (e is CryptographicException or FormatException
            or JsonException or ArgumentException or NotSupportedException)
        {
            return false;
        }
    }
}
