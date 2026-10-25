using System.Data;
using OGIPEN.Core.Licensing;
using Krypton.Docking;
using Krypton.Navigator;
using Krypton.Ribbon;
using Krypton.Toolkit;
using Krypton.Workspace;
using OGIPEN.Desktop.Infrastructure;
using OGIPEN.Desktop.Models;

namespace OGIPEN.Desktop.Forms;

/// <summary>
/// Socle C# du FormMain VB.NET : ruban Office/Revit, documents à onglets et
/// panneaux dockables/détachables Visual Studio. Les vrais modules métier
/// restent désactivés tant qu'ils ne sont pas migrés et autorisés côté API.
/// </summary>
public sealed class MainMdiForm : KryptonForm
{
    private readonly UserSession _session;
    private readonly ProjectAccess _project;
    private readonly ProjectScope _scope;
    private readonly ClientConfiguration _config;
    private readonly KryptonRibbon _ribbon = new();
    private readonly KryptonManager _themeManager = new();

    // Déconnexion : le contexte WinForms réouvre le login sans arrêter l'application.
    public event EventHandler? LogoutRequested;
    private readonly KryptonPanel _shell = new() { Dock = DockStyle.Fill };
    private readonly KryptonDockableWorkspace _workspace = new() { Dock = DockStyle.Fill };
    private readonly KryptonDockingManager _docking = new();
    private readonly Dictionary<string, KryptonPage> _documents = new(StringComparer.Ordinal);
    private readonly Dictionary<string, KryptonPage> _toolPages = new(StringComparer.Ordinal);
    private readonly ToolStripStatusLabel _documentStatus = new("Aucun document");

    public MainMdiForm(UserSession session, ProjectAccess project, ClientConfiguration config)
    {
        _session = session;
        _project = project;
        _config = config;
        _scope = ProjectScope.Open(_session, _project);

        // Palette sombre de la suite Krypton, en cohérence avec Ui.Background/Ui.Panel
        // utilisés par LoginForm et SplashForm.
        _themeManager.GlobalPaletteMode = PaletteMode.Microsoft365BlackDarkMode;
        Text = $"O.G.I.P.E.N.  |  {project.Name}";
        FormBorderStyle = FormBorderStyle.Sizable;
        ControlBox = true;
        MinimizeBox = true;
        MaximizeBox = true;
        ShowInTaskbar = true;
        BackColor = Ui.Background;
        ForeColor = Ui.Text;
        KeyPreview = true;
        _workspace.WorkspaceCellAdding += (_, e) =>
        {
            // Le X des documents (pas seulement celui du formulaire principal).
            e.Cell.Button.CloseButtonDisplay = ButtonDisplay.ShowEnabled;
            e.Cell.Button.CloseButtonAction = CloseButtonAction.RemovePageAndDispose;
        };
        WindowState = FormWindowState.Maximized;
        MinimumSize = new Size(1100, 700);
        StartPosition = FormStartPosition.CenterScreen;

        BuildRibbon();
        BuildLayout();
        Shown += (_, _) => InitializeWorkspace();
        FormClosed += (_, _) => _docking.Dispose();
    }

