using OGIPEN.Desktop.Infrastructure;
using OGIPEN.Desktop.Models;

namespace OGIPEN.Desktop.Forms;
public sealed class LoginForm : Form
{
    private readonly ClientConfiguration _config;
    private readonly Uri? _endpoint;
    private readonly TextBox _username, _password;
    private readonly Button _connect, _preview;
    private readonly Label _status;
    public UserSession? Session { get; private set; }

    public LoginForm(ClientConfiguration config, Uri? endpoint)
    {
        _config = config; _endpoint = endpoint;
        Text = "OGIPEN — Identification"; ClientSize = new Size(540, 460);
        FormBorderStyle = FormBorderStyle.FixedDialog; MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen; BackColor = Ui.Background;
        Controls.Add(Ui.Label("Connexion OGIPEN", 36, 30, 450, 46, true));
        Controls.Add(Ui.Label("Utilisateur", 36, 115, 400));
        _username = Ui.TextBox(36, 147, 454);
        Controls.Add(_username);
        Controls.Add(Ui.Label("Mot de passe", 36, 197, 400));
        _password = Ui.TextBox(36, 229, 454, true);
        Controls.Add(_password);
        _status = Ui.Label(endpoint is null ? "Aucun serveur HTTPS configuré" :
            $"Site : {config.SiteName}", 36, 290, 470, 48);
        _status.ForeColor = Ui.Muted; Controls.Add(_status);
        _connect = Ui.Button("Se connecter", 36, 356, 214);
        _connect.Enabled = endpoint is not null;
        _connect.Click += async (_, _) => await ConnectAsync();
        Controls.Add(_connect);
        _preview = Ui.Button("Aperçu sans serveur", 266, 356, 224);
        _preview.BackColor = Ui.Panel;
        _preview.Click += (_, _) =>
        {
            Session = UserSession.Preview();
            DialogResult = DialogResult.OK; Close();
        };
        Controls.Add(_preview);
        var help = new LinkLabel { Text = "Maintenance / configuration", Location = new Point(36, 407),
            Size = new Size(300, 28), LinkColor = Ui.Accent, BackColor = Ui.Background };
        help.Click += (_, _) => { using var dlg = new MaintenanceInfoForm(_config); dlg.ShowDialog(this); };
        Controls.Add(help);
        AcceptButton = _connect;
    }

    private async Task ConnectAsync()
    {
        if (_endpoint is null || string.IsNullOrWhiteSpace(_username.Text) ||
            string.IsNullOrWhiteSpace(_password.Text))
        {
            _status.Text = "Saisir un identifiant et un mot de passe."; return;
        }
        _connect.Enabled = false; _status.Text = "Authentification sécurisée...";
        try
        {
            using var client = new AuthenticationClient(_endpoint);
            Session = await client.SignInAsync(_username.Text.Trim(), _password.Text, CancellationToken.None);
            DialogResult = DialogResult.OK; Close();
        }
        catch (Exception ex)
        {
            _status.Text = ex is HttpRequestException
                ? "Serveur indisponible ou réponse non valide."
                : ex.Message;
        }
        finally { _password.Clear(); _connect.Enabled = true; }
    }
}
