# Ogipen v0.4.9 — client Windows et connexion licenciée

Livraison du 25 octobre 2026. Le client Windows utilise maintenant le protocole de l'API, avec licence poste, clé CNG du compte Windows courant et projets autorisés par le serveur. Une archive Windows de test est fournie ; aucun logiciel n'est installé automatiquement sur le poste de l'utilisateur.

## Ce qui change

- Le formulaire de connexion n'accepte plus de nom d'utilisateur ni de mot de passe. L'identifiant envoyé est `win-sid:<SID Windows courant>`. Le serveur doit avoir approuvé le rattachement de cette identité à sa clé publique, à son entreprise et à son bénéficiaire SLM.
- La clé privée est celle du magasin CNG du compte courant, non exportable par l'API normale du fournisseur logiciel Windows. La clé existante est conservée ; une nouvelle clé n'est créée que lors d'un export explicite de demande ou de fiche d'enrôlement. Une connexion ne remplace jamais silencieusement une clé manquante.
- L'activation vérifie le logiciel **ogipen**, identifiant SLM par défaut **405**, distinct de Progelec. La preuve WordPress est relue et vérifiée avant chaque nouvelle connexion. Les imports et la configuration sont écrits de façon atomique.
- Le client vérifie le challenge avant de signer : identité, nonce canonique de 32 octets, durée et adresse HTTPS choisie. Le texte signé v2 contient l'adresse publique de l'API, ce qui évite de signer un challenge destiné à un autre profil serveur. L'API refuse les preuves v1 et celles visant une autre adresse.
- Le client envoie la licence signée avec la preuve de clé, récupère le contexte entreprise/licence/bénéficiaire et les projets, puis vérifie leur cohérence avec sa licence locale. Les redirections HTTP ne sont pas suivies. Les messages d'erreur n'affichent pas les corps de réponse ni les jetons.
- Les profils serveur sont enregistrés dans la configuration utilisateur. Le site est choisi explicitement ; aucun basculement automatique vers un autre profil ou Internet. Les jetons restent en mémoire. Une déconnexion demande la suppression de cette seule session API ; les autres sessions restent valides.
- Le bandeau du logiciel utilise l'expiration réellement vérifiée du fichier poste, et la barre d'état affiche l'entreprise, la licence et la limite de session.

## Accès installé

API publique du site de test : `https://www.trueshield.fr/ogipen/client-api/`.

Le chemin est ajouté uniquement au serveur TLS Nginx 8443 existant, derrière le proxy Apache déjà limité au LAN. Le certificat navigateur existant est conservé. Le port Kestrel 5088 reste en boucle locale. Le portail PHP reste sur `http://192.168.2.216:8080/` ; le chemin API y répond 404. HTTPS direct sur 8080 reste reporté selon la demande précédente.

`GET /api/session` fournit désormais le nom affiché et le projet prototype autorisé, avec seulement ses permissions de lecture/édition effectives. `DELETE /api/session` révoque la session courante. Le serveur exige `OGIPEN_AUTH_AUDIENCE=https://www.trueshield.fr/ogipen/client-api/` ; la même adresse doit être choisie dans le profil client. Changer cette adresse nécessite de mettre à jour serveur et profils.

Les journaux d'accès API Nginx et Apache utilisent un format sans paramètres d'URL ni en-têtes d'authentification. Le chemin API est exclu du journal Apache général ; les autres requêtes WordPress conservent leur journal existant. La journalisation diagnostique ASP.NET était déjà limitée par la version précédente. Les tests de journal utilisent un marqueur public, jamais un vrai jeton.

## Utiliser l'archive Windows

1. Extraire le ZIP puis lancer `OGIPEN.Desktop.exe`. Le runtime Windows Desktop .NET **10.0.13** ou une mise à jour compatible est nécessaire. L'archive est une distribution de test non signée, sans installateur automatique.
2. Dans **Profils serveur**, ajouter le site de test avec l'adresse HTTPS ci-dessus, le sélectionner et retester sa disponibilité. Un exemple de configuration est joint comme référence ; aucun profil de secours n'est activé automatiquement.
3. Depuis la session Windows de l'utilisateur concerné, exporter sa demande `.ogreq` et sa fiche d'enrôlement. La demande `.ogreq` reste sans identité AD/SID ; la fiche séparée contient le SID et la clé publique et doit suivre un circuit approuvé.
4. Dans WordPress SLM Plus, utiliser une vraie licence Ogipen et un bénéficiaire vérifié pour émettre le fichier poste `.oglic`. Préparer dans le portail l'entreprise, sa preuve serveur WordPress pour cette instance et l'utilisateur avec l'identifiant et la clé publique de la fiche, son bénéficiaire et ses droits de projet.
5. Importer le fichier poste dans le client, puis se connecter. La clé privée n'est jamais copiée dans le portail, WordPress ou l'archive.

Le serveur réel reste en mode `single`, avec **0 entreprise licenciée et 0 utilisateur inscrit** au dernier contrôle. Aucune identité ni entreprise réelle n'a été inventée. Une connexion métier réelle attend donc ces affectations et un bénéficiaire WordPress vérifié ; les tests ne les remplacent pas.

