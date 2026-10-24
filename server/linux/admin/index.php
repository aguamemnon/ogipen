<?php
declare(strict_types=1);
require __DIR__ . '/lib.php';
login_check();
$page=$_GET['page']??'overview';
if(!in_array($page,['overview','events','locks','identities','license','companies','settings'],true))$page='overview';
$message='';$error='';
if($page==='license')require __DIR__.'/license-controller.php';
if($page==='identities')require __DIR__.'/identity-controller.php';
if($page==='companies')require __DIR__.'/company-controller.php';
if(!in_array($page,['license','identities','companies'],true) && $_SERVER['REQUEST_METHOD']==='POST'){
 try {
  csrf_check();
  switch($_POST['action']??''){
   case 'login': break;
   case 'unlock':
    $type=(string)($_POST['type']??'');$id=(int)($_POST['entity_id']??0);
    if(!preg_match('/^[a-z_]{1,40}$/',$type)||$id<=0)throw new RuntimeException('Objet invalide');
    $db=db();$db->beginTransaction();
    $st=$db->prepare('SELECT token,owner_id FROM ogp_edit_lock WHERE entity_type=? AND entity_id=? FOR UPDATE');$st->execute([$type,$id]);$lock=$st->fetch();
    if(!$lock)throw new RuntimeException('Verrou déjà libéré');
    $st=$db->prepare('DELETE FROM ogp_edit_lock WHERE entity_type=? AND entity_id=? AND token=?');$st->execute([$type,$id,$lock['token']]);
    $st=$db->prepare("INSERT INTO ogp_audit_event (actor_id,action_code,entity_type,entity_id,details) VALUES (?,?,?,?,?)");
    $st->execute(['ADMIN:'.($_SESSION['admin_name']??'admin'),'LOCK_FORCE_RELEASE',$type,$id,json_encode(['previous_owner'=>$lock['owner_id']])]);
    $db->commit();$message='Verrou libéré et opération journalisée. Le client doit renouveler sa fiche avant tout enregistrement.';break;
   case 'set_identity': throw new RuntimeException('Utilisez la rubrique Utilisateurs pour modifier un accès.');
   default: throw new RuntimeException('Action inconnue');
  }
 }catch(Throwable $e){if(isset($db)&&$db->inTransaction())$db->rollBack();$error=$e->getMessage();}
}
if($page!=='license'){
$pdo=null;
try{$pdo=db();}catch(Throwable $e){$error='Connexion aux données indisponible. Consultez les journaux du serveur.';}
function rows(?PDO $pdo,string $sql):array{return $pdo?$pdo->query($sql)->fetchAll():[];}
$locks=rows($pdo,'SELECT entity_type,entity_id,owner_id,expires_utc FROM ogp_edit_lock ORDER BY expires_utc DESC LIMIT 150');
$events=rows($pdo,'SELECT id,happened_utc,actor_id,action_code,entity_type,entity_id,details FROM ogp_audit_event ORDER BY id DESC LIMIT 150');
$identities=rows($pdo,'SELECT id,display_name,enabled,created_utc FROM ogp_identity ORDER BY created_utc DESC LIMIT 150');
$cables=rows($pdo,'SELECT id,reference,row_version FROM ogp_demo_cable ORDER BY id LIMIT 30');
$activeLocks=count(array_filter($locks,fn($x)=>strtotime($x['expires_utc'].' UTC')>time()));
}
require __DIR__.'/portal-header.php';
?>
<?php if($page==='license'):require __DIR__.'/license-view.php';?>
<?php elseif($page==='overview'):?><?php $service=api_status(); ?><section class="panel"><h2>État du serveur</h2><p>API : <strong><?=$service['online']?'Connectée':'Indisponible'?></strong> · Licence : <strong><?=$service['licensed']?'Active':'À importer ou renouveler'?></strong></p><a href="<?=h(url('/?page=license'))?>">Gérer la licence WordPress</a></section><section class="stats"><article><span>Identités</span><strong><?=count($identities)?></strong></article><article><span>Verrous actifs</span><strong><?=$activeLocks?></strong></article><article><span>Événements récents</span><strong><?=count($events)?></strong></article><article><span>Câbles de démonstration</span><strong><?=count($cables)?></strong></article></section><section class="panel"><h2>Dernières opérations</h2><?=event_table(array_slice($events,0,12))?></section><section class="panel"><h2>Objets de démonstration</h2><table><thead><tr><th>Identifiant</th><th>Référence</th><th>Version</th></tr></thead><tbody><?php foreach($cables as $v):?><tr><td><?=h($v['id'])?></td><td><?=h($v['reference'])?></td><td><?=h($v['row_version'])?></td></tr><?php endforeach;?></tbody></table></section>
<?php elseif($page==='events'):?><section class="panel"><h2>Audit du projet</h2><p>Événements stockés dans la base du projet, pas dans la base centrale.</p><?=event_table($events)?></section>
<?php elseif($page==='locks'):?><section class="panel"><h2>Gestion des éditions concurrentes</h2><p>La libération forcée doit être réservée aux administrateurs habilités. Un client ancien ne pourra plus enregistrer avec son jeton de verrou invalidé.</p><table><thead><tr><th>Objet</th><th>Identifiant</th><th>Utilisateur</th><th>Expiration UTC</th><th>Action</th></tr></thead><tbody><?php foreach($locks as $l):?><tr><td><?=h($l['entity_type'])?></td><td><?=h($l['entity_id'])?></td><td><?=h($l['owner_id'])?></td><td><?=h($l['expires_utc'])?></td><td><form method="post" onsubmit="return confirm('Forcer la libération du verrou ?')"><input type="hidden" name="csrf" value="<?=h(csrf())?>"><input type="hidden" name="action" value="unlock"><input type="hidden" name="type" value="<?=h($l['entity_type'])?>"><input type="hidden" name="entity_id" value="<?=h($l['entity_id'])?>"><button class="danger">Libérer</button></form></td></tr><?php endforeach;?></tbody></table></section>
<?php elseif($page==='identities'):require __DIR__.'/identity-view.php';?>
<?php elseif($page==='companies'):require __DIR__.'/company-view.php';?>
<?php else:?><section class="panel"><h2>Paramètres d’installation</h2><dl><dt>Version</dt><dd>Console PHP v0.4.7</dd><dt>Port d’écoute</dt><dd>192.168.2.216:8080 (réseau local)</dd><dt>Base projet</dt><dd><?=h(getenv('OGIPEN_ADMIN_DB_NAME')?:'non définie')?></dd><dt>Serveur MySQL</dt><dd><?=h(getenv('OGIPEN_ADMIN_DB_HOST')?:'127.0.0.1')?></dd><dt>Authentification</dt><dd>Mot de passe administrateur Argon2id / session locale</dd><dt>API Ogipen</dt><dd>127.0.0.1:5088</dd></dl><p>La création des projets se fait exclusivement depuis le logiciel Ogipen. Ce portail ne crée pas de projet. Les rôles métier seront isolés par projet.</p></section><?php endif; ?>
<?php require __DIR__.'/portal-footer.php'; ?>
