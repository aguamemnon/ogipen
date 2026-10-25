using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Collections.Concurrent;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using MySqlConnector;
using static ProjectSql;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var audienceUri=new Uri(Environment.GetEnvironmentVariable("OGIPEN_AUTH_AUDIENCE")??throw new InvalidOperationException("OGIPEN_AUTH_AUDIENCE missing"),UriKind.Absolute);
if(audienceUri.Scheme!="https" || audienceUri.UserInfo!="" || audienceUri.Query!="" || audienceUri.Fragment!="" || !audienceUri.AbsolutePath.EndsWith('/'))throw new InvalidOperationException("Invalid authentication audience");
var authAudience=audienceUri.AbsoluteUri;
var dbcs = Environment.GetEnvironmentVariable("OGIPEN_DB_CONNECTION")
    ?? throw new InvalidOperationException("OGIPEN_DB_CONNECTION missing");
var keyB64 = Environment.GetEnvironmentVariable("OGIPEN_SESSION_KEY")
    ?? throw new InvalidOperationException("OGIPEN_SESSION_KEY missing");
var signKey = Convert.FromBase64String(keyB64);
if(signKey.Length < 32) throw new InvalidOperationException("Session key too short");
builder.Services.AddSignalR();
builder.Services.AddSingleton<LicenseState>();
builder.Services.AddSingleton<CompanyLicensing>();
builder.Services.AddSingleton<AuthenticationAudit>();
builder.WebHost.ConfigureKestrel(o=>o.Limits.MaxRequestBodySize=65536);
builder.Services.AddSingleton<ConnectionRegistry>();
builder.Services.AddHostedService(sp=>sp.GetRequiredService<ConnectionRegistry>());
builder.Logging.AddFilter("Microsoft.AspNetCore.Hosting.Diagnostics",LogLevel.Warning);
builder.Services.AddSingleton(new Db(dbcs));
builder.Services.AddSingleton(new TokenService(signKey));
var app = builder.Build();
app.Use((context,next)=>context.RequestServices.GetRequiredService<AuthenticationAudit>().Observe(context,next));

