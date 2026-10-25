using System.Net;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using OGIPEN.Core.Security;
using OGIPEN.Desktop.Infrastructure;

if(args.Contains("--password-integration")){await LivePasswordCheck.Run();return;}
if(args.Contains("--integration",StringComparer.Ordinal)){await LiveApiCheck.Run();return;}
if(args.Contains("--https",StringComparer.Ordinal)){await HttpsCheck.Run();return;}
var checks=new List<object>();
void Check(string name,bool pass){checks.Add(new{test=name,pass});if(!pass)throw new Exception(name);}
async Task Denied(string name,Func<Task> run){bool denied=false;try{await run();}catch(Exception e) when(e is InvalidOperationException or JsonException){denied=true;}Check(name,denied);}
var grant=new OfflineLicenseActivation.OfflineGrant(2,101,1,405,"ogipen",1,new[]{10},DateTimeOffset.UtcNow.AddHours(1));
using var device=ECDsa.Create(ECCurve.NamedCurves.nistP256);
var signatures=0;
byte[] Sign(string text){signatures++;return device.SignData(Encoding.UTF8.GetBytes(text),HashAlgorithmName.SHA256,DSASignatureFormat.IeeeP1363FixedFieldConcatenation);}
LicensedSessionClient Client(Fake f)=>new(new HttpClient(f){BaseAddress=new Uri(Fake.Audience)});
try{
 CertificateChecks.Run(Check);
 foreach(var url in new[]{"http://site/","https://user:password@site/","https://site/?token=x","https://site/#fragment","ftp://site/"})
  await Denied("unsafe_endpoint_"+checks.Count,()=>Task.FromResult(LicensedSessionClient.RequireSecureEndpoint(url)));
 Check("https_prefix_preserved",LicensedSessionClient.RequireSecureEndpoint("https://SITE/ogipen/client-api").AbsoluteUri==Fake.Audience);
 var f=new Fake(device);var connection=await Client(f).SignInAsync("win-sid:test","signed-file-fixture",grant,Sign,CancellationToken.None,new("PC-FIXTURE","DOMAIN\\user"));
 Check("challenge_complete_metadata",f.Calls==3 && signatures==1 && connection.Context.LicenceId==2);
 Check("bearer_only_on_authenticated_calls",f.AuthHeaders.SequenceEqual(new[]{false,false,true}));
 Check("no_password_in_request",!f.Body.Contains("password",StringComparison.OrdinalIgnoreCase));
 Check("signed_license_sent",f.Body.Contains("signed-file-fixture"));
 Check("computer_and_user_metadata_sent",f.CapturedBodies.Count==2 && f.CapturedBodies.All(x=>JsonNode.Parse(x)!["computerName"]!.GetValue<string>()=="PC-FIXTURE" && JsonNode.Parse(x)!["licenseId"]!.GetValue<int>()==2));
 await Client(f).SignOutAsync(connection.AccessToken,CancellationToken.None);Check("logout_calls_current_session",f.Logout);
 var local=new Fake(device);await Client(local).ReportLocalRefusalAsync("win-sid:test",new("PC-LOCAL","LOCAL-USER"),8,CancellationToken.None);Check("local_licence_refusal_report_has_no_authentication",local.LocalRefusal && local.Calls==1 && !local.AuthHeaders[0]);
 foreach(var kind in new[]{"wrong_identity","foreign_audience","short_nonce","noncanonical_nonce","lifetime"}){
  var bad=new Fake(device){ChallengeFault=kind};var before=signatures;
  await Denied("challenge_"+kind,()=>Client(bad).SignInAsync("win-sid:test","fixture",grant,Sign,CancellationToken.None));
  Check("not_signed_"+kind,signatures==before);
 }
 foreach(var kind in new[]{"identity","licence","beneficiary","company","projects","duplicate_projects"}){
  var bad=new Fake(device){ContextFault=kind};await Denied("context_"+kind,()=>Client(bad).SignInAsync("win-sid:test","fixture",grant,Sign,CancellationToken.None));
 }
 await Denied("redirect_refused",()=>Client(new Fake(device){Status=HttpStatusCode.TemporaryRedirect}).SignInAsync("win-sid:test","fixture",grant,Sign,CancellationToken.None));
 await Denied("expired_local_grant_refused",()=>Client(new Fake(device)).SignInAsync("win-sid:test","fixture",grant with{ExpiresUtc=DateTimeOffset.UtcNow.AddSeconds(-1)},Sign,CancellationToken.None));
 var temp=Path.Combine(Path.GetTempPath(),"ogipen-profiles-"+Guid.NewGuid().ToString("N"));Directory.CreateDirectory(temp);
 try{
  var path=Path.Combine(temp,"settings.json");var config=new ClientConfiguration();
  var a=new ServerProfile{Id="site-a",Name="Site A",ApiBaseUrl="https://site-a/api/"};var b=new ServerProfile{Id="site-b",Name="Site B",ApiBaseUrl="https://site-b/api/"};
  config.ServerProfiles.AddRange(new[]{a,b});config.SelectProfile(a.Id);config.SaveTo(path);
  var loaded=ClientConfiguration.LoadFrom(path);Check("profiles_and_choice_persisted",loaded.ServerProfiles.Count==2 && loaded.SecureApiEndpoint()!.Host=="site-a");
  loaded.SelectedProfileId="missing";Check("no_automatic_server_fallback",loaded.SecureApiEndpoint() is null);
  loaded.SelectProfile(b.Id);loaded.SaveTo(path);Check("explicit_site_switch",ClientConfiguration.LoadFrom(path).SecureApiEndpoint()!.Host=="site-b");
  Check("configuration_contains_no_session",!File.ReadAllText(path).Contains("accessToken",StringComparison.OrdinalIgnoreCase));
  File.WriteAllText(path,"{\"ApiBaseUrl\":\"https://legacy/api/\",\"SiteName\":\"Legacy\"}");
  var legacy=ClientConfiguration.LoadFrom(path);Check("legacy_endpoint_migrated",legacy.ServerProfiles.Count==1 && legacy.SecureApiEndpoint()!.Host=="legacy");
  Check("ogipen_default_catalogue",new ClientConfiguration().OfflineSoftwareId==405);
 }finally{Directory.Delete(temp,true);}
}finally{Console.WriteLine(JsonSerializer.Serialize(checks));}

