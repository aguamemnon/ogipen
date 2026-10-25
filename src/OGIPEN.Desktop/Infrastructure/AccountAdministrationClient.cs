using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
namespace OGIPEN.Desktop.Infrastructure;

public sealed record ManagedAccount(string IdentityId,string Login,string DisplayName,string SystemRole,bool Enabled,int Revision,bool CanRead,bool CanEdit);
public sealed record AccountSnapshot(long CompanyId,string ActorId,string SystemRole,bool CanManage,bool Truncated,ManagedAccount[] Items);
public sealed record AccountEdit(string? IdentityId,string Login,string DisplayName,string SystemRole,bool Enabled,int Revision,string? NewPassword);
public sealed record AccountSaved(string IdentityId,int Revision,bool Reauthenticate);
public sealed class AccountAdministrationClient:IDisposable
{
 readonly HttpClient http;
 public AccountAdministrationClient(ClientConfiguration configuration,string token){var endpoint=configuration.SecureApiEndpoint()??throw new InvalidOperationException("Sélectionnez un serveur.");http=ServerTransport.CreateClient(endpoint,configuration);http.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",token);}
 public async Task<AccountSnapshot> Read(CancellationToken ct){using var r=await http.GetAsync("api/administration/accounts",ct);await Check(r,ct);return await r.Content.ReadFromJsonAsync<AccountSnapshot>(cancellationToken:ct)??throw new InvalidOperationException("Liste des comptes indisponible.");}
 public async Task<AccountSaved> Save(AccountEdit edit,CancellationToken ct){using var r=await http.PostAsJsonAsync("api/administration/accounts",edit,ct);await Check(r,ct);return await r.Content.ReadFromJsonAsync<AccountSaved>(cancellationToken:ct)??throw new InvalidOperationException("Confirmation indisponible. Rechargez la liste.");}
 static async Task Check(HttpResponseMessage r,CancellationToken ct){
  if(r.IsSuccessStatusCode)return;
  if(r.StatusCode==HttpStatusCode.Unauthorized)throw new InvalidOperationException("Session expirée ou modifiée. Reconnectez-vous.");
  if(r.StatusCode==HttpStatusCode.Forbidden)throw new InvalidOperationException("Ce compte ne dispose pas des droits d’administration nécessaires.");
  if(r.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.Conflict){try{using var json=JsonDocument.Parse(await r.Content.ReadAsStringAsync(ct));var text=json.RootElement.GetProperty("message").GetString();if(text is {Length:>0 and <300})throw new AccountValidationException(text);}catch(JsonException){}catch(KeyNotFoundException){}}
  throw new InvalidOperationException("Opération non confirmée. Rechargez la liste avant de recommencer.");
 }
 public void Dispose()=>http.Dispose();
}
public sealed class AccountValidationException(string message):InvalidOperationException(message);
