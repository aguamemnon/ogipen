using OGIPEN.Desktop.Infrastructure;
using OGIPEN.Desktop.Models;

namespace OGIPEN.Desktop.Forms;
public sealed class MainMdiForm : Form
{
    private readonly UserSession _session;
    private readonly ProjectAccess _project;

    public MainMdiForm(UserSession session, ProjectAccess project, ClientConfiguration config)
    {
        _session = session; _project = project;
        if (!_session.Projects.Any(p => ReferenceEquals(p, project)))
            throw new InvalidOperationException("Projet hors de la session.");
        Text = $"OGIPEN — {project.Name}";
        WindowState = FormWindowState.Maximized; MinimumSize = new Size(980, 660);
        IsMdiContainer = true; BackColor = Ui.Background;
        var menu = new MenuStrip { BackColor = Ui.Panel, ForeColor = Ui.Text,
            Font = new Font("Segoe UI", 10), RenderMode = ToolStripRenderMode.System };
        var projectMenu = new ToolStripMenuItem("Projet");
        projectMenu.DropDownItems.Add("Accueil", null, (_, _) => ShowChild("Tableau de bord", false));
        projectMenu.DropDownItems.Add("Quitter", null, (_, _) => Close());
        menu.Items.Add(projectMenu);
        foreach (var category in new[] { "Câbles", "Équipements", "Tronçons", "Parcours", "Tourets", "Rapports" })
        {
            var name = category;
            menu.Items.Add(new ToolStripMenuItem(name, null, (_, _) => ShowChild(name, true)));
        }
        var tools = new ToolStripMenuItem("Outils");
        tools.DropDownItems.Add("Maintenance (diagnostic)", null, (_, _) =>
        {
            using var info = new MaintenanceInfoForm(config);
            info.ShowDialog(this);
        });
        menu.Items.Add(tools);
        var windows = new ToolStripMenuItem("Fenêtres");
        windows.DropDownItems.Add("Cascade", null, (_, _) => LayoutMdi(MdiLayout.Cascade));
        windows.DropDownItems.Add("Mosaïque", null, (_, _) => LayoutMdi(MdiLayout.TileVertical));
        menu.Items.Add(windows);
        MainMenuStrip = menu;
        Controls.Add(menu);
        var status = new StatusStrip { BackColor = Ui.Panel, ForeColor = Ui.Text,
            SizingGrip = false };
        status.Items.Add(new ToolStripStatusLabel($"Utilisateur : {session.DisplayName}"));
        status.Items.Add(new ToolStripStatusLabel($"Projet : {project.Name}"));
        status.Items.Add(new ToolStripStatusLabel($"Poste : {project.Role}"));
        status.Items.Add(new ToolStripStatusLabel(session.IsPreview ?
            "APERÇU LOCAL — aucune connexion aux projets réels" : "API sécurisée — session en mémoire"));
        Controls.Add(status);
        Shown += (_, _) => ShowChild("Tableau de bord", false);
    }

    private void ShowChild(string module, bool notImplemented)
    {
        var child = new Form { Text = module, MdiParent = this, Width = 800, Height = 540,
            BackColor = Ui.Background, ForeColor = Ui.Text };
        child.Controls.Add(Ui.Label(module, 36, 35, 650, 50, true));
        var message = _session.IsPreview
            ? "Mode aperçu : aucun accès aux données ou à MySQL."
            : notImplemented
                ? "Module métier non migré : fonctionnalité disponible dans l'ancien client VB.NET."
                : "Accueil du projet sélectionné.";
        child.Controls.Add(Ui.Label(message, 36, 106, 700, 90));
        child.Show();
    }
}
