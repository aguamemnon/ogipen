using System.Text.Json;

namespace OGIPEN.Desktop.Infrastructure;

public sealed class ClientConfiguration
{
    public string ApiBaseUrl { get; set; } = "";
    public string SiteName { get; set; } = "Site non configuré";

    public static string Location => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "OGIPEN", "clientsettings.json");

    public static ClientConfiguration Load()
    {
        if (!File.Exists(Location)) return new ClientConfiguration();
        var result = JsonSerializer.Deserialize<ClientConfiguration>(
            File.ReadAllText(Location), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return result ?? new ClientConfiguration();
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