// NOTE: use TLS reverse proxy, never expose Kestrel port over the network.
app.MapGet("/health", async (LicenseState license,Db db,CancellationToken ct) => {
    await using var c=await db.Open(ct);
    var mode="single";await using(var cmd=Cmd(c,"SELECT effective_mode FROM ogp_collaboration_config WHERE id=1"))mode=(string?)await cmd.ExecuteScalarAsync(ct)??"single";
    var verified=0;
    await using(var cmd=Cmd(c,"SELECT server_license_json,slm_license_id FROM ogp_project_company WHERE state='prepared' AND server_license_json IS NOT NULL AND slm_license_id IS NOT NULL")){
        await using var r=await cmd.ExecuteReaderAsync(ct);while(await r.ReadAsync(ct))if(license.Verify(r.GetString(0),r.GetInt64(1)) is not null)verified++;
    }
    return Results.Ok(new {status="ok", version="0.4.16-test", licensed=license.Read().Valid || verified>0,collaborationMode=mode,licensedCompanies=verified});
});
app.MapPost("/auth/attempt",(ChallengeRequest req,HttpContext h)=>{h.Items["authReason"]="client_local_license_refused";return Results.Accepted();});
app.MapPost("/auth/challenge",()=>Results.Json(new{message="Client 0.4.13 requis : login et mot de passe."},statusCode:426));
app.MapPost("/auth/complete",()=>Results.Json(new{message="Client 0.4.13 requis : login et mot de passe."},statusCode:426));
PasswordAuthentication.Map(app,authAudience);
// Authorize every project endpoint using signed 15-minute bearer sessions.
var api=app.MapGroup("/api").AddEndpointFilter(async (ctx,next)=>{
    var token=ctx.HttpContext.Request.Headers.Authorization.ToString();
    var svc=ctx.HttpContext.RequestServices.GetRequiredService<TokenService>();
    var session=svc.Validate(token.StartsWith("Bearer ",StringComparison.OrdinalIgnoreCase)?token[7..]:"");
    if(session is null)return Results.Unauthorized();
    var db=ctx.HttpContext.RequestServices.GetRequiredService<Db>();
    await using var c=await db.Open(ctx.HttpContext.RequestAborted);
    if(!await ctx.HttpContext.RequestServices.GetRequiredService<CompanyLicensing>().SessionValid(c,session,ctx.HttpContext.RequestAborted))return Results.Unauthorized();
    ctx.HttpContext.Items["actor"]=session.IdentityId;
    ctx.HttpContext.Items["session"]=session;
    return await next(ctx);
});
AccountAdministration.Map(api);
api.MapGet("/administration",async(HttpContext h,Db db,CompanyLicensing licensing,CancellationToken ct)=>{
    await using var c=await db.Open(ct);var role=await PasswordAuthentication.Role(c,Actor(h),ct);
    var binding=await licensing.Binding(c,Actor(h),ct);if(binding is null)return Results.Unauthorized();
    return role is "admin" or "ossi"?Results.Ok(new{systemRole=role,identities=await Scalar(c,"SELECT COUNT(*) FROM ogp_identity WHERE company_id=@company",ct,("@company",binding.CompanyId)),scope="company-server"}):Results.StatusCode(403);
});
api.MapGet("/session",async(HttpContext h,Db db,CompanyLicensing licensing,CancellationToken ct)=>{
    await using var c=await db.Open(ct);var b=await licensing.Binding(c,Actor(h),ct);
    if(b is null)return Results.Unauthorized();
    var currentGrant=await licensing.ReadGrant(c,b,(AuthSession)h.Items["session"]!,ct);if(currentGrant is null)return Results.Unauthorized();
    string displayName="";bool read=false,edit=false;
    await using(var cmd=Cmd(c,"SELECT i.display_name,COALESCE(p.can_read,0),COALESCE(p.can_edit,0) FROM ogp_identity i LEFT JOIN ogp_permission p ON p.identity_id=i.id WHERE i.id=@id",("@id",Actor(h)))){
        await using var r=await cmd.ExecuteReaderAsync(ct);if(await r.ReadAsync(ct)){displayName=r.GetString(0);read=r.GetBoolean(1);edit=r.GetBoolean(2);}
    }
    var permissions=new List<string>();if(read){permissions.Add("projects.read");permissions.Add("cables.read");if(edit)permissions.Add("cables.write");}
    var projects=new List<object>();if(read)projects.Add(new {
        id=Environment.GetEnvironmentVariable("OGIPEN_PROJECT_ID")??"prototype",
        name=Environment.GetEnvironmentVariable("OGIPEN_PROJECT_NAME")??"Projet de démonstration",
        role=edit?"Lecture et édition":"Lecture seule",permissions
    });
    var systemRole=await PasswordAuthentication.Role(c,Actor(h),ct);
    if(systemRole is "admin" or "ossi")projects.Insert(0,new{id="administration",name="Administration du serveur",role=systemRole=="admin"?"Administrateur logiciel":"OSSI",permissions=new[]{"server.administration.read"}});
    return Results.Ok(new{systemRole,identity=Actor(h),companyId=b.CompanyId,licenceId=b.Server.LicenseId,beneficiaryId=currentGrant.BeneficiaryId,binding=currentGrant.IsDeviceBound?"device":"legacy_user",displayName,projects});
});
api.MapDelete("/session",async(HttpContext h,Db db,CancellationToken ct)=>{
    var session=(AuthSession)h.Items["session"]!;await using var c=await db.Open(ct);
    await Exec(c,"DELETE FROM ogp_auth_session WHERE session_id=@session AND identity_id=@id",ct,("@session",session.SessionId),("@id",session.IdentityId));
    return Results.NoContent();
});
api.MapGet("/modules/{module:int}/access",async(int module,HttpContext h,Db db,CompanyLicensing licensing,CancellationToken ct)=>{
    await using var c=await db.Open(ct);
    return await Authorized(c,Actor(h),false,ct) && await licensing.ModuleAllowed(c,(AuthSession)h.Items["session"]!,module,ct)?Results.Ok(new{module,allowed=true}):Results.StatusCode(403);
});
api.MapGet("/cables/{id:long}",async (long id,HttpContext h,Db db,CancellationToken ct)=>{
    await using var c=await db.Open(ct);if(!await Authorized(c,Actor(h),false,ct))return Results.StatusCode(403);
    await using var cmd=Cmd(c,"SELECT id,reference,description,row_version FROM ogp_demo_cable WHERE id=@id",("@id",id));
    await using var r=await cmd.ExecuteReaderAsync(ct);
    return await r.ReadAsync(ct)?Results.Ok(new{id=r.GetInt64(0),reference=r.GetString(1),description=r.GetString(2),version=r.GetInt64(3)}):Results.NotFound();
});
api.MapPost("/locks/{type}/{id:long}",async (string type,long id,HttpContext h,Db db,IHubContext<EventHub> hub,CancellationToken ct)=>{
    if(!ValidType(type))return Results.BadRequest();
    var actor=Actor(h);await using var c=await db.Open(ct);
    if(!await Authorized(c,actor,true,ct))return Results.StatusCode(403);
    await using var tx=await c.BeginTransactionAsync(IsolationLevel.ReadCommitted,ct);
    // INSERT creates the record, ON DUPLICATE only replaces if lease expired. Conditional update is atomic.
    var token=Guid.NewGuid().ToString();
    var changed=await Exec(c,@"INSERT INTO ogp_edit_lock(entity_type,entity_id,token,owner_id,session_id,expires_utc)
      VALUES(@type,@id,@token,@actor,@session,DATE_ADD(UTC_TIMESTAMP(6),INTERVAL 90 SECOND))
      ON DUPLICATE KEY UPDATE
      token=IF(expires_utc<=UTC_TIMESTAMP(6),VALUES(token),token),
      owner_id=IF(expires_utc<=UTC_TIMESTAMP(6),VALUES(owner_id),owner_id),
      session_id=IF(expires_utc<=UTC_TIMESTAMP(6),VALUES(session_id),session_id),
      expires_utc=IF(expires_utc<=UTC_TIMESTAMP(6),VALUES(expires_utc),expires_utc)",ct,tx,
      ("@type",type),("@id",id),("@token",token),("@actor",actor),("@session",token));
    // Verify we own the token; affected-row counts are driver/config dependent.
    var owner="";var active="";
    await using(var cmd=Cmd(c,"SELECT owner_id,token FROM ogp_edit_lock WHERE entity_type=@t AND entity_id=@id",("@t",type),("@id",id))){cmd.Transaction=(MySqlTransaction)tx;await using var r=await cmd.ExecuteReaderAsync(ct);if(await r.ReadAsync(ct)){owner=r.GetString(0);active=r.GetString(1);}}
    if(active!=token){await tx.RollbackAsync(ct);return Results.Json(new{message="Already edited",owner},statusCode:423);}
    var seq=await Audit(c,tx,actor,"edit.begin",type,id,ct);
    await tx.CommitAsync(ct);await hub.Clients.All.SendAsync("event",new{seq,actor,action="edit.begin",type,id},ct);
    return Results.Ok(new{token,expiresInSeconds=90});
});
api.MapPut("/locks/{type}/{id:long}/renew",async(string type,long id,[FromBody] LeaseRequest body,HttpContext h,Db db,CancellationToken ct)=>{
    if(!ValidType(type))return Results.BadRequest();await using var c=await db.Open(ct);
    if(!await Authorized(c,Actor(h),true,ct))return Results.StatusCode(403);
    var n=await Exec(c,"UPDATE ogp_edit_lock SET expires_utc=DATE_ADD(UTC_TIMESTAMP(6),INTERVAL 90 SECOND) WHERE entity_type=@t AND entity_id=@id AND token=@token AND owner_id=@owner AND expires_utc>UTC_TIMESTAMP(6)",ct,("@t",type),("@id",id),("@token",body.Token),("@owner",Actor(h)));
    return n==1?Results.NoContent():Results.Conflict(new{message="Lease lost"});
});
api.MapDelete("/locks/{type}/{id:long}",async(string type,long id,[FromBody] LeaseRequest body,HttpContext h,Db db,IHubContext<EventHub> hub,CancellationToken ct)=>{
    if(!ValidType(type))return Results.BadRequest();await using var c=await db.Open(ct);
    if(!await Authorized(c,Actor(h),true,ct))return Results.StatusCode(403);
    await using var tx=await c.BeginTransactionAsync(ct);
    var n=await Exec(c,"DELETE FROM ogp_edit_lock WHERE entity_type=@t AND entity_id=@id AND token=@token AND owner_id=@owner",ct,tx,("@t",type),("@id",id),("@token",body.Token),("@owner",Actor(h)));
    if(n!=1){await tx.RollbackAsync(ct);return Results.Conflict();}
    var seq=await Audit(c,tx,Actor(h),"edit.end",type,id,ct);await tx.CommitAsync(ct);
    await hub.Clients.All.SendAsync("event",new{seq,actor=Actor(h),action="edit.end",type,id},ct);return Results.NoContent();
});
api.MapPut("/demo/cables/{id:long}",async(long id,SaveCable body,HttpContext h,Db db,IHubContext<EventHub> hub,CancellationToken ct)=>{
    await using var c=await db.Open(ct);var actor=Actor(h);
    if(!await Authorized(c,actor,true,ct))return Results.StatusCode(403);
    await using var tx=await c.BeginTransactionAsync(IsolationLevel.ReadCommitted,ct);
    long has=0;
    await using(var cmd=Cmd(c,"SELECT COUNT(*) FROM ogp_edit_lock WHERE entity_type='cable' AND entity_id=@id AND token=@token AND owner_id=@owner AND expires_utc>UTC_TIMESTAMP(6) FOR UPDATE",("@id",id),("@token",body.Token),("@owner",actor))){cmd.Transaction=(MySqlTransaction)tx;has=Convert.ToInt64(await cmd.ExecuteScalarAsync(ct));}
    if(has!=1){await tx.RollbackAsync(ct);return Results.Conflict(new{message="Not lock owner"});}
    var changed=await Exec(c,"UPDATE ogp_demo_cable SET description=@desc,row_version=row_version+1 WHERE id=@id AND row_version=@ver",ct,tx,("@desc",body.Description),("@id",id),("@ver",body.ExpectedVersion));
    if(changed!=1){await tx.RollbackAsync(ct);return Results.Conflict(new{message="Stale version"});}
    await Exec(c,"DELETE FROM ogp_edit_lock WHERE entity_type='cable' AND entity_id=@id AND token=@token",ct,tx,("@id",id),("@token",body.Token));
    var seq=await Audit(c,tx,actor,"cable.update","cable",id,ct);await tx.CommitAsync(ct);
    await hub.Clients.All.SendAsync("event",new{seq,actor,action="cable.update",type="cable",id},ct);
    return Results.Ok(new{version=body.ExpectedVersion+1});
});
api.MapGet("/events",async(HttpContext h,Db db,long? after,CancellationToken ct)=>{
    await using var c=await db.Open(ct);if(!await Authorized(c,Actor(h),false,ct))return Results.StatusCode(403);
    var list=new List<object>();
    await using var cmd=Cmd(c,"SELECT id,happened_utc,actor_id,action_code,entity_type,entity_id FROM ogp_audit_event WHERE entity_type NOT IN ('authentication','administration','account_administration') AND id>@after ORDER BY id LIMIT 200",("@after",after??0));
    await using var r=await cmd.ExecuteReaderAsync(ct);
    while(await r.ReadAsync(ct))list.Add(new{id=r.GetInt64(0),utc=r.GetDateTime(1),actor=r.GetString(2),action=r.GetString(3),entityType=r.GetString(4),entityId=r.GetInt64(5)});
    return Results.Ok(list);
});
app.MapHub<EventHub>("/hubs/events");
app.Run();

