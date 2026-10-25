using System.Data;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text.Json;
using MySqlConnector;
using static ProjectSql;

static class AccountAdministration
{
 public static void Map(RouteGroupBuilder api){
  api.MapGet("/administration/accounts",async(HttpContext h,Db db,CompanyLicensing licensing,CancellationToken ct)=>{
   h.Response.Headers.CacheControl="no-store";
   await using var c=await db.Open(ct);var actor=Actor(h);var role=await PasswordAuthentication.Role(c,actor,ct);
   if(role is not ("admin" or "ossi"))return Results.StatusCode(403);
   var binding=await licensing.Binding(c,actor,ct);if(binding is null)return Results.Unauthorized();
   var items=new List<object>();
   await using var cmd=Cmd(c,@"SELECT a.identity_id,a.login_name,i.display_name,a.system_role,a.enabled,i.auth_version,
    COALESCE(p.can_read,0),COALESCE(p.can_edit,0) FROM ogp_app_account a JOIN ogp_identity i ON i.id=a.identity_id
    LEFT JOIN ogp_permission p ON p.identity_id=i.id WHERE i.company_id=@company ORDER BY a.login_name LIMIT 201",("@company",binding.CompanyId));
   await using var reader=await cmd.ExecuteReaderAsync(ct);
   while(await reader.ReadAsync(ct))items.Add(new{identityId=reader.GetString(0),login=reader.GetString(1),displayName=reader.GetString(2),systemRole=reader.GetString(3),enabled=reader.GetBoolean(4),revision=reader.GetInt32(5),canRead=reader.GetBoolean(6),canEdit=reader.GetBoolean(7)});
   bool truncated=items.Count>200;if(truncated)items.RemoveAt(200);
   return Results.Ok(new{companyId=binding.CompanyId,actorId=actor,systemRole=role,canManage=role=="admin",truncated,items});
  });
  api.MapPost("/administration/accounts",async(AccountMutation req,HttpContext h,Db db,CompanyLicensing licensing,CancellationToken ct)=>{
   h.Response.Headers.CacheControl="no-store";
   if(!Valid(req))return Error(400,"Login, nom ou rôle invalide. Le mot de passe doit contenir 12 à 256 caractères.");
   var login=req.Login.Trim().ToLowerInvariant();var actor=Actor(h);var session=(AuthSession)h.Items["session"]!;
   await using var c=await db.Open(ct);
   if(await PasswordAuthentication.Role(c,actor,ct)!="admin")return Results.StatusCode(403);
   await using var tx=await c.BeginTransactionAsync(IsolationLevel.ReadCommitted,ct);
   try{
    // Same allocation lock and lock order as the existing PHP account service.
    await using(var lockCommand=Cmd(c,"SELECT id FROM ogp_collaboration_config WHERE id=1 FOR UPDATE")){lockCommand.Transaction=tx;await lockCommand.ExecuteScalarAsync(ct);}
    var binding=await licensing.Binding(c,actor,ct,tx);if(binding is null){await tx.RollbackAsync(ct);return Results.Unauthorized();}
    await using(var authorization=Cmd(c,@"SELECT COUNT(*) FROM ogp_app_account a JOIN ogp_identity i ON i.id=a.identity_id
      JOIN ogp_auth_session s ON s.identity_id=i.id WHERE a.identity_id=@actor AND a.system_role='admin' AND a.enabled=1
      AND i.enabled=1 AND i.auth_version=@version AND s.session_id=@session AND s.auth_version=i.auth_version AND s.expires_utc>UTC_TIMESTAMP(6)",("@actor",actor),("@version",session.Version),("@session",session.SessionId))){
      authorization.Transaction=tx;if(Convert.ToInt64(await authorization.ExecuteScalarAsync(ct))!=1){await tx.RollbackAsync(ct);return Results.Unauthorized();}
    }
    string? id=null,oldHash=null,oldRole=null;bool oldEnabled=false;int revision=0;
    await using(var select=Cmd(c,@"SELECT a.identity_id,a.password_hash,a.system_role,a.enabled,i.auth_version
      FROM ogp_app_account a JOIN ogp_identity i ON i.id=a.identity_id WHERE a.login_name=@login AND i.company_id=@company FOR UPDATE",("@login",login),("@company",binding.CompanyId))){
      select.Transaction=tx;await using var r=await select.ExecuteReaderAsync(ct);
      if(await r.ReadAsync(ct)){id=r.GetString(0);oldHash=r.IsDBNull(1)?null:r.GetString(1);oldRole=r.GetString(2);oldEnabled=r.GetBoolean(3);revision=r.GetInt32(4);}
    }
    if((id is null)!=(req.IdentityId is null) || (id is not null && (id!=req.IdentityId || revision!=req.Revision))){await tx.RollbackAsync(ct);return Error(409,"Le compte a changé ou existe déjà. Rechargez la liste avant de recommencer.");}
    if(id is null){
     await using var duplicate=Cmd(c,"SELECT COUNT(*) FROM ogp_app_account WHERE login_name=@login",("@login",login));duplicate.Transaction=tx;
     if(Convert.ToInt64(await duplicate.ExecuteScalarAsync(ct))!=0){await tx.RollbackAsync(ct);return Error(409,"Ce login est indisponible.");}
    }
    if(oldRole=="admin" && oldEnabled && (!req.Enabled || req.SystemRole!="admin")){
     await using var last=Cmd(c,@"SELECT COUNT(*) FROM ogp_app_account a JOIN ogp_identity i ON i.id=a.identity_id
       WHERE i.company_id=@company AND a.system_role='admin' AND a.enabled=1 AND i.enabled=1 AND a.password_hash IS NOT NULL",("@company",binding.CompanyId));last.Transaction=tx;
     if(Convert.ToInt64(await last.ExecuteScalarAsync(ct))<=1){await tx.RollbackAsync(ct);return Error(409,"Conservez au moins un administrateur actif dans cette entreprise.");}
    }
    // Lock the company before counting seats, as in PHP's account mutation.
    await using(var parent=Cmd(c,"SELECT id FROM ogp_project_company WHERE id=@company FOR UPDATE",("@company",binding.CompanyId))){parent.Transaction=tx;await parent.ExecuteScalarAsync(ct);}
    if(req.Enabled){
     await using var usage=Cmd(c,"SELECT COUNT(*) FROM ogp_identity WHERE enabled=1 AND company_id=@company AND id<>@id",("@company",binding.CompanyId),("@id",id??""));usage.Transaction=tx;
     if(Convert.ToInt64(await usage.ExecuteScalarAsync(ct))>=binding.Server.Seats){await tx.RollbackAsync(ct);return Error(409,"Quota d’utilisateurs actifs atteint pour cette entreprise.");}
    }
    var hash=string.IsNullOrEmpty(req.NewPassword)?oldHash:HashPassword(req.NewPassword);
    if(req.Enabled && hash is null){await tx.RollbackAsync(ct);return Error(400,"Définissez un mot de passe avant d’activer ce compte.");}
    bool created=id is null;id??="ogipen:"+Guid.NewGuid().ToString("N");
    if(created){
     await Exec(c,"INSERT INTO ogp_identity(id,display_name,public_key_pem,public_key_sha256,enabled,company_id,auth_version) VALUES(@id,@name,'',NULL,@enabled,@company,1)",ct,tx,("@id",id),("@name",req.DisplayName.Trim()),("@enabled",req.Enabled),("@company",binding.CompanyId));
     await Exec(c,"INSERT INTO ogp_permission(identity_id,can_read,can_edit) VALUES(@id,0,0)",ct,tx,("@id",id));
     await Exec(c,"INSERT INTO ogp_app_account(identity_id,login_name,password_hash,system_role,enabled) VALUES(@id,@login,@hash,@role,@enabled)",ct,tx,("@id",id),("@login",login),("@hash",(object?)hash??DBNull.Value),("@role",req.SystemRole),("@enabled",req.Enabled));
    }else{
     await Exec(c,"UPDATE ogp_identity SET display_name=@name,enabled=@enabled,auth_version=auth_version+1 WHERE id=@id",ct,tx,("@id",id),("@name",req.DisplayName.Trim()),("@enabled",req.Enabled));
     await Exec(c,"UPDATE ogp_app_account SET password_hash=@hash,system_role=@role,enabled=@enabled,updated_utc=UTC_TIMESTAMP(6) WHERE identity_id=@id",ct,tx,("@id",id),("@hash",(object?)hash??DBNull.Value),("@role",req.SystemRole),("@enabled",req.Enabled));
    }
    await Exec(c,"DELETE FROM ogp_auth_session WHERE identity_id=@id",ct,tx,("@id",id));
    var details=JsonSerializer.Serialize(new{companyId=binding.CompanyId,identityId=id,login,systemRole=req.SystemRole,enabled=req.Enabled,created,passwordChanged=!string.IsNullOrEmpty(req.NewPassword),source="desktop"});
    await Exec(c,"INSERT INTO ogp_audit_event(actor_id,action_code,entity_type,entity_id,details) VALUES(@actor,'ACCOUNT_CHANGED','account_administration',0,@details)",ct,tx,("@actor",actor),("@details",details));
    await tx.CommitAsync(ct);
    return Results.Ok(new{identityId=id,revision=created?1:revision+1,reauthenticate=id==actor});
   }catch(MySqlException e) when(e.Number==1062){await tx.RollbackAsync(ct);return Error(409,"Le compte a changé ou ce login est indisponible.");}
  });
 }
 static IResult Error(int status,string message)=>Results.Json(new{message},statusCode:status);
 static bool Valid(AccountMutation r)=>r.Login is {Length:>0 and <=80} && Regex.IsMatch(r.Login.Trim(),"^[A-Za-z0-9][A-Za-z0-9_.@-]{0,79}$",RegexOptions.CultureInvariant)
  && r.DisplayName is {Length:>0 and <=180} && r.DisplayName.Trim().Length>0 && !r.DisplayName.Any(char.IsControl)
  && (r.SystemRole is "user" or "admin" or "ossi") && r.Revision>=0 && (r.IdentityId is null || r.IdentityId.Length<=80)
  && (string.IsNullOrEmpty(r.NewPassword) || (r.NewPassword.EnumerateRunes().Count()>=12 && System.Text.Encoding.UTF8.GetByteCount(r.NewPassword)<=256));
 static string HashPassword(string password){var salt=RandomNumberGenerator.GetBytes(32);return "pbkdf2-sha256$600000$"+Convert.ToBase64String(salt)+"$"+Convert.ToBase64String(Rfc2898DeriveBytes.Pbkdf2(password,salt,600000,HashAlgorithmName.SHA256,32));}
}
record AccountMutation(string? IdentityId,string Login,string DisplayName,string SystemRole,bool Enabled,int Revision,string? NewPassword);
