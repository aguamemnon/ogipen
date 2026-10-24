<?php
declare(strict_types=1);
ini_set('session.use_strict_mode','1');ini_set('session.cookie_httponly','1');ini_set('session.cookie_samesite','Strict');ini_set('session.gc_maxlifetime','1800');
$base=rtrim((string)($_SERVER['OGIPEN_BASE_PATH']??(getenv('OGIPEN_PUBLIC_BASE_PATH')?:'')),'/');
if ($base!=='' && !preg_match('#^/[a-zA-Z0-9_-]+$#D',$base)) throw new RuntimeException('Invalid base path');
session_set_cookie_params(['lifetime'=>0,'path'=>$base.'/','secure'=>!empty($_SERVER['HTTPS'])&&$_SERVER['HTTPS']!=='off','httponly'=>true,'samesite'=>'Strict']);
session_name('OGIPENADMIN');session_start();
header('Cache-Control: no-store');header('X-Content-Type-Options: nosniff');header('X-Frame-Options: DENY');header('Referrer-Policy: no-referrer');header("Content-Security-Policy: default-src 'self'; style-src 'self'; form-action 'self'; frame-ancestors 'none'; base-uri 'none'");
function h(mixed $s):string{return htmlspecialchars((string)$s,ENT_QUOTES|ENT_SUBSTITUTE,'UTF-8');}
function csrf():string{return $_SESSION['csrf']??=bin2hex(random_bytes(32));}
function csrf_check():void{if(!hash_equals(csrf(),(string)($_POST['csrf']??'')))throw new RuntimeException('Jeton CSRF invalide');}
function url(string $path='/'):string{global $base;return $base.$path;}
function admin_lock(callable $operation):mixed {
 $f=fopen('/var/lib/ogipen/licensing/.portal-state/administration.lock','c');
 if(!$f)throw new RuntimeException('Verrou administratif indisponible.');
 chmod('/var/lib/ogipen/licensing/.portal-state/administration.lock',0600);
 if(!flock($f,LOCK_EX)){fclose($f);throw new RuntimeException('Administration occupée.');}
 try{return $operation();}finally{flock($f,LOCK_UN);fclose($f);}
}
function login_check():void{if(empty($_SESSION['is_admin'])){header('Location: '.url('/login.php'));exit;}if(time()-($_SESSION['last_seen']??0)>1800 || time()-($_SESSION['created_at']??0)>28800){session_destroy();header('Location: '.url('/login.php'));exit;}$_SESSION['last_seen']=time();}
function login_attempt(string $mode):bool {
 $file='/var/lib/ogipen/licensing/.portal-state/rate-limit/'.hash('sha256',(string)($_SERVER['REMOTE_ADDR']??'unknown')).'.json';
 $f=fopen($file,'c+');if(!$f)throw new RuntimeException('Authentication state unavailable');
 chmod($file,0600);flock($f,LOCK_EX);
 try {
  $d=json_decode(stream_get_contents($f)?:'{}',true)?:[];$now=time();
  if($now-(int)($d['since']??0)>600)$d=['since'=>$now,'failures'=>0];
  $allowed=(int)($d['failures']??0)<5;
  if($mode==='failure')$d['failures']=(int)($d['failures']??0)+1;
  if($mode==='success')$d=['since'=>$now,'failures'=>0];
  rewind($f);ftruncate($f,0);fwrite($f,json_encode($d,JSON_THROW_ON_ERROR));fflush($f);
  return $allowed;
 } finally {flock($f,LOCK_UN);fclose($f);}
}
function api_status():array {
 $ctx=stream_context_create(['http'=>['timeout'=>2,'ignore_errors'=>true]]);
 $body=@file_get_contents('http://127.0.0.1:5088/health',false,$ctx);
 $d=$body!==false?json_decode($body,true):null;
 return is_array($d)?['online'=>($d['status']??'')==='ok','licensed'=>($d['licensed']??false)===true]:['online'=>false,'licensed'=>false];
}
function db():PDO{
 $host=getenv('OGIPEN_ADMIN_DB_HOST')?:'127.0.0.1';$port=(int)(getenv('OGIPEN_ADMIN_DB_PORT')?:3306);$db=getenv('OGIPEN_ADMIN_DB_NAME');$user=getenv('OGIPEN_ADMIN_DB_USER');$pass=getenv('OGIPEN_ADMIN_DB_PASSWORD');
 if(!$db||!$user||$pass===false)throw new RuntimeException('Configuration MySQL absente');
 return new PDO('mysql:host='.$host.';port='.$port.';dbname='.$db.';charset=utf8mb4',$user,$pass,[PDO::ATTR_ERRMODE=>PDO::ERRMODE_EXCEPTION,PDO::ATTR_DEFAULT_FETCH_MODE=>PDO::FETCH_ASSOC,PDO::ATTR_EMULATE_PREPARES=>false]);
}
function event_table(array $events):string{
 ob_start();echo '<table><thead><tr><th>Date UTC</th><th>Utilisateur</th><th>Action</th><th>Objet</th><th>Détails</th></tr></thead><tbody>';
 foreach($events as $e){echo '<tr><td>'.h($e['happened_utc']).'</td><td>'.h($e['actor_id']).'</td><td><span class="pill">'.h($e['action_code']).'</span></td><td>'.h($e['entity_type']).' #'.h($e['entity_id']).'</td><td class="detail">'.h($e['details']??'').'</td></tr>';}
 echo '</tbody></table>';return (string)ob_get_clean();
}
require_once __DIR__.'/auth-event-view.php';
function portal_auth_event(bool $success,string $reason):void {
 try{
  $data=['schema'=>'ogipen-auth-audit-v1','phase'=>'portal','success'=>$success,'reason'=>$reason,'computerName'=>'','userName'=>'admin','identityId'=>'ADMIN:admin','ip'=>(string)($_SERVER['REMOTE_ADDR']??'unknown'),'licenseId'=>null,'serverLicenseId'=>null,'licenseSignatureVerified'=>false,'identityProofVerified'=>false,'clientMetadataDeclared'=>true];
  $q=db()->prepare("INSERT INTO ogp_audit_event(happened_utc,actor_id,action_code,entity_type,entity_id,details) VALUES(UTC_TIMESTAMP(6),'ADMIN:admin','PORTAL_LOGIN','authentication',0,?)");$q->execute([json_encode($data,JSON_THROW_ON_ERROR)]);
 }catch(Throwable $e){error_log('Ogipen portal authentication audit storage unavailable');}
}
