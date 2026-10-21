using Krypton.Ribbon;
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
