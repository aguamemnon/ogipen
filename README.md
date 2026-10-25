ogipen
======

Progiciel de gestion de projects electrique dans le BTP / gestion des câbles , parcours , taux de remplissage des tremies et tronçons , avancement , historique des evenements sur un projet etc


## Activation simplifiée — 0.4.12

Dans WordPress, choisir la licence Ogipen et charger le `.ogreq` du poste, puis importer le `.oglic` dans le client 0.4.12. Aucun bénéficiaire ni vérification utilisateur WordPress n’est requis. Les quotas, signatures et droits de projet sont conservés. Voir [le parcours d’activation](docs/activation-hors-ligne.md).


## Connexion utilisateur — 0.4.13

Le login est prérempli avec le compte Windows courant, modifiable, avec mot de passe obligatoire. Choix Windows/AD ou compte interne Ogipen. Les comptes admin/OSSI se configurent dans le portail, rubrique Comptes Ogipen. La licence du poste reste distincte du compte choisi. Voir [la connexion 0.4.13](docs/authentification-v0.4.13.md). L’ancienne connexion sans mot de passe est désactivée côté API.


## Démarrage et thème — 0.4.14

L’activation du poste est séparée du login. Sans licence valide, la fenêtre dédiée précède la connexion ; avec une licence valide, le login s’ouvre directement. La licence se met à jour depuis Administration → Application → Licence / activation. Les fenêtres utilisent le thème sombre Krypton. Voir [le parcours 0.4.14](docs/parcours-licence-login-v0.4.14.md).


## Comptes internes — 0.4.15

Gestion des comptes internes dans Administration → Application → Comptes Ogipen : administrateur en modification, OSSI en consultation. Le rôle technique et les droits métier restent distincts. API protégée et limitée à l’entreprise licenciée. Voir [la livraison 0.4.15](docs/comptes-internes-v0.4.15.md).


## Rôles dans Utilisateurs — serveur 0.4.16

La liste du portail regroupe les comptes Windows/AD et internes Ogipen. Le rôle Utilisateur, Administrateur logiciel ou OSSI s’attribue directement sur chaque ligne ou dans la fiche, séparément des droits du projet. Reconnexion nécessaire après changement. Le client Windows 0.4.15 reste compatible. Voir [la livraison 0.4.16](docs/roles-utilisateurs-v0.4.16.md).
