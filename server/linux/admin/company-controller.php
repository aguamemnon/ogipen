<?php
if(!function_exists('login_check')){http_response_code(404);exit;}
require_once __DIR__.'/company-service.php';
$companies=[];$companyEdit=null;$collaboration=null;
try{
 $companyDb=db();
 if($_SERVER['REQUEST_METHOD']==='POST'){
  try{csrf_check();$input=$_POST;if(($input['action']??'')==='company_license_import'){$f=$_FILES['license']??null;if(!$f || $f['error']!==UPLOAD_ERR_OK || $f['size']>65536 || !is_uploaded_file($f['tmp_name']))throw new DomainException('Fichier serveur .oglic invalide.');$input['license_json']=file_get_contents($f['tmp_name']);}$message=collaboration_change($companyDb,$input);}
  catch(DomainException $e){$error=$e->getMessage();}
  catch(Throwable $e){$error='Déclaration refusée. Vérifiez le formulaire et rechargez la page.';}
 }
 $collaboration=$companyDb->query('SELECT requested_mode,effective_mode,revision FROM ogp_collaboration_config WHERE id=1')->fetch();
 $companies=$companyDb->query('SELECT c.*,(SELECT COUNT(*) FROM ogp_identity i WHERE i.enabled=1 AND i.company_id=c.id) AS active_users FROM ogp_project_company c ORDER BY display_name,id LIMIT 500')->fetchAll();
 if(isset($_GET['edit'])){foreach($companies as $row){if($row['company_code']===(string)$_GET['edit']){$companyEdit=$row;break;}}if(!$companyEdit)$error='Entreprise introuvable.';}
}catch(Throwable $e){$error='Configuration des entreprises indisponible.';}
