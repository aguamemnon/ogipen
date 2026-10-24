using OGIPEN.Desktop.Forms;
using OGIPEN.Desktop.Infrastructure;
using OGIPEN.Desktop.Models;

namespace OGIPEN.Desktop;

internal static class Program
{
    // L'ancienne version démarrait le splash avant l'écran de connexion.
    // Ici la boucle WinForms démarre AVANT toute opération asynchrone.
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new StartupApplicationContext());
    }


}

internal sealed class StartupApplicationContext : ApplicationContext
{
    private readonly SplashForm _splash = new();
    private bool _started;
    private bool _changingUser;
    private ClientConfiguration? _configuration;
    private Uri? _serverEndpoint;
    private ServerPreflightResult? _preflight;
    private UserSession? _activeSession;

    public StartupApplicationContext()
    {
        MainForm = _splash;
        _splash.Shown += OnSplashShown;
    }

    private async void OnSplashShown(object? sender, EventArgs args)
    {
        if (_started) return;
        _started = true;

        try
        {
            _splash.Report("Initialisation des paramètres...", 5);
            await Task.Yield(); // laisse le splash se dessiner, boucle active
            var config = await Task.Run(ClientConfiguration.Load);

            _splash.Report("Chargement de la configuration du site...", 25);
            Uri? endpoint = config.SecureApiEndpoint();
            _configuration = config;
            _serverEndpoint = endpoint;
            await Task.Yield();

            _splash.Report("Test de présence du serveur...", 45);
            ServerPreflightResult result =
                await StartupChecks.CheckServerAsync(config, endpoint, CancellationToken.None);

            _preflight = result;
            _splash.Report(result.Message, 65);
            await Task.Yield();

            if (result.Maintenance)
            {
                _splash.Report("Serveur en maintenance — connexion indisponible", 80);
            }
            else if (result.ApiAvailable)
            {
                _splash.Report("Recherche des mises à jour...", 75);
                string updateStatus =
                    await StartupChecks.CheckUpdateAsync(endpoint!, CancellationToken.None);
                _splash.Report(updateStatus, 90);
            }
            else
            {
                _splash.Report("Vérification des mises à jour différée (serveur/API indisponible)", 90);
            }

            _splash.Report("Ouverture de l'identification...", 100);
            await Task.Yield();
            _splash.Hide();

            var selected = RequestSession(config, endpoint, result);
            if (selected is null)
            {
                _splash.Close();
                return;
            }
            ShowMainWindow(selected.Value.Session, selected.Value.Project, config);
            _splash.Close();
        }
        catch (Exception ex)
        {
            _splash.Hide();
            MessageBox.Show(
                "Impossible de démarrer OGIPEN : " + ex.Message,
                "OGIPEN — démarrage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _splash.Close();
            ExitThread();
        }
    }
    private static (UserSession Session, ProjectAccess Project)? RequestSession(
        ClientConfiguration config, Uri? endpoint, ServerPreflightResult server)
    {
        using var login = new LoginForm(config, endpoint, server);
        if (login.ShowDialog() != DialogResult.OK || login.Session is null)
            return null;

        var session = login.Session;
        using var chooseProject = new ProjectSelectionForm(session);
        if (chooseProject.ShowDialog() != DialogResult.OK ||
            chooseProject.SelectedProject is null)
            return null;

        return (session, chooseProject.SelectedProject);
    }

    private void ShowMainWindow(UserSession session, ProjectAccess project, ClientConfiguration config)
    {
        _activeSession=session;
        _serverEndpoint=config.SecureApiEndpoint();
        var main = new MainMdiForm(session, project, config);
        main.LogoutRequested += OnLogoutRequested;
        MainForm = main;
        main.Show();
    }

    // La déconnexion efface l'ancienne session en fermant le shell, puis
    // réaffiche LoginForm et la sélection du projet. Aucun accès au projet
    // précédent n'est possible à partir du nouveau shell.
    private async void OnLogoutRequested(object? sender, EventArgs args)
    {
        if (_changingUser || sender is not MainMdiForm previous ||
            _configuration is null)
            return;

        _changingUser = true;
        previous.Hide();

        try
        {
            if(_activeSession is { IsPreview:false } current && _serverEndpoint is not null){
                using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(3));
                try{using var client=new AuthenticationClient(_serverEndpoint);await client.SignOutAsync(current,timeout.Token);}
                catch(Exception e) when(e is HttpRequestException or OperationCanceledException or InvalidOperationException){/* Local logout continues; server session expires at its signed deadline. */}
            }
            _activeSession=null;
            // On reteste le service pour ne pas réutiliser un ancien état de maintenance.
            _preflight = await StartupChecks.CheckServerAsync(
                _configuration, _serverEndpoint, CancellationToken.None);
            var selected = RequestSession(_configuration, _serverEndpoint, _preflight);
            if (selected is null)
            {
                previous.Close();
                ExitThread();
                return;
            }

            ShowMainWindow(selected.Value.Session, selected.Value.Project, _configuration);
            previous.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Échec de la reconnexion : " + ex.Message,
                "OGIPEN — connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            previous.Close();
            ExitThread();
        }
        finally
        {
            _changingUser = false;
        }
    }
}
