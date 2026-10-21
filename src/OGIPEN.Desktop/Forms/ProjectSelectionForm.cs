using OGIPEN.Desktop.Models;

namespace OGIPEN.Desktop.Forms;
public sealed class ProjectSelectionForm : Form
{
    private readonly ListBox _list;
    private readonly UserSession _session;
    public ProjectAccess? SelectedProject { get; private set; }

    public ProjectSelectionForm(UserSession session)
    {
        _session = session;
        Text = "OGIPEN — Choix du projet"; ClientSize = new Size(610, 420);
        StartPosition = FormStartPosition.CenterScreen; BackColor = Ui.Background;
        Controls.Add(Ui.Label("Sélection du projet", 30, 24, 500, 42, true));
        Controls.Add(Ui.Label("Seuls les projets autorisés par le serveur sont présentés.", 30, 72, 540));
        _list = new ListBox { Location = new Point(30, 120), Size = new Size(550, 210),
            Font = new Font("Segoe UI", 12), DisplayMember = nameof(ProjectAccess.Name) };
        foreach (var project in session.Projects) _list.Items.Add(project);
        if (_list.Items.Count > 0) _list.SelectedIndex = 0;
        Controls.Add(_list);
        var open = Ui.Button("Ouvrir", 30, 352, 260);
        open.Click += (_, _) =>
        {
            var selected = _list.SelectedItem as ProjectAccess;
            if (selected is null) return;
            if (!_session.Projects.Any(p => ReferenceEquals(p, selected))) return;
            SelectedProject = selected; DialogResult = DialogResult.OK; Close();
        };
        Controls.Add(open);
        var cancel = Ui.Button("Annuler", 310, 352, 270);
        cancel.BackColor = Ui.Panel;
        cancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };
        Controls.Add(cancel);
    }
}
