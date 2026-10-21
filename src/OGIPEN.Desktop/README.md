# OGIPEN Desktop — premier socle C# WinForms

Projet **.NET 10 Windows Forms** fondé sur les écrans `SplashScreen.vb`,
`LoginForm.vb`, `FormSelectProject.vb` et `FormMain.vb` de l'application d'origine.

## Démarrage sous Windows

Installer le SDK .NET 10 (avec la charge WinForms), puis :

```powershell
dotnet run --project src/OGIPEN.Desktop/OGIPEN.Desktop.csproj
```

Ou ouvrir le `.csproj` dans Visual Studio, démarrer et choisir
« Aperçu sans serveur ». L'aperçu contient uniquement des données fictives.

## Connexion serveur

Le serveur d'authentification **n'est pas encore implémenté**.
Un client d'API HTTPS existe mais aucune connexion MySQL directe n'est permise.

Configurer le fichier utilisateur suivant (sans mot de passe !) :

`%APPDATA%\\OGIPEN\\clientsettings.json`

```json
{
  "ApiBaseUrl": "https://ogipen.example.test/",
  "SiteName": "Site principal"
}
```

Contrat attendu : `POST /api/v1/auth/login`, corps JSON
`{"username":"...","password":"..."}`, réponse JSON
`{"accessToken":"...","displayName":"...","projects":[{"id":"...","name":"...","role":"..."}]}`.
Cette API devra implémenter AD/SSO, contrôle du compte, droits par projet et
contrôle d'autorisation **pour chaque opération**. Une liste de projets dans
une réponse de login ne remplace jamais un contrôle côté serveur.

## Périmètre réalisé

- Splash avec progression et reprise optionnelle de l'image d'origine.
- Formulaire de connexion Windows moderne, appel API HTTPS (contrat préparatoire).
- Sélection des projets fournis par l'API, sans nom de base SQL exposé.
- Fenêtre principale MDI, navigation et état de session.
- Diagnostic maintenance **lecture seule**.
- Aucun compte administrateur statique ni identifiant SQL dans le client.
- Aperçu local sans aucun accès aux bases réelles.

## À intégrer ensuite

API et schéma d'authentification, gestion AD, profils/postes dynamiques,
vérification serveur des projets, licence signée, auto-update signé,
maintenance par défi signé, cache hors ligne chiffré, modules métier VB -> C#.

## Limitation de validation

Les sources n'ont pas été compilées dans l'environnement d'édition : SDK
.NET absent. Vérifier le build sur Windows avant d'envisager une distribution.
Aucun mécanisme d'authentification, mise à jour ou licence n'est simulé en
tant que protection de production. `master` est inchangée.