La clé publique WordPress approuvée est fournie dans `Assets/SLMMS-Signing-Public.pem`. Empreinte SHA-256 du SPKI : `7c175aa8923d373118683fea3656f929457a66c7f9547d65da61ea1a92316ee9`. Elle correspond à la clé déjà épinglée sur le serveur ; aucune clé privée de signature ne quitte WordPress.

## Validation

- 35 contrôles du client de protocole et des profils : challenges étrangers refusés avant signature, données de session incohérentes refusées, absence de mot de passe et de jeton persistant, choix de site conservé et absence de repli automatique.
- 46 contrôles de suite API sur une base distincte et un émetteur de test, dont les contrôles de fin de suites imbriquées. Ils incluent les refus de preuve v1 et d'adresse étrangère, la séparation des entreprises et la conservation des autres sessions à la déconnexion.
- 4 scénarios du **vrai client C#** contre cette API isolée : vérification du fichier signé, récupération des permissions, lecture d'un câble, puis refus du jeton après déconnexion. Le transport de cette suite est un adaptateur de test vers la boucle locale ; il ne prétend pas tester TLS.
- 18 contrôles PHP/MySQL et 34 contrôles HTTP du portail, sur 8080 et le proxy HTTPS.
- 5 contrôles réseau depuis Windows, sans exception de certificat : certificat et santé API 0.4.9, refus d'accès anonyme, refus d'identité non enrôlée et absence d'API sur HTTP 8080.
- 5 vérifications des journaux d'accès Apache/Nginx : chemin journalisé, marqueur de requête omis et absence de l'API dans le journal général.
- 18 contrôles existants de licences du cœur conservés. Le smoke test Windows construit le vrai formulaire de connexion, les profils et le shell Krypton ; il vérifie le SID courant, une signature par la vraie clé CNG, le refus d'une autre identité, l'export privé désactivé, le fichier public d'émetteur et l'absence de champs de mot de passe. Exécution confirmée sur **.NET 10.0.13**.

La compilation utilise le SDK Windows déjà installé `10.0.100-rc.2.25502.107` ; l'archive publiée cible explicitement les runtimes stables `Microsoft.NETCore.App` et `Microsoft.WindowsDesktop.App` **10.0.13** et ne requiert pas le runtime preview. Aucun SDK ni composant système n'a été remplacé. Les tests UI sont des constructions et contrôles de code, pas une recette visuelle complète ni un test AD distant.

Le binaire API installé et testé a le SHA-256 `f2b14500abf882c1c3f2b7fbb5a82d4223911ae6d506c337003b3b8e8680377a`. Les clés, les fichiers de licence de test et la base temporaire sont supprimés à la fin des scénarios.

## Limites et suite

- L'enrôlement est approuvé administrativement. Le client prend le SID du token Windows courant et utilise le magasin de ce compte ; le serveur vérifie la clé approuvée. Ce n'est pas une attestation distante du domaine AD ou du matériel. Le parcours Linux PAM/SSSD reste à développer.
- Le client obtient maintenant le contexte autorisé, mais les grilles et les modules métier ne chargent pas encore les données réelles via l'API. Les notifications SignalR, le renouvellement d'édition et les modules Étude/Rapport/Chantier restent à raccorder dans le bureau Windows.
- La session dure au plus 15 minutes et peut être plus courte selon les licences. Aucun renouvellement automatique n'est ajouté ici. Une déconnexion hors réseau efface la session locale mais la session serveur reste valable jusqu'à sa limite si sa révocation n'a pas pu être transmise.
- Le serveur reste celui du projet prototype ; provisionnement multi-projet, rôles métier personnalisés, périmètres de données par lot et modèles commerciaux site/multiposte restent des chantiers séparés.
- Le logiciel n'a pas été installé automatiquement, aucune licence réelle supplémentaire n'a été émise et aucun compte réel n'a été marqué vérifié pour faire passer les tests.

## Sauvegardes et incidents corrigés

ct_Mysql : `/root/ogipen-v049/before.tgz`, `/root/ogipen-v049/api-env-before` (0600), `/root/ogipen-v049/nginx-before-logs.conf`. WordPress : `/var/backups/ogipen-api-v049/ssl-before.conf` et `portal-before.conf` (0600). La sauvegarde originale porte sur l'API, Nginx et les seuls réglages de journal nécessaires ; aucun changement de schéma SQL n'est requis dans ce lot.

API Ogipen redémarrée ; Nginx et Apache rechargés sans redémarrage complet. MySQL conserve le PID **243** ; PHP Ogipen, Postfix et Webmin restent actifs. Aucun changement Proxmox ni plugin WordPress. Aucun secret n'est inclus dans les archives livrées.

Le premier build local manquait de l'image splash parce que son chemin de copie était erroné dans le dossier de travail ; la ressource originale a été récupérée et copiée au bon emplacement. Une première vérification du proxy juste après son rechargement a reçu 404, puis les contrôles ultérieurs et le test .NET HTTPS ont réussi. Aucun échec restant dans les suites décrites.

Le script de déploiement vérifie les versions de départ et prévoit un retour aux fichiers sauvegardés si la santé API échoue. Le retour arrière complet du lot doit également restaurer les deux fichiers Apache de journalisation. Aucun exercice volontaire de restauration complète n'a été effectué.
