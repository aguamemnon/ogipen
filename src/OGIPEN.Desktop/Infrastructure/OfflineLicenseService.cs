using System.Security.Cryptography;
using OGIPEN.Core.Security;

namespace OGIPEN.Desktop.Infrastructure;

/// <summary>
/// Native Windows device key: private material is non-exportable through the
/// user-scoped Windows CNG key storage provider. A workstation administrator
/// or compromised OS can still bypass this; this is not a TPM guarantee.
/// </summary>
public static class OfflineLicenseService
{
    public const string SoftwareSlug = "progelec";
    public const int SoftwareMajorVersion = 1;
    public const string ExpectedIssuer = "https://www.trueshield.fr";
    private const string KeyName = "OGIPEN_Offline_P256_v1";

    public static string PublicKeyFile => Path.Combine(AppContext.BaseDirectory,
        "Assets", "SLMMS-Signing-Public.pem");

    public static string StoredLicenseFile => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "OGIPEN", "offline-license.oglic");

    private static ECDsa OpenDeviceKey()
    {
        if (!OperatingSystem.IsWindows())
            throw new PlatformNotSupportedException("Le stockage sécurisé CNG nécessite Windows.");
        var provider = CngProvider.MicrosoftSoftwareKeyStorageProvider;
        CngKey key;
        if (CngKey.Exists(KeyName, provider, CngKeyOpenOptions.UserKey))
        {
            key = CngKey.Open(KeyName, provider, CngKeyOpenOptions.UserKey);
        }
        else
        {
            key = CngKey.Create(CngAlgorithm.ECDsaP256, KeyName,
                new CngKeyCreationParameters
                {
                    Provider = provider,
                    KeyCreationOptions = CngKeyCreationOptions.None,
                    ExportPolicy = CngExportPolicies.None,
                    KeyUsage = CngKeyUsages.Signing
                });
        }
        using (key)
        {
            return new ECDsaCng(key);
        }
    }

    public static void ExportRequest(string destination, int softwareId)
    {
        if (softwareId <= 0)
            throw new InvalidOperationException(
                "L'identifiant logiciel doit être renseigné dans la configuration du site.");
        using var key = OpenDeviceKey();
        var nonce = RandomNumberGenerator.GetBytes(32);
        var request = OfflineLicenseActivation.CreateRequest(
            key, softwareId, SoftwareMajorVersion, nonce);
        File.WriteAllText(destination, request, new System.Text.UTF8Encoding(false));
    }

    public static bool TryReadLicense(int softwareId,
        out OfflineLicenseActivation.OfflineGrant? grant)
    {
        grant = null;
        if (softwareId < 1 || !File.Exists(StoredLicenseFile) ||
            !File.Exists(PublicKeyFile)) return false;
        try
        {
            return VerifyFile(StoredLicenseFile, softwareId, out grant);
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException
            or CryptographicException or FormatException or InvalidOperationException)
        {
            return false;
        }
    }

    private static bool VerifyFile(string file, int softwareId,
        out OfflineLicenseActivation.OfflineGrant? grant)
    {
        grant = null;
        var fileInfo = new FileInfo(file);
        if (fileInfo.Length > OfflineLicenseActivation.MaxLicenseBytes)
            return false;
        using var key = OpenDeviceKey();
        var trustedPublicKey = File.ReadAllText(PublicKeyFile);
        return OfflineLicenseActivation.TryImport(
            File.ReadAllText(file), key, trustedPublicKey, ExpectedIssuer,
            softwareId, SoftwareSlug, SoftwareMajorVersion,
            Array.Empty<int>(), out grant);
    }

    public static OfflineLicenseActivation.OfflineGrant ImportLicense(string source,
        int softwareId)
    {
        if (!File.Exists(PublicKeyFile))
            throw new InvalidOperationException(
                "Clé publique de confiance absente. Distribue-la via l'installateur signé.");
        if (softwareId < 1)
            throw new InvalidOperationException("L'identifiant logiciel n'est pas configuré.");
        if (!VerifyFile(source, softwareId, out var grant) || grant is null)
            throw new InvalidOperationException(
                "Licence refusée : signature, poste, logiciel, majeure ou date invalides.");
        Directory.CreateDirectory(Path.GetDirectoryName(StoredLicenseFile)!);
        // Store signed, integrity-protected data. The private CNG device key is
        // never stored in this directory nor in the exported request.
        File.Copy(source, StoredLicenseFile, true);
        return grant;
    }
}
