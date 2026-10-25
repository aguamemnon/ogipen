<?php
if(!function_exists('login_check')){http_response_code(404);exit;}
require_once __DIR__.'/identity-service.php';
$identityEdit=null;$identityRows=[];$identityUsed=0;$identityLimit=null;$identityCompanies=[];
try{
    $identityDb=db();
    if($_SERVER['REQUEST_METHOD']==='POST'){
        try{
            csrf_check();$message=identity_change($identityDb,$_POST);
        }catch(DomainException $e){$error=$e->getMessage();}
        catch(PDOException $e){$error=$e->getCode()==='23000'?'Cet identifiant ou cette clé publique est déjà attribué.':'Modification annulée : données indisponibles.';}
        catch(Throwable $e){$error='Modification refusée. Vérifiez le formulaire et son jeton de sécurité.';}
    }
    $identityRows=$identityDb->query('SELECT i.id,i.display_name,i.enabled,i.created_utc,i.public_key_sha256,i.auth_version,i.company_id,i.license_beneficiary_id,COALESCE(p.can_read,0) AS can_read,COALESCE(p.can_edit,0) AS can_edit FROM ogp_identity i LEFT JOIN ogp_permission p ON p.identity_id=i.id WHERE i.id NOT LIKE \'ogipen:%\' ORDER BY i.display_name LIMIT 500')->fetchAll();
    $identityCompanies=$identityDb->query("SELECT id,display_name,slm_license_id FROM ogp_project_company WHERE state='prepared' ORDER BY display_name")->fetchAll();
    $identityUsed=(int)$identityDb->query('SELECT COUNT(*) FROM ogp_identity WHERE enabled=1')->fetchColumn();
    // The quota is company-specific, never a sum of companies' seats.
    if(isset($_GET['edit'])){
        foreach($identityRows as $row){if($row['id']===(string)$_GET['edit']){$identityEdit=$row;break;}}
        if(!$identityEdit)$error='Utilisateur introuvable dans cette liste.';
    }
}catch(Throwable $e){$error='La gestion des utilisateurs est temporairement indisponible.';}
