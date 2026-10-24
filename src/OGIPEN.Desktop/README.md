# Version courante : serveur d’entreprise autonome 0.4.10

Le client se connecte directement à l’API de l’entreprise. Le relais WordPress est retiré. Voir [la version 0.4.10](../../server/linux/docs/company-server-v0.4.10.md) pour les adresses, la confiance au certificat par serveur, le paquet et les limites actuelles. Les anciens modes d’accès ci-dessous sont historiques.

# Connexion Windows v0.4.9

Le client utilise désormais la session Windows, une preuve CNG et une licence poste Ogipen. Voir [le lot v0.4.9](../../server/linux/docs/client-windows-v0.4.9.md) pour la configuration HTTPS, l’enrôlement, les tests et les limites actuelles. Les descriptions historiques ci-dessous ne représentent pas toutes le parcours courant.

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


## Correctif démarrage — 21 octobre 2026

### Blocage du splash (corrigé dans les sources)

La première version appelait `await Task.Delay(...)` après `splash.Show()` mais avant
`Application.Run(...)`. Les continuations du thread graphique pouvaient rester
bloquées faute de boucle de messages WinForms.

Le démarrage utilise désormais `Application.Run(new StartupApplicationContext())`.
Le splash devient la première fenêtre de cette boucle, et les contrôles démarrent
dans son événement `Shown`. Le lancement suit :

1. Lire `%APPDATA%\OGIPEN\clientsettings.json` et, si présent, l'ancien
   `config.ini` situé à côté de l'exécutable (**adresse serveur uniquement**).
2. Tester la disponibilité de l'API HTTPS via `GET /api/v1/health`
   (timeout de 5 secondes) et recevoir l'état `maintenance`.
3. Si disponible, rechercher une mise à jour via
   `GET /api/v1/client/update?version=...` (timeout de 4 secondes).
4. Fermer/masquer le splash et afficher le login.
5. Charger la liste de projets autorisés, puis afficher le MDI.

**L'API serveur n'existe pas encore dans cette branche.** Les contrôles
ne passent donc au vert que si tu configures un service réel répondant à :

```json
{"status":"ok","maintenance":false}
```

En cas de serveur indisponible ou de maintenance, le login affiche l'erreur et
permet de **Retester le serveur**. L'aperçu local reste utilisable sans accès
MySQL. La mise à jour est uniquement *détectée* : aucun package non signé
n'est exécuté ; l'installation sécurisée reste à développer.

### Test du serveur MySQL historique

Si aucune API HTTPS n'est configurée, le client peut vérifier que le port
TCP MySQL est joignable (sans authentification SQL ni lecture de tables).
Le test reprend l'adresse de l'ancien `config.ini` s'il est présent à côté
de l'exécutable, ou les champs suivants dans le JSON utilisateur :

```json
{
  "ApiBaseUrl": "",
  "SiteName": "Chantier",
  "LegacyDatabaseServer": "nom-dns-ou-adresse-du-serveur",
  "LegacyDatabasePort": 3306
}
```

Ce contrôle TCP n'établit **pas** qu'une authentification SQL est possible
ou que `progelec.maintenance` est accessible. Pour reproduire ce dernier
contrôle sans distribuer les identifiants administrateur dans un client,
le serveur OGIPEN devra fournir cet état via l'API.

**Ne copie pas les mots de passe** de l'ancien `config.ini` vers
`clientsettings.json`. L'ancienne configuration Git contient déjà des
secrets en clair qui doivent être révoqués s'ils sont encore valides.

### Pour tester

```powershell
git checkout modernisation-csharp
git pull
dotnet clean OGIPEN.CSharp.sln
dotnet run --project src/OGIPEN.Desktop/OGIPEN.Desktop.csproj
```

Le splash ne doit plus se figer à 5 % et l'écran de connexion doit apparaître,
même sans serveur configuré. La compilation Windows est surveillée dans
GitHub Actions ; elle n'a pas encore été confirmée dans le poste de
développement utilisé pour ces modifications.
