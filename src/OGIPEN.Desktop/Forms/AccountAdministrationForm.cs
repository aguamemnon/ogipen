using Krypton.Toolkit;
using OGIPEN.Desktop.Infrastructure;
using OGIPEN.Desktop.Models;
namespace OGIPEN.Desktop.Forms;

public sealed class AccountAdministrationForm:AppDialog
{
 readonly AccountAdministrationClient? client;
 readonly CancellationTokenSource closing=new();
 readonly KryptonDataGridView grid=new(){Dock=DockStyle.Fill,ReadOnly=true,AllowUserToAddRows=false,AllowUserToDeleteRows=false,AutoGenerateColumns=false,SelectionMode=DataGridViewSelectionMode.FullRowSelect,MultiSelect=false,RowHeadersVisible=false};
 readonly KryptonTextBox login=new(){Dock=DockStyle.Fill,MaxLength=80},name=new(){Dock=DockStyle.Fill,MaxLength=180},password=new(){Dock=DockStyle.Fill,MaxLength=256,UseSystemPasswordChar=true};
 readonly KryptonComboBox role=new(){Dock=DockStyle.Fill,DropDownStyle=ComboBoxStyle.DropDownList};
 readonly KryptonCheckBox enabled=new(){Text="Compte actif",Dock=DockStyle.Fill};
 readonly KryptonButton save=new(){Text="Enregistrer",Width=170},create=new(){Text="Nouveau compte",Width=170},refresh=new(){Text="Actualiser",Width=150};
 readonly Label status=new(){Dock=DockStyle.Fill,ForeColor=Ui.Muted,AutoEllipsis=true};
 ManagedAccount? selected;AccountSnapshot? snapshot;bool selecting,busy;
 public bool ReauthenticationRequired {get;private set;}
 // Preview is used only by the local form smoke test, never as an authorization source.
 public AccountAdministrationForm(UserSession session,ClientConfiguration config,bool previewOnly=false){
  Text="OGIPEN — Comptes internes";ClientSize=new(1000,690);MinimumSize=new(850,650);
  if(!previewOnly)client=new(config,session.AccessToken);
  var layout=new TableLayoutPanel{Dock=DockStyle.Fill,BackColor=Ui.Background,Padding=new(20),RowCount=5,ColumnCount=1};
  layout.RowStyles.Add(new(SizeType.Absolute,65));layout.RowStyles.Add(new(SizeType.Percent,100));layout.RowStyles.Add(new(SizeType.Absolute,220));layout.RowStyles.Add(new(SizeType.Absolute,44));layout.RowStyles.Add(new(SizeType.Absolute,52));
  layout.Controls.Add(new Label{Dock=DockStyle.Fill,ForeColor=Ui.Text,Text="Comptes internes Ogipen\nLe rôle technique et les droits de projet sont distincts. Les comptes Windows restent gérés dans le portail."},0,0);
  foreach(var (title,property,width) in new[]{("Login","Login",150),("Nom","DisplayName",210),("Rôle technique","SystemRole",130),("Actif","Enabled",65),("Lecture projet","CanRead",110),("Édition projet","CanEdit",110)}){
   DataGridViewColumn column=property is "Enabled" or "CanRead" or "CanEdit"?new DataGridViewCheckBoxColumn():new DataGridViewTextBoxColumn();column.HeaderText=title;column.DataPropertyName=property;column.Width=width;grid.Columns.Add(column);
  }layout.Controls.Add(grid,0,1);
  var fields=new TableLayoutPanel{Dock=DockStyle.Fill,BackColor=Ui.Background,ColumnCount=2,RowCount=5,Padding=new(0,12,0,0)};fields.ColumnStyles.Add(new(SizeType.Absolute,260));fields.ColumnStyles.Add(new(SizeType.Percent,100));
  void Field(string label,Control input,int row){fields.RowStyles.Add(new(SizeType.Absolute,38));fields.Controls.Add(new Label{Dock=DockStyle.Fill,Text=label,ForeColor=Ui.Text,TextAlign=ContentAlignment.MiddleLeft},0,row);fields.Controls.Add(input,1,row);}
  Field("Login",login,0);Field("Nom affiché",name,1);Field("Rôle technique",role,2);Field("Nouveau mot de passe (12 caractères min.)",password,3);fields.Controls.Add(enabled,1,4);role.Items.AddRange(new object[]{"Utilisateur","Administrateur logiciel","OSSI"});role.SelectedIndex=0;layout.Controls.Add(fields,0,2);
  var actions=new FlowLayoutPanel{Dock=DockStyle.Fill,BackColor=Ui.Background};actions.Controls.AddRange(new Control[]{refresh,create,save});layout.Controls.Add(actions,0,3);layout.Controls.Add(status,0,4);Controls.Add(layout);
  refresh.Click+=async(_,_)=>await LoadAccounts();create.Click+=(_,_)=>ClearSelection();save.Click+=async(_,_)=>await SaveAccount();
  grid.SelectionChanged+=(_,_)=>{if(selecting)return;selected=grid.CurrentRow?.DataBoundItem as ManagedAccount;ShowSelection();};
  Shown+=async(_,_)=>{if(!previewOnly)await LoadAccounts();else{status.Text="Aperçu de contrôle — aucune donnée réelle.";SetAccess();}};
  FormClosing+=(_,_)=>closing.Cancel();FormClosed+=(_,_)=>{password.Clear();client?.Dispose();closing.Dispose();};SetAccess();
 }
 void SetAccess(){bool edit=!busy&&snapshot?.CanManage==true;foreach(var field in new Control[]{login,name,password,role,enabled,create,save})field.Enabled=edit;login.ReadOnly=selected is not null;refresh.Enabled=!busy&&client is not null;grid.Enabled=!busy;}
 void ShowSelection(){password.Clear();login.Text=selected?.Login??"";name.Text=selected?.DisplayName??"";role.SelectedIndex=selected?.SystemRole switch{"admin"=>1,"ossi"=>2,_=>0};enabled.Checked=selected?.Enabled??true;SetAccess();}
 void ClearSelection(){selecting=true;try{grid.ClearSelection();selected=null;ShowSelection();status.Text="Nouveau compte : le mot de passe initial est obligatoire pour l’activer. Aucun droit de projet n’est ajouté.";login.Focus();}finally{selecting=false;}}
 async Task LoadAccounts(){if(client is null||busy)return;busy=true;SetAccess();status.Text="Chargement des comptes…";try{var next=await client.Read(closing.Token);if(IsDisposed)return;snapshot=next;selecting=true;grid.DataSource=next.Items;selected=null;grid.ClearSelection();selecting=false;ShowSelection();status.Text=next.CanManage?"Entreprise "+next.CompanyId+" · Mot de passe vide : conserver l’actuel. Les droits de projet affichés ne sont pas modifiés ici.":"Consultation OSSI — modification des comptes réservée à un administrateur.";if(next.Truncated)status.Text+=" Liste limitée à 200 comptes.";}catch(OperationCanceledException) when(closing.IsCancellationRequested){}catch(Exception ex){if(!IsDisposed)status.Text=ex is HttpRequestException?"Serveur indisponible.":ex.Message;}finally{selecting=false;busy=false;if(!IsDisposed)SetAccess();}}
 async Task SaveAccount(){
  if(client is null||busy||snapshot?.CanManage!=true)return;
  var edit=new AccountEdit(selected?.IdentityId,login.Text.Trim(),name.Text.Trim(),role.SelectedIndex switch{1=>"admin",2=>"ossi",_=>"user"},enabled.Checked,selected?.Revision??0,password.Text);
  if(string.IsNullOrWhiteSpace(edit.Login)||string.IsNullOrWhiteSpace(edit.DisplayName)){status.Text="Renseignez le login et le nom.";return;}
  busy=true;password.Clear();SetAccess();status.Text="Enregistrement…";
  try{var saved=await client.Save(edit,closing.Token);if(IsDisposed)return;if(saved.Reauthenticate){ReauthenticationRequired=true;DialogResult=DialogResult.OK;Close();return;}busy=false;await LoadAccounts();if(!IsDisposed)status.Text="Compte enregistré. Ses anciennes sessions ont été fermées ; ses droits de projet sont conservés.";}
  catch(OperationCanceledException) when(closing.IsCancellationRequested){}catch(Exception ex){if(!IsDisposed)status.Text=ex is HttpRequestException?"Opération non confirmée. Actualisez la liste.":ex.Message;}
  finally{busy=false;if(!IsDisposed){password.Clear();SetAccess();}}
 }
}
