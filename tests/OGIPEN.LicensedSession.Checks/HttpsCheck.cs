using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using OGIPEN.Desktop.Infrastructure;

static class HttpsCheck
{
    public static async Task Run()
    {
        var results=new List<object>();void Check(string name,bool pass){results.Add(new{test=name,pass});if(!pass)throw new Exception(name);}
        using var http=ServerTransport.CreateClient(new Uri("https://192.168.2.216/"));
        using var health=await http.GetAsync("health");Check("windows_direct_pinned_https_and_health",health.IsSuccessStatusCode);
        var existing=new ClientConfiguration{ServerProfiles=new(){new(){Id="existing-user-profile",Name="Ogipen test",ApiBaseUrl="https://192.168.2.216/"}},SelectedProfileId="existing-user-profile"};ServerTransport.ApplyProvisioning(existing);
        using var existingClient=ServerTransport.CreateClient(existing.SecureApiEndpoint()!,existing);using var existingHealth=await existingClient.GetAsync("health");Check("existing_ip_profile_uses_provisioned_pin",existingHealth.IsSuccessStatusCode && existing.ServerProfiles.Count==1);
        using var data=JsonDocument.Parse(await health.Content.ReadAsStringAsync());Check("installed_api_0416",data.RootElement.GetProperty("version").GetString()=="0.4.16-test");
        using var anonymous=await http.GetAsync("api/session");Check("https_anonymous_session_refused",anonymous.StatusCode==HttpStatusCode.Unauthorized);
        using var unknownRequest=new HttpRequestMessage(HttpMethod.Post,"auth/challenge"){Content=JsonContent.Create(new{identityId="nonexistent-v0412-selftest",computerName="SELFTEST-WINDOWS-PC",userName="SELFTEST-USER",licenseId=999,password="AUDIT_SECRET_SENTINEL",accessToken="AUDIT_SECRET_SENTINEL"})};unknownRequest.Headers.Add("X-Real-IP","203.0.113.99");
        using var unknown=await http.SendAsync(unknownRequest);Check("https_legacy_passwordless_login_disabled",unknown.StatusCode==HttpStatusCode.UpgradeRequired);
        using var blocked=await http.GetAsync("http://192.168.2.216:8080/client-api/health");Check("api_not_exposed_over_portal_http",blocked.StatusCode==HttpStatusCode.NotFound);
        using var standard=new HttpClient(new HttpClientHandler{AllowAutoRedirect=false}){Timeout=TimeSpan.FromSeconds(10)};
        bool requiresPin=false;try{using var untrusted=await standard.GetAsync("https://192.168.2.216/health");}catch(HttpRequestException){requiresPin=true;}
        Check("no_global_windows_trust_added",requiresPin);
        var wrong=new ClientConfiguration{ServerProfiles=new(){new(){Id="wrong",Name="Wrong",ApiBaseUrl="https://192.168.2.216/",CertificateSha256=new string('0',64)}}};
        using var wrongClient=ServerTransport.CreateClient(new Uri("https://192.168.2.216/"),wrong);bool refused=false;try{using var bad=await wrongClient.GetAsync("health");}catch(HttpRequestException){refused=true;}Check("network_wrong_pin_rejected",refused);
        using var retired=await standard.GetAsync("https://www.trueshield.fr/ogipen/client-api/health");Check("wordpress_relay_retired",retired.StatusCode==HttpStatusCode.Gone);
        using var wordpress=await standard.GetAsync("https://www.trueshield.fr/");Check("wordpress_site_preserved",wordpress.IsSuccessStatusCode);
        Console.WriteLine(JsonSerializer.Serialize(results));
    }
}
