using System.Net.Sockets;
using System.Text.Json;

namespace OGIPEN.Desktop.Infrastructure;

public sealed record ServerPreflightResult(bool ApiAvailable, bool Maintenance, string Message);

/// <summary>
/// Précontrôles issus du démarrage VB : présence du serveur, état maintenance,
/// puis information de mise à jour. Aucun accès direct MySQL ni mot de passe
/// administrateur embarqué : la lecture de progelec.maintenance doit être
/// assurée par l'API serveur GET /health.
/// </summary>
public static class StartupChecks
{
    public static async Task<ServerPreflightResult> CheckServerAsync(
        ClientConfiguration config, Uri? endpoint, CancellationToken cancellationToken)
    {
        if (endpoint is not null)
        {
            try
            {
                using var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                timeout.CancelAfter(TimeSpan.FromSeconds(5));
                using var http = new HttpClient
                {
                    BaseAddress = endpoint,
                    Timeout = TimeSpan.FromSeconds(6)
                };
                using var response = await http.GetAsync(
                    "health", HttpCompletionOption.ResponseHeadersRead, timeout.Token);

                // L'endpoint de contrôle doit renvoyer un JSON, pas une page HTML.
                using var stream = await response.Content.ReadAsStreamAsync(timeout.Token);
                using var doc = await JsonDocument.ParseAsync(
                    stream, cancellationToken: timeout.Token);
                if (doc.RootElement.ValueKind != JsonValueKind.Object)
                    return new(false, false, "Réponse de contrôle serveur invalide.");

                bool maintenance = doc.RootElement.TryGetProperty("maintenance", out var flag)
                    && flag.ValueKind == JsonValueKind.True;
                string? status = doc.RootElement.TryGetProperty("status", out var state)
                    && state.ValueKind == JsonValueKind.String
                    ? state.GetString() : null;

                if (maintenance)
                    return new(false, true, "Serveur en maintenance — accès métier bloqué.");

                if (response.IsSuccessStatusCode &&
                    (string.Equals(status, "ok", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(status, "healthy", StringComparison.OrdinalIgnoreCase)))
                    return new(true, false, "Serveur disponible, état maintenance OK.");

                return new(false, false, "Service de contrôle serveur non opérationnel.");
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                return new(false, false, "Délai de connexion au serveur dépassé (5 s).");
            }
            catch (HttpRequestException)
            {
                return new(false, false, "Serveur HTTPS inaccessible ou certificat non valide.");
            }
            catch (JsonException)
            {
                return new(false, false, "Le contrôle serveur ne renvoie pas de JSON valide.");
            }
            catch (IOException)
            {
                return new(false, false, "Impossible de lire la réponse du serveur.");
            }
        }

        // Compatibilité de diagnostic avec l'ancien config.ini.
        // Il s'agit uniquement d'un test TCP ; pas d'authentification SQL.
        if (!string.IsNullOrWhiteSpace(config.LegacyDatabaseServer))
        {
            try
            {
                using var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                timeout.CancelAfter(TimeSpan.FromSeconds(4));
                using var tcp = new TcpClient();
                await tcp.ConnectAsync(
                    config.LegacyDatabaseServer, config.LegacyDatabasePort, timeout.Token);
                return new(false, false,
                    "Serveur MySQL joignable (TCP), API d'authentification non configurée.");
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                return new(false, false, "Ancien serveur MySQL injoignable (4 s).");
            }
            catch (SocketException)
            {
                return new(false, false, "Ancien serveur MySQL inaccessible sur le réseau.");
            }
        }

        return new(false, false, "Serveur non configuré — aperçu local disponible.");
    }

    public static async Task<string> CheckUpdateAsync(
        Uri endpoint, CancellationToken cancellationToken)
    {
        // Découverte seulement. Aucun package n'est exécuté sans signature valide.
        try
        {
            using var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            timeout.CancelAfter(TimeSpan.FromSeconds(4));
            using var http = new HttpClient { BaseAddress = endpoint };
            string version = Uri.EscapeDataString(Application.ProductVersion);
            using var response = await http.GetAsync(
                "api/v1/client/update?version=" + version,
                HttpCompletionOption.ResponseHeadersRead, timeout.Token);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return "Aucune mise à jour signalée.";
            if (response.IsSuccessStatusCode)
                return "Mise à jour signalée — installation non encore intégrée.";
            return "Vérification des mises à jour non disponible.";
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            return "Recherche des mises à jour : délai dépassé, démarrage maintenu.";
        }
        catch (HttpRequestException)
        {
            return "Service de mise à jour indisponible, démarrage maintenu.";
        }
    }
}
