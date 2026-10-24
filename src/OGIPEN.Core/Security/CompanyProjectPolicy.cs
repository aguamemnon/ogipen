namespace OGIPEN.Core.Security;

/// <summary>Project-local policy. Inputs must come from verified enrolment, signed licences
/// and project permissions, never from untrusted client company/module fields.</summary>
public static class CompanyProjectPolicy
{
    public static CompanyAccessDecision Evaluate(CompanyAccessContext c, DateTimeOffset now)
    {
        if (!c.IdentityProofVerified) return Deny("identity_proof_required");
        if (string.IsNullOrWhiteSpace(c.CompanyId) || string.IsNullOrWhiteSpace(c.ProjectId))
            return Deny("company_and_project_required");
        if (!c.ProjectMember || !c.CompanyParticipates) return Deny("project_membership_required");
        if (!c.ServerBindingVerified || !c.ServerLicenceVerified || !c.ClientLicenceVerified)
            return Deny("verified_licences_required");
        if (string.IsNullOrWhiteSpace(c.ServerId) || c.ServerId != c.LicensedServerId)
            return Deny("server_binding_mismatch");
        if (c.ServerLicenceId <= 0 || c.ServerLicenceId != c.ClientLicenceId)
            return Deny("company_licence_mismatch");
        if (c.CompanyId != c.LicensedCompanyId) return Deny("company_binding_mismatch");
        if (c.ServerExpires <= now || c.ClientExpires <= now) return Deny("licence_expired");
        if (c.SeatLimit <= 0 || c.ActiveCompanySeats < 0 || c.ActiveCompanySeats > c.SeatLimit)
            return Deny("company_seat_limit_exceeded");
        if (c.ServerSoftwareId <= 0 || c.ServerSoftwareId != c.ClientSoftwareId ||
            c.ServerMajor <= 0 || c.ServerMajor != c.ClientMajor)
            return Deny("software_mismatch");
        if (c.RequiredModuleId <= 0 || !c.ServerModuleIds.Contains(c.RequiredModuleId) ||
            !c.ClientModuleIds.Contains(c.RequiredModuleId)) return Deny("module_not_licensed");
        if (!c.CanRead || (c.WantsWrite && !c.CanWrite)) return Deny("project_permission_denied");
        return new(true, "allowed");
    }
    private static CompanyAccessDecision Deny(string reason) => new(false, reason);
}

public sealed record CompanyAccessDecision(bool Allowed, string Reason);
public sealed record CompanyAccessContext(
    string CompanyId, string ProjectId, string ServerId, string LicensedCompanyId, string LicensedServerId,
    bool IdentityProofVerified, bool ProjectMember, bool CompanyParticipates,
    bool ServerBindingVerified, bool ServerLicenceVerified, bool ClientLicenceVerified,
    long ServerLicenceId, long ClientLicenceId, DateTimeOffset ServerExpires, DateTimeOffset ClientExpires,
    int SeatLimit, int ActiveCompanySeats, int ServerSoftwareId, int ClientSoftwareId,
    int ServerMajor, int ClientMajor, IReadOnlySet<int> ServerModuleIds, IReadOnlySet<int> ClientModuleIds,
    int RequiredModuleId, bool CanRead, bool CanWrite, bool WantsWrite);
