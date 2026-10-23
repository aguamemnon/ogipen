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

static string MakeOfflineLicense(ECDsa signer, Dictionary<string, object> claims)
{
    var header = new Dictionary<string, object>
    {
        ["typ"] = "SLMMS-OFFLINE", ["alg"] = "ES256-DER",
        ["kid"] = "test-offline-server", ["v"] = 1
    };
    var input = Encode(JsonSerializer.SerializeToUtf8Bytes(header)) + "." +
        Encode(JsonSerializer.SerializeToUtf8Bytes(claims));
    var sig = signer.SignData(Encoding.ASCII.GetBytes(input), HashAlgorithmName.SHA256,
        DSASignatureFormat.Rfc3279DerSequence);
    return JsonSerializer.Serialize(new Dictionary<string, object>
    {
        ["type"] = "OGIPEN-OFFLINE-LICENSE",
        ["version"] = 1,
        ["token"] = input + "." + Encode(sig)
    });
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
// Air-gapped workflow: signed workstation request and offline license.
using var workstation = ECDsa.Create(ECCurve.NamedCurves.nistP256);
using var otherMachine = ECDsa.Create(ECCurve.NamedCurves.nistP256);
byte[] nonce = RandomNumberGenerator.GetBytes(32);
string offlineRequest = OfflineLicenseActivation.CreateRequest(workstation, 42, 1, nonce);
Check(OfflineLicenseActivation.TryParseRequest(offlineRequest, out int reqSoft,
        out int reqMajor, out string reqNonce, out string fingerprint) &&
    reqSoft == 42 && reqMajor == 1 && reqNonce == Encode(nonce),
    "demande hors ligne sans identifiant Windows et avec preuve P256");

string modifiedRequest = offlineRequest.Replace("\"major\":1", "\"major\":2");
Check(!OfflineLicenseActivation.TryParseRequest(modifiedRequest,
    out _, out _, out _, out _), "falsification de majeure dans .ogreq refusée");

var offlineClaims = new Dictionary<string, object>
{
    ["iss"] = issuer, ["aud"] = "ogipen-offline", ["lic"] = 55,
    ["sub"] = 88, ["activation"] = 1001,
    ["software_id"] = 42, ["software"] = "progelec", ["major"] = 1,
    ["modules"] = new[] { 10, 11 }, ["device_sha256"] = fingerprint,
    ["nonce"] = reqNonce, ["iat"] = start - 5, ["exp"] = start + 86400
};
string offline = MakeOfflineLicense(key, offlineClaims);
bool OfflineVerify(string file, ECDsa machine, int expectedMajor = 1,
    int[]? needed = null, string expectedIssuer = issuer) =>
    OfflineLicenseActivation.TryImport(file, machine, pinnedPublic,
        expectedIssuer, 42, "progelec", expectedMajor,
        needed ?? new[] { 10, 11 }, out _, now);

Check(OfflineVerify(offline, workstation), "fichier .oglic vérifié sans réseau");
Check(!OfflineVerify(offline, otherMachine), "fichier copié sur un autre poste refusé");
Check(!OfflineVerify(offline, workstation, expectedMajor: 2), "licence v1 refusée sur soft v2");
Check(!OfflineVerify(offline, workstation, needed: new[] { 12 }),
    "module hors contrat refusé localement");
Check(!OfflineVerify(offline, workstation, expectedIssuer: "https://autre.test"),
    "émetteur étranger refusé");
Check(!OfflineLicenseActivation.TryImport(offline, workstation, otherPublic,
    issuer, 42, "progelec", 1, Array.Empty<int>(), out _, now),
    "clé publique serveur étrangère refusée");
var alteredOffline = offline.Replace("OGIPEN-OFFLINE-LICENSE", "FAUSSE-LICENCE");
Check(!OfflineVerify(alteredOffline, workstation), "type fichier falsifié refusé");
offlineClaims["exp"] = start - 1;
Check(!OfflineVerify(MakeOfflineLicense(key, offlineClaims), workstation),
    "licence hors ligne expirée refusée");
offlineClaims["exp"] = start + 366L * 86400;
Check(!OfflineVerify(MakeOfflineLicense(key, offlineClaims), workstation),
    "fichier hors ligne dépassant 365 jours refusé");

Console.WriteLine("Tests OGIPEN.Core de signatures de licence : réussis.");
