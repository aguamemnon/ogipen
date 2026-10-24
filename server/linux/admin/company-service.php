<?php
declare(strict_types=1);
if(!function_exists('login_check')){http_response_code(404);exit;}
require_once __DIR__.'/license-service.php';

function company_license(array $company):array {
 if(empty($company['server_license_json']) || empty($company['slm_license_id']))throw new DomainException('Importez une licence serveur signée pour cette entreprise.');
 // Use a private, short-lived file because the common verifier reads a path.
 $tmp=tempnam('/var/lib/ogipen/licensing/.portal-state','verify-');
 if(!$tmp)throw new RuntimeException('Vérification indisponible.');
 try{chmod($tmp,0600);file_put_contents($tmp,$company['server_license_json']);$d=bound_license($tmp);}
 finally{unlink($tmp);}
 if($d['license_id']!=='slmms:'.(int)$company['slm_license_id'])throw new DomainException('La licence signée ne correspond pas à cette entreprise.');
 if(count($d['modules'])>200)throw new DomainException('Liste de modules invalide.');
 foreach($d['modules'] as $module){if(!is_int($module) || $module<1)throw new DomainException('Liste de modules invalide.');}
 return $d;
}

// Declarations only: this service cannot allocate seats or authorize a client.
function collaboration_change(PDO $pdo,array $input):string {
 return admin_lock(function()use($pdo,$input){
  $action=(string)($input['action']??'');
  $reason=trim((string)($input['reason']??''));
  if(!preg_match('/\A[^\x00-\x1f\x7f]{3,300}\z/u',$reason))throw new DomainException('Indiquez un motif de 3 à 300 caractères.');
  $pdo->beginTransaction();
  try{
   $config=$pdo->query('SELECT * FROM ogp_collaboration_config WHERE id=1 FOR UPDATE')->fetch();
   if(!$config)throw new RuntimeException('Configuration absente.');
   if($action==='company_license_import'){
    $id=(int)($input['company_id']??0);$q=$pdo->prepare('SELECT * FROM ogp_project_company WHERE id=? FOR UPDATE');$q->execute([$id]);$company=$q->fetch();
    if(!$company || (string)($input['revision']??'')!==(string)$company['revision'])throw new DomainException('Entreprise modifiée ou introuvable. Rechargez la page.');
    $candidate=$company;$candidate['server_license_json']=(string)($input['license_json']??'');
    if(strlen($candidate['server_license_json'])>65536)throw new DomainException('Fichier trop volumineux.');
    $d=company_license($candidate);
    $q=$pdo->prepare('SELECT COUNT(*) FROM ogp_project_company WHERE id<>? AND slm_license_id=? AND server_license_json IS NOT NULL');$q->execute([$id,$company['slm_license_id']]);
    if((int)$q->fetchColumn()>0)throw new DomainException('Cette licence est déjà affectée à une autre entreprise de ce projet.');
    $q=$pdo->prepare('SELECT COUNT(*) FROM ogp_identity WHERE enabled=1 AND company_id=?');$q->execute([$id]);
    if((int)$q->fetchColumn()>$d['seats'])throw new DomainException('Le quota signé est inférieur aux utilisateurs actifs de cette entreprise.');
    $q=$pdo->prepare('UPDATE ogp_project_company SET server_license_json=?,revision=revision+1 WHERE id=?');$q->execute([$candidate['server_license_json'],$id]);
    $entity=$id;$details=['company_id'=>$id,'license_id'=>$d['license_id'],'seats'=>$d['seats'],'sha256'=>hash('sha256',$candidate['server_license_json']),'reason'=>$reason];
   }elseif($action==='collaboration_activate'){
    if((string)($input['revision']??'')!==(string)$config['revision'])throw new DomainException('La configuration a changé. Rechargez la page.');
    $prepared=$pdo->query("SELECT * FROM ogp_project_company WHERE state='prepared'")->fetchAll();
    if(!$prepared || ($config['requested_mode']==='single' && count($prepared)!==1))throw new DomainException('Déclarez les entreprises et choisissez le mode adapté.');
    $ids=[];foreach($prepared as $company){$d=company_license($company);if(isset($ids[$d['license_id']]))throw new DomainException('Chaque entreprise doit avoir sa propre licence.');$ids[$d['license_id']]=true;}
    $q=$pdo->prepare('UPDATE ogp_collaboration_config SET effective_mode=requested_mode,revision=revision+1 WHERE id=1');$q->execute();
    $entity=1;$details=['effective_mode'=>$config['requested_mode'],'companies'=>count($prepared),'reason'=>$reason];
   }elseif($action==='collaboration_mode'){
    if((string)($input['revision']??'')!==(string)$config['revision'])throw new DomainException('La configuration a changé. Rechargez la page.');
    $mode=(string)($input['mode']??'');
    if(!in_array($mode,['single','multi'],true))throw new DomainException('Mode invalide.');
    if($mode==='single' && (int)$pdo->query("SELECT COUNT(*) FROM ogp_project_company WHERE state='prepared'")->fetchColumn()>1)throw new DomainException('Archivez les entreprises supplémentaires avant de préparer le mode mono-entreprise.');
    if($mode===$config['requested_mode']){$pdo->rollBack();return 'Aucun changement à enregistrer.';}
    $q=$pdo->prepare('UPDATE ogp_collaboration_config SET requested_mode=?,revision=revision+1 WHERE id=1');$q->execute([$mode]);
    $details=['before'=>$config['requested_mode'],'requested_mode'=>$mode,'effective_mode'=>$config['effective_mode'],'reason'=>$reason];$entity=1;
   }elseif($action==='company_save'){
    $code=trim((string)($input['company_code']??''));$name=trim((string)($input['display_name']??''));$lot=trim((string)($input['work_package']??''));$license=trim((string)($input['slm_license_id']??''));$state=(string)($input['state']??'prepared');
    if(!preg_match('/\A[a-z0-9][a-z0-9_-]{0,63}\z/D',$code) || !preg_match('/\A[^\x00-\x1f\x7f]{1,180}\z/u',$name) || !preg_match('/\A[^\x00-\x1f\x7f]{0,180}\z/u',$lot) || !in_array($state,['prepared','archived'],true) || ($license!=='' && !preg_match('/\A[1-9][0-9]{0,8}\z/D',$license)))throw new DomainException('Code, nom, lot, état ou référence SLM invalide.');
    $q=$pdo->prepare('SELECT * FROM ogp_project_company WHERE company_code=? FOR UPDATE');$q->execute([$code]);$old=$q->fetch();
    if((string)($input['revision']??'')!==($old?(string)$old['revision']:'0'))throw new DomainException('Cette entreprise a changé. Rechargez sa fiche.');
    $q=$pdo->prepare("SELECT COUNT(*) FROM ogp_project_company WHERE state='prepared' AND company_code<>?");$q->execute([$code]);
    if($state==='prepared' && $config['requested_mode']==='single' && (int)$q->fetchColumn()>0)throw new DomainException('Préparez le mode multi-entreprise avant de déclarer une deuxième entreprise.');
    if($old){$q=$pdo->prepare('UPDATE ogp_project_company SET display_name=?,work_package=?,server_license_json=IF(slm_license_id<=>?,server_license_json,NULL),slm_license_id=?,state=?,revision=revision+1 WHERE id=?');$q->execute([$name,$lot,$license===''?null:(int)$license,$license===''?null:(int)$license,$state,$old['id']]);$entity=(int)$old['id'];}
    else{$q=$pdo->prepare('INSERT INTO ogp_project_company(company_code,display_name,work_package,slm_license_id,state) VALUES(?,?,?,?,?)');$q->execute([$code,$name,$lot,$license===''?null:(int)$license,$state]);$entity=(int)$pdo->lastInsertId();}
    $details=['company_code'=>$code,'before'=>$old?:null,'after'=>['display_name'=>$name,'work_package'=>$lot,'slm_license_id'=>$license,'state'=>$state],'reason'=>$reason];
   }else throw new DomainException('Action inconnue.');
   $q=$pdo->prepare('INSERT INTO ogp_audit_event(actor_id,action_code,entity_type,entity_id,details) VALUES(?,?,?,?,?)');
   $codes=['collaboration_mode'=>'COLLABORATION_REQUESTED','collaboration_activate'=>'COLLABORATION_ACTIVATED','company_license_import'=>'COMPANY_LICENSE_IMPORTED','company_save'=>'COMPANY_DECLARED'];
   $q->execute(['ADMIN:'.($_SESSION['admin_name']??'admin'),$codes[$action],'collaboration',$entity,json_encode($details,JSON_THROW_ON_ERROR)]);
   $pdo->commit();
   return 'Modification enregistrée et auditée. Les accès restent soumis aux licences signées et aux droits du projet.';
  }catch(Throwable $e){if($pdo->inTransaction())$pdo->rollBack();throw $e;}
 });
}
