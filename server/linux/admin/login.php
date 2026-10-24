<?php
declare(strict_types=1);require __DIR__.'/lib.php';
if(!empty($_SESSION['is_admin'])){login_check();header('Location: '.url('/'));exit;}
$err='';if($_SERVER['REQUEST_METHOD']==='POST'){
 try{csrf_check();$env=getenv('OGIPEN_ADMIN_PASSWORD_HASH');$pass=(string)($_POST['password']??'');
 if(!login_attempt('check')){$err='Trop de tentatives. Réessayez dans dix minutes.';}
 elseif($env&&password_verify($pass,$env)){login_attempt('success');session_regenerate_id(true);$_SESSION['is_admin']=true;$_SESSION['admin_name']='admin';$_SESSION['last_seen']=time();$_SESSION['created_at']=time();header('Location: '.url('/'));exit;}
 else{login_attempt('failure');$err='Identifiant ou mot de passe invalide';}
 }catch(Throwable $e){$err='Erreur de validation';}}
?><!doctype html><html lang="fr"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1"><title>Ogipen · Connexion</title><link rel="stylesheet" href="<?=h(url('/style.css'))?>"></head><body class="loginbody"><form class="loginbox" method="post"><h1>◈ OGIPEN</h1><p>Portail d'administration</p><?php if($err):?><div class="error"><?=h($err)?></div><?php endif;?><input type="hidden" name="csrf" value="<?=h(csrf())?>"><label>Administrateur</label><input value="admin" disabled><label>Mot de passe</label><input type="password" name="password" required autofocus autocomplete="current-password"><button>Se connecter</button><small>Accès sécurisé · Session administrateur</small></form></body></html>
