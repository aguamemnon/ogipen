<?php
declare(strict_types=1);
require __DIR__.'/lib.php';
login_check();
header('Content-Type: application/json; charset=utf-8');
$database=false;
try{$database=(int)db()->query('SELECT 1')->fetchColumn()===1;}catch(Throwable $e){}
echo json_encode(['portal_version'=>'0.4.5','database'=>$database,'api'=>api_status()],JSON_THROW_ON_ERROR);
