using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using OGIPEN.Core.Security;
using OGIPEN.Desktop.Infrastructure;

static class CertificateChecks
{
    public static void Run(Action<string,bool> check)
    {
        using var key=RSA.Create(2048);
        X509Certificate2 Make(DateTimeOffset before,DateTimeOffset after,bool ca=false,bool server=true){
            var request=new CertificateRequest("CN=fixture",key,HashAlgorithmName.SHA256,RSASignaturePadding.Pkcs1);
            request.CertificateExtensions.Add(new X509BasicConstraintsExtension(ca,false,0,true));
            request.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(new OidCollection{new Oid(server?"1.3.6.1.5.5.7.3.1":"1.3.6.1.5.5.7.3.2")},false));
            return request.CreateSelfSigned(before,after);
        }
        var now=DateTimeOffset.UtcNow;using var leaf=Make(now.AddMinutes(-5),now.AddDays(1));var pin=ServerCertificateTrust.Fingerprint(leaf);
        check("approved_leaf_pin",ServerCertificateTrust.Validate(leaf,null,SslPolicyErrors.None,pin));
        check("other_leaf_rejected",!ServerCertificateTrust.Validate(leaf,null,SslPolicyErrors.None,new string('0',64)));
        check("hostname_mismatch_rejected",!ServerCertificateTrust.Validate(leaf,null,SslPolicyErrors.RemoteCertificateNameMismatch,pin));
        check("missing_certificate_rejected",!ServerCertificateTrust.Validate(null,null,SslPolicyErrors.RemoteCertificateNotAvailable,pin));
        check("malformed_pin_rejected",!ServerCertificateTrust.Validate(leaf,null,SslPolicyErrors.None,"bad-pin"));
        using var expired=Make(now.AddDays(-3),now.AddDays(-1));check("expired_leaf_rejected",!ServerCertificateTrust.Validate(expired,null,SslPolicyErrors.None,ServerCertificateTrust.Fingerprint(expired)));
        using var future=Make(now.AddDays(1),now.AddDays(3));check("future_leaf_rejected",!ServerCertificateTrust.Validate(future,null,SslPolicyErrors.None,ServerCertificateTrust.Fingerprint(future)));
        using var ca=Make(now.AddMinutes(-5),now.AddDays(1),ca:true);check("ca_certificate_rejected",!ServerCertificateTrust.Validate(ca,null,SslPolicyErrors.None,ServerCertificateTrust.Fingerprint(ca)));
        using var client=Make(now.AddMinutes(-5),now.AddDays(1),server:false);check("client_only_certificate_rejected",!ServerCertificateTrust.Validate(client,null,SslPolicyErrors.None,ServerCertificateTrust.Fingerprint(client)));
        using var chain=new X509Chain();chain.ChainPolicy.RevocationMode=X509RevocationMode.NoCheck;chain.Build(leaf);
        check("approved_self_signed_chain_supported",ServerCertificateTrust.Validate(leaf,chain,SslPolicyErrors.RemoteCertificateChainErrors,pin));
        check("unknown_chain_not_ignored",!ServerCertificateTrust.Validate(leaf,null,SslPolicyErrors.RemoteCertificateChainErrors,pin));
        var config=new ClientConfiguration();ServerTransport.ApplyProvisioning(config);
        check("company_profile_provided",config.SecureApiEndpoint()?.AbsoluteUri=="https://192.168.2.216/");
        var old=new ClientConfiguration{ServerProfiles=new(){new(){Id="legacy",Name="Ancien",ApiBaseUrl="https://legacy.invalid/api/"}},SelectedProfileId="legacy"};ServerTransport.ApplyProvisioning(old);
        check("existing_selection_not_silently_replaced",old.SecureApiEndpoint()?.Host=="legacy.invalid" && old.ServerProfiles.Count==2);
        var collision=new ClientConfiguration{ServerProfiles=new(){new(){Id="ogipen-company-test",Name="Autre",ApiBaseUrl="https://another.invalid/"}},SelectedProfileId="ogipen-company-test"};ServerTransport.ApplyProvisioning(collision);
        check("company_profile_identifiers_remain_unique",collision.ServerProfiles.Select(x=>x.Id).Distinct().Count()==2);
    }
}
