<?php
declare(strict_types=1);
if(!function_exists('login_check')){http_response_code(404);exit;}
require_once __DIR__.'/company-service.php';
require_once __DIR__.'/technical-role-service.php';
function account_password(string $value):string {
 if(strlen($value)<12 || strlen($value)>256)throw new DomainException('Choisissez un mot de passe de 12 à 256 caractères.');
 $salt=random_bytes(32);return 'pbkdf2-sha256$600000$'.base64_encode($salt).'$'.base64_encode(hash_pbkdf2('sha256',$value,$salt,600000,32,true));
}
function account_change(PDO $pdo,array $input):string {
 return admin_lock(function()use($pdo,$input){
  $login=strtolower(trim((string)($input['login']??'')));$action=(string)($input['action']??'');
  if(!preg_match('/\A[a-z0-9][a-z0-9_.@-]{0,79}\z/D',$login) || !in_array($action,['account_save','account_disable'],true))throw new DomainException('Login ou action invalide.');
  $pdo->beginTransaction();try{
   $pdo->query('SELECT id FROM ogp_collaboration_config WHERE id=1 FOR UPDATE')->fetchColumn();
   $q=$pdo->prepare('SELECT a.*,i.system_role AS identity_system_role,i.enabled AS identity_enabled,i.auth_version,i.company_id,i.display_name FROM ogp_app_account a JOIN ogp_identity i ON i.id=a.identity_id WHERE a.login_name=? FOR UPDATE');$q->execute([$login]);$old=$q->fetch();
   if($old && (string)($input['revision']??'')!==(string)$old['auth_version'])throw new DomainException('Compte modifié : rechargez la page.');
   if($action==='account_disable'){
    if(!$old)throw new DomainException('Compte introuvable.');$id=$old['identity_id'];
    technical_role_guard($pdo,['system_role'=>$old['identity_system_role'],'enabled'=>$old['identity_enabled'],'company_id'=>$old['company_id']],$old['identity_system_role'],false,$old['company_id']);
    $q=$pdo->prepare('UPDATE ogp_app_account SET enabled=0,updated_utc=UTC_TIMESTAMP(6) WHERE identity_id=?');$q->execute([$id]);
    $q=$pdo->prepare('UPDATE ogp_identity SET enabled=0,auth_version=auth_version+1 WHERE id=?');$q->execute([$id]);
   }else{
    $name=trim((string)($input['display_name']??''));$role=(string)($input['system_role']??'user');$project=(string)($input['project_role']??'none');$company=(int)($input['company_id']??0);
    if(!$name || strlen($name)>180 || !in_array($role,['user','admin','ossi'],true) || !in_array($project,['none','reader','editor'],true))throw new DomainException('Nom ou rôle invalide.');
    $q=$pdo->prepare("SELECT * FROM ogp_project_company WHERE id=? AND state='prepared' FOR UPDATE");$q->execute([$company]);$c=$q->fetch();if(!$c)throw new DomainException('Choisissez une entreprise licenciée.');$licence=company_license($c);
    $id=$old?$old['identity_id']:'ogipen:'.bin2hex(random_bytes(16));
    $q=$pdo->prepare('SELECT COUNT(*) FROM ogp_identity WHERE enabled=1 AND company_id=? AND id<>?');$q->execute([$company,$id]);if((int)$q->fetchColumn()>=$licence['seats'])throw new DomainException('Quota de l’entreprise atteint.');
    technical_role_guard($pdo,$old?['system_role'=>$old['identity_system_role'],'enabled'=>$old['identity_enabled'],'company_id'=>$old['company_id']]:null,$role,true,$company);
    $password=(string)($input['new_password']??'');$hash=$password!==''?account_password($password):($old['password_hash']??null);if(!$hash)throw new DomainException('Définissez le mot de passe initial.');
    if($old){$q=$pdo->prepare('UPDATE ogp_identity SET display_name=?,enabled=1,company_id=?,system_role=?,auth_version=auth_version+1 WHERE id=?');$q->execute([$name,$company,$role,$id]);}
    else{$q=$pdo->prepare("INSERT INTO ogp_identity(id,display_name,public_key_pem,public_key_sha256,enabled,company_id,auth_version,system_role) VALUES(?,?,'',NULL,1,?,1,?)");$q->execute([$id,$name,$company,$role]);}
    $q=$pdo->prepare('INSERT INTO ogp_app_account(identity_id,login_name,password_hash,system_role,enabled) VALUES(?,?,?,?,1) ON DUPLICATE KEY UPDATE password_hash=VALUES(password_hash),system_role=VALUES(system_role),enabled=1,updated_utc=UTC_TIMESTAMP(6)');$q->execute([$id,$login,$hash,$role]);
    $q=$pdo->prepare('INSERT INTO ogp_permission(identity_id,can_read,can_edit) VALUES(?,?,?) ON DUPLICATE KEY UPDATE can_read=VALUES(can_read),can_edit=VALUES(can_edit)');$q->execute([$id,$project!=='none'?1:0,$project==='editor'?1:0]);
   }
   $q=$pdo->prepare('DELETE FROM ogp_auth_session WHERE identity_id=?');$q->execute([$id]);
   $q=$pdo->prepare("INSERT INTO ogp_audit_event(actor_id,action_code,entity_type,entity_id,details) VALUES(?,'ACCOUNT_CHANGED','administration',0,?)");$q->execute(['ADMIN:'.($_SESSION['admin_name']??'admin'),json_encode(['login'=>$login,'action'=>$action,'system_role'=>$role??$old['system_role']],JSON_THROW_ON_ERROR)]);
   $pdo->commit();return 'Compte enregistré. Le mot de passe n’est ni affiché ni journalisé.';
  }catch(Throwable $e){if($pdo->inTransaction())$pdo->rollBack();throw $e;}
 });
}
