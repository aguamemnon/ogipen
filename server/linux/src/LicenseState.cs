using System.Text.Json;
using Ogipen.Licensing;

sealed class LicenseState
{
    public static string PublicKeyPath => Environment.GetEnvironmentVariable("OGIPEN_LICENSE_PUBLIC_KEY") ?? "/etc/ogipen/licensing/public.pem";
    public ServerGrant? Verify(string json,long expectedLicence)
    {
        try {
            if(json.Length>65536 || expectedLicence<1)return null;
            using var doc=OgipenLicenseVerifier.Verify(json,File.ReadAllText(PublicKeyPath));
            var p=doc.RootElement;
            if(p.GetProperty("subject_type").GetString()!="server" ||
                p.GetProperty("subject_id").GetString()!=Environment.GetEnvironmentVariable("OGIPEN_SERVER_ID") ||
                p.GetProperty("software_id").GetInt32().ToString()!=Environment.GetEnvironmentVariable("OGIPEN_SOFTWARE_ID") ||
                p.GetProperty("major_version").GetInt32()!=1 ||
                p.GetProperty("issuer").GetString()!=Environment.GetEnvironmentVariable("OGIPEN_LICENSE_ISSUER") ||
                p.GetProperty("license_id").GetString()!="slmms:"+expectedLicence ||
                p.GetProperty("modules").ValueKind!=JsonValueKind.Array)return null;
            var modules=new HashSet<int>();
            foreach(var v in p.GetProperty("modules").EnumerateArray()){int m=v.GetInt32();if(m<1 || modules.Count>=200)return null;modules.Add(m);}
            int seats=p.GetProperty("seats").GetInt32();if(seats<1 || seats>100000)return null;
            var expires=DateTimeOffset.Parse(p.GetProperty("expires_utc").GetString()!,System.Globalization.CultureInfo.InvariantCulture);
            return new(expectedLicence,p.GetProperty("software_id").GetInt32(),seats,expires,modules);
        }catch{return null;}
    }
    public (bool Valid, int Seats) Read()
    {
        try {
            var path = Environment.GetEnvironmentVariable("OGIPEN_LICENSE_PATH") ?? "/var/lib/ogipen/licensing/server.oglic";
            var key = Environment.GetEnvironmentVariable("OGIPEN_LICENSE_PUBLIC_KEY") ?? "/etc/ogipen/licensing/public.pem";
            if (new FileInfo(path).Length > 65536) return (false, 0);
            using var doc = OgipenLicenseVerifier.Verify(File.ReadAllText(path), File.ReadAllText(key));
            var p = doc.RootElement;
            bool bound = p.GetProperty("subject_type").GetString() == "server" &&
                p.GetProperty("subject_id").GetString() == Environment.GetEnvironmentVariable("OGIPEN_SERVER_ID") &&
                p.GetProperty("software_id").GetInt32().ToString() == Environment.GetEnvironmentVariable("OGIPEN_SOFTWARE_ID") &&
                p.GetProperty("major_version").GetInt32() == 1 &&
                p.GetProperty("issuer").GetString() == Environment.GetEnvironmentVariable("OGIPEN_LICENSE_ISSUER") &&
                p.GetProperty("license_id").GetString()!.StartsWith("slmms:") &&
                p.GetProperty("modules").ValueKind == JsonValueKind.Array;
            var seats = p.GetProperty("seats").GetInt32();
            return bound && seats > 0 && seats <= 100000 ? (true, seats) : (false, 0);
        } catch { return (false, 0); }
    }
}
