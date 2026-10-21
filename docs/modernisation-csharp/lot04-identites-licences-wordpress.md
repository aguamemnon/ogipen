# OGIPEN — Architecture d'identité, licences et modules (référence du projet)

**Statut : décision d'architecture, à implémenter progressivement.** Cette note prévaut sur les premiers schémas de démonstration du client C#.

## Séparation des responsabilités

1. **WordPress + WooCommerce + [SLM Plus](https://github.com/michelve/slm-plus)** sur serveur Linux : achat, activation, renouvellement, état de licence, nombre maximal d'utilisateurs autorisés et modules achetés. Une extension **OGIPEN License Manager** gère la déclaration/suspension des utilisateurs nominatifs par le client, la limite de sièges et les droits aux modules. **Aucun accès projet ni rôle métier ne se configure ici.**
2. **Authentification utilisateur** : trois modes à prévoir :
   - **SAM Windows local**, vérifié sur le poste (compte Windows local) ;
   - **AD DS local de l'organisation**, vérifié côté poste / infrastructure interne, jamais en forçant l'entreprise à exposer son annuaire sur Internet ni à utiliser Azure ;
   - **Compte OGIPEN**, authentifié via le service web.
   L'identité AD/SAM ne suffit pas comme preuve auprès d'un serveur Internet : définir un **enrôlement initial sécurisé / liaison au compte OGIPEN** et des attestations bornées, sans accepter aveuglément un username envoyé par le client.
3. **Base centrale `progelec`** sur serveur métier Linux : profils/postes évolutifs (OSSI, chef de projet, technicien, chef de chantier, etc.), permissions fines et affectations aux projets. Un utilisateur peut exercer des fonctions distinctes selon le projet.
4. **Une base MySQL métier distincte par projet**, inchangée. Résolution ID de projet → base physique exclusivement côté service métier Linux. Vérification serveur systématique utilisateur + projet + permission + module souscrit ; pas de credentials SQL `root` côté client.
5. **Client C# .NET 10 WinForms/Krypton** sous Windows : splash réutilisant **l'image originale VB.NET**, login, sélection projet, ruban Office/Revit, workspace dockable type Visual Studio et grilles. Le thème sera harmonisé lors d'un lot graphique ultérieur.

## Algorithme d'autorisation

Autoriser l'action uniquement si :
- l'identité est authentifiée et liée à une personne autorisée par OGIPEN ;
- la licence de l'organisation est active et l'utilisateur figure dans sa liste nominative **dans la limite des sièges achetés** ;
- le module correspondant (ex. `etude`, `rapports`, `chantier`) est souscrit et non suspendu ;
- `progelec` autorise cette personne pour ce projet et cette opération selon poste/profil et affectation ;
- le serveur utilise exclusivement la base du projet résolue depuis son ID autorisé.

Le catalogue de postes **et** le catalogue de modules doivent être extensibles.

### Premières familles de modules

- `etude` : câbles, fils, équipements, borniers, tronçons, calculs, parcours ;
- `rapports` : édition de rapports, exports, statistiques ;
- `chantier` : avancement, suivi et saisies terrain, mode hors ligne autorisé ;
- modules complémentaires possibles (stock, tourets, etc.). Aucun nom de module ne doit conférer de rôle implicite.

### Règles métier initiales (non exhaustives)

- **OSSI** : comptes et projets à l'échelle de l'organisation ; création et gestion des habilitations.
- **Chef de projet** : périmètre des projets qu'il a créés, permissions explicitement définies.
- **Technicien** : projets assignés ; **pas de modification des avancements de chantier**.
- **Chef de chantier** : projets assignés ; suivi et avancement, synchronisation terrain ; **pas d'édition des données de conception**.

## Licence numérique et mode hors ligne

L'export `JSON` brut de SLM Plus **n'est pas une licence signée**, et peut contenir plus de colonnes que nécessaire. Ne pas diffuser cet export comme source d'autorisation.

Créer un document limité aux claims pertinents (ID licence, organisation, date, expiration, modules, sièges), signé côté serveur PHP avec une **clé privée non exposée** (ECDSA P-256 / SHA-256, signature DER). Le client C# doit vérifier la signature contre **une clé publique intégrée et authentique**, et rejeter les documents modifiés, expirés ou non conformes. Une licence globale signée ne prouve **pas** qu'un utilisateur individuel est autorisé : il faut également une session d'identité et/ou une autorisation nominative bornée en durée.

L'activation et la révocation sont validées en ligne. Pour le hors ligne, exiger un laissez-passer utilisateur/poste/projet signé, de courte durée, chiffrer la base locale et rejeter l'accès non autorisé lors de la synchronisation. La révocation immédiate est impossible sans connectivité ; documenter cette limite et les périodes de grâce.

Éviter d'utiliser le numéro processeur/la version de l'exécutable comme secret pour le mode maintenance : préférer un défi unique, une autorisation courte et signée depuis le portail, contrôlée et historisée.

## Déroulement attendu

1. Splash et vérification de présence des services avec délai borné, état maintenance, mises à jour signées.
2. Identité SAM/AD local ou compte OGIPEN, puis **liaison cryptographiquement vérifiable** à une identité OGIPEN.
3. Portail WordPress : confirmer licence active, utilisateur inscrit, quota respecté, modules souscrits.
4. Service métier : consulter `progelec` et lister uniquement les projets autorisés.
5. Sélection du projet, puis ouverture du workspace MDI avec modules activés selon licence **ET** droits métier.
6. En mode hors ligne, appliquer uniquement les droits et données préalablement autorisés et mis en cache de manière sûre.

## Principe de migration

**Ne pas modifier** les clés, relations, procédures et données MySQL `progelec` ou des bases projet sans audit/validation. Préserver le VB.NET sur `master`. Toutes les nouvelles évolutions résident dans `modernisation-csharp`. Pas de véritables identifiants, mots de passe, secrets de signature ou clés privées dans le dépôt.

## Audit initial de SLM Plus (master, PHP)

- `includes/slm-api-listener.php` expose des actions `slm_create_new`, `slm_activate`, `slm_deactivate`, `slm_check`, etc.
- `includes/slm-utility.php` possède un export JSON des colonnes SQL dans les uploads WordPress. **Ne pas l'utiliser comme preuve de licence**.
- La vérification d'API utilise une clé partagée passée en paramètres HTTP ; **ne jamais embarquer cette clé dans le client Windows**.
- Développer **un plugin compagnon OGIPEN** et non modifier arbitrairement l'extension tierce.
- Examiner les indications de licence divergentes du dépôt SLM Plus avant réutilisation ou distribution.

**À faire** : concevoir les tables compagnon liées aux licences SLM Plus pour bénéficiaires et modules ; vérifier propriété des licences/quotas sous WooCommerce et la politique de transfert ; écrire API REST WordPress protégée ; implémenter émission des licences signées puis vérification C# ; en dernier intégrer avec login et autorisations `progelec`.
