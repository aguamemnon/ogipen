# Ogipen 0.4.10 — serveur d’entreprise autonome

Livraison du 25 octobre 2026. Cette version corrige l’architecture et l’accès du client : **chaque entreprise héberge son API, son portail et ses données ; WordPress émet uniquement les licences Ogipen.** Le mode multi-entreprise reste une option explicite d’un serveur désigné pour un projet partagé.

## Accès installés pour le serveur de test

| Fonction | Adresse |
|---|---|
| API de l’entreprise, à saisir dans le client | **https://192.168.2.216/** |
| Portail PHP de l’entreprise | **http://192.168.2.216:8080/** |
| Vérification de santé API | https://192.168.2.216/health |
| WordPress SLM Plus | Émission des fichiers de licence uniquement |

Le port HTTPS 443 est désormais ouvert sur l’adresse locale 192.168.2.216 et limité au LAN 192.168.2.0/24. Kestrel reste en boucle locale sur 5088. L’ancien relais WordPress `/ogipen/` renvoie HTTP 410, pour son API comme pour son portail. Le listener intermédiaire 8443 est retiré. Le site WordPress normal continue de répondre ; ses plugins et données de licence ne sont pas modifiés.

L’adresse de challenge signée du serveur est maintenant `OGIPEN_AUTH_AUDIENCE=https://192.168.2.216/`. Le binaire API et son protocole restent en version 0.4.9 ; le client et la configuration de déploiement passent en 0.4.10. Aucun changement SQL n’est requis par ce lot.

## Certificat propre à l’entreprise

Un nouveau certificat serveur a été généré **sur le serveur Ogipen**, avec SAN IP 192.168.2.216, usage TLS serveur, validité d’un an et `CA:FALSE`. Sa clé privée reste uniquement dans `/etc/ogipen/tls/company-server.key`, root:root 0600.

Empreinte SHA-256 du certificat :

`139BB05C51ED32D64FD502498787A8F1656337498D67C99C12232626B6C46540`

Le client reconnaît uniquement ce certificat pour ce serveur grâce au profil livré dans `Assets/company-server-profiles.json`. La validation conserve les contrôles de nom/IP, dates, usage serveur et identité du certificat ; seules les erreurs de chaîne privée non approuvée peuvent être acceptées pour cette empreinte exacte. Un autre certificat, une mauvaise adresse, une expiration ou un certificat d’autorité sont refusés.

**Aucune autorité de certification n’a été installée dans Windows. Aucun réglage TLS global n’a été désactivé.** La confiance est propre au client et au profil. Un navigateur peut donc encore avertir sur le certificat lorsqu’on ouvre l’API manuellement : le portail courant reste celui du port 8080.

Le certificat public `.cer` est fourni ; il ne contient aucune clé privée. Pour une autre entreprise, le responsable fournit son adresse API et son propre certificat public, importable dans **Profils serveur**. Un certificat public déjà approuvé par Windows peut aussi utiliser la validation système habituelle. Le certificat TLS du serveur reste distinct de la clé publique WordPress utilisée pour vérifier les licences.

Une rotation de certificat exige un nouvel import approuvé ou une nouvelle distribution du profil. Le client ne récupère ni n’accepte automatiquement un certificat inconnu. Si l’adresse IP change, le certificat, le profil et l’audience du serveur doivent être adaptés ensemble.

## Utiliser le nouveau ZIP Windows

1. **Fermer l’ancienne version 0.4.9**, puis extraire le nouveau ZIP dans un dossier distinct et lancer son `OGIPEN.Desktop.exe`.
2. Le profil déjà saisi `https://192.168.2.216/` est reconnu par la nouvelle version. Un profil de test de cette entreprise est aussi fourni dans le paquet. Aucun outil de cette livraison ne modifie directement le fichier de configuration utilisateur existant.
3. Si un ancien profil pointe encore vers WordPress, choisir le profil du serveur d’entreprise. Le logiciel ne change pas silencieusement le serveur sélectionné et ne prévoit aucun repli sur Internet.
4. Retester le serveur. L’accès réseau doit maintenant réussir sans installer de certificat racine.
5. La connexion métier nécessite toujours une licence poste `.oglic`, une entreprise licenciée et un utilisateur approuvé avec le bon bénéficiaire SLM et la clé de sa session Windows.

