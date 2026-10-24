using System.Security.Principal;

namespace OGIPEN.Desktop.Infrastructure;

public sealed record WindowsSessionIdentity(string IdentityId,string DisplayName)
{
    public static WindowsSessionIdentity Current()
    {
        if(!OperatingSystem.IsWindows())throw new PlatformNotSupportedException("Une session Windows est requise.");
        using var identity=WindowsIdentity.GetCurrent();
        var sid=identity.User?.Value;
        if(!identity.IsAuthenticated || string.IsNullOrEmpty(sid))throw new InvalidOperationException("Session Windows non authentifiée.");
        var id="win-sid:"+sid;
        if(id.Length>80)throw new InvalidOperationException("Identifiant de session Windows trop long.");
        return new(id,identity.Name);
    }
}
