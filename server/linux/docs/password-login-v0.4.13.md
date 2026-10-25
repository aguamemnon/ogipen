# Connexion utilisateur Ogipen — livraison 0.4.13

Déployée le 25 octobre 2026 sur le serveur Ogipen 192.168.2.216. WordPress et les quotas commerciaux n’ont pas été modifiés.

## Ce qui change

- Login Windows prérempli et modifiable ; mot de passe masqué et obligatoire ; choix explicite Windows/AD ou compte interne Ogipen.
- Mot de passe Windows contrôlé localement par Windows ; mot de passe interne contrôlé par l’API. Les identités et les preuves de clé sont distinctes du poste licencié.
- Nouvelle rubrique du portail **Comptes Ogipen**. Comptes `admin` et `ossi` préparés sans mot de passe et désactivés jusqu’à la définition de leur mot de passe initial. Leur rôle technique et leurs droits de projet sont séparés.
- Espace technique admin/OSSI avec diagnostic serveur, contrôlé côté API. Les fonctions d’administration complètes du logiciel restent à développer.
- Désactivation des anciens endpoints sans mot de passe : le client 0.4.13 est obligatoire. Pas de réactivation WordPress nécessaire.
- Limitation des tentatives, audit sans mots de passe, défis à usage unique, sessions temporaires et invalidation après modification du compte.

## Sauvegardes et déploiement

Sauvegardes protégées : `/root/ogipen-v0413/before.tgz` (API, portail, configuration) et `/root/ogipen-v0413/before-project.sql` (base projet). Migration additive : tables `ogp_device`, `ogp_app_account`, `ogp_login_attempt` et colonnes de méthode/poste dans `ogp_auth_session`. Les clés publiques existantes autorisées ont été reprises dans le registre de postes. Les comptes internes initiaux sont inactifs et n’occupent pas de place active.

API et PHP ont été redémarrés ; MySQL conserve son PID 243. API, PHP, Nginx, MySQL, Postfix et Webmin sont actifs. Certificats, ports et services tiers sont conservés. Empreinte API SHA-256 : `8219b71331ff8cdebf590ef4214020eb66bc47040c4c568f6a8f9f425b7a22fb`.

## Validation

85 contrôles API en base isolée, 9 contrôles de gestion des comptes PHP, 16 contrôles du portail réellement déployé, 51 contrôles client existants, 10 contrôles HTTPS et 4 contrôles C# client/API. Tous passent. Le contrôle Windows natif valide les champs login/mot de passe, le préremplissage, la preuve CNG et le refus d’un compte Windows inexistant. L’écran a aussi été rendu pour vérification visuelle.

Les essais couvrent mauvais mot de passe, absence de mot de passe, autre compte sur le même poste, compte Windows distinct avec sa propre preuve, absence de droit d’édition implicite pour admin, révocation après changement du compte, limitation des tentatives et absence de mot de passe dans l’audit. Les fixtures restent isolées et leur base est supprimée après les essais.

Le test de connexion Windows avec un mot de passe correct doit être fait par l’utilisateur : son mot de passe n’a pas été demandé ni utilisé par l’agent. L’API et les comptes internes ont été testés avec des identifiants de test éphémères. Les limites de profils Windows et de confiance du client sont décrites dans la documentation d’authentification.

## Corrections pendant les essais

Le premier lint PHP a détecté une erreur de guillemets dans un filtre SQL ; elle a été corrigée avant déploiement. Les tests ont ensuite révélé une différence de collation MySQL dans les fixtures : les nouvelles tables utilisent la collation des tables existantes et les comparaisons d’identifiants de test ont été corrigées. Aucun de ces échecs ne reste ouvert. Après démarrage de l’API, une lecture immédiate de santé a précédé l’ouverture du port ; les lectures suivantes et les contrôles HTTPS ont réussi.

Le portail reste en HTTP sur le port 8080 comme demandé précédemment. HTTPS pour ce portail et l’expiration de la licence de test ne sont pas modifiés par ce lot.
