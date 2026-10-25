using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using OGIPEN.Core.Security;
static class LivePasswordCheck
{
 public static async Task Run(){
  string Env(string n)=>Environment.GetEnvironmentVariable(n)??throw new Exception("Fixture absente.");
  using var key=ECDsa.Create();key.ImportFromPem(File.ReadAllText(Env("OGIPEN_CHECK_KEY")));var file=File.ReadAllText(Env("OGIPEN_CHECK_LICENSE"));
  if(!OfflineLicenseActivation.TryImport(file,key,File.ReadAllText(Env("OGIPEN_CHECK_ISSUER_KEY")),Env("OGIPEN_CHECK_ISSUER"),405,"ogipen",1,Array.Empty<int>(),out var grant))throw new Exception("Licence invalide.");
  using var http=new HttpClient(new Local()){BaseAddress=new Uri("https://isolated-ogipen-test.invalid/client-api/")};
  var result=await new PasswordSessionClient(http).SignIn("ogipen","a","","a",Env("OGIPEN_CHECK_PASSWORD"),file,grant!,s=>key.SignData(Encoding.UTF8.GetBytes(s),HashAlgorithmName.SHA256,DSASignatureFormat.IeeeP1363FixedFieldConcatenation),null,new("ISOLATED-C#","a"),CancellationToken.None);
  if(result.Connection.Context.Identity!="a"||!result.Connection.Context.Projects.Any(p=>p.Permissions.Contains("cables.read")))throw new Exception("Contexte inattendu.");
  await new LicensedSessionClient(http).SignOutAsync(result.Connection.AccessToken,CancellationToken.None);
  Console.WriteLine(JsonSerializer.Serialize(new[]{new{test="csharp_password_login_licensed_device_and_selected_identity",pass=true},new{test="csharp_password_session_logout",pass=true}}));
 }
 sealed class Local:HttpMessageHandler{
  readonly HttpMessageInvoker transport=new(new SocketsHttpHandler{AllowAutoRedirect=false});
  protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken ct){var u=request.RequestUri!.AbsoluteUri;const string prefix="https://isolated-ogipen-test.invalid/client-api/";if(!u.StartsWith(prefix))throw new Exception("Cible de test invalide");request.RequestUri=new Uri("http://127.0.0.1:5089/"+u[prefix.Length..]);return transport.SendAsync(request,ct);}
  protected override void Dispose(bool disposing){if(disposing)transport.Dispose();base.Dispose(disposing);}
 }
}
