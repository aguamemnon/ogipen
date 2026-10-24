using OGIPEN.Core.Security;
using OGIPEN.Desktop.Models;

namespace OGIPEN.Desktop.Infrastructure;

public sealed class AuthenticationClient : IDisposable
{
    private readonly HttpClient _http;
    public AuthenticationClient(Uri apiBase)
    {
        _http=new HttpClient(new HttpClientHandler{AllowAutoRedirect=false}) {
            BaseAddress=LicensedSessionClient.RequireSecureEndpoint(apiBase.AbsoluteUri),
            Timeout=TimeSpan.FromSeconds(15),MaxResponseContentBufferSize=65536
        };
    }
    public async Task<UserSession> SignInAsync(ClientConfiguration config,CancellationToken ct)
    {
        var identity=WindowsSessionIdentity.Current();
        var licence=OfflineLicenseService.ReadConnectionLicense(config.OfflineSoftwareId);
        var connection=await new LicensedSessionClient(_http).SignInAsync(identity.IdentityId,
            licence.Json,licence.Grant,text=>OfflineLicenseService.SignChallenge(text,_http.BaseAddress!),ct);
        return UserSession.FromReply(new LoginReply {
            AccessToken=connection.AccessToken,DisplayName=connection.Context.DisplayName,
            CompanyId=connection.Context.CompanyId,LicenceId=connection.Context.LicenceId,
            BeneficiaryId=connection.Context.BeneficiaryId,ExpiresUtc=connection.ExpiresUtc,LicenseExpiresUtc=licence.Grant.ExpiresUtc,
            Projects=connection.Context.Projects.Select(p=>new ProjectAccess {
                Id=p.Id,Name=p.Name,Role=p.Role,Permissions=p.Permissions.ToList()
            }).ToList()
        });
    }
    public Task SignOutAsync(UserSession session,CancellationToken ct)=>
        session.IsPreview?Task.CompletedTask:new LicensedSessionClient(_http).SignOutAsync(session.AccessToken,ct);
    public void Dispose()=>_http.Dispose();
}
