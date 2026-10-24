# Ogipen 0.4.11 — journal des tentatives de connexion

Livraison du 25 octobre 2026. API et portail mis à jour sur **192.168.2.216** ; nouveau client Windows x64 généré. L’architecture autonome de la version 0.4.10 est conservée : API directe **https://192.168.2.216/**, portail PHP **http://192.168.2.216:8080/**, WordPress uniquement pour émettre les licences. L’ancien relais WordPress reste retiré.

## Journal installé

Actualiser **Événements** dans le portail. Un tableau distinct présente les 150 dernières opérations d’authentification, séparées de l’audit métier :

- date et heure locales avec le fuseau et le décalage UTC ; stockage en UTC en base ;
- résultat et phase : challenge émis/refusé, connexion réussie/refusée, refus local signalé, connexion au portail administrateur ;
- nom du PC déclaré par le client ;
- nom utilisateur déclaré et identifiant de session Windows / identifiant Ogipen présenté ;
- IP source relevée par le serveur, sans se fier à une IP annoncée dans le corps JSON ;
- référence numérique de licence SLM présentée, même différente de celle attendue ;
- référence de licence de l’entreprise associée à l’identité, ou référence initiale de l’instance si l’identité n’est pas rattachée ;
- signature vérifiée ou simple annonce non vérifiée, expiration éventuelle, preuve de clé et motif du refus.

Le fuseau d’affichage est **Europe/Paris** par défaut, modifiable via `OGIPEN_PORTAL_TIMEZONE`. L’offset affiché distingue les heures répétées lors du changement d’heure. Les événements métier conservent leur affichage UTC historique.

La référence affichée est le numéro interne SLM (`lic` dans le fichier signé), pas une clé commerciale secrète. Une licence différente reste refusée par les règles d’autorisation habituelles. En mode partagé, la licence attendue est celle de l’entreprise de l’identité ; pour une identité inconnue, le tableau indique explicitement qu’il s’agit de la référence initiale de l’instance.

## Provenance et confidentialité

Le PC et le nom utilisateur sont des informations déclarées : un nom de PC n’est pas une preuve d’identité matérielle. La signature du fichier et la preuve de possession de la clé utilisateur sont vérifiées séparément et ne doivent pas être confondues avec le résultat d’autorisation.

Nginx remplace `X-Real-IP` par l’adresse réelle de son correspondant. L’API n’utilise ce relais que lorsqu’elle est appelée depuis sa boucle locale ; elle ignore toute IP placée dans le JSON. Un test depuis Windows avec un faux en-tête IP confirme que cette valeur n’est pas retenue.

Le journal ne conserve aucun mot de passe, jeton de session, nonce, signature brute, clé privée, fichier `.oglic` complet ou corps HTTP brut. Seuls les champs définis pour cet audit sont enregistrés. Les connexions administrateur du portail sont également journalisées ; le navigateur ne communiquant pas de nom de PC, cette colonne reste « Non communiqué » pour ces événements.

Les événements d’authentification ne sont pas exposés par `GET /api/events` aux lecteurs du projet et ne sont pas diffusés par SignalR. Ils restent accessibles via le portail administrateur. Le tableau échappe les textes clients avant affichage HTML.

## Nouveau client requis pour les noms de PC et utilisateur

Fermer l’ancienne application et lancer celle du **ZIP 0.4.11**, extrait dans un dossier distinct. Le nom du PC et le compte courant sont envoyés automatiquement au serveur choisi lors du challenge et de la validation ; aucune saisie d’un autre compte n’est ajoutée. Les demandes d’activation `.ogreq` restent sans nom de PC, SID ou utilisateur.

Si la licence locale est absente ou invalide, le client signale un refus local au serveur choisi, s’il est joignable. Il ne transmet alors que la référence déclarée éventuellement lisible, sans le fichier défectueux ni données sensibles. Cette déclaration n’accorde aucune session et n’est jamais présentée comme une licence vérifiée.

