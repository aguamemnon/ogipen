# Ogipen 0.4.15 — gestion des comptes depuis le logiciel

## Utilisation

Connectez-vous avec un compte interne disposant du rôle technique **Administrateur logiciel** ou **OSSI**, puis ouvrez **Administration → Application → Comptes Ogipen**. Le bouton **Administration serveur** donne également accès à cette fenêtre.

L’administrateur peut créer un compte interne, modifier son nom et son rôle technique, l’activer ou le désactiver, et définir ou réinitialiser son mot de passe. Le login d’un compte existant reste fixe. Le mot de passe saisi est masqué, effacé après l’envoi et jamais renvoyé dans la liste. Un champ de mot de passe vide conserve celui d’un compte existant.

L’OSSI consulte les comptes de son entreprise ; les commandes de modification sont désactivées et l’API refuse aussi toute modification. Un utilisateur ordinaire ne peut ni lire ni modifier cette liste.

Les comptes `admin` et `ossi` préparés précédemment gardent leur état actuel. Leur premier mot de passe reste à définir dans le portail s’ils n’ont pas encore été activés. Aucun mot de passe par défaut n’a été créé.

## Droits et contrôles

- La liste et les modifications sont limitées à l’entreprise liée à la session licenciée. Un identifiant de compte appartenant à une autre entreprise est refusé.
- Le rôle technique est indépendant des droits métier du projet. Ceux-ci sont affichés en lecture seule, conservés lors des modifications et ne sont pas accordés automatiquement à un nouveau compte.
- Le nombre de comptes actifs reste plafonné par la licence de l’entreprise. Un compte inactif peut être préparé sans occuper une place active.
- Le dernier administrateur actif de l’entreprise ne peut pas être désactivé ou rétrogradé depuis cette API.
- Les modifications utilisent une révision pour refuser les formulaires périmés. Elles invalident les anciennes sessions du compte concerné. Une modification de son propre compte entraîne une reconnexion.
- Les changements et leur audit sont enregistrés dans la même transaction. Une panne d’audit annule aussi le changement de mot de passe et de révision.
- Les réponses ne contiennent ni mot de passe ni empreinte de mot de passe. L’audit n’en contient pas non plus. Les événements techniques de comptes sont exclus du flux d’événements métier.

## Déploiement et fichiers

API déployée sur **192.168.2.216**, version **0.4.15-test**. Nouvelles routes protégées : `GET /api/administration/accounts` et `POST /api/administration/accounts`. La supervision `/api/administration` compte maintenant les identités de l’entreprise autorisée.

Nouveau fichier serveur : `AccountAdministration.cs`. Raccordement et filtrage du flux dans `Program.cs`. Côté client : `AccountAdministrationClient.cs`, `AccountAdministrationForm.cs`, raccordement au ruban et au diagnostic serveur, version 0.4.15. La nouvelle fenêtre utilise le thème sombre Krypton.

Sauvegardes protégées : `/root/ogipen-v0415/before.tgz`, `/root/ogipen-v0415/before-project.sql` et `/root/ogipen-v0415/api-before-final/`. Pas de migration SQL ; pas de modification des comptes réels, des quotas ou des licences. Seule l’API a été redémarrée. MySQL conserve son PID **243** ; API, PHP, Nginx, MySQL, Postfix et Webmin sont actifs.

Empreinte SHA-256 de l’API : `5a6d48724c3655128ad6e66f7397f7f8aef86f313e77ea73dfdbbf80c0857ada`.

## Tests et limites

**123 contrôles API**, **9 contrôles PHP de gestion des comptes**, **4 contrôles d’intégration C# client/API**, **51 contrôles client existants** et **10 contrôles HTTPS** passent. La nouvelle fenêtre, sa grille en lecture seule, les saisies masquées et le ruban ont été contrôlés sous Windows et rendus pour vérification visuelle.

Les essais couvrent création, activation, quota, changement de rôle, réinitialisation du mot de passe, fermeture des anciennes sessions, OSSI en consultation, isolation entre entreprises, protection du dernier administrateur, rejet des révisions périmées, compatibilité du dérivé de mot de passe avec le portail PHP et annulation transactionnelle si l’audit échoue. Ils utilisent une base temporaire supprimée après les essais. En réel, la nouvelle route sans session retourne 401 et les contrôles HTTPS passent.

Ce lot gère les **comptes internes** et leurs rôles techniques. L’enrôlement Windows reste dans le portail. La modification des permissions métier et les rôles personnalisables par projet restent à développer avec le registre central et l’isolation des bases projets. Cette livraison ne prétend pas créer ce socle multi-projet.

Le parcours licence/login séparé de la 0.4.14 est conservé. Aucun renouvellement commercial ni changement de date d’expiration n’a été effectué.
