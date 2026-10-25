using System.Data;
using System.Security.Cryptography;
using System.Text;
using MySqlConnector;
using static ProjectSql;

static class PasswordAuthentication
{
 public static void Map(WebApplication app,string audience){
  app.MapPost("/auth/v3/attempt",(LoginAttempt req,HttpContext h)=>{h.Items["authReason"]="client_windows_password_refused";return Results.Accepted();});
  app.MapPost("/auth/v3/challenge",async(LoginChallenge req,HttpContext h,Db db,CompanyLicensing licensing,CancellationToken ct)=>{
   if(!Valid(req.Provider,req.Login,req.DeviceIdentityId))return Results.BadRequest();
   await using var c=await db.Open(ct);
   var id=await Resolve(c,req.Provider,req.Login,req.IdentityId,ct);
   if(id is null || await licensing.Binding(c,id,ct) is not {} user || await licensing.DeviceBinding(c,req.DeviceIdentityId,ct) is not {} device || user.CompanyId!=device.CompanyId){h.Items["authReason"]="login_not_authorized";return Results.Unauthorized();}
   var nonce=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));var hash=Hash(req.Provider,id,req.DeviceIdentityId,nonce);
   await Exec(c,"INSERT INTO ogp_challenge(nonce_hash,identity_id,expires_utc) VALUES(@hash,@id,DATE_ADD(UTC_TIMESTAMP(6),INTERVAL 90 SECOND))",ct,("@hash",hash),("@id",id));
   h.Items["authIdentity"]=id;
   return Results.Ok(new{nonce,identityId=id,signingText=Canonical(audience,req.Provider,id,req.DeviceIdentityId,nonce),expiresInSeconds=90});
  });
  app.MapPost("/auth/v3/complete",async(LoginComplete req,HttpContext h,Db db,CompanyLicensing licensing,TokenService tokens,CancellationToken ct)=>{
   h.Items["authIdentity"]=req.IdentityId;
   if(!Valid(req.Provider,req.Login,req.DeviceIdentityId) || string.IsNullOrEmpty(req.IdentityId) || req.IdentityId.Length>80 || string.IsNullOrEmpty(req.LicenseJson) || req.LicenseJson.Length>16384 || string.IsNullOrEmpty(req.Nonce) || req.Nonce.Length>128 || string.IsNullOrEmpty(req.DeviceSignature) || req.DeviceSignature.Length>256 || (req.UserSignature?.Length??0)>256 || (req.Password?.Length??0)>1024)return Results.BadRequest();
   await using var c=await db.Open(ct);
   if(!await Rate(c,h,req.Login,ct)){h.Items["authReason"]="login_rate_limited";return Results.StatusCode(429);}
   try{
    if(Convert.FromBase64String(req.Nonce).Length!=32)return Results.Unauthorized();
    await using var tx=await c.BeginTransactionAsync(IsolationLevel.ReadCommitted,ct);
    // Consume even a failed attempt: a password retry needs a new challenge.
    var changed=await Exec(c,"UPDATE ogp_challenge SET consumed=1 WHERE nonce_hash=@hash AND identity_id=@id AND consumed=0 AND expires_utc>UTC_TIMESTAMP(6)",ct,tx,("@hash",Hash(req.Provider,req.IdentityId,req.DeviceIdentityId,req.Nonce)),("@id",req.IdentityId));
    if(changed!=1){await tx.RollbackAsync(ct);return Results.Unauthorized();}
    await tx.CommitAsync(ct);
    if(await Resolve(c,req.Provider,req.Login,req.IdentityId,ct)!=req.IdentityId)return Results.Unauthorized();
    var user=await licensing.Binding(c,req.IdentityId,ct);var device=await licensing.DeviceBinding(c,req.DeviceIdentityId,ct);
    if(user is null || device is null || user.CompanyId!=device.CompanyId)return Results.Unauthorized();
    var text=Canonical(audience,req.Provider,req.IdentityId,req.DeviceIdentityId,req.Nonce);
    if(!Verify(device.PublicKey,text,req.DeviceSignature) || !licensing.VerifyClient(device,req.LicenseJson,out var grant)){h.Items["authReason"]="device_or_licence_refused";return Results.Unauthorized();}
    if(!grant!.IsDeviceBound && (grant.BeneficiaryId!=user.BeneficiaryId || user.PublicKey!=device.PublicKey)){h.Items["authReason"]="legacy_nominative_licence_refused";return Results.Unauthorized();}
    if(req.Provider=="windows"){
     if(!req.IdentityId.StartsWith("win-sid:",StringComparison.Ordinal)||req.Password is not null||!Verify(user.PublicKey,text,req.UserSignature??"")){h.Items["authReason"]="windows_identity_proof_refused";return Results.Unauthorized();}
    }else{
     await using var cmd=Cmd(c,"SELECT password_hash FROM ogp_app_account WHERE identity_id=@id AND enabled=1",("@id",req.IdentityId));
     if(!Password((string?)await cmd.ExecuteScalarAsync(ct),req.Password)){h.Items["authReason"]="password_refused";return Results.Unauthorized();}
    }
    h.Items["identityProofVerified"]=true;
    var bucket=AccountBucket(h,req.Login);await Exec(c,"DELETE FROM ogp_login_attempt WHERE bucket=@b",ct,("@b",bucket));
    var expires=new[]{DateTimeOffset.UtcNow.AddMinutes(15),grant!.ExpiresUtc,user.Server.Expires}.Min();var sid=Guid.NewGuid().ToString("N");
    await Exec(c,"INSERT INTO ogp_auth_session(session_id,identity_id,auth_version,company_id,client_license_json,expires_utc,device_identity_id,auth_method) VALUES(@s,@i,@v,@c,@l,@e,@d,@m)",ct,("@s",sid),("@i",req.IdentityId),("@v",user.Version),("@c",user.CompanyId),("@l",req.LicenseJson),("@e",expires.UtcDateTime),("@d",req.DeviceIdentityId),("@m",req.Provider));
    return Results.Ok(new{accessToken=tokens.Mint(req.IdentityId,user.Version,sid,expires),expiresInSeconds=(int)(expires-DateTimeOffset.UtcNow).TotalSeconds});
   }catch(Exception e) when(e is FormatException or CryptographicException){return Results.Unauthorized();}
  });
 }
 static bool Valid(string provider,string login,string device)=>(provider is "windows" or "ogipen") && !string.IsNullOrWhiteSpace(login) && login.Length<=180 && device is {Length:>0 and <=80};
 public static async Task<string> Role(MySqlConnection c,string identity,CancellationToken ct){await using var cmd=Cmd(c,"SELECT system_role FROM ogp_identity WHERE id=@id AND enabled=1",("@id",identity));return (string?)await cmd.ExecuteScalarAsync(ct)??"user";}
 static async Task<string?> Resolve(MySqlConnection c,string provider,string login,string identity,CancellationToken ct){
  if(provider=="windows")return identity.StartsWith("win-sid:",StringComparison.Ordinal) && identity.Length<=80?identity:null;
  await using var cmd=Cmd(c,"SELECT identity_id FROM ogp_app_account WHERE login_name=@login AND enabled=1 AND password_hash IS NOT NULL",("@login",login.Trim().ToLowerInvariant()));return (string?)await cmd.ExecuteScalarAsync(ct);
 }
 static string Canonical(string audience,string provider,string identity,string device,string nonce)=>$"OGIPEN-AUTH-v3:{audience}:{provider}:{identity}:{device}:{nonce}";
 static string Hash(string provider,string identity,string device,string nonce)=>Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(provider+"\n"+identity+"\n"+device+"\n"+nonce)));
 static bool Verify(string pem,string text,string signature){using var key=ECDsa.Create();key.ImportFromPem(pem);return key.VerifyData(Encoding.UTF8.GetBytes(text),Convert.FromBase64String(signature),HashAlgorithmName.SHA256,DSASignatureFormat.IeeeP1363FixedFieldConcatenation);}
 internal static bool Password(string? stored,string? supplied){
  if(string.IsNullOrEmpty(supplied)||stored is null)return false;
  try{var p=stored.Split('$');if(p.Length!=4||p[0]!="pbkdf2-sha256"||p[1]!="600000")return false;var salt=Convert.FromBase64String(p[2]);var expected=Convert.FromBase64String(p[3]);return salt.Length==32&&expected.Length==32&&CryptographicOperations.FixedTimeEquals(expected,Rfc2898DeriveBytes.Pbkdf2(supplied,salt,600000,HashAlgorithmName.SHA256,32));}catch{return false;}
 }
 static string Source(HttpContext h){
  var ip=h.Connection.RemoteIpAddress?.ToString()??"unknown";
  if(System.Net.IPAddress.TryParse(ip,out var address)&&System.Net.IPAddress.IsLoopback(address))ip=h.Request.Headers["X-Real-IP"].ToString();
  return ip;
 }
 static string AccountBucket(HttpContext h,string login)=>Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(Source(h)+"|"+login.Trim().ToLowerInvariant())));
 static async Task<bool> Rate(MySqlConnection c,HttpContext h,string login,CancellationToken ct){
  var ip=Source(h);
  foreach(var (bucket,max) in new[]{(ip+"|*",60),(ip+"|"+login.Trim().ToLowerInvariant(),5)}){
   var key=Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(bucket)));
   await Exec(c,"INSERT INTO ogp_login_attempt(bucket,attempts,window_end) VALUES(@b,1,DATE_ADD(UTC_TIMESTAMP(),INTERVAL 15 MINUTE)) ON DUPLICATE KEY UPDATE attempts=IF(window_end<=UTC_TIMESTAMP(),1,attempts+1),window_end=IF(window_end<=UTC_TIMESTAMP(),DATE_ADD(UTC_TIMESTAMP(),INTERVAL 15 MINUTE),window_end)",ct,("@b",key));
   if(await Scalar(c,"SELECT attempts FROM ogp_login_attempt WHERE bucket=@b",ct,("@b",key))>max)return false;
  }return true;
 }
}
record LoginChallenge(string Provider,string Login,string IdentityId,string DeviceIdentityId);
record LoginComplete(string Provider,string Login,string IdentityId,string DeviceIdentityId,string Nonce,string DeviceSignature,string? UserSignature,string? Password,string LicenseJson);

record LoginAttempt(string IdentityId,string? ComputerName,string? UserName,long? LicenseId);
