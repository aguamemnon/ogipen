<?php
// Compatibility for existing links; the licence now belongs to the portal.
declare(strict_types=1);
if($_SERVER['REQUEST_METHOD']==='GET'){
    require __DIR__.'/lib.php';
    login_check();
    header('Location: '.url('/?page=license'));
    exit;
}
$_GET['page']='license';
require __DIR__.'/index.php';