    private void BuildRibbon()
    {
        _ribbon.Dock = DockStyle.Top;
        _ribbon.QATLocation = QATLocation.Hidden;
        // La fusion Krypton Ribbon/Form masque le X par défaut, même avec ControlBox=true.
        _ribbon.RibbonFileAppButton.FormCloseBoxVisible = true;
        _ribbon.RibbonFileAppButton.AppButtonShowRecentDocs = false;
        var logout = new KryptonContextMenuItem { Text = "Déconnexion" };
        logout.Click += (_, _) => LogoutRequested?.Invoke(this, EventArgs.Empty);
        var quit = new KryptonContextMenuItem { Text = "Quitter" };
        quit.Click += (_, _) => Close();
        _ribbon.RibbonFileAppButton.AppButtonMenuItems.Add(logout);
        _ribbon.RibbonFileAppButton.AppButtonMenuItems.Add(quit);

        var home = AddTab("Accueil",
            ("Projet", new[] { ("Tableau de bord", "dashboard"), ("Projets", "projects"), ("Actualiser", "refresh") }),
            ("Navigation", new[] { ("Câbles", "cables"), ("Équipements", "equipments"), ("Tronçons", "segments") }),
            ("Outils", new[] { ("Recherche", "search"), ("Historique", "history"), ("Maintenance", "maintenance") }));
        AddTab("Études",
            ("Câblage", new[] { ("Liste câbles", "cables"), ("Fils", "wires"), ("Borniers", "terminals") }),
            ("Implantation", new[] { ("Équipements", "equipments"), ("Salles", "rooms"), ("Départs", "departures") }),
            ("Contrôles", new[] { ("Contrôle études", "studies"), ("Besoins", "requirements"), ("Synoptique", "synoptic") }));
        AddTab("Cheminements",
            ("Parcours", new[] { ("Tronçons", "segments"), ("Parcours", "routes"), ("Associations", "associations") }),
            ("Calculs", new[] { ("Taux remplissage", "fillrates"), ("Besoin câbles", "requirements"), ("Disponibilité", "availability") }));
        AddTab("Chantier",
            ("Avancement", new[] { ("Suivi chantier", "progress"), ("Pose câbles", "installation"), ("Disponibilités", "availability") }),
            ("Logistique", new[] { ("Tourets", "reels"), ("Fournitures", "materials"), ("Livraisons", "deliveries") }));
        AddTab("Rapports",
            ("Éditions", new[] { ("Carnet câbles", "cable-report"), ("Parcours", "route-report"), ("Rapport projet", "project-report") }),
            ("Suivi", new[] { ("Tableaux de bord", "dashboard"), ("Historique", "history") }));
        AddTab("Administration",
            ("Projet", new[] { ("Utilisateurs", "users"), ("Droits", "permissions"), ("Maintenance", "maintenance") }),
            ("Application", new[] { ("Connexion", "connection"), ("Mise à jour", "updates"), ("Informations", "about"), ("Licence / activation", "offline-activation"), ("Fiche d’accès Windows", "windows-enrollment"), ("Comptes Ogipen", "accounts") }));
        AddTab("Affichage",
            ("Documents", new[] { ("Onglets", "tabs"), ("Côte à côte", "split-left-right"), ("Haut / bas", "split-top-bottom"), ("Fermer l'onglet", "close-document") }),
            ("Fenêtres", new[] { ("Explorateur", "explorer"), ("Propriétés", "properties"), ("Journal", "activity") }));

        _ribbon.SelectedTab = home;
    }

    private KryptonRibbonTab AddTab(
        string title, params (string Group, (string Title, string Action)[] Buttons)[] groups)
    {
        var tab = new KryptonRibbonTab { Text = title };
        foreach (var (groupTitle, buttons) in groups)
        {
            var group = new KryptonRibbonGroup { TextLine1 = groupTitle };
            // KryptonRibbonGroupTriple accepte strictement trois éléments.
            // Créer plusieurs conteneurs pour les rubans à quatre boutons ou plus.
            for (var start = 0; start < buttons.Length; start += 3)
            {
                var triple = new KryptonRibbonGroupTriple
                {
                    MinimumSize = GroupItemSize.Medium,
                    MaximumSize = GroupItemSize.Medium
                };
                foreach (var (buttonTitle, action) in buttons.Skip(start).Take(3))
                {
                    var button = new KryptonRibbonGroupButton { TextLine1 = buttonTitle };
                    string selectedAction = action;
                    button.Click += (_, _) => ExecuteAction(selectedAction);
                    triple.Items!.Add(button);
                }
                group.Items.Add(triple);
            }
            tab.Groups.Add(group);
        }
        _ribbon.RibbonTabs.Add(tab);
        return tab;
    }

