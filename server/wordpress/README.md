# WordPress SLM Plus — activation directe du poste, 0.4.12

WordPress reste le seul émetteur des licences serveur et poste. Le parcours **Ogipen hors ligne → Activer un poste (.ogreq)** demande maintenant une licence Ogipen et une demande du poste. Il ne demande plus de bénéficiaire ni de vérification d’identité.

Déployer les MU-plugins `ogipen-workstation-offline.php` et `slmms-admin-quota.php` avec le fork SLM Plus déjà installé et `ogipen-slm-offline.php`. La clé privée de signature reste exclusivement sur WordPress. Aucune migration SQL ni modification d’utilisateur vérifié n’est nécessaire ; `beneficiary_id=0` représente une activation de clé directe, avec le marqueur signé `binding=device`.

Le client et l’API doivent être en 0.4.12 pour accepter le nouveau format. Les demandes `.ogreq` déjà exportées restent compatibles. Les anciens fichiers nominatifs restent acceptés avec leur correspondance historique.

Le compteur de places additionne réservations nominatives actives et clés activées encore valides non couvertes par ces réservations. Le verrou parent de licence sérialise émission, renouvellement et modification administrative du quota. Une nouvelle clé consomme une place ; un renouvellement ne remplace que la même clé. La réduction administrative est refusée sous le nombre de places utilisées. Les quotas existants ne sont pas modifiés.

Les contrôles administrateur, POST, CSRF, preuve P-256, logiciel/version, modules, expiration, nonce unique, signature, audit transactionnel et révocation sont conservés. L’interface explique l’étape suivante : importer le `.oglic` dans le client 0.4.12. L’activation ne donne pas de droits sur un projet : ces droits restent attribués dans le portail de l’entreprise.

Les tests utilisent des tables temporaires qui masquent les tables commerciales uniquement dans la connexion de test. Leurs fixtures signées sont éphémères et ne doivent pas être livrées. Le test v0.4.12 contrôle également qu’aucune licence réelle, aucun utilisateur réel et aucun indicateur de vérification n’a changé.
