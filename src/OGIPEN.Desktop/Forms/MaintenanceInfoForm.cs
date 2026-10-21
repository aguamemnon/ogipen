using System.Reflection;
using OGIPEN.Desktop.Infrastructure;

namespace OGIPEN.Desktop.Forms;
// Aucun compte de secours, clé cachée ou mot de passe dérivé du matériel.
// Les opérations sensibles attendent le futur portail de jetons signés.
public sealed class MaintenanceInfoForm : Form
{
    public MaintenanceInfoForm(ClientConfiguration config)
    {
        Text = "OGIPEN — Maintenance"; ClientSize = new Size(600, 300);
        StartPosition = FormStartPosition.CenterParent; BackColor = Ui.Background;
        Controls.Add(Ui.Label("Diagnostic et maintenance", 24, 24, 540, 42, true));
        Controls.Add(Ui.Label($"Version : {Application.ProductVersion}", 24, 95, 520));
        Controls.Add(Ui.Label($"Site : {config.SiteName}", 24, 132, 520));
        Controls.Add(Ui.Label($"Serveur : {(string.IsNullOrWhiteSpace(config.ApiBaseUrl) ? "Non configuré" : config.ApiBaseUrl)}", 24, 169, 540));
        Controls.Add(Ui.Label("Accès aux réglages réservé : jeton de maintenance signé à intégrer.", 24, 211, 560, 48));
        var close = Ui.Button("Fermer", 24, 255, 160);
        close.Click += (_, _) => Close(); Controls.Add(close);
    }
}