    private void BuildLayout()
    {
        var status = new StatusStrip
        {
            Dock = DockStyle.Bottom,
            BackColor = Ui.Panel,
            ForeColor = Ui.Text,
            SizingGrip = false
        };
        status.Items.Add(new ToolStripStatusLabel("OGIPEN C#"));
        if(_session.SystemRole is "admin" or "ossi"){var administration=new ToolStripButton("Administration serveur");administration.Click+=(_,_)=>{using var form=new ServerAdministrationForm(_session,_config);form.ShowDialog(this);if(form.ReauthenticationRequired)LogoutRequested?.Invoke(this,EventArgs.Empty);};status.Items.Add(administration);}
        status.Items.Add(new ToolStripStatusLabel($"Utilisateur : {_session.DisplayName} · {_session.SystemRole}"));
        status.Items.Add(new ToolStripStatusLabel($"Projet : {_project.Name}"));
        status.Items.Add(new ToolStripStatusLabel($"Poste : {_project.Role}"));
        status.Items.Add(_documentStatus);
        status.Items.Add(new ToolStripStatusLabel(_session.IsPreview
            ? "APERÇU — aucune donnée réelle"
            : $"Entreprise {_session.CompanyId} · Licence {_session.LicenceId} · Session jusqu’à {_session.ExpiresUtc.ToLocalTime():HH:mm} — modules métier non migrés"));

        _shell.BackColor = Ui.Background;
        _workspace.BackColor = Ui.Background;
        _shell.Controls.Add(_workspace);
        var licenseNotice = new LicenseNoticePanel();
        DateOnly? expiry=_session.IsPreview || _session.LicenseExpiresUtc==default?null:DateOnly.FromDateTime(_session.LicenseExpiresUtc.UtcDateTime);
        licenseNotice.Display(LicenseAlertEvaluator.Evaluate(
            expiry,!_session.IsPreview && expiry is not null,DateOnly.FromDateTime(DateTime.UtcNow)),_session.IsPreview);
        _shell.Controls.Add(licenseNotice);
        Controls.Add(_shell);
        Controls.Add(_ribbon);
        Controls.Add(status);
    }

    private void InitializeWorkspace()
    {
        // Suite Krypton : espace documentaire + panneaux détachables.
        var managed = _docking.ManageWorkspace(_workspace);
        _docking.ManageControl(_shell, managed);
        _docking.ManageFloating(this);

        _docking.AddToWorkspace("Workspace", new[] { CreateDocument("Tableau de bord", "dashboard") });
        AddToolPane("explorer", DockingEdge.Left, "Explorateur de projet", CreateExplorer());
        AddToolPane("properties", DockingEdge.Right, "Propriétés", CreateProperties());
        AddToolPane("activity", DockingEdge.Bottom, "Journal / suivi", CreateActivity());
        _documentStatus.Text = "Tableau de bord";
    }

    private KryptonPage MakePage(string title, Control control)
    {
        var page = new KryptonPage
        {
            Text = title,
            TextTitle = title,
            TextDescription = title
        };
        control.Dock = DockStyle.Fill;
        page.Controls.Add(control);
        return page;
    }

    private KryptonPage CreateDocument(string title, string kind)
    {
        Control content = kind switch
        {
            "dashboard" => CreateDashboard(),
            "cables" or "equipments" or "segments" => new BusinessGridControl(
                kind, _session.IsPreview),
            _ => CreatePlaceholder(title)
        };
        var page = MakePage(title, content);
        page.ClearFlags(KryptonPageFlags.DockingAllowAutoHidden | KryptonPageFlags.DockingAllowDocked);
        _documents[title] = page;
        return page;
    }

    private void OpenDocument(string title, string kind)
    {
        if (_documents.TryGetValue(title, out var existing))
        {
            var cell = _workspace.CellForPage(existing);
            if (cell is not null)
            {
                cell.SelectedPage = existing;
                _workspace.ActiveCell = cell;
                _documentStatus.Text = title;
                return;
            }
            _documents.Remove(title);
        }

        var page = CreateDocument(title, kind);
        var active = _workspace.ActiveCell;
        if (active is null)
        {
            active = new KryptonWorkspaceCell();
            _workspace.Root!.Children!.Add(active);
        }
        active.Pages.Add(page);
        active.SelectedPage = page;
        _workspace.ActiveCell = active;
        _documentStatus.Text = title;
    }

    private void AddToolPane(string id, DockingEdge edge, string title, Control content)
    {
        var page = MakePage(title, content);
        _toolPages[id] = page;
        _docking.AddDockspace("Control", edge, new[] { page });
    }

