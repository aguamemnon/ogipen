# Ogipen 0.4.14 — activation séparée de la connexion

## Parcours livré

- Au démarrage, la licence signée locale est contrôlée avant le contrôle du serveur et le login.
- Si elle est absente, expirée ou invalide, une fenêtre dédiée **Activation du poste** s’ouvre. **Continuer vers la connexion** reste désactivé tant que la licence n’est pas valide. **Quitter** arrête le démarrage.
- Si la licence est valide, cette fenêtre n’apparaît pas : le login s’ouvre directement après les contrôles du serveur.
- Le login conserve le choix Windows/AD ou compte interne Ogipen, le nom Windows prérempli modifiable et le mot de passe obligatoire. Aucun bouton d’activation de licence n’y figure.
- Dans l’application : **Administration → Application → Licence / activation** permet de consulter la licence et d’importer son renouvellement. Après un import réussi, une reconnexion applique les nouveaux droits à la session ; fermer la fenêtre sans import ne déconnecte pas l’utilisateur.
- La fiche d’accès Windows reste disponible avant la connexion et dans le menu de l’application. Elle est distincte de l’activation commerciale.

## Concordance visuelle

Les fenêtres de connexion, licence, sélection de projet et profils serveur utilisent le cadre Krypton et la palette sombre de l’application. Les champs et boutons principaux de connexion et de licence sont des contrôles Krypton. Les fonds, libellés et encodages ont été vérifiés sur des rendus Windows réels.

## Validation

Contrôles du démarrage : licence valide sans ouverture du dialogue, activation avant login, annulation bloquante, refus d’un simple résultat de dialogue sans licence valide. Contrôles Windows : vrai ruban Krypton et 7 onglets, formulaires, séparation activation/login, saisies de connexion, preuve de clé CNG et refus Windows invalide. Les 51 contrôles client et les 10 contrôles HTTPS existants passent.

Le premier rendu a révélé un fond clair hérité dans le panneau du login et des caractères mal décodés. Ces défauts ont été corrigés avant livraison, puis les fenêtres ont été rendues et revérifiées. La version utilise le runtime stable .NET Desktop 10.0.13 pour les contrôles.

Ce lot modifie le client Windows uniquement. Il est compatible avec l’API 0.4.13 déjà installée. Aucun service, compte, mot de passe, quota ou fichier de licence existant n’a été modifié sur les serveurs.

Les nouvelles archives et les sources sont disponibles avec cette livraison. La licence déjà importée et la clé locale restent utilisables ; aucune réactivation n’est imposée par la mise à jour du client.
