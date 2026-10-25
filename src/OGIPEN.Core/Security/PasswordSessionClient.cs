using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace OGIPEN.Core.Security;

public sealed class PasswordSessionClient(HttpClient http)
{
 public async Task<(LicensedConnection Connection,string SystemRole)> SignIn(string provider,string login,string identityId,string deviceId,string? password,string licence,OfflineLicenseActivation.OfflineGrant grant,Func<string,byte[]> deviceSign,Func<string,byte[]>? userSign,ClientAuditMetadata metadata,CancellationToken ct)
 {
  var audience=LicensedSessionClient.RequireSecureEndpoint(http.BaseAddress?.AbsoluteUri??"").AbsoluteUri;
  if(provider is not ("windows" or "ogipen") || string.IsNullOrWhiteSpace(login) || login.Length>180 || grant.ExpiresUtc<=DateTimeOffset.UtcNow || (provider=="ogipen" && string.IsNullOrEmpty(password)))throw new InvalidOperationException("Login et mot de passe obligatoires.");
  using var challenge=await http.PostAsJsonAsync("auth/v3/challenge",new{provider,login,identityId,deviceIdentityId=deviceId,computerName=metadata.ComputerName,userName=login,licenseId=grant.LicenseId},ct);
  await Success(challenge,ct);
  var c=await challenge.Content.ReadFromJsonAsync<Challenge>(cancellationToken:ct)??throw new InvalidOperationException("Défi serveur absent.");
  var expected=$"OGIPEN-AUTH-v3:{audience}:{provider}:{c.IdentityId}:{deviceId}:{c.Nonce}";
  byte[] nonce;try{nonce=Convert.FromBase64String(c.Nonce);}catch{throw new InvalidOperationException("Défi invalide.");}
  if(nonce.Length!=32 || Convert.ToBase64String(nonce)!=c.Nonce || c.SigningText!=expected || c.ExpiresInSeconds is <1 or >90 || (provider=="windows" && c.IdentityId!=identityId))throw new InvalidOperationException("Défi ou identité serveur invalide.");
  using var complete=await http.PostAsJsonAsync("auth/v3/complete",new{provider,login,identityId=c.IdentityId,deviceIdentityId=deviceId,nonce=c.Nonce,deviceSignature=Convert.ToBase64String(deviceSign(expected)),userSignature=provider=="windows"?Convert.ToBase64String((userSign??throw new InvalidOperationException("Preuve Windows absente."))(expected)):null,password=provider=="ogipen"?password:null,licenseJson=licence,computerName=metadata.ComputerName,userName=login,licenseId=grant.LicenseId},ct);
  await Success(complete,ct);
  var token=await complete.Content.ReadFromJsonAsync<Token>(cancellationToken:ct)??throw new InvalidOperationException("Session absente.");
  if(string.IsNullOrEmpty(token.AccessToken)||token.AccessToken.Length>4096||token.ExpiresInSeconds is <1 or >900)throw new InvalidOperationException("Session invalide.");
  using var req=new HttpRequestMessage(HttpMethod.Get,"api/session");req.Headers.Authorization=new("Bearer",token.AccessToken);
  using var response=await http.SendAsync(req,ct);await Success(response,ct);
  var context=await response.Content.ReadFromJsonAsync<SessionContext>(cancellationToken:ct)??throw new InvalidOperationException("Contexte absent.");
  if(context.Identity!=c.IdentityId || context.LicenceId!=grant.LicenseId || context.BeneficiaryId!=grant.BeneficiaryId || context.CompanyId<1 || context.Projects is null)throw new InvalidOperationException("Le contexte ne correspond pas à l’utilisateur et à la licence.");
  using var json=JsonDocument.Parse(await response.Content.ReadAsStringAsync(ct));
  var role=json.RootElement.TryGetProperty("systemRole",out var r)?r.GetString()??"user":"user";
  return(new(token.AccessToken,DateTimeOffset.UtcNow.AddSeconds(token.ExpiresInSeconds),context),role);
 }
 private static async Task Success(HttpResponseMessage r,CancellationToken ct){ct.ThrowIfCancellationRequested();if(!r.IsSuccessStatusCode){await Task.CompletedTask;throw new InvalidOperationException(r.StatusCode switch{HttpStatusCode.TooManyRequests=>"Trop de tentatives. Réessayez dans quinze minutes.",HttpStatusCode.UpgradeRequired=>"Mettez à jour le client Ogipen.",HttpStatusCode.Forbidden=>"Licence ou droits d’accès insuffisants.",_=>"Connexion refusée : vérifiez le type de compte, le login, le mot de passe et l’enrôlement."});}}
 private sealed record Challenge(string Nonce,string IdentityId,string SigningText,int ExpiresInSeconds);
 private sealed record Token(string AccessToken,int ExpiresInSeconds);
}
