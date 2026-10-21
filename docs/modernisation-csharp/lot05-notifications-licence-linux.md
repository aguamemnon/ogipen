# OGIPEN — Alertes de licence et préparation Linux

## Alertes de validité (lot 05)

Un moteur C# **sans WinForms** a été ajouté dans `src/OGIPEN.Core`, compilable sur Windows **et Linux**.

### Seuils, date UTC, date de fin incluse

| Situation | Message | Sévérité | Modules sous licence |
|---|---|---|---|
| Aucune licence | Aucune licence OGIPEN | Critique | Bloqués |
| Signature non validée | Licence non authentifiée | Critique | Bloqués |
| J-30 à J-16 avant expiration | Renouvellement à prévoir | Avertissement | Autorisés si les autres contrôles sont OK |
| J-15 à J-1 avant expiration | Expiration prochaine | Avertissement | Autorisés si les autres contrôles sont OK |
| J0 (jour de validité final) | Dernier jour de validité | Avertissement | Autorisés jusqu'à la fin du jour UTC |
| J+1 à J+14 | Licence expirée | Critique | Bloqués |
| J+15 à J+29 | Licence expirée depuis 15 jours ou plus | Critique | Bloqués |
| J+30 ou plus | Licence expirée depuis 30 jours ou plus | Critique | Bloqués |

Les intervalles après expiration ne constituent **pas** une période de grâce automatique. Toute grâce doit être une autorisation **distincte, signée, limitée dans le temps**. Les limites 15/30 sont des seuils de notification, pas des licences prolongées.

### Implémentation actuelle

- `LicenseAlertEvaluator.Evaluate` : classe métier pure .NET 10, testée.
- `LicenseSignatureVerifier.TryVerify` : vérification ECDSA P-256 SHA-256 de données signées par WordPress (signature DER, payload JSON UTF-8 codé en base64, `kid` explicite). Refus si signature altérée / `kid` non reconnu.
- `LicenseNoticePanel` : bandeau de notification présent sur Login et MainForm.
- En absence de service SLM Plus / OGIPEN License Manager connecté, le bandeau indique **« Aucune licence signée vérifiée »**. Le mode aperçu sans données reste accessible.
- **Attention** : le client n'utilise pas encore un flux réel de licence WordPress, et n'a pas de clé publique de production à épingler. Les notifications J0/J±15/30 sont implémentées dans le moteur et testées, mais **pas encore alimentées depuis une vraie licence**. Ne pas interpréter les prototypes comme un mécanisme de protection final.
- L'activation effective des modules exige toujours un utilisateur déclaré par le client sur WordPress, une licence active, un module acheté, puis le droit `progelec` pour le projet et l'opération.

### Test multiplateforme

```bash
dotnet run --project tests/OGIPEN.Core.Checks/OGIPEN.Core.Checks.csproj -c Release
```

Ces contrôles couvrent : absence de licence, signature non vérifiée, seuils J±30/J±15/J0, refus de JSON falsifié, mauvaise clé publique et mauvaise `kid`.

## Portage de l'interface Windows vers Linux

- L'application actuelle **WinForms/Krypton** ne fonctionne pas nativement sous Linux, même si l'API ASP.NET Core fonctionne très bien sous Linux.
- Le moteur métier, les contrats API, les droits, la synchronisation, le chiffrement et les licences sont à isoler dans des projets `net10.0` sans dépendance Windows, tels que `OGIPEN.Core`.
- Une interface Linux native pourra être créée avec **Avalonia UI** et partager ces bibliothèques. Les rubans et panneaux dockables devront être recréés avec des contrôles compatibles Avalonia ; on ne peut pas simplement copier les composants Krypton.
- Sous Windows : identité locale SAM / AD. Sous Linux : PAM, intégration du domaine selon environnement, ou compte OGIPEN. Les identités externes doivent être liées à un compte OGIPEN autorisé.
- Les futures chaînes de compilation pourront générer `win-x64`, `linux-x64`, et `linux-arm64` après validation des dépendances et du moteur graphique.
- Si une vraie version Linux est stratégique, choisir l'interface multiplateforme **avant** le portage de nombreux formulaires métier pour éviter deux développements d'UI.

## Référence architecture

Voir `lot04-identites-licences-wordpress.md` : WordPress / SLM Plus + extension OGIPEN, utilisateurs nominatifs, modules Étude/Rapports/Chantier, SAM/AD local, `progelec`, une base MySQL par projet.

**Aucune modification de la base MySQL ni de `master`.**
