using System.Data;
using Krypton.Toolkit;

namespace OGIPEN.Desktop.Forms;

/// <summary>
/// Première grille C# remplaçant le composant de liste DotNetBar SuperGrid.
/// Tri sur entêtes, redimensionnement, réorganisation, filtre et sélection.
/// L'arborescence/groupement SuperGrid et le chargement paginé restent à migrer.
/// Aucune modification des données métier ni connexion MySQL directe.
/// </summary>
public sealed class BusinessGridControl : UserControl
{
    private readonly DataTable _table;
    private readonly DataView _view;
    private readonly KryptonDataGridView _grid;
    private readonly KryptonTextBox _search;
    private readonly Label _count;

    public BusinessGridControl(string module, bool isPreview)
    {
        Dock = DockStyle.Fill;
        BackColor = Ui.Background;
        _table = BuildModel(module);

        if (isPreview)
            InsertIllustrativeRows(_table, module);

        _view = new DataView(_table) { Sort = _table.Columns[0].ColumnName + " ASC" };

        var header = new Panel
        {
            Dock = DockStyle.Top,
            Height = 84,
            BackColor = Ui.Panel,
            Padding = new Padding(16, 8, 16, 10)
        };
        var heading = new Label
        {
            Dock = DockStyle.Top,
            Height = 32,
            Text = isPreview
                ? "GRILLE DE DÉMONSTRATION — données fictives, lecture seule"
                : "GRILLE OGIPEN — connexion métier en attente",
            ForeColor = Ui.Muted,
            Font = new Font("Segoe UI", 11, FontStyle.Bold)
        };
        header.Controls.Add(heading);

        var tools = new FlowLayoutPanel
        {
            Dock = DockStyle.Bottom,
            Height = 34,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            BackColor = Ui.Panel
        };
        _search = new KryptonTextBox
        {
            Width = 285,
            Height = 29,
            Text = ""
        };
        _search.TextChanged += (_, _) => ApplyFilter();
        tools.Controls.Add(_search);

        var clear = new KryptonButton
        {
            Text = "Effacer le filtre",
            Size = new Size(140, 29)
        };
        clear.Click += (_, _) => _search.Clear();
        tools.Controls.Add(clear);

        var copy = new KryptonButton
        {
            Text = "Copier la sélection",
            Size = new Size(155, 29)
        };
        copy.Click += (_, _) =>
        {
            if (_grid?.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                var data = _grid.GetClipboardContent();
                if (data is not null) Clipboard.SetDataObject(data);
            }
        };
        tools.Controls.Add(copy);
        header.Controls.Add(tools);

        _grid = new KryptonDataGridView
        {
            Dock = DockStyle.Fill,
            DataSource = _view,
            ReadOnly = true,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToOrderColumns = true,
            AllowUserToResizeColumns = true,
            AllowUserToResizeRows = false,
            RowHeadersVisible = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = true,
            ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText,
            ColumnHeadersHeight = 40,
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
            BackgroundColor = Ui.Background,
            GridColor = Color.FromArgb(59, 70, 83),
            BorderStyle = BorderStyle.None
        };
        _grid.DefaultCellStyle.Font = new Font("Segoe UI", 10);
        _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(234, 239, 247);
        _grid.DataBindingComplete += (_, _) => UpdateCount();

        var footer = new Panel { Dock = DockStyle.Bottom, Height = 30, BackColor = Ui.Panel };
        _count = new Label
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(14, 6, 0, 0),
            ForeColor = Ui.Muted
        };
        footer.Controls.Add(_count);

        Controls.Add(_grid);
        Controls.Add(footer);
        Controls.Add(header);
        UpdateCount();
    }

    private void ApplyFilter()
    {
        var pattern = _search.Text.Trim();
        if (string.IsNullOrWhiteSpace(pattern))
        {
            _view.RowFilter = "";
        }
        else
        {
            // Les noms de colonnes sont exclusivement définis dans BuildModel().
            string escaped = pattern.Replace("'", "''", StringComparison.Ordinal)
                .Replace("[", "[[]", StringComparison.Ordinal)
                .Replace("%", "[%]", StringComparison.Ordinal)
                .Replace("*", "[*]", StringComparison.Ordinal);
            _view.RowFilter = string.Join(" OR ", _table.Columns
                .Cast<DataColumn>()
                .Where(c => c.DataType == typeof(string))
                .Select(c => $"[{c.ColumnName.Replace("]", "]]", StringComparison.Ordinal)}] LIKE '%{escaped}%'"));
        }
        UpdateCount();
    }

    private void UpdateCount()
    {
        if (_count is not null)
            _count.Text = $"{_view.Count} ligne(s)  |  Tri sur colonnes, filtre et sélection multiples";
    }

    private static DataTable BuildModel(string kind)
    {
        var t = new DataTable(kind) { CaseSensitive = false };
        if (kind == "cables")
        {
            t.Columns.Add("Repère", typeof(string));
            t.Columns.Add("Départ", typeof(string));
            t.Columns.Add("Aboutissant", typeof(string));
            t.Columns.Add("Type", typeof(string));
            t.Columns.Add("Longueur estimée (m)", typeof(decimal));
            t.Columns.Add("État", typeof(string));
        }
        else if (kind == "equipments")
        {
            t.Columns.Add("Repère", typeof(string));
            t.Columns.Add("Désignation", typeof(string));
            t.Columns.Add("Salle", typeof(string));
            t.Columns.Add("Lot", typeof(string));
            t.Columns.Add("État", typeof(string));
        }
        else
        {
            t.Columns.Add("Repère", typeof(string));
            t.Columns.Add("Tenant", typeof(string));
            t.Columns.Add("Aboutissant", typeof(string));
            t.Columns.Add("Type", typeof(string));
            t.Columns.Add("Longueur (mm)", typeof(int));
            t.Columns.Add("État", typeof(string));
        }
        return t;
    }

    private static void InsertIllustrativeRows(DataTable t, string kind)
    {
        // Données strictement fictives, uniquement pour tester le SuperGrid C#.
        if (kind == "cables")
        {
            t.Rows.Add("DEMO-C-001", "TGBT-A", "MOT-01", "U1000 R2V", 125.50m, "À tirer");
            t.Rows.Add("DEMO-C-002", "TGBT-A", "MOT-02", "U1000 R2V", 82.75m, "Posé");
            t.Rows.Add("DEMO-C-003", "TGBT-B", "CAP-01", "LIYCY", 26.00m, "Étude");
            t.Rows.Add("DEMO-C-004", "TGBT-B", "MOT-03", "U1000 R2V", 63.25m, "À tirer");
        }
        else if (kind == "equipments")
        {
            t.Rows.Add("DEMO-E-001", "Tableau TGBT A", "Local HT", "Électricité", "Installé");
            t.Rows.Add("DEMO-E-002", "Moteur convoyeur", "Atelier", "Électricité", "En attente");
            t.Rows.Add("DEMO-E-003", "Coffret commande", "Atelier", "Automatisme", "Installé");
        }
        else
        {
            t.Rows.Add("DEMO-T-001", "Salle A", "Salle B", "DALLE", 12500, "Disponible");
            t.Rows.Add("DEMO-T-002", "Salle B", "Salle C", "TUBE", 3850, "Occupé");
            t.Rows.Add("DEMO-T-003", "Salle C", "Salle D", "FOURREAU", 7260, "Disponible");
        }
    }
}
