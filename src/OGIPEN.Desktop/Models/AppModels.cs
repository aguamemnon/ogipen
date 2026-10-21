using System.Text.Json.Serialization;

namespace OGIPEN.Desktop.Models;

// Le client ne reçoit pas le nom de la base MySQL ni de credentials SQL.
// L'API vérifie l'utilisateur, le projet ET la permission de chaque opération.
public sealed class ProjectAccess
{
    [JsonPropertyName("id")] public string Id { get; set; } = "";
    [JsonPropertyName("name")] public string Name { get; set; } = "";
    [JsonPropertyName("role")] public string Role { get; set; } = "";
}

public sealed class LoginReply
{
    [JsonPropertyName("accessToken")] public string AccessToken { get; set; } = "";
    [JsonPropertyName("displayName")] public string DisplayName { get; set; } = "";
    [JsonPropertyName("projects")] public List<ProjectAccess> Projects { get; set; } = new();
}

public sealed class UserSession
{
    // Jamais persisté sur disque. En mode aperçu, jeton vide et données fictives.
    public string AccessToken { get; }
    public string DisplayName { get; }
    public IReadOnlyList<ProjectAccess> Projects { get; }
    public bool IsPreview { get; }

    private UserSession(string token, string displayName,
        IReadOnlyList<ProjectAccess> projects, bool preview)
    {
        AccessToken = token;
        DisplayName = displayName;
        Projects = projects;
        IsPreview = preview;
    }

    public static UserSession FromReply(LoginReply reply)
    {
        if (string.IsNullOrWhiteSpace(reply.AccessToken) || string.IsNullOrWhiteSpace(reply.DisplayName))
            throw new InvalidOperationException("Réponse d'authentification invalide.");
        if (reply.Projects.Any(p => string.IsNullOrWhiteSpace(p.Id) ||
                                    string.IsNullOrWhiteSpace(p.Name)) ||
            reply.Projects.Select(p => p.Id).Distinct(StringComparer.Ordinal).Count() != reply.Projects.Count)
            throw new InvalidOperationException("Liste de projets invalide.");
        return new UserSession(reply.AccessToken, reply.DisplayName, reply.Projects, false);
    }

    public static UserSession Preview() => new(
        "", "Aperçu local", new List<ProjectAccess>
        {
            new() { Id = "preview-only", Name = "Projet de démonstration", Role = "Aucune autorisation" }
        }, true);
}
