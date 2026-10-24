using OGIPEN.Core.Security;
var now = DateTimeOffset.UtcNow;
var a = new CompanyAccessContext("a", "shared-project", "server-112", "a", "server-112",
    true, true, true, true, true, true, 2, 2, now.AddDays(1), now.AddHours(1),
    3, 3, 405, 405, 1, 1, new HashSet<int>{10,20}, new HashSet<int>{10}, 10, true, true, true);
var results = new List<object>();
void Check(string name, CompanyAccessContext c, string expected) {
    var d = CompanyProjectPolicy.Evaluate(c, now);
    if(d.Reason != expected || d.Allowed != (expected == "allowed")) throw new Exception(name);
    results.Add(new {test=name, pass=true});
}
Check("company_a_at_own_quota",a,"allowed");
var b=a with { CompanyId="b", LicensedCompanyId="b", ServerLicenceId=8, ClientLicenceId=8,
    SeatLimit=1, ActiveCompanySeats=1, ServerModuleIds=new HashSet<int>{20}, ClientModuleIds=new HashSet<int>{20}, RequiredModuleId=20 };
Check("company_b_same_project_independent_licence",b,"allowed");
Check("b_cannot_borrow_a_modules",b with {RequiredModuleId=10},"module_not_licensed");
Check("a_cannot_borrow_b_licence",a with {ClientLicenceId=8},"company_licence_mismatch");
Check("company_spoofing",a with {CompanyId="b"},"company_binding_mismatch");
Check("foreign_server",a with {LicensedServerId="other-server"},"server_binding_mismatch");
Check("server_proof_required",a with {ServerBindingVerified=false},"verified_licences_required");
Check("unsigned_client",a with {ClientLicenceVerified=false},"verified_licences_required");
Check("unsigned_server",a with {ServerLicenceVerified=false},"verified_licences_required");
Check("ad_identifier_alone_insufficient",a with {IdentityProofVerified=false},"identity_proof_required");
Check("project_invitation_required",a with {ProjectMember=false},"project_membership_required");
Check("company_participation_required",a with {CompanyParticipates=false},"project_membership_required");
Check("seats_not_pooled",b with {ActiveCompanySeats=2},"company_seat_limit_exceeded");
Check("negative_usage_rejected",a with {ActiveCompanySeats=-1},"company_seat_limit_exceeded");
Check("expired_server",a with {ServerExpires=now},"licence_expired");
Check("expired_client",a with {ClientExpires=now},"licence_expired");
Check("wrong_software",a with {ClientSoftwareId=391},"software_mismatch");
Check("wrong_major",a with {ClientMajor=2},"software_mismatch");
Check("client_subset_enforced",a with {RequiredModuleId=20},"module_not_licensed");
Check("project_read_only",a with {CanWrite=false},"project_permission_denied");
Check("read_allowed_without_write",a with {CanWrite=false,WantsWrite=false},"allowed");
Check("no_project_read_right",a with {CanRead=false},"project_permission_denied");
Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(results));
