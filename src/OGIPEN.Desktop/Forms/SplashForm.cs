using System.Reflection;
namespace OGIPEN.Desktop.Forms;

public sealed class SplashForm : Form
{
    private readonly ProgressBar _progress = new() { Dock = DockStyle.Bottom, Height = 10, Minimum = 0, Maximum = 100 };
    private readonly Label _status;
    public SplashForm()
    {
        Text = "OGIPEN — Initialisation";
        Width = 940; Height = 520; StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.None; BackColor = Ui.Background;
        var root = new Panel { Dock = DockStyle.Fill, BackColor = Ui.Background };
        var image = Path.Combine(AppContext.BaseDirectory, "Assets", "SplashLegacy.png");
        if (File.Exists(image))
        {
            using var source = Image.FromFile(image);
            var banner = new PictureBox { Dock = DockStyle.Fill,
                Image = (Image)source.Clone(), SizeMode = PictureBoxSizeMode.Zoom, BackColor = Ui.Background };
            root.Controls.Add(banner);
        }
        var foot = new Panel { Dock = DockStyle.Bottom, Height = 91, BackColor = Ui.Panel };
        foot.Controls.Add(Ui.Label("OGIPEN   |   Gestion de projets électriques", 22, 10, 800));
        _status = Ui.Label("Démarrage...", 22, 44, 780);
        _status.ForeColor = Ui.Muted;
        foot.Controls.Add(_status);
        root.Controls.Add(foot);
        Controls.Add(root); Controls.Add(_progress);
    }
    public void Report(string status, int percentage)
    {
        _status.Text = status;
        _progress.Value = Math.Clamp(percentage, 0, 100);
        Refresh();
    }
}
