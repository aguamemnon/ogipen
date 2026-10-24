using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using OGIPEN.Core.Security;

namespace OGIPEN.Desktop.Infrastructure;

public static class ServerTransport
{
    private static ServerProfile[] Provisioned()
    {
        var path=Path.Combine(AppContext.BaseDirectory,"Assets","company-server-profiles.json");
        if(!File.Exists(path))return Array.Empty<ServerProfile>();
        if(new FileInfo(path).Length>65536)throw new InvalidOperationException("Configuration des serveurs fournie invalide.");
        var profiles=JsonSerializer.Deserialize<ServerProfile[]>(File.ReadAllText(path))??Array.Empty<ServerProfile>();
        foreach(var p in profiles){_ = LicensedSessionClient.RequireSecureEndpoint(p.ApiBaseUrl);ValidatePin(p.CertificateSha256);}
        return profiles;
    }
    public static void ApplyProvisioning(ClientConfiguration configuration)
    {
        var empty=configuration.ServerProfiles.Count==0;
        foreach(var p in Provisioned()){
            var uri=LicensedSessionClient.RequireSecureEndpoint(p.ApiBaseUrl);
            if(!configuration.ServerProfiles.Any(x=>LicensedSessionClient.RequireSecureEndpoint(x.ApiBaseUrl)==uri)){
                if(configuration.ServerProfiles.Any(x=>x.Id==p.Id))p.Id="company-"+Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(uri.AbsoluteUri)))[..24];
                configuration.ServerProfiles.Add(p);
            }
        }
        if(empty && configuration.ServerProfiles.Count==1)configuration.SelectProfile(configuration.ServerProfiles[0].Id);
    }
    public static void ValidatePin(string pin)
    {
        if(pin!="" && (pin.Length!=64 || !pin.All(Uri.IsHexDigit)))throw new InvalidOperationException("L’empreinte du certificat doit contenir 64 caractères hexadécimaux SHA-256.");
    }
    public static HttpClient CreateClient(Uri endpoint,ClientConfiguration? configuration=null)
    {
        endpoint=LicensedSessionClient.RequireSecureEndpoint(endpoint.AbsoluteUri);
        var pin=configuration?.ServerProfiles.FirstOrDefault(x=>LicensedSessionClient.RequireSecureEndpoint(x.ApiBaseUrl)==endpoint)?.CertificateSha256;
        if(string.IsNullOrEmpty(pin))pin=Provisioned().FirstOrDefault(x=>LicensedSessionClient.RequireSecureEndpoint(x.ApiBaseUrl)==endpoint)?.CertificateSha256;
        pin??="";ValidatePin(pin);
        var handler=new HttpClientHandler{AllowAutoRedirect=false};
        if(pin!="")handler.ServerCertificateCustomValidationCallback=(_,certificate,chain,errors)=>ServerCertificateTrust.Validate(certificate,chain,errors,pin);
        return new HttpClient(handler){BaseAddress=endpoint,Timeout=TimeSpan.FromSeconds(15),MaxResponseContentBufferSize=65536};
    }
    public static string ImportCertificateFingerprint(string path)
    {
        if(new FileInfo(path).Length>32768)throw new InvalidOperationException("Certificat trop volumineux.");
        var bytes=File.ReadAllBytes(path);var text=System.Text.Encoding.UTF8.GetString(bytes);
        if(text.Contains("PRIVATE KEY",StringComparison.Ordinal))throw new InvalidOperationException("Importez uniquement le certificat public du serveur.");
        using var cert=text.Contains("BEGIN CERTIFICATE",StringComparison.Ordinal)?X509Certificate2.CreateFromPem(text):X509CertificateLoader.LoadCertificate(bytes);
        if(cert.Extensions.OfType<X509BasicConstraintsExtension>().Any(x=>x.CertificateAuthority))throw new InvalidOperationException("Importez le certificat du serveur, pas une autorité de certification.");
        if(cert.NotBefore.ToUniversalTime()>DateTime.UtcNow || cert.NotAfter.ToUniversalTime()<=DateTime.UtcNow)throw new InvalidOperationException("Certificat hors période de validité.");
        return ServerCertificateTrust.Fingerprint(cert);
    }
}
