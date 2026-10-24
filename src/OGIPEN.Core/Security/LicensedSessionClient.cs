using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text.Json;

namespace OGIPEN.Core.Security;

/// <summary>Transport for the licensed challenge protocol. The caller obtains identity and
/// signer from the current OS session and verifies the offline grant before calling.</summary>
public sealed class LicensedSessionClient(HttpClient http)
{
    public static Uri RequireSecureEndpoint(string address)
    {
        if(!Uri.TryCreate(address.Trim().TrimEnd('/')+"/",UriKind.Absolute,out var uri) ||
            uri.Scheme!=Uri.UriSchemeHttps || !string.IsNullOrEmpty(uri.UserInfo) ||
            !string.IsNullOrEmpty(uri.Query) || !string.IsNullOrEmpty(uri.Fragment))
            throw new InvalidOperationException("L’adresse API doit être une URL HTTPS, sans identifiant, paramètre ni fragment.");
        return uri;
    }

    public async Task<LicensedConnection> SignInAsync(string identityId,string licenseJson,
        OfflineLicenseActivation.OfflineGrant localGrant,Func<string,byte[]> sign,CancellationToken ct,ClientAuditMetadata? auditMetadata=null)
    {
        var audience=RequireSecureEndpoint(http.BaseAddress?.AbsoluteUri??"").AbsoluteUri;
        if(localGrant.LicenseId<1 || localGrant.BeneficiaryId<1 || localGrant.ExpiresUtc<=DateTimeOffset.UtcNow || string.IsNullOrWhiteSpace(licenseJson))
            throw new InvalidOperationException("Licence locale invalide ou expirée.");
        if(string.IsNullOrWhiteSpace(identityId) || identityId.Length>80 || identityId.Contains('|'))
            throw new InvalidOperationException("Identité Windows non utilisable pour l’enrôlement.");
        using var challengeResponse=await http.PostAsJsonAsync("auth/challenge",new{identityId,computerName=auditMetadata?.ComputerName,userName=auditMetadata?.UserName,licenseId=localGrant.LicenseId},ct);
        await EnsureSuccess(challengeResponse,ct);
        var challenge=await challengeResponse.Content.ReadFromJsonAsync<Challenge>(cancellationToken:ct)
            ??throw new InvalidOperationException("Challenge serveur vide.");
        byte[] nonce;
        try{nonce=Convert.FromBase64String(challenge.Nonce);}catch(FormatException){throw new InvalidOperationException("Challenge serveur invalide.");}
        var expected=$"OGIPEN-AUTH-v2:{audience}:{identityId}:{challenge.Nonce}";
        if(nonce.Length!=32 || Convert.ToBase64String(nonce)!=challenge.Nonce ||
            challenge.SigningText!=expected || challenge.ExpiresInSeconds is <1 or >90)
            throw new InvalidOperationException("Challenge serveur invalide.");
        var proof=sign(expected);if(proof.Length!=64)throw new InvalidOperationException("Preuve de clé P-256 invalide.");
        var signature=Convert.ToBase64String(proof);
        using var complete=await http.PostAsJsonAsync("auth/complete",new{identityId,nonce=challenge.Nonce,signature,licenseJson,computerName=auditMetadata?.ComputerName,userName=auditMetadata?.UserName,licenseId=localGrant.LicenseId},ct);
        await EnsureSuccess(complete,ct);
        var reply=await complete.Content.ReadFromJsonAsync<TokenReply>(cancellationToken:ct)
            ??throw new InvalidOperationException("Session serveur vide.");
        if(string.IsNullOrWhiteSpace(reply.AccessToken) || reply.AccessToken.Length>4096 ||
            reply.ExpiresInSeconds is <1 or >900)
            throw new InvalidOperationException("Session serveur invalide.");
        using var request=new HttpRequestMessage(HttpMethod.Get,"api/session");
        request.Headers.Authorization=new AuthenticationHeaderValue("Bearer",reply.AccessToken);
        using var metadata=await http.SendAsync(request,ct);
        await EnsureSuccess(metadata,ct);
        var context=await metadata.Content.ReadFromJsonAsync<SessionContext>(cancellationToken:ct)
            ??throw new InvalidOperationException("Contexte de session vide.");
        if(context.Identity!=identityId || context.CompanyId<1 ||
            context.LicenceId!=localGrant.LicenseId || context.BeneficiaryId!=localGrant.BeneficiaryId ||
            string.IsNullOrWhiteSpace(context.DisplayName) || context.Projects is null ||
            context.Projects.Any(p=>string.IsNullOrWhiteSpace(p.Id) || string.IsNullOrWhiteSpace(p.Name) ||
                p.Permissions is null || p.Permissions.Any(string.IsNullOrWhiteSpace)) ||
            context.Projects.Select(p=>p.Id).Distinct(StringComparer.Ordinal).Count()!=context.Projects.Length)
            throw new InvalidOperationException("Le contexte serveur ne correspond pas à la licence et à l’identité du poste.");
        var expires=DateTimeOffset.UtcNow.AddSeconds(reply.ExpiresInSeconds);
        return new(reply.AccessToken,expires<localGrant.ExpiresUtc?expires:localGrant.ExpiresUtc,context);
    }
    public async Task SignOutAsync(string accessToken,CancellationToken ct)
    {
        _=RequireSecureEndpoint(http.BaseAddress?.AbsoluteUri??"");
        using var request=new HttpRequestMessage(HttpMethod.Delete,"api/session");
        request.Headers.Authorization=new AuthenticationHeaderValue("Bearer",accessToken);
        using var response=await http.SendAsync(request,ct);
        if(response.StatusCode!=HttpStatusCode.Unauthorized)await EnsureSuccess(response,ct);
    }
    public async Task ReportLocalRefusalAsync(string identityId,ClientAuditMetadata metadata,long? licenseId,CancellationToken ct)
    {
        _=RequireSecureEndpoint(http.BaseAddress?.AbsoluteUri??"");
        using var response=await http.PostAsJsonAsync("auth/attempt",new{identityId,computerName=metadata.ComputerName,userName=metadata.UserName,licenseId},ct);
        await EnsureSuccess(response,ct);
    }
    private static Task EnsureSuccess(HttpResponseMessage response,CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        if(!response.IsSuccessStatusCode)throw new InvalidOperationException(response.StatusCode switch {
            HttpStatusCode.NotFound=>"Utilisateur non enrôlé, entreprise non licenciée ou API non disponible à cette adresse.",
            HttpStatusCode.Unauthorized=>"Connexion refusée : clé, licence, bénéficiaire ou session invalide.",
            HttpStatusCode.Forbidden=>"Accès au projet ou module non autorisé.",
            _=>"Le serveur ne peut pas ouvrir la session demandée."
        });
        return Task.CompletedTask;
    }
    private sealed record Challenge(string Nonce,string SigningText,int ExpiresInSeconds);
    private sealed record TokenReply(string AccessToken,int ExpiresInSeconds);
}
public sealed record SessionProject(string Id,string Name,string Role,string[] Permissions);
public sealed record SessionContext(string Identity,long CompanyId,long LicenceId,long BeneficiaryId,string DisplayName,SessionProject[] Projects);
public sealed record LicensedConnection(string AccessToken,DateTimeOffset ExpiresUtc,SessionContext Context);
public sealed record ClientAuditMetadata(string ComputerName,string UserName);
