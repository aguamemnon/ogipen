using Krypton.Ribbon;
using OGIPEN.Core.Security;
using OGIPEN.Desktop.Forms;
using OGIPEN.Desktop.Infrastructure;
using OGIPEN.Desktop.Models;
using System.Security.Cryptography;
using System.Text;

namespace OGIPEN.Desktop.Smoke;

internal static class Program
{
    // Vérifie que tous les groupes du ruban peuvent être construits. Le crash
    // « Collection can only contain 3 entries » provenait du 4e bouton
    // de l'onglet Affichage. Ce contrôle utilise le vrai MainMdiForm.
    [STAThread]
    private static int Main()
    {
        try
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using var issuer=ECDsa.Create();issuer.ImportFromPem(File.ReadAllText(OfflineLicenseService.PublicKeyFile));
            if(issuer.KeySize!=256)throw new Exception("Clé publique d’émetteur invalide.");
            using var profiles=new ServerProfilesForm(new ClientConfiguration());
            var session = UserSession.Preview();
            using var main = new MainMdiForm(session, session.Projects[0],
                new ClientConfiguration());

            var ribbon = main.Controls.OfType<KryptonRibbon>().Single();
            if (ribbon.RibbonTabs.Count != 7)
                throw new Exception("Nombre inattendu d'onglets dans le ruban.");
            if (!ribbon.RibbonFileAppButton.FormCloseBoxVisible)
                throw new Exception("La croix de fermeture du MainForm est masquée.");
            if (!main.ControlBox || !main.CloseBox)
                throw new Exception("Les boutons Windows de fermeture sont désactivés.");
            var previewScope = ProjectScope.Open(session, session.Projects[0]);
            if (previewScope.Can(ProjectPermissions.CableRead))
                throw new Exception("L'aperçu local ne doit accorder aucun droit métier.");
            var authorized = UserSession.FromReply(new LoginReply
            {
                AccessToken = "jeton-de-test",
                DisplayName = "Technicien de test",
                Projects = new List<ProjectAccess>
                {
                    new()
                    {
                        Id = "projet-a",
                        Name = "Projet A",
                        Role = "Technicien",
                        Permissions = new List<string> { ProjectPermissions.CableRead }
                    }
                }
            });
            var scope = ProjectScope.Open(authorized, authorized.Projects[0]);
            if (!scope.Can(ProjectPermissions.CableRead) ||
                 scope.Can(ProjectPermissions.ProgressWrite))
                throw new Exception("Les permissions ne sont pas isolées par projet.");
            try
            {
                ProjectScope.Open(authorized, new ProjectAccess
                {
                    Id = "projet-b",
                    Name = "Projet non attribué"
                });
                throw new Exception("Un projet extérieur à la session a été accepté.");
            }
            catch (UnauthorizedAccessException)
            {
                // Refus attendu.
            }

            var requestFile = Path.Combine(Path.GetTempPath(),
                "ogipen-offline-smoke-" + Guid.NewGuid().ToString("N") + ".ogreq");
            try
            {
                OfflineLicenseService.ExportRequest(requestFile, 42);
                var contents = File.ReadAllText(requestFile);
                if (!OfflineLicenseActivation.TryParseRequest(contents,
                    out int software, out int major, out _, out var fingerprint) ||
                    software != 42 || major != 1 || fingerprint.Length != 64)
                {
                    throw new Exception("La demande hors ligne CNG n'a pas pu être validée.");
                }
                var identity=WindowsSessionIdentity.Current();
                if(!identity.IdentityId.StartsWith("win-sid:S-1-",StringComparison.Ordinal))throw new Exception("L’identité ne provient pas du SID Windows courant.");
                var audience=new Uri("https://site/ogipen/client-api/");
                var text="OGIPEN-AUTH-v2:"+audience.AbsoluteUri+":"+identity.IdentityId+":"+Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
                var proof=OfflineLicenseService.SignChallenge(text,audience);
                using var request=System.Text.Json.JsonDocument.Parse(contents);
                var publicKey=request.RootElement.GetProperty("public_key_spki").GetString()!.Replace('-','+').Replace('_','/');
                using var verifier=ECDsa.Create();verifier.ImportSubjectPublicKeyInfo(Convert.FromBase64String(publicKey.PadRight((publicKey.Length+3)/4*4,'=')),out _);
                if(!verifier.VerifyData(Encoding.UTF8.GetBytes(text),proof,HashAlgorithmName.SHA256,DSASignatureFormat.IeeeP1363FixedFieldConcatenation))throw new Exception("La preuve CNG ne correspond pas à la demande d’activation.");
                try{OfflineLicenseService.SignChallenge(text.Replace(identity.IdentityId,"other-session",StringComparison.Ordinal),audience);throw new Exception("Une autre session a été signée.");}catch(InvalidOperationException){}
                using var native=CngKey.Open("OGIPEN_Offline_P256_v1",CngProvider.MicrosoftSoftwareKeyStorageProvider,CngKeyOpenOptions.UserKey);
                if(native.ExportPolicy!=CngExportPolicies.None)throw new Exception("La clé CNG autorise l’export privé.");
                using var login=new LoginForm(new ClientConfiguration(),null,new(false,false,"Test local"));
                IEnumerable<Control> Descendants(Control c)=>c.Controls.Cast<Control>().SelectMany(x=>new[]{x}.Concat(Descendants(x)));
                if(Descendants(login).OfType<TextBox>().Any())throw new Exception("La connexion contient encore une saisie d’identifiants.");
                Console.WriteLine("OK — SID courant, preuve CNG liée au serveur, refus autre session, export privé désactivé et connexion sans mot de passe.");
            }
            finally
            {
                if (File.Exists(requestFile)) File.Delete(requestFile);
            }
            Console.WriteLine("OK — Demande d'activation générée avec une clé Windows CNG.");
            Console.WriteLine("OK — MainForm, profils serveur, ruban Krypton et 7 onglets construits. Runtime : "+System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription);
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("ÉCHEC du contrôle UI : " + ex);
            return 1;
        }
    }
}
