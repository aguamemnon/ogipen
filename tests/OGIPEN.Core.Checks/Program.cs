using System.Security.Cryptography;
using System.Text.Json;
using OGIPEN.Core.Licensing;

static void Check(bool success, string name)
{
    if (!success) throw new Exception("ÉCHEC: " + name);
    Console.WriteLine("OK: " + name);
}

var today = new DateOnly(2026, 10, 22);
var cases = new (int? Offset, bool Verified, LicenseAlertCode Code, bool Blocks)[]
{
    (null, false, LicenseAlertCode.Missing, true),
    (40, false, LicenseAlertCode.Invalid, true),
    (31, true, LicenseAlertCode.Valid, false),
    (30, true, LicenseAlertCode.Expiring30Days, false),
    (16, true, LicenseAlertCode.Expiring30Days, false),
    (15, true, LicenseAlertCode.Expiring15Days, false),
    (1, true, LicenseAlertCode.Expiring15Days, false),
    (0, true, LicenseAlertCode.ExpiringToday, false),
    (-1, true, LicenseAlertCode.Expired, true),
    (-14, true, LicenseAlertCode.Expired, true),
    (-15, true, LicenseAlertCode.Expired15Days, true),
    (-29, true, LicenseAlertCode.Expired15Days, true),
    (-30, true, LicenseAlertCode.Expired30Days, true)
};
foreach (var (offset, verified, code, blocks) in cases)
{
    var expiry = offset.HasValue ? today.AddDays(offset.Value) : (DateOnly?)null;
    var actual = LicenseAlertEvaluator.Evaluate(expiry, verified, today);
    Check(actual.Code == code && actual.BlocksLicensedFeatures == blocks,
        $"Licence {offset?.ToString() ?? "absente"} jours / {code}");
}

using var issuer = ECDsa.Create(ECCurve.NamedCurves.nistP256);
var trustedPublic = issuer.ExportSubjectPublicKeyInfoPem();
var claims = new LicenseClaims("OGIPEN-TEST", "ORG-TEST", 5, today.AddDays(30),
    new[] { "etude", "rapports" });
var payload = JsonSerializer.SerializeToUtf8Bytes(claims);
var signature = issuer.SignData(payload, HashAlgorithmName.SHA256,
    DSASignatureFormat.Rfc3279DerSequence);
var env = new SignedLicenseEnvelope("issuer-test-2026",
    Convert.ToBase64String(payload), Convert.ToBase64String(signature));
Check(LicenseSignatureVerifier.TryVerify(env, trustedPublic,
        "issuer-test-2026", out var decoded) &&
        decoded is not null && decoded.MaxUsers == 5,
    "Licence ECDSA authentifiée");
Check(!LicenseSignatureVerifier.TryVerify(env, trustedPublic, "mauvaise-cle", out _),
    "Refus kid non reconnu");

var modified = JsonSerializer.SerializeToUtf8Bytes(claims with { MaxUsers = 500 });
var tampered = env with { PayloadBase64 = Convert.ToBase64String(modified) };
Check(!LicenseSignatureVerifier.TryVerify(tampered, trustedPublic,
    "issuer-test-2026", out _), "Refus JSON modifié");

using var stranger = ECDsa.Create(ECCurve.NamedCurves.nistP256);
Check(!LicenseSignatureVerifier.TryVerify(env,
    stranger.ExportSubjectPublicKeyInfoPem(), "issuer-test-2026", out _),
    "Refus clé non approuvée");
Check(!LicenseSignatureVerifier.TryVerify(
    env with { SignatureBase64 = "not-base64" },
    trustedPublic, "issuer-test-2026", out _),
    "Refus enveloppe mal formée");

Console.WriteLine("Tous les contrôles de licence ont réussi sur ce système.");
