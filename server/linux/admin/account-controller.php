<?php
if(!function_exists('login_check')){http_response_code(404);exit;}
require_once __DIR__.'/account-service.php';
$accountRows=[];$accountCompanies=[];
try{
 $pdo=db();if($_SERVER['REQUEST_METHOD']==='POST'){try{csrf_check();$message=account_change($pdo,$_POST);}catch(DomainException $e){$error=$e->getMessage();}catch(Throwable $e){$error='Modification annulée. Vérifiez le formulaire et rechargez la page.';}}
 $accountRows=$pdo->query('SELECT a.identity_id,a.login_name,i.system_role,a.enabled,i.display_name,i.company_id,i.auth_version,COALESCE(p.can_read,0) AS can_read,COALESCE(p.can_edit,0) AS can_edit FROM ogp_app_account a JOIN ogp_identity i ON i.id=a.identity_id LEFT JOIN ogp_permission p ON p.identity_id=i.id ORDER BY a.login_name')->fetchAll();
 $accountCompanies=$pdo->query("SELECT id,display_name FROM ogp_project_company WHERE state='prepared' ORDER BY id")->fetchAll();
}catch(Throwable $e){$error='Gestion des comptes indisponible.';}
