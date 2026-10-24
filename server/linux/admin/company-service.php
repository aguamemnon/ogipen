<?php
declare(strict_types=1);
if(!function_exists('login_check')){http_response_code(404);exit;}

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
   if($action==='collaboration_mode'){
    if((string)($input['revision']??'')!==(string)$config['revision'])throw new DomainException('La configuration a changé. Rechargez la page.');
    $mode=(string)($input['mode']??'');
    if(!in_array($mode,['single','multi'],true))throw new DomainException('Mode invalide.');
    if($mode==='single' && (int)$pdo->query("SELECT COUNT(*) FROM ogp_project_company WHERE state='prepared'")->fetchColumn()>1)throw new DomainException('Archivez les entreprises supplémentaires avant de préparer le mode mono-entreprise.');
    if($mode===$config['requested_mode']){$pdo->rollBack();return 'Aucun changement à enregistrer.';}
    $q=$pdo->prepare('UPDATE ogp_collaboration_config SET requested_mode=?,revision=revision+1 WHERE id=1');$q->execute([$mode]);
    $details=['before'=>$config['requested_mode'],'requested_mode'=>$mode,'effective_mode'=>'single','reason'=>$reason];$entity=1;
   }elseif($action==='company_save'){
    $code=trim((string)($input['company_code']??''));$name=trim((string)($input['display_name']??''));$lot=trim((string)($input['work_package']??''));$license=trim((string)($input['slm_license_id']??''));$state=(string)($input['state']??'prepared');
    if(!preg_match('/\A[a-z0-9][a-z0-9_-]{0,63}\z/D',$code) || !preg_match('/\A[^\x00-\x1f\x7f]{1,180}\z/u',$name) || !preg_match('/\A[^\x00-\x1f\x7f]{0,180}\z/u',$lot) || !in_array($state,['prepared','archived'],true) || ($license!=='' && !preg_match('/\A[1-9][0-9]{0,8}\z/D',$license)))throw new DomainException('Code, nom, lot, état ou référence SLM invalide.');
    $q=$pdo->prepare('SELECT * FROM ogp_project_company WHERE company_code=? FOR UPDATE');$q->execute([$code]);$old=$q->fetch();
    if((string)($input['revision']??'')!==($old?(string)$old['revision']:'0'))throw new DomainException('Cette entreprise a changé. Rechargez sa fiche.');
    $q=$pdo->prepare("SELECT COUNT(*) FROM ogp_project_company WHERE state='prepared' AND company_code<>?");$q->execute([$code]);
    if($state==='prepared' && $config['requested_mode']==='single' && (int)$q->fetchColumn()>0)throw new DomainException('Préparez le mode multi-entreprise avant de déclarer une deuxième entreprise.');
    if($old){$q=$pdo->prepare('UPDATE ogp_project_company SET display_name=?,work_package=?,slm_license_id=?,state=?,revision=revision+1 WHERE id=?');$q->execute([$name,$lot,$license===''?null:(int)$license,$state,$old['id']]);$entity=(int)$old['id'];}
    else{$q=$pdo->prepare('INSERT INTO ogp_project_company(company_code,display_name,work_package,slm_license_id,state) VALUES(?,?,?,?,?)');$q->execute([$code,$name,$lot,$license===''?null:(int)$license,$state]);$entity=(int)$pdo->lastInsertId();}
    $details=['company_code'=>$code,'before'=>$old?:null,'after'=>['display_name'=>$name,'work_package'=>$lot,'slm_license_id'=>$license,'state'=>$state],'reason'=>$reason];
   }else throw new DomainException('Action inconnue.');
   $q=$pdo->prepare('INSERT INTO ogp_audit_event(actor_id,action_code,entity_type,entity_id,details) VALUES(?,?,?,?,?)');
   $q->execute(['ADMIN:'.($_SESSION['admin_name']??'admin'),$action==='collaboration_mode'?'COLLABORATION_REQUESTED':'COMPANY_DECLARED','collaboration',$entity,json_encode($details,JSON_THROW_ON_ERROR)]);
   $pdo->commit();
   return 'Déclaration enregistrée et auditée. Le mode effectif reste mono-entreprise ; aucun accès ni module supplémentaire n’est accordé.';
  }catch(Throwable $e){if($pdo->inTransaction())$pdo->rollBack();throw $e;}
 });
}
