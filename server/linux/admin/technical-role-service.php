<?php
declare(strict_types=1);
if(!function_exists('login_check')){http_response_code(404);exit;}
function technical_role_guard(PDO $pdo,?array $old,string $role,bool $enabled,mixed $company):void {
 if(!in_array($role,['user','admin','ossi'],true))throw new DomainException('Rôle technique invalide.');
 if(!$old || $old['system_role']!=='admin' || !(int)$old['enabled'])return;
 if($enabled && $role==='admin' && (string)$company===(string)$old['company_id'])return;
 $q=$pdo->prepare("SELECT COUNT(*) FROM ogp_identity WHERE company_id=? AND system_role='admin' AND enabled=1");$q->execute([$old['company_id']]);
 if((int)$q->fetchColumn()<=1)throw new DomainException('Conservez au moins un administrateur actif dans cette entreprise.');
}
