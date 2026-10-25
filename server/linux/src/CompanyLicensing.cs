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
    public async Task<CompanyBinding?> DeviceBinding(MySqlConnection c,string device,CancellationToken ct)
    {
        await using var cmd=Cmd(c,@"SELECT d.company_id,d.legacy_beneficiary_id,d.public_key_pem,p.server_license_json,p.slm_license_id,x.effective_mode,
        (SELECT COUNT(*) FROM ogp_project_company q WHERE q.state='prepared' AND q.server_license_json IS NOT NULL),
        (SELECT COUNT(*) FROM ogp_device q WHERE q.enabled=1 AND q.company_id=d.company_id)
        FROM ogp_device d JOIN ogp_project_company p ON p.id=d.company_id JOIN ogp_collaboration_config x ON x.id=1
        WHERE d.device_id=@id AND d.enabled=1 AND p.state='prepared'",("@id",device));
        await using var reader=await cmd.ExecuteReaderAsync(ct);
        if(!await reader.ReadAsync(ct)||reader.IsDBNull(3)||reader.IsDBNull(4))return null;
        var mode=reader.GetString(5);if(mode!="multi"&&(mode!="single"||reader.GetInt64(6)!=1))return null;
        var server=licences.Verify(reader.GetString(3),reader.GetInt64(4));if(server is null||reader.GetInt64(7)>server.Seats)return null;
        return new(reader.GetInt64(0),reader.IsDBNull(1)?0:reader.GetInt64(1),reader.GetString(2),1,server);
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
        string? json=null;string? deviceId=null;string? method=null;
        await using(var cmd=Cmd(c,"SELECT client_license_json,device_identity_id,auth_method FROM ogp_auth_session WHERE session_id=@session AND identity_id=@id AND auth_version=@version AND company_id=@company AND expires_utc>UTC_TIMESTAMP(6)",("@session",s.SessionId),("@id",s.IdentityId),("@version",s.Version),("@company",binding.CompanyId))){
            await using var reader=await cmd.ExecuteReaderAsync(ct);if(await reader.ReadAsync(ct)){json=reader.GetString(0);deviceId=reader.IsDBNull(1)?null:reader.GetString(1);method=reader.GetString(2);}
        }
        if(json is null || deviceId is null || method is not ("windows" or "ogipen"))return null;
        if(method=="ogipen" && await Scalar(c,"SELECT COUNT(*) FROM ogp_app_account WHERE identity_id=@id AND enabled=1 AND password_hash IS NOT NULL",ct,("@id",s.IdentityId))!=1)return null;
        var device=await DeviceBinding(c,deviceId,ct);
        if(device is null || device.CompanyId!=binding.CompanyId || !VerifyClient(device,json,out var grant))return null;
        return grant!.IsDeviceBound || (grant.BeneficiaryId==binding.BeneficiaryId && binding.PublicKey==device.PublicKey)?grant:null;
    }
    public async Task<bool> ModuleAllowed(MySqlConnection c,AuthSession s,int module,CancellationToken ct)
    {
        if(module<1)return false;
        var binding=await Binding(c,s.IdentityId,ct);if(binding is null || !binding.Server.Modules.Contains(module))return false;
        var grant=await ReadGrant(c,binding,s,ct);return grant is not null && grant.ModuleIds.Contains(module);
    }
}
sealed record CompanyBinding(long CompanyId,long BeneficiaryId,string PublicKey,int Version,ServerGrant Server);
sealed record ServerGrant(long LicenseId,int SoftwareId,int Seats,DateTimeOffset Expires,IReadOnlySet<int> Modules);
