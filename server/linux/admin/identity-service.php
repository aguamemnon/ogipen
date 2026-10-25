<?php
declare(strict_types=1);
if(!function_exists('login_check')){http_response_code(404);exit;}
require_once __DIR__.'/license-service.php';
require_once __DIR__.'/company-service.php';

function identity_key(string $pem):array {
    if(strlen($pem)>4096 || str_contains($pem,'PRIVATE KEY') || !str_starts_with(trim($pem),'-----BEGIN PUBLIC KEY-----'))throw new DomainException('Collez uniquement une clé publique ECDSA P-256 au format PEM.');
    $key=openssl_pkey_get_public($pem);$d=$key?openssl_pkey_get_details($key):false;
    if(!$d || $d['type']!==OPENSSL_KEYTYPE_EC || ($d['ec']['curve_name']??'')!=='prime256v1')throw new DomainException('La clé publique doit utiliser la courbe ECDSA P-256.');
    $der=base64_decode(preg_replace('/-----[^-]+-----|\s/','',$d['key']),true);
    if($der===false)throw new DomainException('Clé publique invalide.');
    return ['pem'=>$d['key'],'fingerprint'=>hash('sha256',$der)];
}
function identity_change(PDO $pdo,array $input):string {
    return admin_lock(function()use($pdo,$input){
        $id=(string)($input['identity_id']??'');$action=(string)($input['action']??'');
        if(!preg_match('/\A[A-Za-z0-9][A-Za-z0-9_.:@-]{0,79}\z/D',$id) || !in_array($action,['identity_create','identity_save','identity_toggle'],true))throw new DomainException('Identifiant invalide : utilisez 1 à 80 lettres, chiffres ou caractères . _ : @ -');
        $pdo->beginTransaction();
        try{
            $q=$pdo->prepare('SELECT * FROM ogp_identity WHERE id=? FOR UPDATE');$q->execute([$id]);$old=$q->fetch();
            if($action==='identity_create' && $old)throw new DomainException('Cet identifiant est déjà attribué.');
            if($action!=='identity_create' && !$old)throw new DomainException('Utilisateur introuvable.');
            if($old && (string)($input['revision']??'')!==(string)$old['auth_version'])throw new DomainException('Cet utilisateur a été modifié. Rechargez sa fiche avant de recommencer.');
            $q=$pdo->prepare('SELECT can_read,can_edit FROM ogp_permission WHERE identity_id=?');$q->execute([$id]);$permission=$q->fetch()?:['can_read'=>0,'can_edit'=>0];
            $oldRole=$permission['can_edit']?'editor':($permission['can_read']?'reader':'none');
            $toggle=$action==='identity_toggle';
            $name=$toggle?$old['display_name']:trim((string)($input['display_name']??''));
            $role=$toggle?$oldRole:(string)($input['role']??'');
            $enabled=(string)($input['enabled']??'0');
            if(!preg_match('/\A[^\x00-\x1f\x7f]{1,180}\z/u',$name) || !in_array($role,['none','reader','editor'],true) || !in_array($enabled,['0','1'],true))throw new DomainException('Nom, droits ou état de l’utilisateur invalide.');
            $pem=$toggle?'':trim((string)($input['public_key']??''));
            if(!$pem && !$old)throw new DomainException('La clé publique de l’utilisateur est requise.');
            $key=identity_key($pem?:$old['public_key_pem']);
            $company=$toggle?($old['company_id']??null):($input['company_id']??null);
            $beneficiary=$toggle?($old['license_beneficiary_id']??null):($input['license_beneficiary_id']??($old['license_beneficiary_id']??null));
            $company=$company===''?null:$company;$beneficiary=$beneficiary===''?null:$beneficiary;
            foreach([$company,$beneficiary] as $value){if($value!==null && !preg_match('/\A[1-9][0-9]{0,14}\z/D',(string)$value))throw new DomainException('Entreprise ou bénéficiaire SLM invalide.');}
            if($company===null && $beneficiary!==null)throw new DomainException('L’ancienne attribution nominative nécessite son entreprise.');
            if($enabled==='1'){
                $q=$pdo->prepare("SELECT * FROM ogp_project_company WHERE id=? AND state='prepared' FOR UPDATE");$q->execute([$company]);$companyRow=$q->fetch();
                if(!$companyRow)throw new DomainException('Une entreprise licenciée est requise pour activer cet utilisateur.');
                try{$license=company_license($companyRow);}
                catch(Throwable $e){throw new DomainException('Une licence serveur WordPress valide est requise pour cette entreprise.');}
                $q=$pdo->prepare('SELECT COUNT(*) FROM ogp_identity WHERE enabled=1 AND company_id=? AND id<>?');$q->execute([$company,$id]);
                if((int)$q->fetchColumn()>=$license['seats'])throw new DomainException('Quota atteint. Désactivez un utilisateur ou importez une licence avec davantage de places.');
            }
            $read=$role==='none'?0:1;$edit=$role==='editor'?1:0;
            $changed=!$old || $old['display_name']!==$name || (int)$old['enabled']!==(int)$enabled || $old['public_key_pem']!==$key['pem'] || $role!==$oldRole || (string)$old['company_id']!==(string)$company || (string)$old['license_beneficiary_id']!==(string)$beneficiary;
            if(!$changed){$pdo->rollBack();return 'Aucun changement à enregistrer.';}
            if($old){
                $q=$pdo->prepare('UPDATE ogp_identity SET display_name=?,public_key_pem=?,public_key_sha256=?,enabled=?,company_id=?,license_beneficiary_id=?,auth_version=auth_version+1 WHERE id=?');
                $q->execute([$name,$key['pem'],$key['fingerprint'],(int)$enabled,$company,$beneficiary,$id]);
            }else{
                $q=$pdo->prepare('INSERT INTO ogp_identity(id,display_name,public_key_pem,public_key_sha256,enabled,company_id,license_beneficiary_id,auth_version) VALUES(?,?,?,?,?,?,?,1)');
                $q->execute([$id,$name,$key['pem'],$key['fingerprint'],(int)$enabled,$company,$beneficiary]);
            }
            $q=$pdo->prepare('INSERT INTO ogp_permission(identity_id,can_read,can_edit) VALUES(?,?,?) ON DUPLICATE KEY UPDATE can_read=VALUES(can_read),can_edit=VALUES(can_edit)');
            $q->execute([$id,$read,$edit]);
            if($old){$q=$pdo->prepare('DELETE FROM ogp_edit_lock WHERE owner_id=?');$q->execute([$id]);}
            $details=['identity_id'=>$id,'before'=>$old?['enabled'=>(int)$old['enabled'],'role'=>$oldRole,'public_key_sha256'=>$old['public_key_sha256'],'company_id'=>$old['company_id'],'beneficiary_id'=>$old['license_beneficiary_id']]:null,'after'=>['enabled'=>(int)$enabled,'role'=>$role,'public_key_sha256'=>$key['fingerprint'],'company_id'=>$company,'beneficiary_id'=>$beneficiary]];
            $q=$pdo->prepare('INSERT INTO ogp_audit_event(actor_id,action_code,entity_type,entity_id,details) VALUES(?,?,?,?,?)');
            $q->execute(['ADMIN:'.($_SESSION['admin_name']??'admin'),$old?'IDENTITY_UPDATED':'IDENTITY_ENROLLED','identity',0,json_encode($details,JSON_THROW_ON_ERROR)]);
            $pdo->commit();
            return $old?'Utilisateur mis à jour. Ses sessions précédentes sont révoquées.':'Utilisateur ajouté. Sa clé privée reste sur son poste.';
        }catch(Throwable $e){if($pdo->inTransaction())$pdo->rollBack();throw $e;}
    });
}
