using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace OGIPEN.Desktop.Infrastructure;

/// <summary>Windows validates the supplied password. It is never sent to the Ogipen server.</summary>
public sealed class WindowsPasswordIdentity:IDisposable
{
 private readonly SafeAccessTokenHandle token;
 public string IdentityId{get;}
 public string DisplayName{get;}
 private WindowsPasswordIdentity(SafeAccessTokenHandle token){this.token=token;using var identity=new WindowsIdentity(token.DangerousGetHandle());IdentityId="win-sid:"+identity.User!.Value;DisplayName=identity.Name;}
 public static WindowsPasswordIdentity Authenticate(string login,string password)
 {
  if(string.IsNullOrWhiteSpace(login)||string.IsNullOrEmpty(password))throw new InvalidOperationException("Saisissez votre login et votre mot de passe Windows/AD.");
  string user=login.Trim();string? domain=user.Contains('@')?null:".";
  int slash=user.IndexOf('\\');if(slash>=0){domain=user[..slash];user=user[(slash+1)..];}
  if(!LogonUser(user,domain,password,2,0,out var token)){token?.Dispose();throw new InvalidOperationException("Windows refuse ce login ou ce mot de passe. Pour un compte AD, vérifiez aussi l’accès au domaine.");}
  return new(token);
 }
 public byte[] Sign(string text)=>WindowsIdentity.RunImpersonated(token,()=>{
  try{using var key=CngKey.Open("OGIPEN_Offline_P256_v1",CngProvider.MicrosoftSoftwareKeyStorageProvider,CngKeyOpenOptions.UserKey);using var ec=new ECDsaCng(key);return ec.SignData(Encoding.UTF8.GetBytes(text),HashAlgorithmName.SHA256,DSASignatureFormat.IeeeP1363FixedFieldConcatenation);}
  catch(CryptographicException){throw new InvalidOperationException("La clé de cet utilisateur Windows n’est pas disponible. Exportez sa fiche d’enrôlement depuis sa session Windows et faites autoriser cette clé dans le portail.");}
 });
 public void Dispose()=>token.Dispose();
 [DllImport("advapi32.dll",EntryPoint="LogonUserW",CharSet=CharSet.Unicode,SetLastError=true)]
 [return:MarshalAs(UnmanagedType.Bool)]private static extern bool LogonUser(string user,string? domain,string password,int type,int provider,out SafeAccessTokenHandle token);
}
