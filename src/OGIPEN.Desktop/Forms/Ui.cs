using System.Drawing;
namespace OGIPEN.Desktop.Forms;
internal static class Ui
{
    public static readonly Color Background = Color.FromArgb(19, 25, 35);
    public static readonly Color Panel = Color.FromArgb(29, 38, 51);
    public static readonly Color Accent = Color.FromArgb(56, 153, 232);
    public static readonly Color Text = Color.FromArgb(236, 242, 250);
    public static readonly Color Muted = Color.FromArgb(166, 179, 196);

    public static Label Label(string text, int x, int y, int width, int height = 28, bool title = false)
        => new()
        {
            Text = text, Location = new Point(x, y), Size = new Size(width, height),
            ForeColor = Text, BackColor = Color.Transparent,
            Font = new Font("Segoe UI", title ? 17 : 10,
                title ? FontStyle.Bold : FontStyle.Regular)
        };

    public static Button Button(string label, int x, int y, int width = 160)
    {
        var b = new Button
        {
            Text = label, Location = new Point(x, y), Size = new Size(width, 38),
            BackColor = Accent, ForeColor = Color.White, FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10, FontStyle.Bold), Cursor = Cursors.Hand
        };
        b.FlatAppearance.BorderSize = 0;
        return b;
    }

    public static TextBox TextBox(int x, int y, int width = 290, bool password = false)
        => new()
        {
            Location = new Point(x, y), Size = new Size(width, 30), BorderStyle = BorderStyle.FixedSingle,
            Font = new Font("Segoe UI", 11), UseSystemPasswordChar = password
        };
}
