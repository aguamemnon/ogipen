using Krypton.Toolkit;
namespace OGIPEN.Desktop.Forms;

/// <summary>Shared dialog chrome and controls, matching the application's Krypton dark palette.</summary>
public class AppDialog:KryptonForm
{
 private readonly KryptonManager manager=new();
 protected AppDialog(){manager.GlobalPaletteMode=PaletteMode.Microsoft365BlackDarkMode;BackColor=Ui.Background;ForeColor=Ui.Text;Font=new Font("Segoe UI",10);StartPosition=FormStartPosition.CenterParent;}
 protected override void Dispose(bool disposing){if(disposing)manager.Dispose();base.Dispose(disposing);}
}
