using OGIPEN.Desktop.Infrastructure;
using OGIPEN.Desktop.Models;
namespace OGIPEN.Desktop.Forms;

public sealed class LoginForm:Form
{
    private readonly ClientConfiguration config;
    private Uri? endpoint;
    private bool available,loading;
    private readonly TextBox login=new(){Width=610,MaxLength=180};
    private readonly TextBox password=new(){Width=610,MaxLength=1024,UseSystemPasswordChar=true};
    private readonly ComboBox provider=new(){Width=610,DropDownStyle=ComboBoxStyle.DropDownList};
    private readonly ComboBox servers=new(){DropDownStyle=ComboBoxStyle.DropDownList,Width=460};
    private readonly Label status=new(){Width=620,Height=78};
    private readonly Button connect=new(){Text="Se connecter",Width=195,Height=36};
    private readonly Button retry=new(){Text="Retester le serveur",Width=195,Height=36};
    private readonly CancellationTokenSource closing=new();
    private readonly FlowLayoutPanel content;
    public UserSession? Session { get; private set; }
    public LoginForm(ClientConfiguration configuration,Uri? initialEndpoint,ServerPreflightResult server)
    {
        config=configuration;endpoint=initialEndpoint;available=server.ApiAvailable&&!server.Maintenance;
        Text="OGIPEN "+Application.ProductVersion+" — Connexion utilisateur";ClientSize=new(700,790);MinimumSize=new(700,790);StartPosition=FormStartPosition.CenterScreen;
        var identity=WindowsSessionIdentity.Current();
        content=new FlowLayoutPanel{Dock=DockStyle.Fill,FlowDirection=FlowDirection.TopDown,WrapContents=false,Padding=new(24),AutoScroll=true};
        void Label(string text,int height=32)=>content.Controls.Add(new Label{Text=text,Width=630,Height=height,AutoEllipsis=true});
        Label("Connexion Ogipen — "+Application.ProductVersion,36);
        Label("Type de compte",24);provider.Items.AddRange(new object[]{"Windows / Active Directory","Compte interne Ogipen"});provider.SelectedIndex=0;content.Controls.Add(provider);
        Label("Login — modifiable",24);login.Text=identity.DisplayName;content.Controls.Add(login);
        Label("Mot de passe",24);content.Controls.Add(password);
        provider.SelectedIndexChanged+=(_,_)=>{password.Clear();login.Focus();};
        login.TextChanged+=(_,_)=>password.Clear();
        Shown+=(_,_)=>password.Focus();
        Label("Serveur du site — choix explicite, sans basculement automatique");
        var row=new FlowLayoutPanel{Width=640,Height=42};row.Controls.Add(servers);
        var manage=new Button{Text="Profils serveur…",Width=150,Height=30};row.Controls.Add(manage);content.Controls.Add(row);
        status.Text=server.Message;content.Controls.Add(status);
        var actions=new FlowLayoutPanel{Width=640,Height=45};actions.Controls.Add(connect);actions.Controls.Add(retry);content.Controls.Add(actions);
        var activate=new Button{Text="Activation hors ligne (.ogreq / .oglic)",Width=360,Height=34};content.Controls.Add(activate);
        var enrol=new Button{Text="Exporter la fiche d’enrôlement Windows",Width=360,Height=34};content.Controls.Add(enrol);
        var preview=new Button{Text="Aperçu sans serveur",Width=250,Height=34};content.Controls.Add(preview);
        Label("Windows/AD : mot de passe vérifié par Windows. Compte Ogipen : mot de passe vérifié par le serveur. Le compte choisi peut différer de la session Windows. La licence du poste reste séparée.",65);
        Label("L’aperçu ne donne accès à aucune donnée réelle.");Controls.Add(content);
        connect.Enabled=available&&endpoint is not null;
        connect.Click+=async(_,_)=>await ConnectAsync();retry.Click+=async(_,_)=>await RetryAsync();
        manage.Click+=(_,_)=>{using var form=new ServerProfilesForm(config);form.ShowDialog(this);ReloadServers();endpoint=config.SecureApiEndpoint();available=false;connect.Enabled=false;status.Text="Profil choisi. Retestez le serveur avant la connexion.";};
        activate.Click+=(_,_)=>{using var form=new OfflineActivationForm(config);form.ShowDialog(this);};
        enrol.Click+=(_,_)=>{using var file=new SaveFileDialog{Title="Fiche contenant l’identifiant Windows et la clé publique",Filter="Fiche d’enrôlement (*.txt)|*.txt",FileName="ogipen-enrolement.txt"};if(file.ShowDialog(this)==DialogResult.OK){try{OfflineLicenseService.ExportEnrollmentInfo(file.FileName);status.Text="Fiche enregistrée. Aucune clé privée exportée.";}catch(Exception ex){status.Text=ex.Message;}}};
        preview.Click+=(_,_)=>{Session=UserSession.Preview();DialogResult=DialogResult.OK;Close();};
        servers.SelectedIndexChanged+=(_,_)=>{
            if(loading || servers.SelectedItem is not ServerProfile p)return;
            var old=config.SelectedProfileId;var oldUrl=config.ApiBaseUrl;var oldName=config.SiteName;
            try{config.SelectProfile(p.Id);config.Save();endpoint=config.SecureApiEndpoint();available=false;connect.Enabled=false;status.Text="Serveur choisi. Retestez sa disponibilité.";}
            catch(Exception ex){config.SelectedProfileId=old;config.ApiBaseUrl=oldUrl;config.SiteName=oldName;ReloadServers();status.Text=ex.Message;}
        };
        ReloadServers();AcceptButton=connect;FormClosing+=(_,_)=>closing.Cancel();FormClosed+=(_,_)=>closing.Dispose();
    }
    private void ReloadServers(){loading=true;try{servers.Items.Clear();foreach(var p in config.ServerProfiles)servers.Items.Add(p);servers.SelectedItem=config.ServerProfiles.FirstOrDefault(p=>p.Id==config.SelectedProfileId);}finally{loading=false;}}
    private async Task RetryAsync()
    {
        content.Enabled=false;retry.Enabled=false;connect.Enabled=false;status.Text="Vérification du serveur sélectionné…";
        try{var result=await StartupChecks.CheckServerAsync(config,endpoint,closing.Token);if(IsDisposed)return;available=result.ApiAvailable&&!result.Maintenance;status.Text=result.Message;}
        catch(OperationCanceledException) when(closing.IsCancellationRequested){}
        catch(Exception){if(!IsDisposed){available=false;status.Text="Échec du contrôle serveur.";}}
        finally{if(!IsDisposed){content.Enabled=true;retry.Enabled=true;connect.Enabled=available&&endpoint is not null;}}
    }
    private async Task ConnectAsync()
    {
        if(!available || endpoint is null)return;
        if(string.IsNullOrWhiteSpace(login.Text)||string.IsNullOrEmpty(password.Text)){status.Text="Saisissez le login et le mot de passe.";password.Focus();return;}
        content.Enabled=false;connect.Enabled=false;retry.Enabled=false;servers.Enabled=false;status.Text="Vérification du compte, du mot de passe et de la licence…";
        try{using var client=new AuthenticationClient(endpoint,config);var session=await client.SignInAsync(config,provider.SelectedIndex==0?"windows":"ogipen",login.Text,password.Text,closing.Token);if(IsDisposed)return;Session=session;DialogResult=DialogResult.OK;Close();}
        catch(OperationCanceledException) when(closing.IsCancellationRequested){}
        catch(Exception ex){if(!IsDisposed)status.Text=ex is HttpRequestException or TaskCanceledException?"Serveur HTTPS indisponible ou délai dépassé.":ex.Message;}
        finally{if(!IsDisposed){password.Clear();content.Enabled=true;connect.Enabled=available;retry.Enabled=true;servers.Enabled=true;}}
    }
}
