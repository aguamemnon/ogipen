using OGIPEN.Core.Security;
using OGIPEN.Desktop.Infrastructure;
namespace OGIPEN.Desktop.Forms;

public sealed class ServerProfilesForm:Form
{
    private readonly ClientConfiguration config;
    private readonly ListBox profiles=new(){Dock=DockStyle.Top,Height=130};
    private readonly TextBox name=new(){Dock=DockStyle.Top,MaxLength=80};
    private readonly TextBox address=new(){Dock=DockStyle.Top,MaxLength=2048};
    private readonly TextBox fingerprint=new(){Width=620,ReadOnly=true};
    private ServerProfile? editing;
    public ServerProfilesForm(ClientConfiguration configuration)
    {
        config=configuration;Text="OGIPEN — Profils serveur";ClientSize=new(680,570);StartPosition=FormStartPosition.CenterParent;
        var layout=new FlowLayoutPanel{Dock=DockStyle.Fill,FlowDirection=FlowDirection.TopDown,WrapContents=false,Padding=new(20),AutoScroll=true};
        profiles.Width=620;name.Width=620;address.Width=620;
        layout.Controls.Add(new Label{Text="Choisissez explicitement le serveur du site. Aucun basculement automatique.",Width=620,Height=38});
        layout.Controls.Add(profiles);layout.Controls.Add(new Label{Text="Nom du site",Width=620});layout.Controls.Add(name);
        layout.Controls.Add(new Label{Text="Adresse HTTPS de l’API",Width=620});layout.Controls.Add(address);
        layout.Controls.Add(new Label{Text="Certificat public du serveur — empreinte SHA-256 (facultatif si autorité déjà approuvée)",Width=620,Height=32});layout.Controls.Add(fingerprint);
        var import=new Button{Text="Importer le certificat serveur (.cer / .crt)",Width=340,Height=32};
        import.Click+=(_,_)=>{using var file=new OpenFileDialog{Filter="Certificat public (*.cer;*.crt;*.pem)|*.cer;*.crt;*.pem",CheckFileExists=true};if(file.ShowDialog(this)==DialogResult.OK){try{fingerprint.Text=ServerTransport.ImportCertificateFingerprint(file.FileName);}catch(Exception ex){MessageBox.Show(this,ex.Message,"Certificat refusé",MessageBoxButtons.OK,MessageBoxIcon.Warning);}}};layout.Controls.Add(import);
        var actions=new FlowLayoutPanel{Width=620,Height=45};
        void Button(string title,Action action){var b=new Button{Text=title,Width=145,Height=32};b.Click+=(_,_)=>{try{action();}catch(Exception ex){MessageBox.Show(this,ex.Message,"Profils serveur",MessageBoxButtons.OK,MessageBoxIcon.Warning);}};actions.Controls.Add(b);}
        Button("Nouveau",()=>{profiles.ClearSelected();editing=null;name.Clear();address.Clear();fingerprint.Clear();name.Focus();});
        Button("Enregistrer",()=>{
            var endpoint=LicensedSessionClient.RequireSecureEndpoint(address.Text);
            if(string.IsNullOrWhiteSpace(name.Text))throw new InvalidOperationException("Renseignez le nom du site.");
            var profile=editing??new ServerProfile();var oldName=profile.Name;var oldAddress=profile.ApiBaseUrl;var oldPin=profile.CertificateSha256;var oldSelection=config.SelectedProfileId;var oldUrl=config.ApiBaseUrl;var oldSite=config.SiteName;
            profile.Name=name.Text.Trim();profile.ApiBaseUrl=endpoint.AbsoluteUri;profile.CertificateSha256=fingerprint.Text;var added=editing is null;
            if(added)config.ServerProfiles.Add(profile);
            try{config.SelectProfile(profile.Id);config.Save();}
            catch{if(added)config.ServerProfiles.Remove(profile);profile.Name=oldName;profile.ApiBaseUrl=oldAddress;profile.CertificateSha256=oldPin;config.SelectedProfileId=oldSelection;config.ApiBaseUrl=oldUrl;config.SiteName=oldSite;throw;}
            editing=profile;RefreshList();
        });
        Button("Supprimer",()=>{
            if(editing is null)return;var item=editing;var index=config.ServerProfiles.IndexOf(item);var oldSelection=config.SelectedProfileId;var oldUrl=config.ApiBaseUrl;var oldName=config.SiteName;
            config.ServerProfiles.Remove(item);if(config.SelectedProfileId==item.Id){config.SelectedProfileId="";config.ApiBaseUrl="";config.SiteName="Site non configuré";}
            try{config.Save();}catch{config.ServerProfiles.Insert(index,item);config.SelectedProfileId=oldSelection;config.ApiBaseUrl=oldUrl;config.SiteName=oldName;throw;}
            editing=null;name.Clear();address.Clear();fingerprint.Clear();RefreshList();
        });
        Button("Fermer",()=>Close());layout.Controls.Add(actions);Controls.Add(layout);
        profiles.SelectedIndexChanged+=(_,_)=>{editing=profiles.SelectedItem as ServerProfile;if(editing is not null){name.Text=editing.Name;address.Text=editing.ApiBaseUrl;fingerprint.Text=editing.CertificateSha256;}};
        RefreshList();
    }
    private void RefreshList(){var selected=editing;profiles.Items.Clear();foreach(var p in config.ServerProfiles)profiles.Items.Add(p);if(selected is not null)profiles.SelectedItem=selected;}
}
