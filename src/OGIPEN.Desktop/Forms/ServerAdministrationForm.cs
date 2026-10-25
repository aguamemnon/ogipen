using System.Net.Http.Headers;
using System.Text.Json;
using OGIPEN.Desktop.Infrastructure;
using OGIPEN.Desktop.Models;
namespace OGIPEN.Desktop.Forms;
public sealed class ServerAdministrationForm:AppDialog
{
 public bool ReauthenticationRequired {get;private set;}
 readonly Label result=new(){ForeColor=Ui.Text,BackColor=Ui.Background,Dock=DockStyle.Fill,Padding=new(24),Text="Lecture des droits d’administration…"};
 public ServerAdministrationForm(UserSession session,ClientConfiguration configuration){
  Text="OGIPEN — Administration du serveur";ClientSize=new(560,240);StartPosition=FormStartPosition.CenterParent;Controls.Add(result);
  var accounts=new Krypton.Toolkit.KryptonButton{Text="Comptes internes Ogipen",Dock=DockStyle.Bottom,Height=42};accounts.Click+=(_,_)=>{using var form=new AccountAdministrationForm(session,configuration);form.ShowDialog(this);if(form.ReauthenticationRequired){ReauthenticationRequired=true;Close();}};Controls.Add(accounts);
  Shown+=async(_,_)=>{
   try{var endpoint=configuration.SecureApiEndpoint()??throw new InvalidOperationException("Serveur absent.");using var http=ServerTransport.CreateClient(endpoint,configuration);using var request=new HttpRequestMessage(HttpMethod.Get,"api/administration");request.Headers.Authorization=new AuthenticationHeaderValue("Bearer",session.AccessToken);using var response=await http.SendAsync(request);response.EnsureSuccessStatusCode();using var json=JsonDocument.Parse(await response.Content.ReadAsStringAsync());if(!IsDisposed)result.Text=$"Compte : {session.DisplayName}\nRôle technique : {json.RootElement.GetProperty("systemRole").GetString()}\nIdentités de l’entreprise : {json.RootElement.GetProperty("identities").GetInt64()}\n\nLes droits de projet restent attribués séparément.\nGérez les comptes internes avec le bouton ci-dessous.";}
   catch{if(!IsDisposed)result.Text="Administration refusée ou serveur indisponible. Vérifiez les droits de ce compte.";}
  };
 }
}
