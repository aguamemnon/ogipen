using System.Text.Json;
using OGIPEN.Core.Security;

namespace OGIPEN.Desktop.Infrastructure;

public sealed class ClientConfiguration
{
    public string ApiBaseUrl { get; set; } = "";
    public string SiteName { get; set; } = "Site non configuré";
    public List<ServerProfile> ServerProfiles { get; set; } = new();
    public string SelectedProfileId { get; set; } = "";

    // Identifiant du logiciel dans le catalogue SLM Plus, par exemple l'ID
    // numérique du post Ogipen distinct de Progelec. Aucune clé privée ici.
    public int OfflineSoftwareId { get; set; } = 405;

    // Adresse de l'ancien serveur lue pour un diagnostic TCP, jamais pour
    // utiliser le compte SQL root ou accéder aux bases de projets.
    public string LegacyDatabaseServer { get; set; } = "";
    public int LegacyDatabasePort { get; set; } = 3306;

    public static string Location => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "OGIPEN", "clientsettings.json");

    public static ClientConfiguration Load()=>LoadFrom(Location);
    public static ClientConfiguration LoadFrom(string location)
    {
        ClientConfiguration result;
        if (File.Exists(location))
        {
            result = JsonSerializer.Deserialize<ClientConfiguration>(
                File.ReadAllText(location),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new ClientConfiguration();
        }
        else
        {
            result = new ClientConfiguration();
        }

        if (result.OfflineSoftwareId < 0)
            throw new InvalidOperationException("Identifiant logiciel hors ligne invalide.");

        if (result.LegacyDatabasePort < 1 || result.LegacyDatabasePort > 65535)
            throw new InvalidOperationException("Le port de l'ancien serveur est invalide.");

        // L'ancien client utilisait un config.ini [SECTION=Serveur] address=...
        // On n'importe volontairement PAS son mot de passe MySQL.
        var legacyIni = Path.Combine(AppContext.BaseDirectory, "config.ini");
        if (string.IsNullOrWhiteSpace(result.LegacyDatabaseServer) && File.Exists(legacyIni))
        {
            bool inServer = false;
            foreach (string line in File.ReadLines(legacyIni))
            {
                string entry = line.Trim();
                if (entry.StartsWith("[", StringComparison.Ordinal))
                {
                    inServer = string.Equals(entry, "[SECTION=Serveur]",
                        StringComparison.OrdinalIgnoreCase);
                    continue;
                }
                if (!inServer || entry.StartsWith(";", StringComparison.Ordinal) ||
                    entry.StartsWith("#", StringComparison.Ordinal))
                    continue;

                int separator = entry.IndexOf('=');
                if (separator > 0 &&
                    string.Equals(entry[..separator].Trim(), "address",
                        StringComparison.OrdinalIgnoreCase))
                {
                    result.LegacyDatabaseServer = entry[(separator + 1)..].Trim();
                    break;
                }
            }
        }
        if(result.ServerProfiles is null)throw new InvalidOperationException("Profils serveur invalides.");
        if(result.ServerProfiles.Count==0 && !string.IsNullOrWhiteSpace(result.ApiBaseUrl)){
            result.ServerProfiles.Add(new ServerProfile {Id="legacy",Name=result.SiteName,ApiBaseUrl=LicensedSessionClient.RequireSecureEndpoint(result.ApiBaseUrl).AbsoluteUri});
            result.SelectedProfileId="legacy";
        }
        return result;
    }

    public Uri? SecureApiEndpoint()
    {
        var selected=ServerProfiles.FirstOrDefault(p=>p.Id==SelectedProfileId);
        if(ServerProfiles.Count>0)return selected is null?null:LicensedSessionClient.RequireSecureEndpoint(selected.ApiBaseUrl);
        return string.IsNullOrWhiteSpace(ApiBaseUrl)?null:LicensedSessionClient.RequireSecureEndpoint(ApiBaseUrl);
    }

    public void SelectProfile(string id)
    {
        var p=ServerProfiles.SingleOrDefault(p=>p.Id==id)??throw new InvalidOperationException("Profil serveur introuvable.");
        var endpoint=LicensedSessionClient.RequireSecureEndpoint(p.ApiBaseUrl);
        SelectedProfileId=p.Id;ApiBaseUrl=endpoint.AbsoluteUri;SiteName=p.Name;
    }
    public void Save()=>SaveTo(Location);
    public void SaveTo(string location)
    {
        if(ServerProfiles.Count>50 || ServerProfiles.Select(p=>p.Id).Distinct(StringComparer.Ordinal).Count()!=ServerProfiles.Count)
            throw new InvalidOperationException("Profils serveur invalides ou trop nombreux.");
        foreach(var p in ServerProfiles){
            if(string.IsNullOrWhiteSpace(p.Id) || p.Id.Length>64 || string.IsNullOrWhiteSpace(p.Name) || p.Name.Length>80)
                throw new InvalidOperationException("Code ou nom de profil invalide.");
            p.ApiBaseUrl=LicensedSessionClient.RequireSecureEndpoint(p.ApiBaseUrl).AbsoluteUri;
        }
        if(ServerProfiles.Count>0 && !string.IsNullOrEmpty(SelectedProfileId))SelectProfile(SelectedProfileId);
        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(location))!);
        var temporary=location+"."+Guid.NewGuid().ToString("N")+".tmp";
        try{File.WriteAllText(temporary,JsonSerializer.Serialize(this,new JsonSerializerOptions{WriteIndented=true}),new System.Text.UTF8Encoding(false));File.Move(temporary,location,true);}
        finally{if(File.Exists(temporary))File.Delete(temporary);}
    }
}
public sealed class ServerProfile
{
    public string Id { get; set; }=Guid.NewGuid().ToString("N");
    public string Name { get; set; }="";
    public string ApiBaseUrl { get; set; }="";
    public override string ToString()=>Name;
}
