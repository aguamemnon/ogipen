# OGIPEN C# — Lot 03 : projets et autorisations par poste

**État : contrat client C# + audit de sécurité. L'API serveur et le mapping SQL ne sont pas encore implémentés.** Aucune table, clé, liaison, procédure ou valeur MySQL n'a été modifiée.

## Règles métier conservées

- Une base centrale `progelec` gère les utilisateurs, projets, postes/profils et associations.
- **Une base MySQL dédiée par projet** contient câbles, fils, équipements, tronçons et autres tables métier.
- Le client manipule seulement un identifiant opaque de projet. Il **ne reçoit jamais le nom physique de la base** et n'a pas d'identifiant MySQL `root`.
- L'API serveur vérifie l'identité, le projet et la permission **à chaque requête** avant de résoudre la base du projet.
- Le nom du rôle/poste n'est pas une autorisation suffisante. Les permissions proviennent d'un référentiel central éditable par les administrateurs habilités.

## Profils initiaux, non exhaustifs

| Poste | Portée | Exemples de permissions |
|---|---|---|
| OSSI | Tous les projets | Gérer utilisateurs, droits et projets |
| Chef de projet | Projets créés par lui | Consulter les données et opérer selon délégation explicite |
| Technicien | Projets affectés | Consulter/modifier les données techniques autorisées ; **pas de modification chantier** |
| Chef de chantier | Projets affectés | Consulter le nécessaire ; mettre à jour l'avancement et synchroniser hors ligne ; **pas de modification de la conception** |

Un même utilisateur peut posséder plusieurs affectations de postes distinctes selon le projet. D'autres postes pourront être ajoutés sans recompilation du client.

Les créations de projets par chef de projet, modifications de données techniques par OSSI et délégations restent à préciser : **aucun privilège implicite** ne sera déduit du nom de poste.

## Contrat C# ajouté

`ProjectAccess` :

```json
{
  "id": "project-id-opaque",
  "name": "Projet visible",
  "role": "Technicien",
  "permissions": ["projects.read", "cables.read", "equipments.read"]
}
```

`ProjectScope.Open(session, selected)` refuse un objet projet extérieur à la session. `Can(permission)` sert exclusivement à adapter l'interface ; le serveur refait le contrôle sur chaque endpoint. Les permissions sont explicitement vides en mode aperçu.

**À intégrer ensuite dans l'API ASP.NET Core** :
1. Authentifier via AD / SSO / fournisseur local sécurisé, renvoyer une session valide.
2. Lire les projets attribués depuis `progelec` sans exposer les mots de passe ni les noms de bases.
3. Calculer la liste de permissions par projet (plusieurs affectations possibles, règle de refus par défaut).
4. Sur toute action : autorisation + résolution côté serveur de l'identifiant vers la base + connexion MySQL aux privilèges limités.
5. Faire remonter audit `qui/quand/quoi/pourquoi`, notamment changements de droits et activités hors ligne.
6. Tester qu'un identifiant de projet forgé ou une requête pour un projet non affecté retourne 403, sans accès SQL aux autres projets.

## Vérifications automatiques

Le test Windows `OGIPEN.Desktop.Smoke` vérifie :
- La construction du MainForm et de son ruban.
- La présence du bouton de fermeture de la fenêtre principale.
- Aucune permission métier en mode aperçu.
- Accès possible pour une permission explicite sans en déduire d'autres.
- Refus de contexte pour un projet non présent dans la session.

**Pas de fonctionnalité SQL réelle à ce stade.** La migration vers la base projet reste à développer derrière une API, sans modification du schéma original.
