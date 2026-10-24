using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

static class HttpsCheck
{
    public static async Task Run()
    {
        var results=new List<object>();void Check(string name,bool pass){results.Add(new{test=name,pass});if(!pass)throw new Exception(name);}
        using var http=new HttpClient(new HttpClientHandler{AllowAutoRedirect=false}){BaseAddress=new Uri("https://www.trueshield.fr/ogipen/client-api/"),Timeout=TimeSpan.FromSeconds(15)};
        using var health=await http.GetAsync("health");Check("windows_https_certificate_and_health",health.IsSuccessStatusCode);
        using var data=JsonDocument.Parse(await health.Content.ReadAsStringAsync());Check("installed_api_049",data.RootElement.GetProperty("version").GetString()=="0.4.9-test");
        using var anonymous=await http.GetAsync("api/session");Check("https_anonymous_session_refused",anonymous.StatusCode==HttpStatusCode.Unauthorized);
        using var unknown=await http.PostAsJsonAsync("auth/challenge",new{identityId="nonexistent-v049-selftest"});Check("https_unenrolled_identity_refused",unknown.StatusCode==HttpStatusCode.NotFound);
        using var blocked=await http.GetAsync("http://192.168.2.216:8080/client-api/health");Check("api_not_exposed_over_portal_http",blocked.StatusCode==HttpStatusCode.NotFound);
        Console.WriteLine(JsonSerializer.Serialize(results));
    }
}
