<?php
require_once '/root/ogipen-v0416/admin/identity-service.php';
$id='win-sid:S-1-5-21-991-992-993-1001';
identity_change($pdo,['action'=>'identity_create','identity_id'=>$id,'display_name'=>'Windows role fixture','public_key'=>file_get_contents('/root/ogipen-v0416/tests/other.pub'),'role'=>'reader','system_role'=>'user','company_id'=>'1']);
function role_row(PDO $pdo,string $id):array{$q=$pdo->prepare('SELECT * FROM ogp_identity WHERE id=?');$q->execute([$id]);return $q->fetch();}
$before=role_row($pdo,$id);$q=$pdo->prepare('SELECT can_read,can_edit FROM ogp_permission WHERE identity_id=?');$q->execute([$id]);$rights=$q->fetch();
identity_change($pdo,['action'=>'identity_system_role','identity_id'=>$id,'revision'=>$before['auth_version'],'system_role'=>'ossi','enabled'=>'1','role'=>'editor','public_key'=>'MUST_IGNORE_EXTRA_FIELD']);
$after=role_row($pdo,$id);$q->execute([$id]);
check('inline_role_changes_only_technical_role',$after['system_role']==='ossi'&&$after['enabled']==0&&$q->fetch()===$rights&&$after['public_key_pem']===$before['public_key_pem']);
rejected('stale_inline_role_form_refused',fn()=>identity_change($pdo,['action'=>'identity_system_role','identity_id'=>$id,'revision'=>$before['auth_version'],'system_role'=>'admin']));
rejected('unknown_technical_role_refused',fn()=>identity_change($pdo,['action'=>'identity_system_role','identity_id'=>$id,'revision'=>$after['auth_version'],'system_role'=>'superuser']));
$internal=$pdo->query("SELECT i.*,a.password_hash FROM ogp_identity i JOIN ogp_app_account a ON a.identity_id=i.id WHERE a.login_name='admin-fixture'")->fetch();
identity_change($pdo,['action'=>'identity_system_role','identity_id'=>$internal['id'],'revision'=>$internal['auth_version'],'system_role'=>'ossi']);
$updated=$pdo->query("SELECT i.system_role,a.system_role AS credential_role,a.password_hash FROM ogp_identity i JOIN ogp_app_account a ON a.identity_id=i.id WHERE a.login_name='admin-fixture'")->fetch();
check('internal_role_from_unified_list_preserves_password',$updated['system_role']==='ossi'&&$updated['credential_role']==='ossi'&&$updated['password_hash']===$internal['password_hash']);
$current=role_row($pdo,'a');rejected('last_windows_or_internal_admin_protected',fn()=>identity_change($pdo,['action'=>'identity_system_role','identity_id'=>'a','revision'=>$current['auth_version'],'system_role'=>'user']));
$identityRows=$pdo->query('SELECT i.*,p.can_read,p.can_edit,a.login_name FROM ogp_identity i LEFT JOIN ogp_permission p ON p.identity_id=i.id LEFT JOIN ogp_app_account a ON a.identity_id=i.id ORDER BY i.id')->fetchAll();$identityUsed=1;$identityEdit=null;$identityCompanies=[];$identityLimit=null;
function h(mixed $x):string{return htmlspecialchars((string)$x,ENT_QUOTES|ENT_SUBSTITUTE,'UTF-8');}function url(string $x):string{return $x;}function csrf():string{return 'fixture-csrf';}
ob_start();require '/root/ogipen-v0416/admin/identity-view.php';$html=ob_get_clean();
check('unified_list_contains_native_and_internal_accounts',str_contains($html,'Windows role fixture')&&str_contains($html,'admin-fixture'));
check('inline_role_selector_and_labels_rendered',str_contains($html,'identity_system_role')&&str_contains($html,'Administrateur logiciel')&&str_contains($html,'OSSI')&&str_contains($html,'Droits du projet'));
