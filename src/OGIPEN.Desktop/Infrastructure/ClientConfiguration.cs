using System.Text.Json;

namespace OGIPEN.Desktop.Infrastructure;

public sealed class ClientConfiguration
{
    public string ApiBaseUrl { get; set; } = "";
    public string SiteName { get; set; } = "Site non configuré";

    // Adresse de l'ancien serveur lue pour un diagnostic TCP, jamais pour
    // utiliser le compte SQL root ou accéder aux bases de projets.
    public string LegacyDatabaseServer { get; set; } = "";
    public int LegacyDatabasePort { get; set; } = 3306;

    public static string Location => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "OGIPEN", "clientsettings.json");

    public static ClientConfiguration Load()
    {
        ClientConfiguration result;
        if (File.Exists(Location))
        {
            result = JsonSerializer.Deserialize<ClientConfiguration>(
                File.ReadAllText(Location),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new ClientConfiguration();
        }
        else
        {
            result = new ClientConfiguration();
        }

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
        return result;
    }

    public Uri? SecureApiEndpoint()
    {
        if (string.IsNullOrWhiteSpace(ApiBaseUrl)) return null;
        if (!Uri.TryCreate(ApiBaseUrl.TrimEnd('/') + "/", UriKind.Absolute, out var uri) ||
            uri.Scheme != Uri.UriSchemeHttps || !string.IsNullOrEmpty(uri.UserInfo))
            throw new InvalidOperationException("L'adresse de l'API doit être une URL HTTPS valide.");
        return uri;
    }
}
