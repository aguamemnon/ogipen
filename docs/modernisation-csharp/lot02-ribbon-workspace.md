# OGIPEN C# — Lot 02 : Ruban, espace documentaire et grilles

## Demande métier et référence

L'application VB.NET OGIPEN comportait un vrai `FormMain` à ruban DotNetBar, des
fenêtres MDI, un espace de travail multi-onglets et des listes SuperGrid.
Le premier shell C# avec `MenuStrip` n'était **pas** une migration fidèle.

La cible est un poste de travail électrique de type Revit / Microsoft Office
(ruban métier à onglets) et Visual Studio (documents à onglets, division
horizontale/verticale, outils dockés / détachables).

**Consigne visuelle importante : conserver et réutiliser le visuel original du
SplashScreen VB.NET.** Image versionnée :
`progelec/Resources/splash_266-double-2.png`.
Le `csproj` la copie sous `Assets/SplashLegacy.png`. Toute refonte future du
splash doit préserver cette image, quitte à adapter son cadrage et le texte.

## Architecture réalisée

- `MainMdiForm : KryptonForm` : shell multi-documents.
- `KryptonRibbon` : onglets Accueil, Études, Cheminements, Chantier, Rapports,
  Administration, Affichage.
- `KryptonDockableWorkspace` : pages document à onglets déplacées par
  glisser-déposer, divisions gauche/droite et haut/bas via l'onglet Affichage.
- `KryptonDockingManager` : explorateur de projet à gauche, propriétés à droite
  et journal en bas ; panneaux détachables/dockables.
- `BusinessGridControl` : première grille `KryptonDataGridView` triable,
  filtrable, redimensionnable, sélection multiple, copie presse-papiers.

Ce **MDI modernisé** utilise `KryptonDockableWorkspace` et ses pages document
plutôt que `Form.MdiParent` du WinForms classique ; cela permet le
fractionnement et l'ancrage Visual Studio recherchés. Les deux paradigmes
ne sont pas à mélanger sans décision d'architecture.

Les données présentées en mode aperçu sont **fictives** et explicitement
signalées. Aucune requête directe MySQL, aucune modification des données
métier ni changement de clé / relation.

## Correspondance DotNetBar → C#

| Contrôle VB.NET | Cible C# | Couverture |
|---|---|---|
| RibbonForm / RibbonControl | KryptonForm + KryptonRibbon | Socle |
| RibbonTabItem / RibbonPanel | KryptonRibbonTab | Socle |
| RibbonBar / ButtonItem | KryptonRibbonGroup / GroupButton | Socle |
| SuperTabControl / MDI | KryptonDockableWorkspace / KryptonPage | Socle |
| Panneaux latéraux | KryptonDockingManager | Socle |
| SuperGridControl / DataGridViewX | KryptonDataGridView | Tri, filtrage et redimensionnement initiaux |
| Groupement / arborescence SuperGrid | Évaluation contrôlée d'un grid virtuel/hiérarchique | Non réalisé |
| Enregistrement des dispositions | Persistance du workspace, validation des profils | Non réalisé |

## Critères d'acceptation

1. Ouvrir le shell après login et sélection du projet.
2. Afficher un ruban réel avec groupes de boutons, distinct d'un simple menu.
3. Ouvrir « Liste des câbles », « Équipements » et « Tronçons » comme onglets.
4. Déplacer et diviser les onglets depuis « Affichage » ; utiliser les panneaux
   Explorateur, Propriétés et Journal, détachables.
5. Tester le tri par colonne, le filtre textuel et la sélection dans la grille.
6. Changer de thème et persister la disposition dans un prochain lot, seulement
   après validation du design.
7. Aucun bouton ne doit permettre la modification des données réelles ou le
   contournement des permissions (contrôles métier/API non implémentés).

## Sécurité et migration future

Le serveur doit filtrer les projets et les opérations selon l'utilisateur.
Le client n'utilise pas de compte SQL administrateur ; l'isolation **une base
MySQL par projet** est conservée côté serveur.

Pour une grille de gros volumes, exploiter la pagination API, les tris/filtrages
côté serveur et un cache adapté. Un `KryptonDataGridView` n'offre pas
automatiquement l'intégralité des fonctionnalités du DotNetBar SuperGrid.

## Bibliothèques

Suite Krypton 105.26.7.201 : Toolkit, Ribbon, Navigator, Workspace, Docking.
Source : https://github.com/Krypton-Suite/Standard-Toolkit
Licences et dépendances à vérifier dans le processus de distribution.

Le client original reste intact sur `master`.
