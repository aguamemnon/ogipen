<?php
declare(strict_types=1);
require '/opt/ogipen/admin/lib.php';require '/opt/ogipen/admin/identity-service.php';
class PermissionProbePDO extends PDO {public function commit():bool{throw new RuntimeException('PERMISSION_PROBE_ROLLBACK');}}
$pdo=new PermissionProbePDO('mysql:host='.getenv('OGIPEN_ADMIN_DB_HOST').';dbname='.getenv('OGIPEN_ADMIN_DB_NAME').';charset=utf8mb4',getenv('OGIPEN_ADMIN_DB_USER'),getenv('OGIPEN_ADMIN_DB_PASSWORD'),[PDO::ATTR_ERRMODE=>PDO::ERRMODE_EXCEPTION,PDO::ATTR_DEFAULT_FETCH_MODE=>PDO::FETCH_ASSOC,PDO::ATTR_EMULATE_PREPARES=>false]);
$_SESSION=['admin_name'=>'permission-regression-test'];$results=[];
$row=$pdo->query("SELECT i.*,COALESCE(p.can_read,0) AS can_read,COALESCE(p.can_edit,0) AS can_edit FROM ogp_identity i LEFT JOIN ogp_permission p ON p.identity_id=i.id WHERE i.id LIKE 'win-sid:%' ORDER BY i.id LIMIT 1")->fetch();
if(!$row)throw new RuntimeException('No enrolled Windows account available for non-committing probe');
$probe=['action'=>'identity_save','identity_id'=>$row['id'],'revision'=>(string)$row['auth_version'],'display_name'=>'Diagnostic non validé','company_id'=>(string)$row['company_id'],'role'=>$row['can_edit']?'editor':($row['can_read']?'reader':'none'),'enabled'=>(string)$row['enabled'],'system_role'=>$row['system_role']];
$reached=false;
try{identity_change($pdo,$probe);}catch(RuntimeException $e){if($e->getMessage()!=='PERMISSION_PROBE_ROLLBACK')throw $e;$reached=true;}
$results[]=['test'=>'complete_identity_write_path_with_real_portal_sql_user','pass'=>$reached];
$q=$pdo->prepare('SELECT * FROM ogp_identity WHERE id=?');$q->execute([$row['id']]);$after=$q->fetch();
$before=$row;unset($before['can_read'],$before['can_edit']);$same=$before===$after;
$results[]=['test'=>'real_account_state_preserved_by_rollback','pass'=>$same];
$restricted=false;
try{$pdo->query('SELECT session_id FROM ogp_auth_session LIMIT 0');}catch(PDOException $e){$restricted=($e->errorInfo[1]??0)===1143;}
$results[]=['test'=>'portal_still_cannot_read_session_ids','pass'=>$restricted];
echo json_encode($results,JSON_PRETTY_PRINT|JSON_UNESCAPED_UNICODE),PHP_EOL;
if(!$reached||!$same||!$restricted)exit(1);
