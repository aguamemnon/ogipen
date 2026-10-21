namespace OGIPEN.Desktop.Models;

/// <summary>
/// Une session est liée à un projet déjà autorisé par l'API. Le nom de la
/// base SQL n'est jamais reçu par le client ni dérivé du nom visible.
/// Ce contrôle local protège l'interface mais ne remplace PAS l'autorisation
/// serveur sur chacune des requêtes.
/// </summary>
public sealed class ProjectScope
{
    private readonly HashSet<string> _permissions;

    public string ProjectId { get; }
    public string ProjectName { get; }
    public string Role { get; }
    public bool IsPreview { get; }

    private ProjectScope(ProjectAccess project, bool preview)
    {
        ProjectId = project.Id;
        ProjectName = project.Name;
        Role = project.Role;
        IsPreview = preview;
        _permissions = new HashSet<string>(
            preview ? Array.Empty<string>() : project.Permissions,
            StringComparer.Ordinal);
    }

    public static ProjectScope Open(UserSession session, ProjectAccess selected)
    {
        ArgumentNullException.ThrowIfNull(session);
        ArgumentNullException.ThrowIfNull(selected);

        // Un simple ID fourni par le poste ne crée jamais un accès à un projet.
        if (!session.Projects.Any(p => ReferenceEquals(p, selected)))
            throw new UnauthorizedAccessException(
                "Projet absent des autorisations de la session.");

        return new ProjectScope(selected, session.IsPreview);
    }

    public bool Can(string permission) =>
        !IsPreview && !string.IsNullOrWhiteSpace(permission) &&
        _permissions.Contains(permission);
}

/// <summary>
/// Noms des opérations métier. L'API serveur est toujours l'autorité.
/// Un rôle (OSSI, technicien, chef de chantier...) n'est pas une permission.
/// </summary>
public static class ProjectPermissions
{
    public const string ProjectRead = "projects.read";
    public const string ProjectCreate = "projects.create";
    public const string UsersManage = "users.manage";
    public const string RightsManage = "rights.manage";
    public const string CableRead = "cables.read";
    public const string CableWrite = "cables.write";
    public const string EquipmentRead = "equipments.read";
    public const string EquipmentWrite = "equipments.write";
    public const string SegmentRead = "segments.read";
    public const string SegmentWrite = "segments.write";
    public const string ProgressRead = "site.progress.read";
    public const string ProgressWrite = "site.progress.write";
    public const string OfflineProgressSync = "site.progress.sync";
}
