<?php
declare(strict_types=1);
function login_check():void{}
function admin_lock(callable $f):mixed{return $f();}
require '/root/ogipen-v0416/admin/identity-service.php';
$pdo=new PDO('mysql:host=localhost;dbname=ogp_v0416_selftest;charset=utf8mb4',getenv('TEST_DB_USER'),getenv('TEST_DB_PASSWORD'),[PDO::ATTR_ERRMODE=>PDO::ERRMODE_EXCEPTION,PDO::ATTR_DEFAULT_FETCH_MODE=>PDO::FETCH_ASSOC]);
$_SESSION=['admin_name'=>'isolated-role-test'];$id=$argv[1];$role=$argv[2];
$q=$pdo->prepare('SELECT auth_version FROM ogp_identity WHERE id=?');$q->execute([$id]);$version=$q->fetchColumn();
identity_change($pdo,['action'=>'identity_system_role','identity_id'=>$id,'revision'=>(string)$version,'system_role'=>$role]);
$q=$pdo->prepare('SELECT system_role,auth_version FROM ogp_identity WHERE id=?');$q->execute([$id]);$row=$q->fetch();
$q=$pdo->prepare('SELECT COUNT(*) FROM ogp_app_account WHERE identity_id=?');$q->execute([$id]);$row['internal_count']=(int)$q->fetchColumn();
echo json_encode($row),PHP_EOL;
