<?php
declare(strict_types=1);
function login_check():void{}
function admin_lock(callable $f):mixed{return $f();}
require '/root/ogipen-v0415/admin/account-service.php';
$pdo=new PDO('mysql:host=localhost;dbname=ogp_v0415_selftest;charset=utf8mb4',getenv('TEST_DB_USER'),getenv('TEST_DB_PASSWORD'),[PDO::ATTR_ERRMODE=>PDO::ERRMODE_EXCEPTION,PDO::ATTR_DEFAULT_FETCH_MODE=>PDO::FETCH_ASSOC]);
$_SESSION=['admin_name'=>'isolated-test'];$results=[];
function check(string $name,bool $pass):void{global $results;$results[]=['test'=>$name,'pass'=>$pass];if(!$pass)throw new RuntimeException($name);}
function rejected(string $name,callable $fn):void{try{$fn();$ok=false;}catch(Throwable $e){$ok=true;}check($name,$ok);}
try{
 rejected('password_too_short_rejected',fn()=>account_password('short'));
 $password='fixture-'.bin2hex(random_bytes(24));$hash=account_password($password);$parts=explode('$',$hash);
 check('php_pbkdf2_format_and_hash_valid',count($parts)===4&&hash_equals(base64_decode($parts[3]),hash_pbkdf2('sha256',$password,base64_decode($parts[2]),600000,32,true)));
 check('password_not_stored_as_plaintext',!str_contains($hash,$password));
 // Tests run after existing scenarios revoke a; restore quota and single active company.
 $pdo->exec("UPDATE ogp_identity SET enabled=0");
 $base=['action'=>'account_save','login'=>'admin-fixture','display_name'=>'Admin fixture','system_role'=>'admin','project_role'=>'reader','company_id'=>'1','new_password'=>$password];
 account_change($pdo,$base);
 $a=$pdo->query("SELECT a.*,i.auth_version FROM ogp_app_account a JOIN ogp_identity i ON i.id=a.identity_id WHERE login_name='admin-fixture'")->fetch();
 check('admin_created_without_windows_key',$a['system_role']==='admin'&&$a['enabled']==1);
 check('technical_role_does_not_imply_edit',(int)$pdo->query("SELECT can_edit FROM ogp_permission WHERE identity_id=".$pdo->quote($a['identity_id']))->fetchColumn()===0);
 rejected('stale_account_form_refused',fn()=>account_change($pdo,$base+['revision'=>'0']));
 $base['revision']=$a['auth_version'];$base['new_password']='replacement-'.bin2hex(random_bytes(20));account_change($pdo,$base);
 $next=$pdo->query("SELECT a.*,i.auth_version FROM ogp_app_account a JOIN ogp_identity i ON i.id=a.identity_id WHERE login_name='admin-fixture'")->fetch();
 check('password_reset_changes_hash_and_revision',$next['password_hash']!==$a['password_hash']&&$next['auth_version']>$a['auth_version']);
 account_change($pdo,['action'=>'account_disable','login'=>'admin-fixture','revision'=>$next['auth_version']]);
 check('account_disable_applied',(int)$pdo->query("SELECT enabled FROM ogp_app_account WHERE login_name='admin-fixture'")->fetchColumn()===0);
 check('audit_never_contains_password',(int)$pdo->query('SELECT COUNT(*) FROM ogp_audit_event WHERE details LIKE '.$pdo->quote('%'.$password.'%'))->fetchColumn()===0);
}finally{file_put_contents('/root/ogipen-v0415/tests/results-accounts.json',json_encode($results,JSON_PRETTY_PRINT));echo json_encode($results,JSON_PRETTY_PRINT),PHP_EOL;}
