# OGIPEN C# — Échange de licence hors ligne (.ogreq / .oglic)

## Étapes prévues (sans accès Internet sur le poste)

1. Dans l'écran **Identification**, bouton **Activation hors ligne**
   (également présent dans le ruban **Administration → Application**).
2. Indiquer l'identifiant du logiciel dans le catalogue SLM Plus
   (valeur numérique du post Progelec de la boutique). On peut le
   préconfigurer via `%APPDATA%\\OGIPEN\\clientsettings.json` :
   `{"OfflineSoftwareId": 123}` avec **123 à remplacer**.
3. **Exporter la demande (.ogreq)**.
4. Faire traiter la demande par le gestionnaire de licences sur un poste
   autorisé à accéder à WordPress (voir documentation SLM Plus).
5. **Importer la licence (.oglic)** sur le poste isolé.
6. OGIPEN vérifie la signature, le bon poste, le logiciel,
   la version majeure, les modules et l'expiration **sans réseau**.

## Confiance et cryptographie

- Poste Windows : clé EC P-256 propre au profil, persistante et marquée
  non exportable par le magasin Windows CNG Microsoft Software KSP.
  Aucune clé privée ne figure dans `.ogreq` ou `.oglic`.
- La demande comporte seulement clé publique SPKI, identifiant logiciel,
  version majeure, défi aléatoire, preuve de possession de la clé.
- Le serveur WordPress signe avec sa clé ECDSA P-256, conservée sur Linux.
- OGIPEN refuse tout fichier mal signé ou lié à un autre poste, et vérifie
  les identifiants du logiciel, la version, les modules et les dates.
- Le public signer `SLMMS-Signing-Public.pem` doit être distribué comme
  **ancre de confiance par l'installateur signé** dans le dossier
  `Assets/` du client. Ne pas la récupérer depuis une URL arbitraire
  à chaque vérification : une substitution de clé annulerait la garantie.
- Émetteur attendu en dur pour ce prototype :
  `https://www.trueshield.fr`; logiciel `progelec`, majeure `1`.
  Ces valeurs devront suivre la configuration signée de chaque distribution.
- Une licence valide est conservée dans
  `%LOCALAPPDATA%\\OGIPEN\\offline-license.oglic`.

## Important : portée du prototype

**L'import local cryptographique est implémenté**, mais le logiciel ne
dispose pas encore d'une authentification Windows SAM/AD locale intégrée
au processus de démarrage ni du chargement des projets et données
hors connexion. Le mode aperçu reste sans accès métier.

Une licence signée ne remplace **jamais** le contrôle des identités, des
modules en cours d'utilisation ni les droits de chaque projet. Ces
fonctions sont à raccorder. Les mécanismes d'horloge fiable, anti-retour
en arrière, TPM et renouvellement restent également à développer.

Pour un environnement relevant de l'IGI 1300, ce prototype n'est
**ni homologué ni recommandé en production classifiée en l'état**.
Le transfert physique de `.ogreq` et `.oglic` doit être validé
par l'autorité de sécurité/homologation, avec supports et procédures
autorisés. Même si la demande ne contient aucun nom/AD/projet,
elle doit être examinée avant de sortir d'un SI classifié.

La compromission antérieure du serveur WordPress doit avoir été
entièrement traitée avant d'y installer une clé privée de production.
