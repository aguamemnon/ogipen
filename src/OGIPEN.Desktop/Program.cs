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
            await Task.Yield();

            _splash.Report("Test de présence du serveur...", 45);
            ServerPreflightResult result =
                await StartupChecks.CheckServerAsync(config, endpoint, CancellationToken.None);

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

            using var login = new LoginForm(config, endpoint, result);
            if (login.ShowDialog() != DialogResult.OK || login.Session is null)
            {
                _splash.Close();
                return;
            }

            UserSession session = login.Session;
            ProjectAccess? project;
            using (var selector = new ProjectSelectionForm(session))
            {
                if (selector.ShowDialog() != DialogResult.OK)
                {
                    _splash.Close();
                    return;
                }
                project = selector.SelectedProject;
            }

            if (project is null)
            {
                _splash.Close();
                return;
            }

            var mdi = new MainMdiForm(session, project, config);
            MainForm = mdi; // retirer le splash comme fenêtre principale AVANT de le fermer
            mdi.Show();
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
}
