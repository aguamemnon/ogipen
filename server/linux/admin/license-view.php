<?php if(!function_exists('bound_license')){http_response_code(404);exit;} ?>
<section class="panel license-summary">
<div class="section-heading"><div><h2>Droits du serveur</h2><p>Retrouvez ici votre licence et sa date de validité.</p></div><span class="license-badge <?=$data?'valid':'invalid'?>"><?=$data?'Licence valide':'Activation requise'?></span></div>
<?php if($data):?>
<dl class="license-details"><dt>Licence</dt><dd><?=h($data['license_id'])?></dd><dt>Places autorisées</dt><dd><?=h($data['seats'])?></dd><dt>Valable jusqu’au</dt><dd><?=h((new DateTimeImmutable($data['expires_utc']))->format('d/m/Y à H:i'))?> UTC</dd><dt>Modules supplémentaires</dt><dd><?=count($data['modules'])?h(implode(', ',$data['modules'])):'Aucun'?></dd></dl>
<?php else:?><p>Importez une licence valide pour activer l’API de ce serveur. Vous pouvez continuer à administrer le portail.</p><?php endif;?>
</section>
<div class="license-grid"><section class="panel"><h2>Importer ou renouveler</h2><p>Sélectionnez le fichier de licence exporté depuis WordPress. Il est vérifié avant de remplacer la licence actuelle.</p>
<form class="license-import" method="post" action="<?=h(url('/?page=license'))?>" enctype="multipart/form-data"><input type="hidden" name="csrf" value="<?=h(csrf())?>"><label for="license-file">Fichier de licence</label><input id="license-file" type="file" name="license" accept=".oglic,.json,application/json" required><button>Vérifier et importer la licence</button></form>
<p class="hint">Un fichier refusé ne modifie pas la licence en cours.</p></section>
<section class="panel"><h2>Votre serveur</h2><p>Utilisez cet identifiant lors de l’export dans WordPress :</p><code class="server-identifier"><?=h(getenv('OGIPEN_SERVER_ID'))?></code><p>Les places, modules et renouvellements sont gérés dans SLM Plus.</p><a class="button-link" href="https://www.trueshield.fr/wp-admin/admin.php?page=ogipen-offline" target="_blank" rel="noopener noreferrer">Ouvrir WordPress ↗</a><p class="hint">Les changements de droits dans WordPress nécessitent un nouvel export et un nouvel import sur ce serveur.</p></section></div>