static class ProjectSql {
public static string Actor(HttpContext h)=>(string)h.Items["actor"]!;
public static bool ValidType(string t)=> t is "cable" or "equipement" or "troncon";
public static async Task<bool> Authorized(MySqlConnection c,string id,bool edit,CancellationToken ct)=>
    await Scalar(c,$"SELECT COUNT(*) FROM ogp_permission p JOIN ogp_identity i ON i.id=p.identity_id WHERE i.enabled=1 AND p.identity_id=@id AND {(edit?"can_edit":"can_read")}=1",ct,("@id",id))==1;
public static MySqlCommand Cmd(MySqlConnection c,string sql,params (string,object)[] args){var cmd=new MySqlCommand(sql,c);foreach(var (k,v) in args)cmd.Parameters.AddWithValue(k,v);return cmd;}
public static async Task<long> Scalar(MySqlConnection c,string sql,CancellationToken ct,params (string,object)[] args){await using var cmd=Cmd(c,sql,args);return Convert.ToInt64(await cmd.ExecuteScalarAsync(ct));}
public static async Task<int> Exec(MySqlConnection c,string sql,CancellationToken ct,params (string,object)[] args)=>await Exec(c,sql,ct,null,args);
public static async Task<int> Exec(MySqlConnection c,string sql,CancellationToken ct,System.Data.Common.DbTransaction? tx,params (string,object)[] args){await using var cmd=Cmd(c,sql,args);if(tx!=null)cmd.Transaction=(MySqlTransaction)tx;return await cmd.ExecuteNonQueryAsync(ct);}
public static async Task<long> Audit(MySqlConnection c,System.Data.Common.DbTransaction tx,string actor,string action,string type,long id,CancellationToken ct){await Exec(c,"INSERT INTO ogp_audit_event(actor_id,action_code,entity_type,entity_id) VALUES(@a,@c,@t,@id)",ct,tx,("@a",actor),("@c",action),("@t",type),("@id",id));await using var cmd=Cmd(c,"SELECT LAST_INSERT_ID()");cmd.Transaction=(MySqlTransaction)tx;return Convert.ToInt64(await cmd.ExecuteScalarAsync(ct));}
}
record ChallengeRequest(string IdentityId);
record CompleteRequest(string IdentityId,string Nonce,string Signature,string? LicenseJson=null);
record LeaseRequest(string Token);
record SaveCable(string Token,long ExpectedVersion,string Description);
sealed class Db(string connection){public async Task<MySqlConnection> Open(CancellationToken ct){var c=new MySqlConnection(new MySqlConnectionStringBuilder(connection) { GuidFormat=MySqlGuidFormat.None }.ConnectionString);await c.OpenAsync(ct);return c;}}
sealed record AuthSession(string IdentityId,int Version,string SessionId);
sealed class TokenService(byte[] secret){
    public string Mint(string id,int version,string sessionId,DateTimeOffset expires){
        var expiry=expires.ToUnixTimeSeconds();
        var payload=Convert.ToBase64String(Encoding.UTF8.GetBytes($"v2|{id}|{version}|{expiry}|{sessionId}"));
        var sig=Convert.ToBase64String(HMACSHA256.HashData(secret,Encoding.ASCII.GetBytes(payload)));
        return payload+"."+sig;
    }
    public AuthSession? Validate(string token){
        try{
            var p=token.Split('.');if(p.Length!=2)return null;
            var expected=HMACSHA256.HashData(secret,Encoding.ASCII.GetBytes(p[0]));
            if(!CryptographicOperations.FixedTimeEquals(expected,Convert.FromBase64String(p[1])))return null;
            var s=Encoding.UTF8.GetString(Convert.FromBase64String(p[0])).Split('|');
            if(s.Length!=5 || s[0]!="v2" || !int.TryParse(s[2],out var version) || version<1 || !long.TryParse(s[3],out var expiry) || expiry<=DateTimeOffset.UtcNow.ToUnixTimeSeconds() || s[4].Length!=32)return null;
            return new AuthSession(s[1],version,s[4]);
        }catch{return null;}
    }
}
sealed class EventHub(TokenService tokens,Db db,ConnectionRegistry registry,CompanyLicensing licensing):Hub{
    public override async Task OnConnectedAsync(){
        var token=Context.GetHttpContext()?.Request.Query["access_token"].ToString()??"";
        var session=tokens.Validate(token);
        if(session is null){Context.Abort();return;}
        await using var c=await db.Open(Context.ConnectionAborted);
        if(!await licensing.SessionValid(c,session,Context.ConnectionAborted) || !await Authorized(c,session.IdentityId,false,Context.ConnectionAborted)){Context.Abort();return;}
        registry.Add(Context,token);
        await base.OnConnectedAsync();
    }
    public override async Task OnDisconnectedAsync(Exception? exception){registry.Remove(Context.ConnectionId);await base.OnDisconnectedAsync(exception);}
}