Le paquet Windows x64 reste une **archive de test non signée**, dépendante de Windows Desktop .NET 10.0.13 ou d’une mise à jour compatible. Aucun programme n’est installé ou lancé automatiquement sur le poste de l’utilisateur. Le serveur de test n’a encore aucune entreprise, identité ou session réelle configurée ; aucune n’a été inventée pour les tests.

## Contrôles effectués

- 49 contrôles du client, des profils et des certificats : exactitude de l’empreinte, refus des mauvais noms, dates, usages et autorités, refus d’un certificat inconnu, profils multiples et conservation du choix explicite de serveur.
- 10 contrôles réseau .NET Windows sur l’accès direct : santé API, ancien profil IP reconnu, accès anonyme refusé, identité non enrôlée refusée, API non publiée en HTTP, mauvaise empreinte refusée, absence de confiance Windows globale, ancien relais WordPress retiré et site WordPress préservé. Ils s’exécutent sur le runtime stable 10.0.13.
- 17 contrôles HTTP authentifiés du portail 8080, dont navigation, sessions, refus CSRF et fichiers internes inaccessibles.
- Smoke test Windows : formulaires de connexion et de profils, shell Krypton, SID courant, vraie signature CNG, refus d’une autre session et export privé désactivé. Runtime .NET 10.0.13 confirmé.
- Nginx et Apache passent leurs contrôles de syntaxe. Ports observés après rechargement : 443 et 8080 sur le serveur, 5088 uniquement en boucle locale, 8443 absent.

L’API et les règles de licence métier n’ont pas changé de code dans ce lot ; les tests d’intégration API/client du lot 0.4.9 restent décrits dans son rapport. La présente livraison vérifie le nouveau transport TLS direct ; elle ne prétend pas avoir ouvert une session commerciale réelle sans bénéficiaire approuvé. Les tests ne constituent pas une recette visuelle complète.

## Sauvegardes et exploitation

ct_Mysql : `/root/ogipen-v0410/before.tgz`, `nginx-before.conf`, `api-env-before` et `nginx-before-retiring-8443.conf`. Le fichier d’environnement sauvegardé est protégé en 0600. WordPress : `/var/backups/ogipen-retire-relay-v0410/before.conf` en 0600.

Seule l’API a été redémarrée pour changer son audience. Nginx et Apache ont été rechargés ; MySQL conserve le PID **243**, et PHP Ogipen, Postfix et Webmin restent actifs. La clé privée WordPress reste sur WordPress. Ni les licences ni leurs quotas n’ont été modifiés. Aucun secret ni fichier d’environnement réel n’est livré dans les archives.

Un premier patch local a été refusé avant écriture car son contexte de ligne était incorrect ; il a été corrigé. Aucun échec de test ou de déploiement restant. Après le rechargement gracieux, les anciens workers Nginx ont brièvement conservé le listener 8443 ; le contrôle final confirme sa fermeture.

Les scripts sont des migrations **spécifiques à ce serveur de test déjà installé**, avec sauvegardes et restauration automatique sur erreur de syntaxe/santé. Ils ne sont pas encore un installateur portable de serveur neuf. Pour revenir à 0.4.9, restaurer ensemble la configuration Nginx, l’environnement API et l’ancien relais Apache, puis redémarrer/recharger ces seuls services. Aucun exercice volontaire de restauration complète n’a été effectué.

## Suite restant à développer

L’enrôlement métier réel, le provisionnement complet de projets, les rôles personnalisés, les grilles raccordées aux données API, SignalR dans le client et le client Linux restent des chantiers distincts. Le lien Windows est une identité de session locale et une clé approuvée administrativement ; il n’est pas une attestation distante AD ou matérielle. Les modèles commerciaux multiposte/site et l’installateur générique restent à compléter.
