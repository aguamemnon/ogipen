using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using static ProjectSql;

sealed class AuthenticationAudit(Db db,ILogger<AuthenticationAudit> logger)
{
    public async Task Observe(HttpContext h,RequestDelegate next)
    {
        var path=(h.Request.Path.Value??"").TrimEnd('/').ToLowerInvariant();
        if(!HttpMethods.IsPost(h.Request.Method) || (path!="/auth/challenge" && path!="/auth/complete" && path!="/auth/attempt" && path!="/auth/v3/challenge" && path!="/auth/v3/complete" && path!="/auth/v3/attempt")){await next(h);return;}
        var phase=path.EndsWith("complete",StringComparison.Ordinal)?"login":path.EndsWith("attempt",StringComparison.Ordinal)?"client":"challenge";
        var identity="";var computer="";var user="";long? licence=null;bool signature=false;bool? expired=null;var malformed=false;
        h.Request.EnableBuffering(65536,65536);
        try{
            using var reader=new StreamReader(h.Request.Body,Encoding.UTF8,false,1024,leaveOpen:true);
            var body=await reader.ReadToEndAsync(h.RequestAborted);
            using var document=JsonDocument.Parse(body);var root=document.RootElement;
            identity=Text(root,"identityId",80);computer=Text(root,"computerName",128);user=Text(root,"userName",180);
            licence=Number(Find(root,"licenseId"));
            var file=Text(root,"licenseJson",16384);
            if(file!=""){
                var inspection=InspectLicence(file);if(inspection.Id is not null)licence=inspection.Id;
                signature=inspection.Signature;expired=inspection.Expired;
            }
        }catch(Exception e) when(e is JsonException or IOException or BadHttpRequestException or OperationCanceledException){malformed=true;}
        finally{if(h.Request.Body.CanSeek)h.Request.Body.Position=0;}
        var ip=h.Connection.RemoteIpAddress;
        if(ip is not null && IPAddress.IsLoopback(ip) && IPAddress.TryParse(h.Request.Headers["X-Real-IP"].ToString(),out var forwarded))ip=forwarded;
        var source=ip?.IsIPv4MappedToIPv6==true?ip.MapToIPv4().ToString():ip?.ToString()??"unknown";
        int? failure=null;
        try{await next(h);}catch(OperationCanceledException) when(h.RequestAborted.IsCancellationRequested){failure=499;throw;}catch{failure=500;throw;}
        finally{
            try{
                using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(5));
                await using var c=await db.Open(timeout.Token);
                long? expected=null;
                await using(var cmd=Cmd(c,"SELECT p.slm_license_id FROM ogp_identity i JOIN ogp_project_company p ON p.id=i.company_id WHERE i.id=@id",("@id",identity))){var value=await cmd.ExecuteScalarAsync(timeout.Token);if(value is not null && value!=DBNull.Value)expected=Convert.ToInt64(value);}
                var referenceSource="identity_company";
                if(expected is null){expected=InitialLicenceNumber();referenceSource=expected is null?"unknown":"instance_initial";}
                if(h.Items.TryGetValue("authIdentity",out var actual))identity=actual?.ToString()??identity;
                int status=failure??h.Response.StatusCode;bool success=phase!="client" && status is >=200 and <300;
                bool proof=h.Items.TryGetValue("identityProofVerified",out var proofValue) && proofValue is true;
                bool? mismatch=licence is not null && expected is not null?licence!=expected:null;
                var reason=h.Items.TryGetValue("authReason",out var valueReason)?valueReason?.ToString():malformed?"malformed_request":success?(phase=="login"?"authenticated":"challenge_issued"):mismatch==true?"licence_mismatch":"authentication_refused";
                var details=JsonSerializer.Serialize(new{schema="ogipen-auth-audit-v1",phase,success,statusCode=status,reason,computerName=computer,userName=user,ip=source,identityId=identity,identityProofVerified=proof,licenseId=licence,licenseSignatureVerified=signature,licenseExpired=expired,serverLicenseId=expected,serverLicenseSource=referenceSource,licenseMismatch=mismatch,clientMetadataDeclared=true});
                await Exec(c,"INSERT INTO ogp_audit_event(happened_utc,actor_id,action_code,entity_type,entity_id,details) VALUES(UTC_TIMESTAMP(6),@actor,@action,'authentication',0,@details)",timeout.Token,("@actor",identity==""?"ANONYMOUS":identity),("@action",phase=="login"?"AUTH_LOGIN":phase=="client"?"AUTH_CLIENT_REFUSED":"AUTH_CHALLENGE"),("@details",details));
            }catch{logger.LogWarning("Authentication audit storage unavailable; phase={Phase}",phase);}
        }
    }
    private static JsonElement Find(JsonElement root,string name){JsonElement value=default;if(root.ValueKind==JsonValueKind.Object)foreach(var p in root.EnumerateObject())if(p.Name.Equals(name,StringComparison.OrdinalIgnoreCase))value=p.Value;return value;}
    private static string Text(JsonElement root,string name,int max){var e=Find(root,name);return e.ValueKind==JsonValueKind.String?new string((e.GetString()??"").Where(c=>!char.IsControl(c)).Take(max).ToArray()):"";}
    private static long? Number(JsonElement e)=>e.ValueKind==JsonValueKind.Number && e.TryGetInt64(out var n) && n>0?n:null;
    private static byte[] Decode(string value){var s=value.Replace('-','+').Replace('_','/');return Convert.FromBase64String(s.PadRight((s.Length+3)/4*4,'='));}
    private static (long? Id,bool Signature,bool? Expired) InspectLicence(string json)
    {
        long? id=null;
        try{
            using var f=JsonDocument.Parse(json);var token=Find(f.RootElement,"token");if(token.ValueKind!=JsonValueKind.String)return(null,false,null);
            var p=(token.GetString()??"").Split('.');if(p.Length!=3)return(null,false,null);
            using var claims=JsonDocument.Parse(Decode(p[1]));id=Number(Find(claims.RootElement,"lic"));
            bool valid=false;using var header=JsonDocument.Parse(Decode(p[0]));
            if(Text(f.RootElement,"type",60)=="OGIPEN-OFFLINE-LICENSE" && Text(header.RootElement,"alg",30)=="ES256-DER" && Text(header.RootElement,"typ",30)=="SLMMS-OFFLINE"){
                using var key=ECDsa.Create();key.ImportFromPem(File.ReadAllText(LicenseState.PublicKeyPath));valid=key.VerifyData(Encoding.ASCII.GetBytes(p[0]+"."+p[1]),Decode(p[2]),HashAlgorithmName.SHA256,DSASignatureFormat.Rfc3279DerSequence);
            }
            var expiry=Number(Find(claims.RootElement,"exp"));return(id,valid,expiry is null?null:expiry<=DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        }catch{return(id,false,null);}
    }
    private static long? InitialLicenceNumber()
    {
        try{
            var path=Environment.GetEnvironmentVariable("OGIPEN_LICENSE_PATH")??"/var/lib/ogipen/licensing/server.oglic";if(new FileInfo(path).Length>65536)return null;
            using var f=JsonDocument.Parse(File.ReadAllText(path));var payload=Decode(Text(f.RootElement,"payload",65536));
            using var key=ECDsa.Create();key.ImportFromPem(File.ReadAllText(LicenseState.PublicKeyPath));
            if(!key.VerifyData(payload,Decode(Text(f.RootElement,"signature",2048)),HashAlgorithmName.SHA256,DSASignatureFormat.Rfc3279DerSequence))return null;
            using var d=JsonDocument.Parse(payload);var root=d.RootElement;
            if(Text(root,"subject_type",30)!="server" || Text(root,"subject_id",180)!=Environment.GetEnvironmentVariable("OGIPEN_SERVER_ID"))return null;
            var number=Text(root,"license_id",80);return number.StartsWith("slmms:",StringComparison.Ordinal) && long.TryParse(number[6..],out var n) && n>0?n:null;
        }catch{return null;}
    }
}
