<?php
declare(strict_types=1);
if(!function_exists('login_check')){http_response_code(404);exit;}
require_once __DIR__.'/license-service.php';

$path=getenv('OGIPEN_LICENSE_PATH')?:'/var/lib/ogipen/licensing/server.oglic';
$message='';$error='';$data=null;
if ($_SERVER['REQUEST_METHOD']==='POST') {
    $tmp=null;
    try {
        csrf_check();
        if((int)db()->query('SELECT COUNT(*) FROM ogp_project_company WHERE server_license_json IS NOT NULL')->fetchColumn()>0)throw new DomainException('Les licences utilisées par l’API sont maintenant gérées par entreprise. Importez le renouvellement dans la rubrique Entreprises.');
        $f=$_FILES['license']??null;
        if (!$f || $f['error']!==UPLOAD_ERR_OK || $f['size']>65536 || !is_uploaded_file($f['tmp_name'])) {
            throw new RuntimeException('Fichier de licence invalide ou trop volumineux.');
        }
        $d=bound_license($f['tmp_name']);
        admin_lock(function()use($f,$path,$d,&$tmp){
            $active=(int)db()->query('SELECT COUNT(*) FROM ogp_identity WHERE enabled=1')->fetchColumn();
            if($d['seats']<$active)throw new DomainException('Import refusé : désactivez des utilisateurs avant de réduire le nombre de places à '.$d['seats'].'.');
            $tmp=tempnam(dirname($path),'.import-');
            if (!$tmp || !copy($f['tmp_name'],$tmp) || !chmod($tmp,0640) || !rename($tmp,$path))throw new RuntimeException('Enregistrement impossible.');
            $tmp=null;
        });
        $message='Licence WordPress vérifiée et installée.';
    } catch (DomainException $e) { $error=$e->getMessage(); } catch (Throwable $e) { $error='Import refusé : signature, droits, date ou serveur incorrect.'; }
    finally { if ($tmp && is_file($tmp)) unlink($tmp); }
}
try { $data=bound_license($path); } catch (Throwable $e) {}
