using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;
using static ProjectSql;

sealed class ConnectionRegistry(Db db, TokenService tokens, LicenseState license) : BackgroundService
{
    private readonly ConcurrentDictionary<string,(HubCallerContext Context,string Token)> clients = new();
    public void Add(HubCallerContext context,string token) => clients[context.ConnectionId]=(context,token);
    public void Remove(string id) => clients.TryRemove(id,out _);
    protected override async Task ExecuteAsync(CancellationToken stop)
    {
        using var timer=new PeriodicTimer(TimeSpan.FromSeconds(2));
        try {
            while(await timer.WaitForNextTickAsync(stop)) {
                if(clients.IsEmpty) continue;
                try {
                    var rights=license.Read();
                    if(!rights.Valid){CloseAll();continue;}
                    await using var c=await db.Open(stop);
                    if(await Scalar(c,"SELECT COUNT(*) FROM ogp_identity WHERE enabled=1",stop)>rights.Seats){CloseAll();continue;}
                    foreach(var pair in clients) {
                        var session=tokens.Validate(pair.Value.Token);
                        if(session is null || !await SessionValid(c,session,stop) || !await Authorized(c,session.IdentityId,false,stop)) {
                            pair.Value.Context.Abort();Remove(pair.Key);
                        }
                    }
                } catch(OperationCanceledException) when(stop.IsCancellationRequested){break;}
                  catch { CloseAll(); }
            }
        } catch(OperationCanceledException) when(stop.IsCancellationRequested){}
        finally {CloseAll();}
    }
    private void CloseAll(){foreach(var pair in clients){pair.Value.Context.Abort();Remove(pair.Key);}}
}
