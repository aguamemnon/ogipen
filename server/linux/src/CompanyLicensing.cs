using System.Security.Cryptography;
using OGIPEN.Core.Security;
using MySqlConnector;
using static ProjectSql;

sealed class CompanyLicensing(LicenseState licences)
{
    public async Task<CompanyBinding?> Binding(MySqlConnection c,string identity,CancellationToken ct,MySqlTransaction? tx=null)
    {
        await using var cmd=Cmd(c,@"SELECT i.company_id,i.license_beneficiary_id,i.public_key_pem,i.auth_version,
            p.server_license_json,p.slm_license_id,p.state,x.effective_mode,
            (SELECT COUNT(*) FROM ogp_identity n WHERE n.enabled=1 AND n.company_id=i.company_id),
            (SELECT COUNT(*) FROM ogp_project_company n WHERE n.state='prepared' AND n.server_license_json IS NOT NULL)
            FROM ogp_identity i JOIN ogp_project_company p ON p.id=i.company_id
            JOIN ogp_collaboration_config x ON x.id=1 WHERE i.id=@id AND i.enabled=1",("@id",identity));
        cmd.Transaction=tx;
        await using var r=await cmd.ExecuteReaderAsync(ct);
        if(!await r.ReadAsync(ct) || r.IsDBNull(4) || r.IsDBNull(5) || r.GetString(6)!="prepared")return null;
        var mode=r.GetString(7);
        if(mode!="multi" && (mode!="single" || r.GetInt64(9)!=1))return null;
        var server=licences.Verify(r.GetString(4),r.GetInt64(5));
        if(server is null || r.GetInt64(8)>server.Seats)return null;
        return new(r.GetInt64(0),r.IsDBNull(1)?0:r.GetInt64(1),r.GetString(2),r.GetInt32(3),server);
    }
    public bool VerifyClient(CompanyBinding binding,string json,out OfflineLicenseActivation.OfflineGrant? grant)
    {
        grant=null;
        try {
            using var key=ECDsa.Create();key.ImportFromPem(binding.PublicKey);
            return OfflineLicenseActivation.TryImport(json,key,File.ReadAllText(LicenseState.PublicKeyPath),
                Environment.GetEnvironmentVariable("OGIPEN_LICENSE_ISSUER")??"",
                binding.Server.SoftwareId,"ogipen",1,Array.Empty<int>(),out grant) &&
                grant is not null && grant.LicenseId==binding.Server.LicenseId &&
                (grant.IsDeviceBound || grant.BeneficiaryId==binding.BeneficiaryId);
        }catch{return false;}
    }
    public async Task<bool> SessionValid(MySqlConnection c,AuthSession s,CancellationToken ct)
    {
        var binding=await Binding(c,s.IdentityId,ct);
        if(binding is null || binding.Version!=s.Version)return false;
        return await ReadGrant(c,binding,s,ct) is not null;
    }
    public async Task<OfflineLicenseActivation.OfflineGrant?> ReadGrant(MySqlConnection c,CompanyBinding binding,AuthSession s,CancellationToken ct)
    {
        string? json=null;
        await using(var cmd=Cmd(c,"SELECT client_license_json FROM ogp_auth_session WHERE session_id=@session AND identity_id=@id AND auth_version=@version AND company_id=@company AND expires_utc>UTC_TIMESTAMP(6)",("@session",s.SessionId),("@id",s.IdentityId),("@version",s.Version),("@company",binding.CompanyId)))
            json=(string?)await cmd.ExecuteScalarAsync(ct);
        return json is not null && VerifyClient(binding,json,out var grant)?grant:null;
    }
    public async Task<bool> ModuleAllowed(MySqlConnection c,AuthSession s,int module,CancellationToken ct)
    {
        if(module<1)return false;
        var b=await Binding(c,s.IdentityId,ct);if(b is null || !b.Server.Modules.Contains(module))return false;
        string? json;
        await using(var cmd=Cmd(c,"SELECT client_license_json FROM ogp_auth_session WHERE session_id=@s AND identity_id=@id AND auth_version=@version AND company_id=@company AND expires_utc>UTC_TIMESTAMP(6)",("@s",s.SessionId),("@id",s.IdentityId),("@version",s.Version),("@company",b.CompanyId)))json=(string?)await cmd.ExecuteScalarAsync(ct);
        return json is not null && VerifyClient(b,json,out var grant) && grant!.ModuleIds.Contains(module);
    }
}
sealed record CompanyBinding(long CompanyId,long BeneficiaryId,string PublicKey,int Version,ServerGrant Server);
sealed record ServerGrant(long LicenseId,int SoftwareId,int Seats,DateTimeOffset Expires,IReadOnlySet<int> Modules);
