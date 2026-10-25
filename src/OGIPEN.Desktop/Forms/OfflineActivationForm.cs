using Krypton.Toolkit;
using OGIPEN.Desktop.Infrastructure;

namespace OGIPEN.Desktop.Forms;

/// <summary>Separate licence workflow. It never asks for a login or password, or contacts WordPress.</summary>
public sealed class OfflineActivationForm:AppDialog
{
 private readonly ClientConfiguration configuration;
 private readonly bool required;
 private readonly Label status;
 private readonly KryptonButton finish;
 public bool LicenseChanged { get; private set; }
 public OfflineActivationForm(ClientConfiguration configuration,bool activationRequired=false)
 {
  this.configuration=configuration;required=activationRequired;
  Text=required?"OGIPEN — Activation du poste":"OGIPEN — Licence du poste";
  ClientSize=new(720,480);FormBorderStyle=FormBorderStyle.FixedDialog;MaximizeBox=false;MinimizeBox=false;
  Controls.Add(Ui.Label(required?"Activer ce poste":"Licence du poste",28,24,660,44,true));
  Controls.Add(Ui.Label(required?"Une licence valide est nécessaire avant la connexion.":"Consultez votre licence ou importez son renouvellement.",28,78,660,40));
  status=Ui.Label("",28,130,660,80);Controls.Add(status);
  var export=new KryptonButton{Text="1. Exporter la demande (.ogreq)",Location=new(28,228),Size=new(320,46)};
  var import=new KryptonButton{Text="2. Importer la licence (.oglic)",Location=new(368,228),Size=new(320,46)};
  export.Click+=(_,_)=>ExportRequest();import.Click+=(_,_)=>ImportLicense();Controls.Add(export);Controls.Add(import);
  Controls.Add(Ui.Label("Transmettez la demande au gestionnaire de licences. Importez ensuite le fichier signé fourni par WordPress. Aucune clé privée n’est exportée.",28,300,660,66));
  finish=new KryptonButton{Text=required?"Continuer vers la connexion":"Terminer",Location=new(368,402),Size=new(320,44)};
  finish.Click+=(_,_)=>{if(required&&!IsValid())return;DialogResult=DialogResult.OK;Close();};Controls.Add(finish);AcceptButton=finish;
  var cancel=new KryptonButton{Text=required?"Quitter":"Annuler",Location=new(28,402),Size=new(180,44),DialogResult=DialogResult.Cancel};Controls.Add(cancel);CancelButton=cancel;
  UpdateStatus();
 }
 private bool IsValid()=>OfflineLicenseService.TryReadLicense(configuration.OfflineSoftwareId,out _);
 private void UpdateStatus()
 {
  var valid=OfflineLicenseService.TryReadLicense(configuration.OfflineSoftwareId,out var grant);
  status.Text=valid&&grant is not null?"Licence vérifiée pour ce poste.\nValable jusqu’au "+grant.ExpiresUtc.ToLocalTime().ToString("dd/MM/yyyy HH:mm")+" · Référence "+grant.LicenseId:
   File.Exists(OfflineLicenseService.PublicKeyFile)?"Aucune licence valide sur ce poste.\nExportez une demande ou importez votre fichier de licence.":"Clé publique de confiance absente. Réinstallez la distribution approuvée avant l’activation.";
  status.ForeColor=valid?Ui.Text:Ui.Muted;finish.Enabled=!required||valid;
 }
 private void ExportRequest()
 {
  using var file=new SaveFileDialog{Title="Enregistrer la demande d’activation",Filter="Demande Ogipen (*.ogreq)|*.ogreq",FileName="ogipen-activation.ogreq",AddExtension=true,DefaultExt="ogreq",OverwritePrompt=true};
  if(file.ShowDialog(this)!=DialogResult.OK)return;
  try{OfflineLicenseService.ExportRequest(file.FileName,configuration.OfflineSoftwareId);status.Text="Demande enregistrée. Chargez ce fichier dans WordPress, puis importez le .oglic obtenu.";}
  catch(Exception ex){status.Text=ex.Message;}
 }
 private void ImportLicense()
 {
  using var file=new OpenFileDialog{Title="Importer la licence signée",Filter="Licence Ogipen (*.oglic)|*.oglic",CheckFileExists=true,Multiselect=false};
  if(file.ShowDialog(this)!=DialogResult.OK)return;
  try{OfflineLicenseService.ImportLicense(file.FileName,configuration.OfflineSoftwareId);LicenseChanged=true;UpdateStatus();finish.Focus();}
  catch(Exception ex){status.Text="Licence refusée : "+ex.Message;finish.Enabled=!required||IsValid();}
 }
}
