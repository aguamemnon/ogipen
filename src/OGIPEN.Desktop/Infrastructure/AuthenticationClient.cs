using OGIPEN.Core.Security;
using OGIPEN.Desktop.Models;

namespace OGIPEN.Desktop.Infrastructure;

public sealed class AuthenticationClient : IDisposable
{
    private readonly HttpClient _http;
    public AuthenticationClient(Uri apiBase,ClientConfiguration? configuration=null)
    {
        _http=ServerTransport.CreateClient(apiBase,configuration);
    }
    public async Task<UserSession> SignInAsync(ClientConfiguration config,CancellationToken ct)
    {
        var identity=WindowsSessionIdentity.Current();
        (string Json,OfflineLicenseActivation.OfflineGrant Grant) licence;
        try{licence=OfflineLicenseService.ReadConnectionLicense(config.OfflineSoftwareId);}
        catch(Exception e) when(e is InvalidOperationException or System.Security.Cryptography.CryptographicException or IOException or UnauthorizedAccessException){
            using var timeout=CancellationTokenSource.CreateLinkedTokenSource(ct);timeout.CancelAfter(TimeSpan.FromSeconds(3));
            try{await new LicensedSessionClient(_http).ReportLocalRefusalAsync(identity.IdentityId,new(Environment.MachineName,identity.DisplayName),OfflineLicenseService.DeclaredStoredLicenseNumber(),timeout.Token);}
            catch(Exception reportError) when(reportError is HttpRequestException or OperationCanceledException or InvalidOperationException){}
            throw;
        }
        var connection=await new LicensedSessionClient(_http).SignInAsync(identity.IdentityId,
            licence.Json,licence.Grant,text=>OfflineLicenseService.SignChallenge(text,_http.BaseAddress!),ct,new ClientAuditMetadata(Environment.MachineName,identity.DisplayName));
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