Les anciens clients restent compatibles avec l’API ; leurs champs PC/utilisateur peuvent rester vides. Un échec réseau ou TLS avant réception HTTP ne peut pas fournir ces informations au journal applicatif. Un test de présence `/health` n’est pas une tentative d’authentification. Si la base d’audit est indisponible, un avertissement technique générique est écrit dans le journal du service ; aucune garantie de ligne en base n’est possible dans ce cas.

## Validation

- **58 contrôles de suite API** sur une base isolée et un émetteur de test, dont les contrôles de fin des suites imbriquées : succès avec métadonnées, licence signée 8 conservée et refusée face à la référence 2, fichier altéré non marqué vérifié, refus local, champs sensibles absents, horodatage UTC, casse des champs JSON et des routes, slash final, requête JSON mal formée journalisée et exclusion du flux métier.
- **4 scénarios du vrai client C#** contre l’API isolée et **18 contrôles PHP/MySQL** conservés.
- **9 contrôles de rendu** : noms malveillants échappés, deux références de licence visibles, distinction annonce/signature, heure Europe/Paris et refus local.
- **24 contrôles HTTP du portail réel**, incluant connexion administrateur réussie/refusée, colonnes du journal, tentative Windows visible, licence différente et absence des marqueurs de mot de passe/jeton.
- **6 contrôles de lecture de l’audit réel** : PC/utilisateur conservés, licence 999 différente de la référence 2, provenance de cette référence, signature non vérifiée, fausse IP rejetée et champs sensibles absents.
- **51 contrôles client/certificats** et **10 contrôles réseau HTTPS Windows**, dont les métadonnées émises et le refus local sans authentification.
- Smoke test Windows CNG et formulaires exécuté sur **.NET 10.0.13**. Compilation et publication du client réussies ; le SDK de compilation déjà installé reste celui en aperçu, mais les runtimes ciblés sont les versions stables 10.0.13.

Les émetteurs, clés, licences et entreprises fictifs sont confinés à la suite isolée ; sa base et ses fichiers de clé sont supprimés à la fin. Des tentatives réelles de diagnostic clairement nommées `SELFTEST` restent dans le journal du serveur, sans créer d’entreprise ni d’identité réelle. Les marqueurs de secret utilisés pour tester la non-journalisation ne sont pas de vrais identifiants.

Binaire API installé et testé, SHA-256 : `83b5a135ed0c36165e54c434a26d69774266731aa44b30e3d6ecaee68da9e880`.

## Changements et exploitation

Réutilisation de `ogp_audit_event.details` pour le schéma `ogipen-auth-audit-v1` : aucune migration de table ni modification de quota. Ajout d’un observateur des POST `/auth/challenge`, `/auth/complete` et `/auth/attempt`, d’une vue PHP structurée et des événements de connexion du portail. Les règles de licence, les protections CNG et la confiance TLS par serveur sont conservées.

Sauvegardes : `/root/ogipen-v0411/before.tgz`, `before-final-refinement.tgz` et `style-before.css`. API et PHP-FPM Ogipen redémarrés, Nginx rechargé. MySQL conserve le PID **243**, Postfix et Webmin restent actifs. WordPress n’a pas été modifié dans ce lot. Les journaux existants sont conservés.

Erreurs corrigées avant livraison : collision de nom de variable dans le client C#, comparaison de collations dans une requête de test (sans changer les collations de production), et bibliothèques PHP manquantes dans le dossier isolé. Aucun échec restant dans les suites décrites. La recette visuelle complète et un exercice volontaire de restauration complète n’ont pas été effectués.

La distribution Windows reste une archive de test non signée, sans installation automatique. Le serveur n’a toujours aucune entreprise/identité réelle affectée ; une connexion métier réelle exige ces affectations et un bénéficiaire WordPress vérifié. Le chargement des données métier dans les grilles, les rôles complets, le provisionnement multi-projet, le client Linux et l’installateur générique restent à développer. Le certificat du serveur et le profil d’accès direct sont ceux de la livraison 0.4.10, inchangés.

Après apparition de ces nouvelles lignes, ne pas remettre en service une API ancienne qui les exposerait dans son flux d’événements métier. Un retour arrière doit préserver le filtre de confidentialité des événements `authentication`, ainsi que les données d’audit déjà enregistrées.
