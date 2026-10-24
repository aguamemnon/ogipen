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
    public const string SoftwareSlug = "ogipen";
    public const int SoftwareMajorVersion = 1;
    public const string ExpectedIssuer = "https://www.trueshield.fr";
    private const string KeyName = "OGIPEN_Offline_P256_v1";

    public static string PublicKeyFile => Path.Combine(AppContext.BaseDirectory,
        "Assets", "SLMMS-Signing-Public.pem");

    public static string StoredLicenseFile => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "OGIPEN", "offline-license.oglic");

    private static ECDsa OpenDeviceKey(bool create=false)
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
            if(!create)throw new InvalidOperationException("Clé de ce compte Windows absente. Exportez une demande d’activation depuis cette session.");
            key = CngKey.Create(CngAlgorithm.ECDsaP256, KeyName,
                new CngKeyCreationParameters
                {
                    Provider = provider,
                    KeyCreationOptions = CngKeyCreationOptions.None,
                    ExportPolicy = CngExportPolicies.None,
                    KeyUsage = CngKeyUsages.Signing
                });
        }
        // ECDsaCng takes ownership of the key handle for the lifetime of
        // the signing instance. Do not dispose the CngKey before signing.
        return new ECDsaCng(key);
    }

    public static void ExportRequest(string destination, int softwareId)
    {
        if (softwareId <= 0)
            throw new InvalidOperationException(
                "L'identifiant logiciel doit être renseigné dans la configuration du site.");
        using var key = OpenDeviceKey(create:true);
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

    public static (string Json,OfflineLicenseActivation.OfflineGrant Grant) ReadConnectionLicense(int softwareId)
    {
        if(!File.Exists(StoredLicenseFile) || !File.Exists(PublicKeyFile))
            throw new InvalidOperationException("Importez une licence poste et la clé publique de confiance avant la connexion.");
        if(new FileInfo(StoredLicenseFile).Length>OfflineLicenseActivation.MaxLicenseBytes)
            throw new InvalidOperationException("Fichier de licence trop volumineux.");
        var json=File.ReadAllText(StoredLicenseFile);
        if(!VerifyJson(json,softwareId,out var grant) || grant is null)
            throw new InvalidOperationException("La licence locale ne correspond pas à ce poste, à Ogipen ou à sa période de validité.");
        return (json,grant);
    }
    public static long? DeclaredStoredLicenseNumber()
    {
        try{
            if(!File.Exists(StoredLicenseFile) || new FileInfo(StoredLicenseFile).Length>16384)return null;
            using var file=System.Text.Json.JsonDocument.Parse(File.ReadAllText(StoredLicenseFile));
            var parts=file.RootElement.GetProperty("token").GetString()!.Split('.');if(parts.Length!=3)return null;
            var encoded=parts[1].Replace('-','+').Replace('_','/');
            using var claims=System.Text.Json.JsonDocument.Parse(Convert.FromBase64String(encoded.PadRight((encoded.Length+3)/4*4,'=')));
            return claims.RootElement.GetProperty("lic").TryGetInt64(out var n) && n>0?n:null;
        }catch{return null;}
    }

    public static byte[] SignChallenge(string text,Uri audience)
    {
        var identity=WindowsSessionIdentity.Current();
        var prefix="OGIPEN-AUTH-v2:"+LicensedSessionClient.RequireSecureEndpoint(audience.AbsoluteUri).AbsoluteUri+":"+identity.IdentityId+":";
        if(!text.StartsWith(prefix,StringComparison.Ordinal))throw new InvalidOperationException("Challenge d’une autre session Windows refusé.");
        var nonce=Convert.FromBase64String(text[prefix.Length..]);
        if(nonce.Length!=32 || Convert.ToBase64String(nonce)!=text[prefix.Length..])throw new InvalidOperationException("Challenge invalide.");
        using var key=OpenDeviceKey();
        return key.SignData(System.Text.Encoding.UTF8.GetBytes(text),HashAlgorithmName.SHA256,DSASignatureFormat.IeeeP1363FixedFieldConcatenation);
    }

    public static void ExportEnrollmentInfo(string destination)
    {
        var identity=WindowsSessionIdentity.Current();
        using var key=OpenDeviceKey(create:true);
        File.WriteAllText(destination,"OGIPEN — fiche d’enrôlement administratif\nIdentifiant Ogipen : "+identity.IdentityId+
            "\nSession Windows : "+identity.DisplayName+"\nClé publique :\n"+key.ExportSubjectPublicKeyInfoPem()+
            "\nCette fiche contient un identifiant Windows. Transmettre par un circuit autorisé.\n",new System.Text.UTF8Encoding(false));
    }

    private static bool VerifyFile(string file, int softwareId,
        out OfflineLicenseActivation.OfflineGrant? grant)
    {
        grant = null;
        var fileInfo = new FileInfo(file);
        if (fileInfo.Length > OfflineLicenseActivation.MaxLicenseBytes)
            return false;
        return VerifyJson(File.ReadAllText(file),softwareId,out grant);
    }

    private static bool VerifyJson(string json,int softwareId,out OfflineLicenseActivation.OfflineGrant? grant)
    {
        using var key = OpenDeviceKey();
        var trustedPublicKey = File.ReadAllText(PublicKeyFile);
        return OfflineLicenseActivation.TryImport(
            json, key, trustedPublicKey, ExpectedIssuer,
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
        if(new FileInfo(source).Length>OfflineLicenseActivation.MaxLicenseBytes)throw new InvalidOperationException("Fichier trop volumineux.");
        var json=File.ReadAllText(source);
        if (!VerifyJson(json, softwareId, out var grant) || grant is null)
            throw new InvalidOperationException(
                "Licence refusée : signature, poste, logiciel, majeure ou date invalides.");
        Directory.CreateDirectory(Path.GetDirectoryName(StoredLicenseFile)!);
        // Store signed, integrity-protected data. The private CNG device key is
        // never stored in this directory nor in the exported request.
        var tmp=StoredLicenseFile+"."+Guid.NewGuid().ToString("N")+".tmp";
        try{File.WriteAllText(tmp,json,new System.Text.UTF8Encoding(false));File.Move(tmp,StoredLicenseFile,true);}
        finally{if(File.Exists(tmp))File.Delete(tmp);}
        return grant;
    }
}
