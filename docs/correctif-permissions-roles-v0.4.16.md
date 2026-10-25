# Correction du message « Modification annulée : données indisponibles »

Cause reproduite avec le vrai compte SQL `ogp_admin_php`, sous le compte système PHP et avec les préparations PDO natives : MySQL refusait l’accès à la colonne `identity_id` lors du `DELETE` des anciennes sessions. Le droit DELETE seul ne suffisait pas pour la condition WHERE. La transaction de changement de rôle était donc annulée.

Correction appliquée : `GRANT SELECT (identity_id) ON ogp_test_001.ogp_auth_session TO 'ogp_admin_php'@'localhost'`. Aucun droit de lecture sur les identifiants de session, fichiers de licence ou autres colonnes n’a été accordé. Les scripts de déploiement 0.4.13 et 0.4.16 intègrent maintenant ce prérequis.

Le contrôleur d’utilisateurs journalise désormais uniquement SQLSTATE et le numéro d’erreur, sans données saisies ni secrets. Une erreur de permissions fournit un message technique plus précis.

Validation réelle : l’intégralité de l’écriture d’identité est exécutée avec les droits du portail puis volontairement annulée avant COMMIT. Trois contrôles passent : accès complet au chemin d’écriture, état réel du compte préservé après rollback et lecture des identifiants de session toujours refusée. Les 16 contrôles HTTP du portail passent également.

Les tests antérieurs utilisaient un compte SQL de test plus permissif et n’avaient pas révélé ce droit manquant. Le nouveau contrôle utilise les permissions réelles du portail.

Sauvegardes des droits avant/après et du contrôleur PHP dans `/root/ogipen-v0416/permission-fix/`, protégées pour root. Aucun rôle réel n’a été attribué par ce diagnostic. Aucun service n’a été redémarré. Aucun nouveau client Windows n’est nécessaire.