sealed class Fake(ECDsa device):HttpMessageHandler
{
 public const string Audience="https://site/ogipen/client-api/";
 public string? ChallengeFault,ContextFault;
 public HttpStatusCode Status=HttpStatusCode.OK;
 public int Calls;public bool Logout,LocalRefusal;public List<bool> AuthHeaders=new();public List<string> CapturedBodies=new();public string Body="";
 private string nonce=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
 protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken ct){
  Calls++;AuthHeaders.Add(request.Headers.Authorization is not null);
  if(request.Content is not null)CapturedBodies.Add(await request.Content.ReadAsStringAsync(ct));
  if(Status!=HttpStatusCode.OK)return new(Status);
  JsonObject json;
  if(request.RequestUri!.AbsolutePath.EndsWith("auth/attempt")){LocalRefusal=true;return new(HttpStatusCode.Accepted);}
  if(request.RequestUri!.AbsolutePath.EndsWith("auth/challenge")){
   var n=ChallengeFault=="short_nonce"?Convert.ToBase64String(new byte[8]):ChallengeFault=="noncanonical_nonce"?nonce+"\n":nonce;
   json=new(){["nonce"]=n,["signingText"]=$"OGIPEN-AUTH-v2:{Audience}:win-sid:test:{n}",["expiresInSeconds"]=90};
   if(ChallengeFault=="wrong_identity")json["signingText"]="OGIPEN-AUTH-v2:other-user";
   if(ChallengeFault=="foreign_audience")json["signingText"]=$"OGIPEN-AUTH-v2:https://other/:win-sid:test:{n}";
   if(ChallengeFault=="lifetime")json["expiresInSeconds"]=999;
  }else if(request.RequestUri.AbsolutePath.EndsWith("auth/complete")){
   Body=await request.Content!.ReadAsStringAsync(ct);var data=JsonNode.Parse(Body)!;
   var proof=Convert.FromBase64String(data["signature"]!.GetValue<string>());
   if(!device.VerifyData(Encoding.UTF8.GetBytes($"OGIPEN-AUTH-v2:{Audience}:win-sid:test:{nonce}"),proof,HashAlgorithmName.SHA256,DSASignatureFormat.IeeeP1363FixedFieldConcatenation))throw new Exception("bad proof");
   json=new(){["accessToken"]="fixture-bearer",["expiresInSeconds"]=899};
  }else if(request.Method==HttpMethod.Delete){Logout=true;return new(HttpStatusCode.NoContent);}
  else{
   if(request.Headers.Authorization?.Parameter!="fixture-bearer")throw new Exception("missing bearer");
   json=JsonSerializer.SerializeToNode(new{identity="win-sid:test",companyId=1,licenceId=2,beneficiaryId=101,displayName="Session",projects=new[]{new{id="p",name="Projet",role="reader",permissions=new[]{"cables.read"}}}})!.AsObject();
   switch(ContextFault){case "identity":json["identity"]="other";break;case "licence":json["licenceId"]=8;break;case "beneficiary":json["beneficiaryId"]=999;break;case "company":json["companyId"]=0;break;case "projects":json["projects"]=null;break;case "duplicate_projects":json["projects"]!.AsArray().Add(json["projects"]![0]!.DeepClone());break;}
  }
  return new(HttpStatusCode.OK){Content=JsonContent.Create(json)};
 }
}
