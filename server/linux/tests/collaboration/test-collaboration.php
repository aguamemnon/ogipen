<?php
declare(strict_types=1);
function login_check():void{}
function admin_lock(callable $f):mixed{return $f();}
require '/root/ogipen-v047/admin/company-service.php';
$pdo=new PDO('mysql:host=localhost;dbname=ogp_test_001;charset=utf8mb4',getenv('TEST_DB_USER'),getenv('TEST_DB_PASSWORD'),[PDO::ATTR_ERRMODE=>PDO::ERRMODE_EXCEPTION,PDO::ATTR_DEFAULT_FETCH_MODE=>PDO::FETCH_ASSOC]);
$results=[];
function check(string $name,bool $ok):void{global $results;$results[]=['test'=>$name,'pass'=>$ok];if(!$ok)throw new RuntimeException($name);}
function denied(string $name,array $form):void{global $pdo;try{collaboration_change($pdo,$form);check($name,false);}catch(DomainException $e){check($name,true);}}
$tables=['ogp_collaboration_config','ogp_project_company','ogp_audit_event'];
$before=[];$ddl=[];
foreach($tables as $t){$before[$t]=$pdo->query("SELECT COUNT(*) FROM `$t`")->fetchColumn();$ddl[$t]=$pdo->query("SHOW CREATE TABLE `$t`")->fetch()["Create Table"];}
try{
 foreach($tables as $t)$pdo->exec(preg_replace('/^CREATE TABLE /','CREATE TEMPORARY TABLE ',$ddl[$t],1));
 $pdo->exec('INSERT INTO ogp_collaboration_config(id) VALUES(1)');
 $base=['action'=>'company_save','company_code'=>'company-a','display_name'=>'Entreprise A','work_package'=>'Électricité','slm_license_id'=>'2','state'=>'prepared','revision'=>'0','reason'=>'Test isolé'];
 denied('reason_required',array_replace($base,['reason'=>'']));
 denied('invalid_company_code',array_replace($base,['company_code'=>'../bad']));
 denied('invalid_licence_reference',array_replace($base,['slm_license_id'=>'-1']));
 collaboration_change($pdo,$base);check('first_company_prepared',(int)$pdo->query('SELECT COUNT(*) FROM ogp_project_company')->fetchColumn()===1);
 denied('second_company_needs_multi',array_replace($base,['company_code'=>'company-b']));
 denied('stale_mode_revision',['action'=>'collaboration_mode','mode'=>'multi','revision'=>'0','reason'=>'Test isolé']);
 denied('unknown_mode',['action'=>'collaboration_mode','mode'=>'unrestricted','revision'=>'1','reason'=>'Test isolé']);
 collaboration_change($pdo,['action'=>'collaboration_mode','mode'=>'multi','revision'=>'1','reason'=>'Test isolé']);
 check('multi_requested_not_effective',$pdo->query('SELECT requested_mode FROM ogp_collaboration_config')->fetchColumn()==='multi' && json_decode($pdo->query("SELECT details FROM ogp_audit_event WHERE action_code='COLLABORATION_REQUESTED'")->fetchColumn(),true)['effective_mode']==='single');
 collaboration_change($pdo,array_replace($base,['company_code'=>'company-b','display_name'=>'Entreprise B','slm_license_id'=>'8']));
 check('independent_company_licence_references',(int)$pdo->query('SELECT COUNT(DISTINCT slm_license_id) FROM ogp_project_company')->fetchColumn()===2);
 denied('no_silent_return_to_single',['action'=>'collaboration_mode','mode'=>'single','revision'=>'2','reason'=>'Test isolé']);
 denied('stale_company_revision',array_replace($base,['revision'=>'0','display_name'=>'Overwrite']));
 collaboration_change($pdo,array_replace($base,['company_code'=>'company-b','display_name'=>'Entreprise B','slm_license_id'=>'8','revision'=>'1','state'=>'archived']));
 collaboration_change($pdo,['action'=>'collaboration_mode','mode'=>'single','revision'=>'2','reason'=>'Test isolé']);
 check('return_to_single_after_archiving',$pdo->query('SELECT requested_mode FROM ogp_collaboration_config')->fetchColumn()==='single');
 check('audit_contains_reason',str_contains($pdo->query('SELECT details FROM ogp_audit_event ORDER BY id DESC LIMIT 1')->fetchColumn(),'Test isolé'));
 $pdo->exec('DROP TEMPORARY TABLE ogp_audit_event');$pdo->exec('CREATE TEMPORARY TABLE ogp_audit_event(dummy INT)');
 try{collaboration_change($pdo,array_replace($base,['revision'=>'1','display_name'=>'Must roll back']));check('audit_failure_refuses_change',false);}catch(PDOException $e){check('audit_failure_refuses_change',true);}
 check('transaction_rolled_back',$pdo->query("SELECT display_name FROM ogp_project_company WHERE company_code='company-a'")->fetchColumn()==='Entreprise A');
}finally{
 if($pdo->inTransaction())$pdo->rollBack();
 foreach($tables as $t){$pdo->exec("DROP TEMPORARY TABLE IF EXISTS `$t`");check('real_rows_preserved_'.$t,$pdo->query("SELECT COUNT(*) FROM `$t`")->fetchColumn()===$before[$t]);}
 file_put_contents('/root/ogipen-v047/tests/results-db.json',json_encode($results,JSON_PRETTY_PRINT));
 echo json_encode($results,JSON_PRETTY_PRINT).PHP_EOL;
}