    private void ShowToolPane(string id, DockingEdge edge, string title, Func<Control> content)
    {
        if (_toolPages.TryGetValue(id, out var existing))
        {
            // Le panneau peut avoir été fermé/détaché : le nouveau panneau
            // est créé si l'ancienne page n'est plus enregistrée.
            if (!_docking.PagesDocked.Contains(existing) &&
                !_docking.PagesFloating.Contains(existing) &&
                !_docking.PagesAutoHidden.Contains(existing))
            {
                _toolPages.Remove(id);
            }
            else
            {
                existing.Select();
                return;
            }
        }
        AddToolPane(id, edge, title, content());
    }

    private void ExecuteAction(string action)
    {
        // Le contrôle local masque/refuse les commandes interdites, mais le
        // serveur doit refaire cette vérification lors de chaque opération.
        if (!_session.IsPreview)
        {
            string? required = action switch
            {
                "cables" => ProjectPermissions.CableRead,
                "equipments" => ProjectPermissions.EquipmentRead,
                "segments" => ProjectPermissions.SegmentRead,
                "progress" => ProjectPermissions.ProgressRead,
                "users" => ProjectPermissions.UsersManage,
                "permissions" => ProjectPermissions.RightsManage,
                _ => null
            };
            if (required is not null && !_scope.Can(required))
            {
                MessageBox.Show(this,
                    "Ce poste n'a pas la permission « " + required + " » sur ce projet.",
                    "OGIPEN — accès refusé", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
        }

        switch (action)
        {
            case "accounts":
                if(_session.IsPreview || _session.SystemRole is not ("admin" or "ossi")){MessageBox.Show(this,"Les comptes internes sont réservés à l’administrateur et à l’OSSI.","OGIPEN — Comptes internes",MessageBoxButtons.OK,MessageBoxIcon.Information);return;}
                using(var accounts=new AccountAdministrationForm(_session,_config)){
                    accounts.ShowDialog(this);if(accounts.ReauthenticationRequired)LogoutRequested?.Invoke(this,EventArgs.Empty);
                }
                return;
            case "windows-enrollment":
                using(var file=new SaveFileDialog{Title="Fiche d’accès Windows",Filter="Fiche (*.txt)|*.txt",FileName="ogipen-enrolement.txt"}){
                    if(file.ShowDialog(this)==DialogResult.OK){try{OfflineLicenseService.ExportEnrollmentInfo(file.FileName);}catch(Exception ex){MessageBox.Show(this,ex.Message,"Fiche d’accès",MessageBoxButtons.OK,MessageBoxIcon.Warning);}}
                }
                return;
            case "offline-activation":
                using (var dlg = new OfflineActivationForm(_config)){
                    dlg.ShowDialog(this);
                    if(dlg.LicenseChanged){
                        MessageBox.Show(this,"Licence du poste mise à jour. Reconnectez-vous pour appliquer ses droits à la session.","OGIPEN — Licence mise à jour",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        LogoutRequested?.Invoke(this,EventArgs.Empty);
                    }
                }
                return;
            case "close-document":
                if (_workspace.ActivePage is KryptonPage selected)
                    _workspace.ClosePage(selected);
                return;
            case "tabs":
                _workspace.ApplySingleCell();
                return;
            case "split-left-right":
                _workspace.ApplyGridPages(false, Orientation.Horizontal, 1);
                return;
            case "split-top-bottom":
                _workspace.ApplyGridPages(false, Orientation.Vertical, 1);
                return;
            case "explorer":
                ShowToolPane("explorer", DockingEdge.Left, "Explorateur de projet", CreateExplorer);
                return;
            case "properties":
                ShowToolPane("properties", DockingEdge.Right, "Propriétés", CreateProperties);
                return;
            case "activity":
                ShowToolPane("activity", DockingEdge.Bottom, "Journal / suivi", CreateActivity);
                return;
            case "maintenance":
            case "connection":
            case "updates":
            case "about":
                using (var info = new MaintenanceInfoForm(_config)) info.ShowDialog(this);
                return;
            case "refresh":
                _documentStatus.Text = "Modules métier non connectés à l'API";
                return;
            default:
                string title = action switch
                {
                    "dashboard" => "Tableau de bord",
                    "cables" => "Liste des câbles",
                    "equipments" => "Liste des équipements",
                    "segments" => "Liste des tronçons",
                    "routes" => "Parcours",
                    "wires" => "Fils",
                    "terminals" => "Borniers",
                    "rooms" => "Salles",
                    "reels" => "Tourets",
                    "progress" => "Suivi chantier",
                    "users" => "Utilisateurs",
                    "permissions" => "Droits d'accès",
                    "history" => "Historique",
                    "projects" => "Projets",
                    "search" => "Recherche",
                    "requirements" => "Besoins câbles",
                    "synoptic" => "Synoptique",
                    _ => action.Replace('-', ' ')
                };
                OpenDocument(title, action);
                return;
        }
    }

    private Control CreateDashboard()
    {
        var panel = NewPanel();
        var header = new Label
        {
            Dock = DockStyle.Top,
            Height = 94,
            Text = $"  { _project.Name }\r\n  Tableau de bord du projet",
            Font = new Font("Segoe UI", 20, FontStyle.Bold),
            ForeColor = Ui.Text,
            Padding = new Padding(18, 12, 0, 0)
        };
        panel.Controls.Add(header);
        var message = new Label
        {
            Dock = DockStyle.Top,
            Height = 104,
            Padding = new Padding(22, 12, 20, 0),
            ForeColor = Ui.Muted,
            Font = new Font("Segoe UI", 11),
            Text = _session.IsPreview
                ? "Aperçu local : aucune donnée réelle. Ouvre « Liste des câbles » pour tester la grille, ou « Affichage » pour diviser l'espace de travail."
                : "Interface de migration C#. Les modules métier et leurs contrôles d'accès seront connectés à l'API projet."
        };
        panel.Controls.Add(message);
        panel.Controls.SetChildIndex(header, 0);
        return panel;
    }

    private Control CreateExplorer()
    {
        var tree = new TreeView
        {
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 10),
            BackColor = Ui.Panel,
            ForeColor = Ui.Text,
            BorderStyle = BorderStyle.None,
            HideSelection = false
        };
        var root = tree.Nodes.Add(_project.Name);
        foreach (var (title, action) in new[]
        {
            ("Câbles", "cables"), ("Équipements", "equipments"),
            ("Tronçons", "segments"), ("Parcours", "routes"),
            ("Tourets", "reels"), ("Rapports", "project-report")
        })
        {
            var node = root.Nodes.Add(title);
            node.Tag = action;
        }
        root.Expand();
        tree.NodeMouseDoubleClick += (_, e) =>
        {
            if (e.Node?.Tag is string act) ExecuteAction(act);
        };
        return tree;
    }

    private Control CreateProperties()
    {
        var property = new PropertyGrid
        {
            Dock = DockStyle.Fill,
            SelectedObject = new ProjectSummary
            {
                Projet = _project.Name,
                Poste = _project.Role,
                Utilisateur = _session.DisplayName,
                Mode = _session.IsPreview ? "Aperçu uniquement" : "Connecté"
            },
            ToolbarVisible = false,
            HelpVisible = true
        };
        property.PropertySort = PropertySort.Categorized;
        property.Enabled = false;
        return property;
    }

    private Control CreateActivity()
    {
        var log = new ListView
        {
            Dock = DockStyle.Fill,
            View = View.Details,
            FullRowSelect = true,
            BackColor = Ui.Panel,
            ForeColor = Ui.Text,
            BorderStyle = BorderStyle.None
        };
        log.Columns.Add("Heure", 100);
        log.Columns.Add("Événement", 560);
        var item = new ListViewItem(DateTime.Now.ToString("HH:mm:ss"));
        item.SubItems.Add("Shell C# initialisé — module métier non connecté.");
        log.Items.Add(item);
        return log;
    }

    private Control CreatePlaceholder(string title)
    {
        var panel = NewPanel();
        panel.Controls.Add(new Label
        {
            Dock = DockStyle.Fill,
            ForeColor = Ui.Muted,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 13),
            Text = title + "\r\n\r\nEspace de travail initialisé.\r\nModule VB.NET à migrer sans perte fonctionnelle."
        });
        return panel;
    }

    private static Panel NewPanel() => new()
    {
        Dock = DockStyle.Fill,
        BackColor = Ui.Background
    };

    private sealed class ProjectSummary
    {
        public string Projet { get; init; } = "";
        public string Utilisateur { get; init; } = "";
        public string Poste { get; init; } = "";
        public string Mode { get; init; } = "";
    }
}
