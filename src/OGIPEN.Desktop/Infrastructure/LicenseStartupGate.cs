namespace OGIPEN.Desktop.Infrastructure;

public static class LicenseStartupGate
{
 // Recheck the actual signed licence after the dialog, never trust a dialog result alone.
 public static bool Ensure(Func<bool> validLicence,Func<bool> showActivation)
    =>validLicence() || (showActivation() && validLicence());
}
