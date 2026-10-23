using OGIPEN.Desktop.Infrastructure;

namespace OGIPEN.Desktop.Forms;

/// <summary>
/// Deliberately no network calls. Import/export are usable on an isolated
/// Windows station, including BEFORE the normal online sign-in.
/// </summary>
public sealed class OfflineActivationForm : Form
{
    private readonly NumericUpDown _softwareId;
    private readonly Label _status;
    private readonly ClientConfiguration _configuration;

    public OfflineActivationForm(ClientConfiguration configuration)
    {
        _configuration = configuration;
        Text = "OGIPEN — Activation hors ligne";
        ClientSize = new Size(680, 470);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        BackColor = Ui.Background;
        ForeColor = Ui.Text;

        Controls.Add(Ui.Label("Activation sur poste isolé", 24, 22, 620, 42, true));
        Controls.Add(Ui.Label(
            "Cette procédure n'utilise pas Internet sur le poste à activer.", 24, 69, 620, 26));

        Controls.Add(Ui.Label("Identifiant logiciel SLM Plus", 24, 111, 290));
        _softwareId = new NumericUpDown
        {
            Location = new Point(335, 108), Size = new Size(150, 30),
            Minimum = 0, Maximum = 1000000000,
            Value = Math.Max(0, configuration.OfflineSoftwareId),
            BackColor = Ui.Panel, ForeColor = Ui.Text
        };
        Controls.Add(_softwareId);
        Controls.Add(Ui.Label("0 = à renseigner (ID du logiciel dans SLM Plus).", 490, 111, 176));
        Controls.Add(Ui.Label("Version majeure prise en charge : " +
            OfflineLicenseService.SoftwareMajorVersion, 24, 150, 500));

        var export = Ui.Button("1. Exporter la demande (.ogreq)", 24, 191, 310);
        export.Click += (_, _) => ExportRequest();
        Controls.Add(export);

        var import = Ui.Button("2. Importer la licence (.oglic)", 352, 191, 305);
        import.Click += (_, _) => ImportLicense();
        Controls.Add(import);

        _status = Ui.Label("", 24, 250, 630, 104);
        _status.ForeColor = Ui.Muted;
        Controls.Add(_status);
        Controls.Add(Ui.Label(
            "La clé privée reste dans le magasin cryptographique Windows CNG. " +
            "Ni noms de projets ni identifiants AD ne sont exportés.",
            24, 359, 630, 49));

        var close = Ui.Button("Fermer", 490, 419, 166);
        close.BackColor = Ui.Panel;
        close.Click += (_, _) => Close();
        Controls.Add(close);
        UpdateStatus();
    }

    private int SoftwareId => Decimal.ToInt32(_softwareId.Value);

    private void ExportRequest()
    {
        using var dialog = new SaveFileDialog
        {
            Title = "Enregistrer la demande d'activation",
            Filter = "Demande OGIPEN (*.ogreq)|*.ogreq",
            FileName = "ogipen-activation.ogreq",
            DefaultExt = "ogreq",
            AddExtension = true,
            OverwritePrompt = true
        };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        try
        {
            OfflineLicenseService.ExportRequest(dialog.FileName, SoftwareId);
            _status.Text = "Demande enregistrée. Transmets uniquement ce fichier au gestionnaire " +
                "par un circuit autorisé. La clé privée de ce poste n'a pas été exportée.";
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Demande d'activation",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ImportLicense()
    {
        using var dialog = new OpenFileDialog
        {
            Title = "Importer la licence signée",
            Filter = "Licence OGIPEN (*.oglic)|*.oglic",
            CheckFileExists = true,
            Multiselect = false
        };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        try
        {
            var grant = OfflineLicenseService.ImportLicense(dialog.FileName, SoftwareId);
            _status.Text = "Licence signée valide pour ce poste. " +
                "Expiration : " + grant.ExpiresUtc.ToLocalTime().ToString("dd/MM/yyyy HH:mm") +
                ". Modules autorisés : " + string.Join(", ", grant.ModuleIds) + ".";
            MessageBox.Show(this,
                "Activation cryptographique hors ligne importée. " +
                "L'accès aux projets reste soumis à la connexion locale " +
                "et aux permissions OGIPEN (raccordement métier à finaliser).",
                "Licence vérifiée", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Licence refusée",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void UpdateStatus()
    {
        if (!File.Exists(OfflineLicenseService.PublicKeyFile))
        {
            _status.Text = "Clé publique de confiance absente : " +
                "installer Assets/SLMMS-Signing-Public.pem depuis une distribution approuvée. " +
                "Aucune licence non signée ne sera acceptée.";
            return;
        }
        if (OfflineLicenseService.TryReadLicense(SoftwareId, out var existing) &&
            existing is not null)
        {
            _status.Text = "Licence hors ligne vérifiée, valable jusqu'au " +
                existing.ExpiresUtc.ToLocalTime().ToString("dd/MM/yyyy HH:mm") + ".";
            return;
        }
        _status.Text = "Aucune licence hors ligne valide sur ce poste. " +
            "Commence par exporter une demande.";
    }
}
