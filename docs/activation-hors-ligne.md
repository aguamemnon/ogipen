# Activation Ogipen — 0.4.12

## Parcours du poste

1. Dans le client, ouvrir **Activation hors ligne (.ogreq / .oglic)**. L’identifiant logiciel Ogipen préconfiguré est **405**, majeure **1**.
2. Exporter la demande `.ogreq`. Une demande déjà exportée reste compatible si la clé du même compte Windows existe toujours.
3. Dans WordPress, ouvrir **SLM Plus → Ogipen hors ligne → Activer un poste (.ogreq)**, choisir la **licence Ogipen**, charger la demande puis télécharger le `.oglic`.
4. Dans le **client 0.4.12 ou ultérieur**, choisir **2. Importer la licence (.oglic)**, sélectionner ce fichier puis fermer la fenêtre d’activation.
5. Sélectionner explicitement le serveur de l’entreprise et se connecter avec la session Windows courante.

Il n’y a aucun bénéficiaire à créer, sélectionner ou vérifier dans WordPress. Le gestionnaire reste administrateur de SLM Plus. L’activation automatique en ligne depuis le client reste à développer.

## Licence et accès au projet

WordPress est le seul émetteur. La licence poste contient la même référence commerciale que la licence serveur de l’entreprise. Le serveur vérifie cette correspondance, les dates, les modules et la clé du poste. Les droits métier du projet restent attribués dans le portail à une identité et à sa clé publique ; une activation ne crée pas d’accès au projet.

Le serveur Ogipen de test est **192.168.2.216** : API **https://192.168.2.216/**, portail **http://192.168.2.216:8080/**. WordPress **https://www.trueshield.fr/** émet les licences. Chaque entreprise héberge son API, son portail et ses données. Le mode multi-entreprise reste un choix explicite pour un projet partagé. HTTPS sur le port 8080 est différé à la demande de l’utilisateur.

## Places, renouvellement et anciennes activations

Chaque nouvelle clé activée réserve une place. La clé CNG reste propre au compte Windows ; plusieurs comptes Windows peuvent donc représenter plusieurs clés sur un même PC. Une nouvelle demande de la même clé renouvelle l’activation sans ajouter une place. La durée de 1 à 365 jours est plafonnée par l’expiration commerciale. Un nouvel envoi identique renvoie le même fichier si ses droits sont encore valides.

Les anciennes réservations nominatives et leurs fichiers sont conservés. Elles comptent dans le quota tant qu’elles sont actives. Aucun utilisateur n’est créé ni marqué vérifié par cette mise à jour. Une ancienne activation doit être révoquée explicitement avant de réaffecter sa clé dans le nouveau parcours. Une révocation hors ligne ne supprime pas un fichier déjà importé : sa validité cryptographique dure jusqu’à son expiration.

## Format et contrôles

Les demandes restent au format v1, avec clé publique P-256, nonce, logiciel, majeure et preuve de possession. Aucun nom PC, compte AD ou secret ne figure dans la demande. Les nouvelles licences signées portent `binding: "device"` et `sub: 0`. Zéro sans ce marqueur est refusé ; les anciens fichiers avec un bénéficiaire positif restent pris en charge. Les clés privées restent sur leur hôte respectif.

Le client contrôle la signature WordPress, la clé locale, le logiciel, la version, les modules et l’expiration. Le serveur exige aussi la preuve de la clé, une identité autorisée dans le projet, une entreprise licenciée et la même référence de licence. Le journal des tentatives reste disponible dans le portail.

La licence locale est conservée dans `%LOCALAPPDATA%\OGIPEN\offline-license.oglic`. La clé publique de signature et le profil TLS du serveur de test sont distribués dans `Assets/`. La confiance TLS est limitée au serveur configuré ; aucun certificat racine Windows n’est installé.


## Connexion utilisateur — 0.4.13

Le login est prérempli avec le compte Windows courant, modifiable, avec mot de passe obligatoire. Choix Windows/AD ou compte interne Ogipen. Les comptes admin/OSSI se configurent dans le portail, rubrique Comptes Ogipen. La licence du poste reste distincte du compte choisi. Voir [la connexion 0.4.13](authentification-v0.4.13.md). L’ancienne connexion sans mot de passe est désactivée côté API.
