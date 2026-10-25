using System.Net.Http.Json;
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
    public async Task<UserSession> SignInAsync(ClientConfiguration config,string provider,string login,string password,CancellationToken ct)
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
        if(string.IsNullOrWhiteSpace(login)||string.IsNullOrEmpty(password))throw new InvalidOperationException("Login et mot de passe obligatoires.");
        using var windows=provider=="windows"?await AuthenticateWindows(login,password,identity,ct):null;
        var result=await new PasswordSessionClient(_http).SignIn(provider,windows?.DisplayName??login.Trim(),windows?.IdentityId??"",identity.IdentityId,provider=="ogipen"?password:null,
            licence.Json,licence.Grant,text=>OfflineLicenseService.SignChallenge(text,_http.BaseAddress!),windows is null?null:windows.Sign,new ClientAuditMetadata(Environment.MachineName,login),ct);
        var connection=result.Connection;
        return UserSession.FromReply(new LoginReply {
            SystemRole=result.SystemRole,AccessToken=connection.AccessToken,DisplayName=connection.Context.DisplayName,
            CompanyId=connection.Context.CompanyId,LicenceId=connection.Context.LicenceId,
            BeneficiaryId=connection.Context.BeneficiaryId,ExpiresUtc=connection.ExpiresUtc,LicenseExpiresUtc=licence.Grant.ExpiresUtc,
            Projects=connection.Context.Projects.Select(p=>new ProjectAccess {
                Id=p.Id,Name=p.Name,Role=p.Role,Permissions=p.Permissions.ToList()
            }).ToList()
        });
    }
    private async Task<WindowsPasswordIdentity> AuthenticateWindows(string login,string password,WindowsSessionIdentity device,CancellationToken ct){
        try{return await Task.Run(()=>WindowsPasswordIdentity.Authenticate(login,password),ct);}
        catch(InvalidOperationException){
            using var timeout=CancellationTokenSource.CreateLinkedTokenSource(ct);timeout.CancelAfter(TimeSpan.FromSeconds(3));
            try{using var response=await _http.PostAsJsonAsync("auth/v3/attempt",new{identityId=device.IdentityId,computerName=Environment.MachineName,userName=login,licenseId=OfflineLicenseService.DeclaredStoredLicenseNumber()},timeout.Token);}
            catch(Exception e) when(e is HttpRequestException or OperationCanceledException){}
            throw;
        }
    }
    public Task SignOutAsync(UserSession session,CancellationToken ct)=>
        session.IsPreview?Task.CompletedTask:new LicensedSessionClient(_http).SignOutAsync(session.AccessToken,ct);
    public void Dispose()=>_http.Dispose();
}
