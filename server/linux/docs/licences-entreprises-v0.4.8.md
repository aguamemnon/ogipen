# Ogipen v0.4.8 — licences et sessions par entreprise

Livraison du 25 octobre 2026. API et portail installés sur ct_Mysql, portail sur `http://192.168.2.216:8080/`. Cette livraison remplace la simple déclaration v0.4.7 par des contrôles exécutés dans l'API.

## Comportement livré

Chaque entreprise participante importe sa preuve serveur WordPress pour l'identifiant de cette instance. Le serveur vérifie la signature avec la clé publique WordPress déjà épinglée, le logiciel, la version majeure, l'émetteur, l'expiration et la référence commerciale. Une même licence ne peut pas être affectée par le portail à deux entreprises de ce projet. Changer la référence déclarée efface la preuve précédente.

La rubrique Entreprises permet maintenant d'appliquer le mode souhaité, sous réserve de disposer d'une preuve serveur valide par entreprise préparée. La configuration distingue toujours le mode souhaité du mode effectif. Un mode effectif mono-entreprise refuse les connexions si plusieurs entreprises disposent de preuves serveur importées. Aucun passage automatique en multi-entreprise.

Les utilisateurs du projet sont affectés à une entreprise et à un identifiant de bénéficiaire SLM. Le contrôle de quota se fait par entreprise, selon sa preuve signée ; les places ne sont pas additionnées entre entreprises. La paire entreprise/bénéficiaire est unique, y compris pour les identités inactives : il faut modifier l'identité existante plutôt que réattribuer silencieusement le bénéficiaire à une autre identité.

Le protocole de connexion est désormais :

1. `POST /auth/challenge` avec `identityId` pour un utilisateur actif rattaché à une entreprise licenciée.
2. Signature du texte reçu par la clé privée du poste, format existant ECDSA P-256/SHA-256 P1363.
3. `POST /auth/complete` avec `identityId`, `nonce`, `signature` et **`licenseJson`**, contenu du fichier poste `.oglic` émis par WordPress.
4. Vérification de la signature WordPress du fichier poste, de sa clé de poste, du bénéficiaire, du logiciel, de la version, de l'émetteur et des dates. La référence commerciale du fichier poste doit être celle de la preuve serveur de son entreprise.
5. Session signée v2, limitée à 15 minutes et à la plus proche expiration serveur/poste. Le contexte est conservé dans `ogp_auth_session` ; les anciens jetons sans liaison licence ne sont plus acceptés.

Chaque accès API et connexion SignalR relit la liaison entreprise/utilisateur et vérifie les preuves signées, le quota, l'état et la révision d'identité. Les droits de lecture/édition restent dans la base du projet. Les connexions SignalR déjà ouvertes sont revérifiées toutes les deux secondes ; une révocation n'est donc pas instantanée. Un défaut d'une entreprise ne coupe pas les sessions d'une autre entreprise valide.

`GET /api/session` renvoie le contexte propre à la session. `GET /api/modules/{id}/access` vérifie l'intersection des modules signés serveur/poste et la permission de lecture du projet. Les routes existantes de démonstration, de verrous et d'événements utilisent le socle Ogipen ; les futurs traitements métier Étude/Rapport/Chantier devront appeler ce contrôle de module dans leurs propres opérations. Ces traitements métier ne sont pas implémentés par cette livraison.

La vérification des fichiers poste réutilise le code existant `src/OGIPEN.Core/Security/OfflineLicenseActivation.cs`, lié dans le projet API. L'archive autonome contient une copie de secours identique. `CompanyLicensing` applique les contrôles d'intégration et ne reçoit aucun booléen de confiance du client. La classe de politique préparatoire v0.4.7 reste séparée ; elle n'est pas présentée comme un filtre exécuté dans l'API.

## Portail et données

- Entreprises : import `.oglic` serveur, places occupées/autorisées, modules signés, mode souhaité/effectif, application après vérification, audit et révisions de formulaires.
- Utilisateurs : sélection d'entreprise et bénéficiaire SLM, quota propre à l'entreprise ; modification de liaison, de clé ou de droits révoque les anciennes sessions par changement de révision.
- Licence : distingue le diagnostic de l'activation initiale de l'instance et les licences d'entreprises utilisées par l'API. Dès qu'une preuve entreprise existe, l'ancien import global refuse les renouvellements et renvoie vers Entreprises.
- Migration additive : `effective_mode`, `server_license_json`, `company_id`, `license_beneficiary_id`, index unique de bénéficiaire par entreprise, nouvelle table `ogp_auth_session`. Les ALTER conditionnels sont dans `prepare-db.py` ; le fichier SQL crée la table de sessions. Le compte API reçoit SELECT sur les tables de collaboration et SELECT/INSERT/DELETE sur les sessions. Aucun utilisateur ni entreprise réel n'est créé par migration.

