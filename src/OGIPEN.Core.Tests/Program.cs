using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using OGIPEN.Core.Security;

static string Encode(byte[] bytes) =>
    Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');

static string MakeToken(ECDsa signer, Dictionary<string, object> claims, string algorithm = "ES256-DER")
{
    var header = new Dictionary<string, object>
    {
        ["typ"] = "SLMMS-ENT", ["alg"] = algorithm, ["kid"] = "example-test-key", ["v"] = 1
    };
    var input = Encode(JsonSerializer.SerializeToUtf8Bytes(header)) + "." +
        Encode(JsonSerializer.SerializeToUtf8Bytes(claims));
    var signature = signer.SignData(
        Encoding.ASCII.GetBytes(input), HashAlgorithmName.SHA256,
        DSASignatureFormat.Rfc3279DerSequence);
    return input + "." + Encode(signature);
}

static void Check(bool condition, string label)
{
    if (!condition)
        throw new InvalidOperationException("ÉCHEC : " + label);
    Console.WriteLine("OK : " + label);
}

using var key = ECDsa.Create(ECCurve.NamedCurves.nistP256);
using var foreignKey = ECDsa.Create(ECCurve.NamedCurves.nistP256);
var pinnedPublic = key.ExportSubjectPublicKeyInfoPem();
var otherPublic = foreignKey.ExportSubjectPublicKeyInfoPem();
const string issuer = "https://example.test";
var now = DateTimeOffset.UtcNow;
var start = now.ToUnixTimeSeconds();
var claims = new Dictionary<string, object>
{
    ["iss"] = issuer,
    ["aud"] = "slmms-desktop",
    ["lic"] = 55,
    ["sub"] = 99,
    ["uid"] = 7,
    ["software_id"] = 42,
    ["software"] = "progelec",
    ["major"] = 1,
    ["modules"] = new[] { 10, 11 },
    ["iat"] = start - 5,
    ["nbf"] = start - 5,
    ["exp"] = start + 900
};
var token = MakeToken(key, claims);
bool Verify(string value, string pem, int major = 1, int[]? modules = null,
    string expectedIssuer = issuer) =>
    SignedSoftwareEntitlement.TryVerify(value, pem, expectedIssuer,
        42, "progelec", major, modules ?? new[] { 10, 11 },
        out _, now);

Check(Verify(token, pinnedPublic), "signature DER, majeure et modules vérifiés");
Check(SignedSoftwareEntitlement.TryVerify(token, pinnedPublic, issuer,
    42, "progelec", 1, new[] { 10 }, out var grant, now) &&
    grant is not null && grant.LicenseId == 55 &&
    grant.BeneficiaryId == 99 && grant.PortalUserId == 7,
    "identité liée au compte WordPress et à la licence");
Check(!Verify(token, otherPublic), "clé publique étrangère refusée");
Check(!Verify(token, pinnedPublic, major: 2), "v1 ne permet pas v2");
Check(!Verify(token, pinnedPublic, modules: new[] { 10, 12 }),
    "module non acheté refusé");
Check(!Verify(token, pinnedPublic, expectedIssuer: "https://evil.test"),
    "émetteur inattendu refusé");
Check(!Verify(token + "a", pinnedPublic), "signature modifiée refusée");
Check(!Verify("broken.token", pinnedPublic), "jeton incomplet refusé");
Check(!Verify(MakeToken(key, claims, "none"), pinnedPublic),
    "algorithme none refusé malgré une signature");
claims["aud"] = "different-client";
Check(!Verify(MakeToken(key, claims), pinnedPublic), "audience différente refusée");
claims["aud"] = "slmms-desktop";
claims["exp"] = start - 1;
Check(!Verify(MakeToken(key, claims), pinnedPublic), "jeton expiré refusé");
claims["exp"] = start + 7200;
Check(!Verify(MakeToken(key, claims), pinnedPublic),
    "attestation de plus d'une heure refusée");
Console.WriteLine("Tests OGIPEN.Core de signatures de licence : réussis.");
