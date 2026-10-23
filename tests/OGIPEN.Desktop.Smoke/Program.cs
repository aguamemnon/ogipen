using Krypton.Ribbon;
using OGIPEN.Core.Security;
using OGIPEN.Desktop.Forms;
using OGIPEN.Desktop.Infrastructure;
using OGIPEN.Desktop.Models;

namespace OGIPEN.Desktop.Smoke;

internal static class Program
{
    // Vérifie que tous les groupes du ruban peuvent être construits. Le crash
    // « Collection can only contain 3 entries » provenait du 4e bouton
    // de l'onglet Affichage. Ce contrôle utilise le vrai MainMdiForm.
    [STAThread]
    private static int Main()
    {
        try
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var session = UserSession.Preview();
            using var main = new MainMdiForm(session, session.Projects[0],
                new ClientConfiguration());

            var ribbon = main.Controls.OfType<KryptonRibbon>().Single();
            if (ribbon.RibbonTabs.Count != 7)
                throw new Exception("Nombre inattendu d'onglets dans le ruban.");
            if (!ribbon.RibbonFileAppButton.FormCloseBoxVisible)
                throw new Exception("La croix de fermeture du MainForm est masquée.");
            if (!main.ControlBox || !main.CloseBox)
                throw new Exception("Les boutons Windows de fermeture sont désactivés.");
            var previewScope = ProjectScope.Open(session, session.Projects[0]);
            if (previewScope.Can(ProjectPermissions.CableRead))
                throw new Exception("L'aperçu local ne doit accorder aucun droit métier.");
            var authorized = UserSession.FromReply(new LoginReply
            {
                AccessToken = "jeton-de-test",
                DisplayName = "Technicien de test",
                Projects = new List<ProjectAccess>
                {
                    new()
                    {
                        Id = "projet-a",
                        Name = "Projet A",
                        Role = "Technicien",
                        Permissions = new List<string> { ProjectPermissions.CableRead }
                    }
                }
            });
            var scope = ProjectScope.Open(authorized, authorized.Projects[0]);
            if (!scope.Can(ProjectPermissions.CableRead) ||
                 scope.Can(ProjectPermissions.ProgressWrite))
                throw new Exception("Les permissions ne sont pas isolées par projet.");
            try
            {
                ProjectScope.Open(authorized, new ProjectAccess
                {
                    Id = "projet-b",
                    Name = "Projet non attribué"
                });
                throw new Exception("Un projet extérieur à la session a été accepté.");
            }
            catch (UnauthorizedAccessException)
            {
                // Refus attendu.
            }

            var requestFile = Path.Combine(Path.GetTempPath(),
                "ogipen-offline-smoke-" + Guid.NewGuid().ToString("N") + ".ogreq");
            try
            {
                OfflineLicenseService.ExportRequest(requestFile, 42);
                var contents = File.ReadAllText(requestFile);
                if (!OfflineLicenseActivation.TryParseRequest(contents,
                    out int software, out int major, out _, out var fingerprint) ||
                    software != 42 || major != 1 || fingerprint.Length != 64)
                {
                    throw new Exception("La demande hors ligne CNG n'a pas pu être validée.");
                }
            }
            finally
            {
                if (File.Exists(requestFile)) File.Delete(requestFile);
            }
            Console.WriteLine("OK — Demande d'activation générée avec une clé Windows CNG.");
            Console.WriteLine("OK — MainForm, ruban Krypton et 7 onglets construits.");
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("ÉCHEC du contrôle UI : " + ex);
            return 1;
        }
    }
}
