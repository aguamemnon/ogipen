<?php
if(!function_exists('login_check')){http_response_code(404);exit;}
require_once __DIR__.'/company-service.php';
$companies=[];$companyEdit=null;$collaboration=null;
try{
 $companyDb=db();
 if($_SERVER['REQUEST_METHOD']==='POST'){
  try{csrf_check();$message=collaboration_change($companyDb,$_POST);}
  catch(DomainException $e){$error=$e->getMessage();}
  catch(Throwable $e){$error='Déclaration refusée. Vérifiez le formulaire et rechargez la page.';}
 }
 $collaboration=$companyDb->query('SELECT requested_mode,revision FROM ogp_collaboration_config WHERE id=1')->fetch();
 $companies=$companyDb->query('SELECT * FROM ogp_project_company ORDER BY display_name,id LIMIT 500')->fetchAll();
 if(isset($_GET['edit'])){foreach($companies as $row){if($row['company_code']===(string)$_GET['edit']){$companyEdit=$row;break;}}if(!$companyEdit)$error='Entreprise introuvable.';}
}catch(Throwable $e){$error='Configuration des entreprises indisponible.';}
