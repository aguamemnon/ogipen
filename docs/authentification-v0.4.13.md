# Ogipen 0.4.13 — login modifiable et mot de passe

Cette version applique la demande utilisateur du 25 octobre 2026 et remplace la règle précédente qui imposait exclusivement la session OS courante sans saisie de mot de passe.

## Utilisation

L’écran de connexion préremplit le login avec le compte Windows courant. Le champ reste modifiable et le mot de passe, masqué, doit être saisi à chaque connexion. Le changement d’utilisateur ferme la session précédente puis revient à cet écran.

- **Windows / Active Directory** : saisir le login Windows/AD et son mot de passe Windows. Le PIN Windows Hello ne remplace pas ce mot de passe. Windows valide les identifiants avec `LogonUserW` ; le mot de passe Windows n’est jamais envoyé au serveur Ogipen. L’identité retenue est le SID du compte effectivement authentifié, qui peut différer du compte de la session OS courante.
- **Compte interne Ogipen** : saisir le login Ogipen et son mot de passe Ogipen. Le serveur vérifie le mot de passe via HTTPS, à partir d’un dérivé PBKDF2-SHA256 salé. Aucun mot de passe en clair n’est stocké ou journalisé.

Le poste doit rester activé avec une licence valide. Le changement de compte dans le logiciel ne provoque pas une nouvelle activation WordPress. Le serveur vérifie séparément la clé du poste licencié, le compte choisi, l’entreprise, la licence et les permissions du projet.

## Comptes internes admin et OSSI

Dans le portail de l’entreprise, ouvrir **Comptes Ogipen** (`/?page=accounts`). Les comptes `admin` et `ossi` sont préparés, mais restent désactivés sans mot de passe initial. Choisir leur entreprise, définir un mot de passe d’au moins 12 caractères, choisir les droits de projet éventuels puis enregistrer. Aucun mot de passe prédéfini ou partagé avec le portail PHP n’est utilisé.

Le compte interne peut porter le rôle technique **Utilisateur**, **Administrateur logiciel** ou **OSSI**, et recevoir indépendamment **Aucun accès métier**, **Lecture seule** ou **Lecture et édition** dans le projet de démonstration. Admin/OSSI disposent d’un espace technique et d’un diagnostic serveur autorisé côté API. Ce premier espace technique est consultatif ; il ne constitue pas encore l’ensemble des fonctions d’administration du futur logiciel.

Une réinitialisation de mot de passe ou une modification du compte invalide ses anciennes sessions. Le portail protège les opérations par session administrateur, CSRF, verrou et audit transactionnel. Les mots de passe ne sont pas réaffichés après erreur. Les comptes Windows restent gérés dans **Utilisateurs** et les comptes internes dans **Comptes Ogipen**.

## Protocole et compatibilité

Les routes `/auth/v3/challenge` et `/auth/v3/complete` lient le défi à l’URL du serveur, au type de compte, à l’identité choisie et au poste. Le poste signe le défi avec sa clé existante. Pour Windows, la clé de l’identité authentifiée signe aussi ce défi. Pour un compte interne, l’API exige son mot de passe. Les nonces sont à usage unique et expirent après 90 secondes ; les sessions durent au plus 15 minutes, plafonnées par les licences.

Les anciens endpoints de connexion sans mot de passe retournent HTTP 426. **Le client 0.4.13 est nécessaire après cette mise à jour serveur.** L’import de licence, le profil de serveur, la clé CNG et les fichiers `.ogreq`/`.oglic` restent compatibles. Un ancien fichier nominatif reste limité à son attribution et sa clé ; le nouveau fichier poste avec `binding=device` permet de choisir plusieurs comptes autorisés.

L’enregistrement du poste est conservé dans `ogp_device`, séparément des utilisateurs. Les comptes internes sont dans `ogp_app_account` et le contrôle des tentatives dans `ogp_login_attempt`. Les sessions retiennent le poste et la méthode de connexion. Désactiver un utilisateur ne désactive pas implicitement le poste pour les autres comptes.

## Limites précises

La validation d’un mot de passe Windows relève de Windows sur le poste. Le serveur Ogipen vérifie la preuve de clé et l’enrôlement ; il ne vérifie pas indépendamment le mot de passe Windows et le client Windows fait partie du périmètre de confiance. Aucun service Kerberos/AD n’a été ajouté sur Linux.

Pour un autre compte Windows, sa clé doit déjà avoir été enrôlée et son profil CNG doit être accessible sous le jeton authentifié. Un profil non chargé ou une clé absente provoque un refus explicite ; le logiciel ne contourne pas cette protection. Le fonctionnement AD déconnecté dépend des règles et capacités de Windows. Aucun mode « accepter le mot de passe sans le vérifier » n’est ajouté.

Ce lot concerne le client Windows. Le parcours PAM/SSSD d’un futur client Linux reste à développer.

Références techniques : [LogonUserW](https://learn.microsoft.com/windows/win32/api/winbase/nf-winbase-logonuserw), [profils utilisateurs locaux et chargement du profil](https://learn.microsoft.com/en-us/windows/win32/shell/local-user-profiles).
