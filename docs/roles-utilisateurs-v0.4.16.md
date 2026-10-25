# Ogipen — rôles techniques dans la liste Utilisateurs

## Parcours

Dans le portail, ouvrir **Utilisateurs**. La liste regroupe désormais les identités Windows/AD et les comptes internes Ogipen. Chaque ligne comporte un sélecteur **Rôle technique** : **Utilisateur**, **Administrateur logiciel** ou **OSSI**. Choisir le rôle puis cliquer sur **Appliquer**.

Le même sélecteur figure dans **Modifier l’utilisateur**, à côté des **Droits du projet**. Ces deux notions restent indépendantes : un compte OSSI ou administrateur peut aussi recevoir ses propres droits de lecture/édition dans le projet.

Un changement ferme les anciennes sessions du compte. Se reconnecter dans le logiciel pour prendre le nouveau rôle en compte. Pour un compte Windows, conserver **Windows / Active Directory** et son mot de passe Windows ; attribuer un rôle ne crée pas un compte interne ni un mot de passe supplémentaire. Pour un compte interne, son mot de passe Ogipen reste inchangé.

Le client Windows **0.4.15 reste compatible**. Aucun nouveau téléchargement ni renouvellement de licence n’est nécessaire.

## Changements techniques

- Ajout de `ogp_identity.system_role`, avec les valeurs `user`, `admin`, `ossi`.
- Reprise des rôles internes déjà déclarés depuis `ogp_app_account`, sans modifier les mots de passe, clés, états, révisions ni droits de projet. Les autres identités conservent le rôle Utilisateur qu’elles avaient jusqu’ici.
- L’API lit le rôle sur l’identité commune aux deux types de comptes. Un administrateur Windows peut ainsi utiliser l’administration des comptes internes depuis le logiciel ; un OSSI Windows reste en consultation.
- Les écritures API et PHP synchronisent les rôles internes pour conserver la compatibilité des outils existants.
- Protection du dernier administrateur actif, contrôle des révisions, CSRF, audit transactionnel et révocation des anciennes sessions. Une affectation de rôle seule ne réactive pas un poste et ne modifie pas ses droits de projet.
- Formulaire des comptes internes adapté dans Utilisateurs : pas de clé Windows demandée pour un compte Ogipen ; lien vers sa gestion de mot de passe.

## Déploiement et validation

Portail et API déployés en **0.4.16** sur **192.168.2.216**. Les rôles, mots de passe, clés, états et droits existants ont été comparés avant/après migration et sont conservés. Aucun compte réel n’a été promu automatiquement.

Sauvegardes protégées : `/root/ogipen-v0416/before.tgz`, `/root/ogipen-v0416/before-project.sql`, copies finales API/portail et feuille de style dans ce même dossier. API et PHP ont été redémarrés. MySQL conserve le PID **243** ; les six services surveillés sont actifs.

Empreinte API SHA-256 : `b0ff3eddc50f67540bef9749bbafae03793b0296d8cdc8366e63ed733aac0d1c`.

**132 contrôles API**, **17 contrôles PHP**, **16 contrôles du portail réel**, **4 contrôles d’intégration C#** et **10 contrôles HTTPS** passent. Les tests vérifient notamment la promotion d’une identité Windows sans création de compte interne, la prise en compte du rôle après reconnexion, l’OSSI en lecture seule, la conservation des droits/projets et mots de passe, les révisions périmées et le refus des rôles inconnus.

Un test de création d’identité a révélé qu’une absence de ligne PDO était transmise comme `false` au nouveau garde de rôle ; cette valeur a été normalisée à `null` avant déploiement. Tous les contrôles passent après correction.

La création de rôles métier personnalisés et l’isolation de plusieurs bases projets restent des lots distincts. WordPress, les quotas et les dates des licences ne sont pas modifiés par cette livraison.
