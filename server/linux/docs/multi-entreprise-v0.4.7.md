# Ogipen v0.4.7 — préparation du partage multi-entreprise

Cette livraison ajoute une déclaration de mode et un registre d'entreprises dans le portail PHP existant. **Elle n'active pas encore un serveur multi-entreprise.** Le mode API effectif reste mono-entreprise. Aucune référence SLM saisie dans ce registre n'est une preuve de licence.

## Règles retenues

- Un même serveur technique et une même base de projet pourront accueillir plusieurs entreprises participantes. Une entreprise peut participer à plusieurs projets : l'appartenance au projet est explicite, jamais déduite d'un domaine AD.
- Chaque entreprise dispose de sa propre licence commerciale Ogipen, émise uniquement par WordPress SLM Plus. Les preuves serveur et poste devront correspondre à cette même licence. Plusieurs licences d'entreprises pourront autoriser la même instance serveur ; aucune clé de signature ne sera installée sur celle-ci.
- Les modules accessibles correspondent à l'intersection des droits signés serveur/poste de l'entreprise et des permissions du projet. Les modules et les places d'une autre entreprise ne sont jamais prêtés automatiquement.
- Le quota est évalué par entreprise et selon le modèle commercial retenu. Le prototype actuel utilise encore un quota de places/utilisateurs ; cette livraison n'ajoute pas un quota de postes indépendant ni les modèles site/multiposte.
- Une identité PC/SAM, AD ou Ogipen doit être enrôlée et prouver la possession de sa clé. Le nom, le SID ou le domaine seul ne prouvent pas une identité. Un utilisateur lié à plusieurs entreprises devra choisir un contexte autorisé ; aucun changement implicite d'entreprise.
- Les rôles et les périmètres métier restent dans chaque base projet. Les lots déclarés ici sont descriptifs ; ils ne filtrent pas les données. Un projet partagé ne signifie pas que toutes ses données sont visibles par tous.
- L'administration technique du serveur et l'administration métier d'un projet doivent rester distinctes. Les événements, verrous et reprises d'événements devront appliquer les mêmes périmètres que les lectures et écritures.
- Le portail ne crée aucun projet. La création complète demeure réservée au logiciel et à son API de provisionnement.

## Livré et installé

Rubrique `/?page=companies`, intégrée à la navigation et à la session existantes :

- sélection du **mode souhaité**, mono ou multi-entreprise en préparation ; affichage permanent du mode effectif mono-entreprise ;
- déclaration/modification/archivage des entreprises du projet courant : code stable, nom, lot indicatif, référence SLM déclarée ;
- motif obligatoire, journal d'audit transactionnel, protection CSRF, vérification des révisions pour éviter les écrasements ;
- seconde entreprise préparée uniquement si le mode souhaité est multi ; retour souhaité en mono refusé tant que plusieurs entreprises sont préparées ;
- aucune attribution de droits, de modules ou de places par ces formulaires.

Migration additive `003_collaboration_preparation.sql` : deux tables dans la base prototype `ogp_test_001`. Elles sont locales à ce projet, sans base métier centrale. Aucun utilisateur existant n'est rattaché automatiquement et aucune entreprise réelle n'est inventée. La migration peut être rejouée ; les opérations DDL MySQL ne sont pas transactionnelles. Le script de déploiement sauvegarde la base avant exécution et accorde uniquement SELECT/INSERT/UPDATE sur les nouvelles tables au compte PHP existant.

`CompanyProjectPolicy` dans OGIPEN.Core définit et teste les refus de licence, de serveur, d'entreprise, de module, de quota et de permission. **Cette classe n'est pas encore appelée par l'API déployée.** Les booléens de preuve de son contexte sont des résultats attendus des vérificateurs de signature/enrôlement ; ils ne doivent jamais être acceptés depuis un formulaire ou une requête client.

## Contrôles restant nécessaires avant activation effective

1. Enrôlement vérifié avec rattachement entreprise/bénéficiaire/poste et appartenance au projet, en respectant le modèle de licence commercial.
2. Vérification cryptographique des preuves client et serveur à la connexion, avec identité de licence commune par entreprise ; persistance de ce contexte dans la session et contrôle de révocation/expiration.
3. Import de plusieurs autorisations serveur signées WordPress pour la même instance, sans agréger les quotas ni les modules, et vérification du rattachement entreprise/licence.
4. Application de la politique à toutes les lectures, éditions, verrous, événements et connexions SignalR ; remplacement de l'ancien chemin de connexion client par la preuve de clé liée à la session système.
5. Tests API de bout en bout avec deux entreprises réelles de test, données communes et données restreintes. Les tests de politique présents ne prouvent pas cette intégration.

HTTPS direct sur 8080 reste reporté conformément à la demande de l'utilisateur. Le proxy HTTPS complémentaire est conservé.

## Validation et sauvegardes

74 contrôles réussis : 22 scénarios C# de politique d'accès, 18 tests MySQL/PHP dans des tables temporaires isolées et 34 contrôles HTTP authentifiés sur l'accès 8080 et le proxy HTTPS. Cinq fichiers PHP passent le contrôle de syntaxe. Aucun test ne crée de vraie entreprise, n'émet de licence ni ne change les quotas.

La première assertion de test comparait textuellement du JSON normalisé par MySQL ; elle a été corrigée pour analyser le JSON. Tous les contrôles ont ensuite réussi.

Sauvegardes sur ct_Mysql : `/root/ogipen-v047/portal-before.tgz` et `/root/ogipen-v047/project-before.sql`. Seul PHP-FPM Ogipen a été redémarré. API, Nginx et MySQL n'ont pas été redémarrés ; MySQL conserve le PID 243. WordPress, Proxmox, les clés de signature et les licences existantes ne sont pas modifiés par cette livraison.

Retour à la version précédente : restaurer `index.php` et `portal-header.php` depuis l'archive, retirer les trois nouveaux fichiers PHP, puis redémarrer uniquement le service PHP Ogipen. Conserver les deux tables additives pour ne pas perdre les déclarations éventuellement saisies. Aucun exercice de restauration n'a été effectué.

Les scripts `prepare-db.py` et `run-db-tests.py` sont spécifiques à ce serveur de test et lisent les accès depuis le fichier Webmin protégé ; ils ne contiennent aucun identifiant secret. Ce ne sont pas encore un installateur portable.