Le serveur réel reste en mode mono-entreprise avec **zéro entreprise et zéro utilisateur inscrit** lors du déploiement. Aucun nom commercial ni bénéficiaire vérifié n'a été inventé. La licence initiale demeure inchangée ; WordPress reste le seul émetteur et sa clé privée n'a pas quitté WordPress.

## Validation

94 contrôles réussis : 42 contrôles de suite API (dont un contrôle de réussite de la suite PHP), 18 scénarios PHP/MySQL et 34 contrôles HTTP sur 8080 et le proxy HTTPS. Compilation .NET 10 réussie ; syntaxe des 12 fichiers PHP du lot vérifiée.

Les tests API exécutent les vrais endpoints et le hub sur `127.0.0.1:5089`, avec une base distincte `ogp_v048_selftest`, des entreprises fictives A/B et un émetteur de test épinglé uniquement dans ce processus. A et B lisent le même projet avec des licences différentes ; les tests refusent l'emprunt de modules/licence, les mauvais bénéficiaires/postes, les signatures étrangères, le rejeu du challenge, les anciennes sessions, les expirations et les dépassements de quota. Ils vérifient qu'une entreprise invalide est coupée sans couper l'autre, y compris sur SignalR. Les tests PHP couvrent les imports, le basculement, les quotas, l'affectation et le rollback en cas d'échec d'audit.

Le processus, la base isolée et les clés de test sont supprimés à la fin. Ces scénarios ne prétendent pas qu'une deuxième licence commerciale réelle a été émise par WordPress : l'interopérabilité avec les signatures WordPress a été validée dans le lot v0.4.6. Le processus réel garde sa clé publique WordPress d'origine.

Le binaire installé correspond au binaire testé : SHA-256 `b62847547f2ec9fe9420d78c3bfc92d0a60c9305c8b8ef35a26ff9955dc22037`. Le contrôle `/health` installé répond version `0.4.8-test`, mode `single`, `licensedCompanies: 0`.

Échecs rencontrés et corrigés : des éditions locales ont été refusées par les outils de patch/PowerShell avant écriture ; une première exécution PHP isolée manquait des deux bibliothèques de licence inchangées, qui ont été copiées dans le dossier de test ; le premier contrôle HTTP après redémarrage est arrivé avant l'écoute de Kestrel, puis le contrôle suivant et les 34 contrôles HTTP ont réussi. Aucun échec de test restant.

## Limites et suite

- Le client Windows existant utilise encore son ancien chemin de connexion ; il n'a pas été modifié ni livré dans ce lot. Il faut raccorder sa clé locale et sa licence importée au challenge API et aux profils serveur.
- L'enrôlement approuvé est administratif. La preuve cryptographique n'atteste pas encore la session OS Windows SAM/AD ou Linux PAM/SSSD ; le lien au SID et le parcours d'approbation automatique restent à développer.
- La base est toujours le projet prototype `ogp_test_001`. Les droits restent lecture/édition, sans rôles personnalisés complets ni restrictions de données par lot. Tous les participants ayant lecture voient les données communes du prototype ; le portail le précise. Il n'y a pas encore de provisionneur complet de projets ni de routage multi-projet.
- Un utilisateur ne possède qu'une affectation entreprise dans ce prototype. La sélection entre plusieurs appartenances approuvées pour une même personne reste à développer.
- Le modèle actuel est une place/utilisateur lié à une installation nominative, comme le lot hors ligne précédent. Les modèles site, multi-installation et quotas de postes indépendants ne sont pas ajoutés ici.
- Une révocation WordPress d'un fichier déjà exporté ne se propage pas instantanément sur un réseau isolé. Le serveur applique l'expiration signée et permet la désactivation locale.
- HTTPS direct 8080 reste reporté à la demande de l'utilisateur ; le proxy HTTPS existant est conservé.

## Sauvegarde et exploitation

Sauvegardes ct_Mysql : `/root/ogipen-v048/files-before.tgz`, `/root/ogipen-v048/pre-install-current.tgz`, `/root/ogipen-v048/project-before.sql`. Seuls `ogipen-api` et `ogipen-admin` ont été redémarrés. MySQL conserve le PID 243 ; Nginx, WordPress, Proxmox et les autres applications ne sont pas modifiés.

Le retour arrière nécessite de restaurer les fichiers API/portail depuis la sauvegarde et de redémarrer uniquement ces deux services. Conserver les colonnes et tables additives évite de perdre les affectations éventuellement saisies après livraison. Un retour à l'ancienne API supprime ses nouvelles protections de licence : ne pas le faire pendant une exploitation multi-entreprise. Aucun exercice de restauration n'a été effectué.

Les scripts de migration et de test sont spécifiques à ce serveur et lisent les accès existants dans des fichiers protégés, sans les afficher. Ils ne constituent pas encore l'installateur portable final.
