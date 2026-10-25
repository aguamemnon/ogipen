# Ogipen 0.4.12 — activation sans vérification utilisateur

Déployé le 25 octobre 2026 sur WordPress et sur le serveur Ogipen 192.168.2.216.

## Parcours livré

Dans WordPress : **SLM Plus → Ogipen hors ligne → Activer un poste (.ogreq)**. Sélectionner la licence Ogipen, charger la demande du poste et télécharger le `.oglic`. Dans le client **0.4.12**, ouvrir **Activation hors ligne → 2. Importer la licence (.oglic)**.

Aucun bénéficiaire n’est demandé. Aucun utilisateur WordPress n’est créé ni marqué vérifié. Les demandes `.ogreq` déjà exportées restent compatibles avec la clé du même compte Windows. WordPress reste le seul émetteur ; l’API et le portail restent propres à l’entreprise.

## Changements exacts

- WordPress : `ogipen-workstation-offline.php` remplace la sélection de bénéficiaire par la sélection de licence Ogipen. Les fichiers signés portent `binding=device`, `sub=0`. Le compteur réserve une place par clé active, renouvelle la même clé sans place supplémentaire et conserve les réservations nominatives anciennes. Historique, téléchargement, révocation et audit transactionnel restent actifs.
- WordPress : `slmms-admin-quota.php` refuse une réduction sous le total des réservations et des clés actives. Progelec reste à **10 places**, Ogipen à **3 places**.
- API : `CompanyLicensing.cs`, `OfflineLicenseActivation.cs` et `Program.cs` acceptent le nouveau format sans bénéficiaire mappé et renvoient le contexte de licence correspondant. La signature, la possession de clé, la correspondance de licence serveur/poste, les quotas, modules et droits de projet restent obligatoires. Les anciens fichiers nominatifs restent compatibles avec leur correspondance historique.
- Portail : `identity-service.php`, `identity-view.php`, `company-runtime-view.php`, `index.php`, `portal-header.php`. Le formulaire d’utilisateur du projet ne demande plus de bénéficiaire SLM. Les anciennes correspondances sont conservées en base. Version affichée 0.4.12.
- Client : import du nouveau format et contexte de session avec bénéficiaire nul, version 0.4.12. Même nom de clé CNG ; aucune suppression de clé ni changement automatique de serveur. L’archive inclut la clé publique de signature et le profil de confiance TLS du serveur de test.

Le portail reste **http://192.168.2.216:8080/** et l’API **https://192.168.2.216/**. Aucun changement de MySQL, Nginx, certificats, pare-feu ou services tiers n’était nécessaire.

## Sauvegardes et validation

WordPress : sauvegarde complète préalable base/configuration dans `/var/backups/ogipen-wordpress-*`, copie des MU-plugins `/root/ogipen-v0412/mu-before.tgz`, protégées pour root. Serveur Ogipen : `/root/ogipen-v0412/before.tgz` et `/root/ogipen-v0412/before-project.sql`, protégés pour root.

Contrôles réussis : **36 WordPress**, **68 API**, **19 services PHP**, **24 portail HTTP**, **51 client**, **10 HTTPS**, **6 journal réel**, **9 rendu du journal**, **4 intégration client/API ancienne licence**, **4 intégration client/API sans bénéficiaire**, **8 import d’une véritable signature WordPress**. Le contrôle Windows natif valide SID courant, preuve CNG, clé non exportable, formulaires et ruban. Les tests WordPress utilisent des tables temporaires et vérifient explicitement que les licences et utilisateurs réels sont inchangés. L’API utilise une base temporaire supprimée après les essais.

MySQL n’a pas redémarré : PID **243** conservé. API, portail PHP, Nginx, MySQL, Postfix et Webmin sont actifs. Empreinte SHA-256 de l’API déployée : `82c4659055658cffd404636e4fb64e4283af2c36fd0bfae3fbe01bfaf210cd3c`.

Archive Windows SHA-256 : `C36D0FF00CDDC0EFB0DB18204A928FD307E38334593F79DD93707F14DC9C1AB3`.

## Échecs rencontrés et état restant

Le premier déploiement a été annulé automatiquement car le service PHP FPM dédié ne propose pas de commande de rechargement. Le script a été corrigé pour redémarrer uniquement ce service et l’API, puis le déploiement et les tests ont réussi. La commande PHP générique de WordPress n’avait pas l’extension MySQL ; les vérifications ont utilisé PHP 8.3, déjà installé. Des dépendances de tests manquantes dans le dossier de préparation et un ancien identifiant de fixture ont été corrigés avant validation. Aucun échec de test ne reste ouvert.

L’activation automatique en ligne depuis le client reste à développer. L’accès au projet nécessite encore une entreprise licenciée, une identité et sa clé publique autorisées dans le portail ; les registres réels d’entreprises et d’identités sont encore vides. La simplification d’activation ne crée pas ces accès. Les essais complets ont donc été faits dans une base isolée, sans inventer d’utilisateur réel.

La licence Ogipen de test #2 expire le **25 octobre 2026 à 20:07:16 UTC** (21:07:16 heure de Paris après le changement d’heure). Aucune prolongation commerciale n’a été effectuée. HTTPS sur le port 8080 reste différé à la demande de l’utilisateur. Les fichiers hors ligne déjà importés ne peuvent pas être supprimés à distance par une révocation.
