<?php
declare(strict_types=1);
require __DIR__.'/lib.php';
if($_SERVER['REQUEST_METHOD']!=='POST'){http_response_code(405);header('Allow: POST');exit;}
try{csrf_check();}catch(Throwable $e){http_response_code(403);exit;}
$_SESSION=[];session_destroy();
setcookie(session_name(),'', ['expires'=>time()-3600,'path'=>url('/'),'secure'=>!empty($_SERVER['HTTPS'])&&$_SERVER['HTTPS']!=='off','httponly'=>true,'samesite'=>'Strict']);
header('Location: '.url('/login.php'));exit;
