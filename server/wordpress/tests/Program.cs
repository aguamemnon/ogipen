using System.Security.Cryptography;
using System.Text.Json;
using OGIPEN.Core.Security;

var mode=args[0];
if(mode is "request" or "renew"){
    using var key=ECDsa.Create(ECCurve.NamedCurves.nistP256);
    if(mode=="renew")key.ImportPkcs8PrivateKey(File.ReadAllBytes(args[2]),out _);
    else File.WriteAllBytes(args[2],key.ExportPkcs8PrivateKey());
    var request=OfflineLicenseActivation.CreateRequest(key,int.Parse(args[3]),1,RandomNumberGenerator.GetBytes(32));
    File.WriteAllText(args[1],request);
    if(!OfflineLicenseActivation.TryParseRequest(request,out _,out _,out _,out _))throw new Exception("Generated request rejected by client parser");
    Console.WriteLine("CLIENT_REQUEST_GENERATED_AND_VERIFIED");
}else if(mode=="verify"){
    using var key=ECDsa.Create();key.ImportPkcs8PrivateKey(File.ReadAllBytes(args[2]),out _);
    var json=File.ReadAllText(args[1]);var pub=File.ReadAllText(args[3]);var software=int.Parse(args[5]);
    var results=new List<object>();
    void Check(string name,bool ok){results.Add(new {test=name,pass=ok});if(!ok)throw new Exception(name);}
    bool Verify(string text,ECDsa device,string issuer,int sw,int[] modules,DateTimeOffset? now=null)=>OfflineLicenseActivation.TryImport(text,device,pub,issuer,sw,"ogipen",1,modules,out _,now);
    Check("wordpress_license_imports_in_existing_client",Verify(json,key,args[4],software,[]));
    using var other=ECDsa.Create(ECCurve.NamedCurves.nistP256);
    Check("other_device_rejected",!Verify(json,other,args[4],software,[]));
    Check("wrong_software_rejected",!Verify(json,key,args[4],software+1,[]));
    Check("wrong_issuer_rejected",!Verify(json,key,"https://invalid.example",software,[]));
    Check("unlicensed_module_rejected",!Verify(json,key,args[4],software,[999999]));
    Check("expired_license_rejected",!Verify(json,key,args[4],software,[],DateTimeOffset.UtcNow.AddDays(2)));
    using var d=JsonDocument.Parse(json);var token=d.RootElement.GetProperty("token").GetString()!;
    var parts=token.Split('.');parts[1]=(parts[1][0]=='A'?"B":"A")+parts[1][1..];
    var tampered=JsonSerializer.Serialize(new {type="OGIPEN-OFFLINE-LICENSE",version=1,token=string.Join('.',parts)});
    Check("tampered_claims_rejected",!Verify(tampered,key,args[4],software,[]));
    Check("malformed_license_rejected",!Verify("{}",key,args[4],software,[]));
    Console.WriteLine(JsonSerializer.Serialize(results,new JsonSerializerOptions{WriteIndented=true}));
}else throw new Exception("Unknown mode");
