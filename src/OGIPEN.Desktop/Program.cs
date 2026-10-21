using OGIPEN.Desktop.Forms;
using OGIPEN.Desktop.Infrastructure;
using OGIPEN.Desktop.Models;

namespace OGIPEN.Desktop;

internal static class Program
{
    [STAThread]
    private static async Task Main()
    {
        ApplicationConfiguration.Initialize();
        try
        {
            ClientConfiguration config = ClientConfiguration.Load();
            using var splash = new SplashForm();
            splash.Show();
            splash.Report("Initialisation des paramètres...", 15);
            await Task.Delay(100);
            splash.Report("Vérification de la configuration...", 55);
            Uri? endpoint = config.SecureApiEndpoint();
            splash.Report(endpoint is null ? "Serveur non configuré — mode aperçu disponible" : "Client prêt pour l'authentification sécurisée", 100);
            await Task.Delay(200);
            splash.Close();

            using var login = new LoginForm(config, endpoint);
            if (login.ShowDialog() != DialogResult.OK || login.Session is null)
                return;
            UserSession session = login.Session;
            ProjectAccess? selected;
            using (var choose = new ProjectSelectionForm(session))
            {
                if (choose.ShowDialog() != DialogResult.OK) return;
                selected = choose.SelectedProject;
            }
            if (selected is null) return;
            Application.Run(new MainMdiForm(session, selected, config));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "OGIPEN — Démarrage impossible",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
