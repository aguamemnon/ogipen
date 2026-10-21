using System.Net.Http.Json;
using System.Text.Json;
using OGIPEN.Desktop.Models;

namespace OGIPEN.Desktop.Infrastructure;

public sealed class AuthenticationClient : IDisposable
{
    private readonly HttpClient _http;

    public AuthenticationClient(Uri apiBase)
    {
        _http = new HttpClient { BaseAddress = apiBase, Timeout = TimeSpan.FromSeconds(15) };
    }

    // Contrat de la future API : POST /api/v1/auth/login
    // { username, password } -> { accessToken, displayName, projects: [{id,name,role}] }
    // L'API doit réaliser l'authentification AD/locale et le filtrage des projets.
    public async Task<UserSession> SignInAsync(string username, string password, CancellationToken token)
    {
        using var response = await _http.PostAsJsonAsync(
            "api/v1/auth/login", new { username, password }, token);
        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new InvalidOperationException("Identifiant ou mot de passe incorrect.");
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("Compte non autorisé.");
            throw new HttpRequestException("Le serveur d'authentification ne répond pas correctement.");
        }

        var reply = await response.Content.ReadFromJsonAsync<LoginReply>(
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }, token);
        if (reply is null) throw new InvalidOperationException("Réponse serveur vide.");
        return UserSession.FromReply(reply);
    }

    public void Dispose() => _http.Dispose();
}
