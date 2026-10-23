using OGIPEN.Core.Licensing;
using OGIPEN.Desktop.Infrastructure;
using OGIPEN.Desktop.Models;

namespace OGIPEN.Desktop.Forms;

public sealed class LoginForm : Form
{
    private readonly ClientConfiguration _config;
    private readonly Uri? _endpoint;
    private readonly TextBox _username, _password;
    private readonly Button _connect, _retry;
    private readonly Label _status;
    private bool _serverAvailable;

    public UserSession? Session { get; private set; }

    public LoginForm(ClientConfiguration config, Uri? endpoint, ServerPreflightResult server)
    {
        _config = config;
        _endpoint = endpoint;
        _serverAvailable = server.ApiAvailable && !server.Maintenance;

        Text = "OGIPEN — Identification";
        ClientSize = new Size(540, 628);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Ui.Background;
        Controls.Add(Ui.Label("Connexion OGIPEN", 36, 30, 450, 46, true));
        Controls.Add(Ui.Label("Utilisateur", 36, 115, 400));
        _username = Ui.TextBox(36, 147, 454);
        Controls.Add(_username);
        Controls.Add(Ui.Label("Mot de passe", 36, 197, 400));
        _password = Ui.TextBox(36, 229, 454, true);
        Controls.Add(_password);

        _status = Ui.Label(server.Message, 36, 284, 470, 60);
        _status.ForeColor = Ui.Muted;
        Controls.Add(_status);

        _connect = Ui.Button("Se connecter", 36, 356, 214);
        _connect.Enabled = _serverAvailable;
        _connect.Click += async (_, _) => await ConnectAsync();
        Controls.Add(_connect);

        var preview = Ui.Button("Aperçu sans serveur", 266, 356, 224);
        preview.BackColor = Ui.Panel;
        preview.Click += (_, _) =>
        {
            Session = UserSession.Preview();
            DialogResult = DialogResult.OK;
            Close();
        };
        Controls.Add(preview);

        _retry = Ui.Button("Retester le serveur", 36, 409, 214);
        _retry.BackColor = Ui.Panel;
        _retry.Enabled = endpoint is not null ||
            !string.IsNullOrWhiteSpace(config.LegacyDatabaseServer);
        _retry.Click += async (_, _) => await RetryServerAsync();
        Controls.Add(_retry);

        var help = new LinkLabel
        {
            Text = "Maintenance / configuration",
            Location = new Point(266, 418),
            Size = new Size(240, 28),
            LinkColor = Ui.Accent,
            BackColor = Ui.Background
        };
        help.Click += (_, _) =>
        {
            using var dlg = new MaintenanceInfoForm(_config);
            dlg.ShowDialog(this);
        };
        Controls.Add(help);
        var offline = Ui.Button("Activation hors ligne", 36, 461, 254);
        offline.BackColor = Ui.Panel;
        offline.Click += (_, _) =>
        {
            using var dlg = new OfflineActivationForm(_config);
            dlg.ShowDialog(this);
        };
        Controls.Add(offline);
        Controls.Add(Ui.Label("L'aperçu ne donne accès à aucune donnée réelle.", 36, 515, 450));
        var notice = new LicenseNoticePanel
        {
            Dock = DockStyle.None,
            Location = new Point(0, 570),
            Size = new Size(540, 58)
        };
        notice.Display(LicenseAlertEvaluator.Evaluate(
            null, false, DateOnly.FromDateTime(DateTime.UtcNow)), true);
        Controls.Add(notice);
        AcceptButton = _connect;
    }

    private async Task RetryServerAsync()
    {
        _retry.Enabled = false;
        _connect.Enabled = false;
        _status.Text = "Vérification de présence du serveur...";
        try
        {
            var server = await StartupChecks.CheckServerAsync(
                _config, _endpoint, CancellationToken.None);
            _serverAvailable = server.ApiAvailable && !server.Maintenance;
            _status.Text = server.Message;
            _connect.Enabled = _serverAvailable;
        }
        catch (Exception)
        {
            _serverAvailable = false;
            _status.Text = "Échec du contrôle serveur.";
        }
        finally
        {
            if (!IsDisposed) _retry.Enabled = true;
        }
    }

    private async Task ConnectAsync()
    {
        if (!_serverAvailable || _endpoint is null ||
            string.IsNullOrWhiteSpace(_username.Text) ||
            string.IsNullOrWhiteSpace(_password.Text))
        {
            _status.Text = "Connexion indisponible ou identifiants manquants.";
            return;
        }

        _connect.Enabled = false;
        _status.Text = "Authentification sécurisée en cours...";
        try
        {
            using var client = new AuthenticationClient(_endpoint);
            Session = await client.SignInAsync(
                _username.Text.Trim(), _password.Text, CancellationToken.None);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            _status.Text = ex is HttpRequestException or TaskCanceledException
                ? "Serveur indisponible ou délai de connexion dépassé."
                : ex.Message;
        }
        finally
        {
            _password.Clear();
            if (!IsDisposed) _connect.Enabled = _serverAvailable;
        }
    }
}
