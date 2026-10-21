using OGIPEN.Core.Licensing;

namespace OGIPEN.Desktop.Forms;

/// <summary>
/// Bandeau de licence commun au login et au MainForm. Il n'accorde jamais
/// lui-même de droit; une licence signée doit être validée séparément.
/// </summary>
public sealed class LicenseNoticePanel : Panel
{
    private readonly Label _heading = new();
    private readonly Label _details = new();

    public LicenseNoticePanel()
    {
        Dock = DockStyle.Top;
        Height = 58;
        Padding = new Padding(12, 5, 12, 5);

        _heading.Dock = DockStyle.Top;
        _heading.Height = 23;
        _heading.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        _heading.AutoEllipsis = true;

        _details.Dock = DockStyle.Fill;
        _details.Font = new Font("Segoe UI", 9);
        _details.AutoEllipsis = true;

        Controls.Add(_details);
        Controls.Add(_heading);
    }

    public void Display(LicenseAlert alert, bool preview)
    {
        ArgumentNullException.ThrowIfNull(alert);

        // Prévisualisation autorisée, mais pas d'accès aux données réelles.
        var suffix = preview ? " — Aperçu sans accès métier" : "";
        _heading.Text = alert.Title + suffix;
        _details.Text = alert.Description;
        BackColor = alert.Severity switch
        {
            LicenseAlertSeverity.Critical => Color.FromArgb(95, 30, 40),
            LicenseAlertSeverity.Warning => Color.FromArgb(101, 74, 29),
            _ => Color.FromArgb(25, 75, 54)
        };
        _heading.ForeColor = Color.White;
        _details.ForeColor = Color.FromArgb(240, 239, 239);
        Visible = alert.Severity != LicenseAlertSeverity.None || preview;
    }
}
