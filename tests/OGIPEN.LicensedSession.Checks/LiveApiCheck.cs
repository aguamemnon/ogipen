using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using OGIPEN.Core.Security;

// Test-only transport to a temporary loopback API. Never shipped in the desktop app.
static class LiveApiCheck
{
    private const string Audience="https://isolated-ogipen-test.invalid/client-api/";
    public static async Task Run()
    {
        var results=new List<object>();void Check(string name,bool pass){results.Add(new{test=name,pass});if(!pass)throw new Exception(name);}
        string Env(string name)=>Environment.GetEnvironmentVariable(name)??throw new InvalidOperationException("Missing isolated fixture");
        using var key=ECDsa.Create();key.ImportFromPem(File.ReadAllText(Env("OGIPEN_CHECK_KEY")));
        var json=File.ReadAllText(Env("OGIPEN_CHECK_LICENSE"));
        Check("live_client_verifies_signed_file",OfflineLicenseActivation.TryImport(json,key,File.ReadAllText(Env("OGIPEN_CHECK_ISSUER_KEY")),Env("OGIPEN_CHECK_ISSUER"),405,"ogipen",1,Array.Empty<int>(),out var grant));
        using var http=new HttpClient(new Loopback()){BaseAddress=new Uri(Audience),Timeout=TimeSpan.FromSeconds(10)};
        var client=new LicensedSessionClient(http);
        var session=await client.SignInAsync("a",json,grant!,text=>key.SignData(Encoding.UTF8.GetBytes(text),HashAlgorithmName.SHA256,DSASignatureFormat.IeeeP1363FixedFieldConcatenation),CancellationToken.None);
        Check("live_client_receives_authorized_project",session.Context.Projects.Length==1 && session.Context.Projects[0].Permissions.Contains("cables.read") && !session.Context.Projects[0].Permissions.Contains("cables.write"));
        using var read=new HttpRequestMessage(HttpMethod.Get,"api/cables/425");read.Headers.Authorization=new AuthenticationHeaderValue("Bearer",session.AccessToken);
        using var response=await http.SendAsync(read);Check("live_client_reads_project",response.StatusCode==HttpStatusCode.OK);
        await client.SignOutAsync(session.AccessToken,CancellationToken.None);
        using var revoked=new HttpRequestMessage(HttpMethod.Get,"api/session");revoked.Headers.Authorization=new AuthenticationHeaderValue("Bearer",session.AccessToken);
        using var refused=await http.SendAsync(revoked);Check("live_client_logout_revokes_token",refused.StatusCode==HttpStatusCode.Unauthorized);
        Console.WriteLine(JsonSerializer.Serialize(results));
    }
    private sealed class Loopback:HttpMessageHandler
    {
        private readonly HttpMessageInvoker transport=new(new SocketsHttpHandler{AllowAutoRedirect=false});
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken ct)
        {
            var uri=request.RequestUri!.AbsoluteUri;
            if(!uri.StartsWith(Audience,StringComparison.Ordinal))throw new InvalidOperationException("Unexpected test target");
            request.RequestUri=new Uri("http://127.0.0.1:5089/"+uri[Audience.Length..]);
            return transport.SendAsync(request,ct);
        }
        protected override void Dispose(bool disposing){if(disposing)transport.Dispose();base.Dispose(disposing);}
    }
}
