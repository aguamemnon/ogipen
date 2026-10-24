<?php
declare(strict_types=1);
function login_check():void{}
function admin_lock(callable $f):mixed{return $f();}
require '/root/ogipen-v048/admin/identity-service.php';
$pdo=new PDO('mysql:host=localhost;dbname=ogp_v048_selftest;charset=utf8mb4',getenv('TEST_DB_USER'),getenv('TEST_DB_PASSWORD'),[PDO::ATTR_ERRMODE=>PDO::ERRMODE_EXCEPTION,PDO::ATTR_DEFAULT_FETCH_MODE=>PDO::FETCH_ASSOC,PDO::ATTR_EMULATE_PREPARES=>false]);
$_SESSION=['admin_name'=>'isolated-test'];$results=[];
function check(string $name,bool $ok):void{global $results;$results[]=['test'=>$name,'pass'=>$ok];if(!$ok)throw new RuntimeException($name);}
function refused(string $name,callable $f):void{try{$f();}catch(Throwable $e){check($name,true);return;}check($name,false);}
function config():array{global $pdo;return $pdo->query('SELECT * FROM ogp_collaboration_config WHERE id=1')->fetch();}
function company(int $id):array{global $pdo;$q=$pdo->prepare('SELECT * FROM ogp_project_company WHERE id=?');$q->execute([$id]);return $q->fetch();}
try{
 check('company_signed_grant_verified',company_license(company(1))['license_id']==='slmms:2');
 $bad=company(1);$bad['server_license_json']=getenv('TEST_BAD_MODULE_GRANT');refused('invalid_signed_module_list_refused',fn()=>company_license($bad));
 refused('unsigned_company_grant_refused',fn()=>collaboration_change($pdo,['action'=>'company_license_import','company_id'=>1,'revision'=>company(1)['revision'],'reason'=>'Isolated test','license_json'=>'{}']));
 refused('stale_import_refused',fn()=>collaboration_change($pdo,['action'=>'company_license_import','company_id'=>1,'revision'=>'999','reason'=>'Isolated test','license_json'=>company(1)['server_license_json']]));
 collaboration_change($pdo,['action'=>'company_license_import','company_id'=>1,'revision'=>company(1)['revision'],'reason'=>'Isolated test','license_json'=>company(1)['server_license_json']]);
 check('valid_signed_import_stored',company(1)['revision']==2);
 $pdo->exec('UPDATE ogp_project_company SET slm_license_id=2 WHERE id=2');
 refused('licence_cannot_be_shared_between_companies',fn()=>collaboration_change($pdo,['action'=>'company_license_import','company_id'=>2,'revision'=>company(2)['revision'],'reason'=>'Isolated test','license_json'=>company(1)['server_license_json']]));
 $pdo->exec('UPDATE ogp_project_company SET slm_license_id=8 WHERE id=2');
 collaboration_change($pdo,['action'=>'collaboration_activate','revision'=>config()['revision'],'reason'=>'Isolated test']);
 check('multi_mode_applied_after_verification',config()['effective_mode']==='multi');
 $old=company(2)['server_license_json'];$pdo->exec('UPDATE ogp_project_company SET server_license_json=NULL WHERE id=2');
 refused('activation_requires_every_company_licence',fn()=>collaboration_change($pdo,['action'=>'collaboration_activate','revision'=>config()['revision'],'reason'=>'Isolated test']));
 $q=$pdo->prepare('UPDATE ogp_project_company SET server_license_json=? WHERE id=2');$q->execute([$old]);
 $key=file_get_contents('/root/ogipen-v048/tests/other.pub');
 $base=['action'=>'identity_create','identity_id'=>'portal-user','display_name'=>'Portal user','public_key'=>$key,'role'=>'reader','enabled'=>'1'];
 refused('active_identity_requires_company',fn()=>identity_change($pdo,$base));
 refused('active_identity_company_quota',fn()=>identity_change($pdo,$base+['company_id'=>'1','license_beneficiary_id'=>'303']));
 $q=$pdo->query("SELECT auth_version FROM ogp_identity WHERE id='a'");$revision=(string)$q->fetchColumn();
 identity_change($pdo,['action'=>'identity_toggle','identity_id'=>'a','revision'=>$revision,'enabled'=>'0']);
 refused('beneficiary_cannot_be_reassigned_to_another_identity',fn()=>identity_change($pdo,$base+['company_id'=>'1','license_beneficiary_id'=>'101']));
 identity_change($pdo,$base+['company_id'=>'1','license_beneficiary_id'=>'303']);
 check('active_enrolment_bound_to_company',(int)$pdo->query("SELECT company_id FROM ogp_identity WHERE id='portal-user'")->fetchColumn()===1);
 refused('stale_identity_form_refused',fn()=>identity_change($pdo,['action'=>'identity_toggle','identity_id'=>'portal-user','revision'=>'0','enabled'=>'0']));
 refused('below_usage_company_import_refused',function()use($pdo){$pdo->exec("UPDATE ogp_identity SET enabled=1 WHERE id='a'");try{collaboration_change($pdo,['action'=>'company_license_import','company_id'=>1,'revision'=>company(1)['revision'],'reason'=>'Isolated test','license_json'=>company(1)['server_license_json']]);}finally{$pdo->exec("UPDATE ogp_identity SET enabled=0 WHERE id='a'");}});
 $before=company(1)['revision'];$pdo->exec("CREATE TRIGGER refuse_test_audit BEFORE INSERT ON ogp_audit_event FOR EACH ROW SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT='Isolated audit failure'");
 try{refused('audit_failure_refuses_import',fn()=>collaboration_change($pdo,['action'=>'company_license_import','company_id'=>1,'revision'=>company(1)['revision'],'reason'=>'Isolated test','license_json'=>company(1)['server_license_json']]));}finally{$pdo->exec('DROP TRIGGER refuse_test_audit');}
 check('audit_failure_rolls_back_company_revision',company(1)['revision']===$before);
 // A declared SLM reference must invalidate the previously signed binding.
 $c=company(1);collaboration_change($pdo,['action'=>'company_save','company_code'=>$c['company_code'],'display_name'=>$c['display_name'],'work_package'=>'Lot test','slm_license_id'=>'99','state'=>'prepared','revision'=>$c['revision'],'reason'=>'Isolated test']);
 check('licence_reference_change_clears_old_proof',company(1)['server_license_json']===null);
 check('admin_changes_audited',(int)$pdo->query('SELECT COUNT(*) FROM ogp_audit_event')->fetchColumn()>=6);
}finally{
 if($pdo->inTransaction())$pdo->rollBack();
 file_put_contents('/root/ogipen-v048/tests/results-portal-services.json',json_encode($results,JSON_PRETTY_PRINT));
 echo json_encode($results,JSON_PRETTY_PRINT).PHP_EOL;
}
