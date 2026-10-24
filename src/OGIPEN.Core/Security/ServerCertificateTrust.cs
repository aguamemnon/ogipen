using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace OGIPEN.Core.Security;

/// <summary>Trust a specific approved server leaf, without installing a root CA or
/// disabling hostname, validity, usage or certificate identity checks.</summary>
public static class ServerCertificateTrust
{
    public static string Fingerprint(X509Certificate2 certificate)=>
        Convert.ToHexString(SHA256.HashData(certificate.RawData));
    public static bool Validate(X509Certificate2? certificate,X509Chain? chain,SslPolicyErrors errors,string expected)
    {
        try {
            if(certificate is null || expected.Length!=64 || !expected.All(Uri.IsHexDigit))return false;
            if((errors & ~SslPolicyErrors.RemoteCertificateChainErrors)!=SslPolicyErrors.None)return false;
            var now=DateTime.UtcNow;
            if(certificate.NotBefore.ToUniversalTime()>now || certificate.NotAfter.ToUniversalTime()<=now)return false;
            if(!CryptographicOperations.FixedTimeEquals(SHA256.HashData(certificate.RawData),Convert.FromHexString(expected)))return false;
            if(certificate.Extensions.OfType<X509BasicConstraintsExtension>().Any(x=>x.CertificateAuthority))return false;
            if(!certificate.Extensions.OfType<X509EnhancedKeyUsageExtension>().Any(x=>x.EnhancedKeyUsages.Cast<Oid>().Any(o=>o.Value=="1.3.6.1.5.5.7.3.1")))return false;
            if(errors.HasFlag(SslPolicyErrors.RemoteCertificateChainErrors)){
                if(chain is null)return false;
                var allowed=X509ChainStatusFlags.UntrustedRoot|X509ChainStatusFlags.PartialChain;
                if(chain.ChainStatus.Any(x=>(x.Status & ~allowed)!=X509ChainStatusFlags.NoError))return false;
            }
            return true;
        }catch(CryptographicException){return false;}catch(FormatException){return false;}
    }
}
