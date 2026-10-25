<?php
/** Plugin Name: Ogipen — demandes et activations hors ligne
 * Version: 0.4.12
 * Description: Activation d’un poste par licence, sans vérification d’utilisateur.
 */
if(!defined('ABSPATH'))exit;

function ogipen_activation_table(){global $wpdb;return $wpdb->prefix.'slmms_offline_activations';}
function ogipen_activation_schema(){
    if(!current_user_can('manage_options') || !function_exists('slmms_table') || get_option('ogipen_activation_schema')==='1')return;
    global $wpdb;$t=ogipen_activation_table();$charset=$wpdb->get_charset_collate();
    if($wpdb->query("CREATE TABLE IF NOT EXISTS $t (
        id bigint unsigned NOT NULL AUTO_INCREMENT,
        license_id bigint unsigned NOT NULL, beneficiary_id bigint unsigned NOT NULL,
        actor_user_id bigint unsigned NOT NULL,
        device_sha256 char(64) NOT NULL, nonce_sha256 char(64) NOT NULL,
        request_sha256 char(64) NOT NULL, rights_sha256 char(64) NOT NULL,
        license_json longtext NOT NULL,
        issued_utc datetime NOT NULL, expires_utc datetime NOT NULL,
        state varchar(20) NOT NULL, revoked_utc datetime NULL,
        revocation_reason varchar(500) NOT NULL DEFAULT '',
        PRIMARY KEY(id), UNIQUE KEY nonce_sha256(nonce_sha256),
        KEY license_beneficiary(license_id,beneficiary_id), KEY device_sha256(device_sha256)
    ) ENGINE=InnoDB $charset")!==false)update_option('ogipen_activation_schema','1',false);
}
add_action('admin_init','ogipen_activation_schema',31);

function ogipen_offline_b64($bytes){return rtrim(strtr(base64_encode($bytes),'+/','-_'),'=');}
function ogipen_offline_decode($text){
    if(!is_string($text) || !preg_match('/^[A-Za-z0-9_-]+$/D',$text))throw new DomainException('Encodage de demande invalide.');
    $data=base64_decode(strtr($text,'-_','+/').str_repeat('=',(4-strlen($text)%4)%4),true);
    if($data===false || ogipen_offline_b64($data)!==$text)throw new DomainException('Encodage de demande non canonique.');
    return $data;
}
function ogipen_parse_offline_request($json){
    if(!is_string($json) || strlen($json)>8192 || !$json)throw new DomainException('Demande vide ou trop volumineuse (8 Ko maximum).');
    try{$r=json_decode($json,true,16,JSON_THROW_ON_ERROR);}catch(Throwable $e){throw new DomainException('Le fichier .ogreq doit contenir une demande JSON valide.');}
    $fields=['type','version','software_id','major','nonce','public_key_spki','proof'];
    if(!is_array($r) || count($r)!==count($fields) || array_diff($fields,array_keys($r)) ||
        $r['type']!=='OGIPEN-OFFLINE-REQUEST' || $r['version']!==1 ||
        !is_int($r['software_id']) || $r['software_id']<1 || $r['software_id']>2147483647 ||
        !is_int($r['major']) || $r['major']<1 || $r['major']>999)throw new DomainException('Format ou version de demande non pris en charge.');
    $nonce=ogipen_offline_decode($r['nonce']);$spki=ogipen_offline_decode($r['public_key_spki']);$proof=ogipen_offline_decode($r['proof']);
    if(strlen($nonce)!==32 || strlen($spki)>1024 || strlen($proof)<64 || strlen($proof)>256)throw new DomainException('Paramètres cryptographiques invalides.');
    $pem="-----BEGIN PUBLIC KEY-----\n".chunk_split(base64_encode($spki),64,"\n")."-----END PUBLIC KEY-----\n";
    $key=openssl_pkey_get_public($pem);$details=$key?openssl_pkey_get_details($key):false;
    if(!$details || $details['type']!==OPENSSL_KEYTYPE_EC || ($details['ec']['curve_name']??'')!=='prime256v1')throw new DomainException('Une clé publique ECDSA P-256 est requise.');
    $normalized=base64_decode(preg_replace('/-----[^-]+-----|\s/','',$details['key']),true);
    if($normalized===false || !hash_equals($normalized,$spki))throw new DomainException('Encodage de clé publique non canonique.');
    $canonical="OGIPEN-OFFLINE-REQUEST-v1\n".$r['software_id']."\n".$r['major']."\n".$r['nonce']."\n".$r['public_key_spki']."\n";
    if(openssl_verify($canonical,$proof,$key,OPENSSL_ALGO_SHA256)!==1)throw new DomainException('La preuve de possession de la clé est invalide.');
    return ['software_id'=>$r['software_id'],'major'=>$r['major'],'nonce'=>$r['nonce'],
        'nonce_sha256'=>hash('sha256',$nonce),'device_sha256'=>hash('sha256',$spki),'request_sha256'=>hash('sha256',$canonical)];
}
function ogipen_offline_authorized(){
    if(!current_user_can('manage_options') || !function_exists('slmms_table'))throw new DomainException('Opération réservée aux administrateurs SLM Plus.');
}
function ogipen_activation_used_places($license_id){
    global $wpdb;$users=slmms_table('users');$table=ogipen_activation_table();
    $reserved=(int)$wpdb->get_var($wpdb->prepare("SELECT COUNT(*) FROM $users WHERE license_id=%d AND active=1",$license_id));
    $extra=(int)$wpdb->get_var($wpdb->prepare("SELECT COUNT(DISTINCT a.device_sha256) FROM $table a WHERE a.license_id=%d AND a.state='active' AND a.expires_utc>UTC_TIMESTAMP() AND (a.beneficiary_id=0 OR NOT EXISTS(SELECT 1 FROM $users u WHERE u.id=a.beneficiary_id AND u.license_id=a.license_id AND u.active=1))",$license_id));
    return $reserved+$extra;
}
function ogipen_offline_rights($license,$beneficiary){
    $device=$beneficiary===null;
    if(!$license || (!$device && ((int)$beneficiary->license_id!==(int)$license->id || !$beneficiary->active || !in_array($beneficiary->provider,['ogipen','sam','ad'],true))) ||
        $license->status!=='active' || (int)$license->seats<1 ||
        strtotime($license->expires_utc.' UTC')<=time() ||
        get_post_type($license->software_id)!=='slm_software' || get_post_status($license->software_id)!=='publish'){
        throw new DomainException('Une licence active et valide est requise.');
    }
    global $wpdb;
    if(ogipen_activation_used_places($license->id)>(int)$license->seats)throw new DomainException('Les places réservées et les postes activés dépassent le quota de la licence.');
    $modules=json_decode($license->modules_json,true,32,JSON_THROW_ON_ERROR);
    if(!is_array($modules) || count($modules)>200)throw new DomainException('Liste de modules invalide.');
    foreach($modules as $m){if(!is_int($m) || $m<1 || get_post_type($m)!=='slm_module' || (int)get_post_meta($m,'_slmms_software',true)!==(int)$license->software_id)throw new DomainException('Module incompatible avec le logiciel.');}
    $modules=array_values(array_unique($modules));sort($modules,SORT_NUMERIC);
    $slug=(string)get_post_field('post_name',$license->software_id);
    if(!$slug)throw new DomainException('Identifiant logiciel manquant.');
    if($device && $slug!=='ogipen')throw new DomainException('Sélectionnez une licence Ogipen.');
    $snapshot=['license_id'=>(int)$license->id,'beneficiary_id'=>$device?0:(int)$beneficiary->id,
        'software_id'=>(int)$license->software_id,'software'=>$slug,'major'=>(int)$license->major_version,
        'modules'=>$modules,'seats'=>(int)$license->seats,'expires_utc'=>$license->expires_utc];
    if($device)$snapshot['binding']='device';
    return ['snapshot'=>$snapshot,'hash'=>hash('sha256',wp_json_encode($snapshot))];
}
function ogipen_offline_audit($license,$beneficiary,$action){
    global $wpdb;
    if($wpdb->insert(slmms_table('audit'),['owner_id'=>(int)$license->owner_id,
        'actor_user_id'=>get_current_user_id(),'license_id'=>(int)$license->id,
        'action'=>$action,'subject_id'=>$beneficiary?(int)$beneficiary->id:0,'occurred_utc'=>gmdate('Y-m-d H:i:s')])===false)throw new RuntimeException('Journalisation impossible.');
}
function ogipen_issue_workstation($beneficiary_id,$request_json,$days,$direct_license_id=0){
    ogipen_offline_authorized();
    if(!is_int($days) || $days<1 || $days>365)throw new DomainException('La durée hors ligne doit être comprise entre 1 et 365 jours.');
    $request=ogipen_parse_offline_request($request_json);
    global $wpdb;$licenses=slmms_table('license');$users=slmms_table('users');$activations=ogipen_activation_table();
    $device=is_int($direct_license_id) && $direct_license_id>0;
    if($device && $beneficiary_id!==0)throw new DomainException('Paramètres d’activation incompatibles.');
    $hint=$device?(object)['license_id'=>$direct_license_id]:$wpdb->get_row($wpdb->prepare("SELECT license_id FROM $users WHERE id=%d",$beneficiary_id));
    if(!$hint)throw new DomainException('Licence ou ancienne attribution introuvable.');
    if($wpdb->query('START TRANSACTION')===false)throw new RuntimeException('Transaction indisponible.');
    try{
        // Same parent lock as user allocation and administrative quota changes.
        $license=$wpdb->get_row($wpdb->prepare("SELECT * FROM $licenses WHERE id=%d FOR UPDATE",$hint->license_id));
        $beneficiary=$device?null:$wpdb->get_row($wpdb->prepare("SELECT * FROM $users WHERE id=%d AND license_id=%d FOR UPDATE",$beneficiary_id,$hint->license_id));
        if(!$device && !$beneficiary)throw new DomainException('Ancienne attribution introuvable.');
        $rights=ogipen_offline_rights($license,$beneficiary);$s=$rights['snapshot'];
        if($request['software_id']!==$s['software_id'] || $request['major']!==$s['major'])throw new DomainException('Le logiciel ou la version de la demande ne correspond pas à la licence sélectionnée.');
        $replay=$wpdb->get_row($wpdb->prepare("SELECT * FROM $activations WHERE nonce_sha256=%s FOR UPDATE",$request['nonce_sha256']));
        if($replay){
            if((int)$replay->license_id!==$s['license_id'] || (int)$replay->beneficiary_id!==$s['beneficiary_id'] ||
                !hash_equals($replay->request_sha256,$request['request_sha256']) || $replay->state!=='active' ||
                !hash_equals($replay->rights_sha256,$rights['hash']) || strtotime($replay->expires_utc.' UTC')<=time())throw new DomainException('Cette demande a déjà été utilisée ou ses droits ont changé. Générez une nouvelle demande depuis Ogipen.');
            if($wpdb->query('COMMIT')===false)throw new RuntimeException('Validation impossible.');
            return ['id'=>(int)$replay->id,'json'=>$replay->license_json,'reused'=>true];
        }
        $active=$wpdb->get_results($wpdb->prepare("SELECT id,beneficiary_id,device_sha256 FROM $activations WHERE license_id=%d AND state='active' AND expires_utc>UTC_TIMESTAMP() FOR UPDATE",$s['license_id']));
        $sameDevice=false;
        foreach($active as $a){
            if($device){
                if((int)$a->beneficiary_id>0 && hash_equals($a->device_sha256,$request['device_sha256']))throw new DomainException('Cette clé possède déjà une ancienne activation. Téléchargez-la ou révoquez-la dans l’historique.');
                if((int)$a->beneficiary_id===0 && hash_equals($a->device_sha256,$request['device_sha256']))$sameDevice=true;
                continue;
            }
            if((int)$a->beneficiary_id===$s['beneficiary_id'] && !hash_equals($a->device_sha256,$request['device_sha256']))throw new DomainException('Ce bénéficiaire dispose déjà d’une activation sur une autre clé. Révoquez-la avant une réaffectation.');
            if((int)$a->beneficiary_id!==$s['beneficiary_id'] && hash_equals($a->device_sha256,$request['device_sha256']))throw new DomainException('Cette clé est déjà affectée à un autre bénéficiaire de la licence.');
        }
        if($device && ogipen_activation_used_places($s['license_id'])+($sameDevice?0:1)>$s['seats'])throw new DomainException('Quota atteint : révoquez un poste ou libérez une ancienne place réservée avant une nouvelle activation.');
        $now=time();$expires=min(strtotime($license->expires_utc.' UTC'),$now+$days*86400);
        if($wpdb->insert($activations,['license_id'=>$s['license_id'],'beneficiary_id'=>$s['beneficiary_id'],
            'actor_user_id'=>get_current_user_id(),'device_sha256'=>$request['device_sha256'],
            'nonce_sha256'=>$request['nonce_sha256'],'request_sha256'=>$request['request_sha256'],
            'rights_sha256'=>$rights['hash'],'license_json'=>'','issued_utc'=>gmdate('Y-m-d H:i:s',$now),
            'expires_utc'=>gmdate('Y-m-d H:i:s',$expires),'state'=>'pending'])===false)throw new RuntimeException('Enregistrement impossible.');
        $id=(int)$wpdb->insert_id;
        $header=ogipen_offline_b64(wp_json_encode(['alg'=>'ES256-DER','typ'=>'SLMMS-OFFLINE','v'=>1]));
        $claims=['aud'=>'ogipen-offline','iss'=>rtrim(home_url('/'),'/'),
            'software_id'=>$s['software_id'],'software'=>$s['software'],'major'=>$s['major'],
            'lic'=>$s['license_id'],'sub'=>$s['beneficiary_id'],'activation'=>$id,
            'device_sha256'=>$request['device_sha256'],'nonce'=>$request['nonce'],
            'iat'=>$now,'exp'=>$expires,'modules'=>$s['modules']];
        if($device)$claims['binding']='device';
        $body=ogipen_offline_b64(wp_json_encode($claims,JSON_UNESCAPED_SLASHES));
        $key=openssl_pkey_get_private('file:///etc/ogipen-licensing/signing.pem');
        $details=$key?openssl_pkey_get_details($key):false;
        if(!$details || $details['type']!==OPENSSL_KEYTYPE_EC || ($details['ec']['curve_name']??'')!=='prime256v1' || !openssl_sign($header.'.'.$body,$signature,$key,OPENSSL_ALGO_SHA256))throw new RuntimeException('Signature indisponible.');
        $json=wp_json_encode(['type'=>'OGIPEN-OFFLINE-LICENSE','version'=>1,'token'=>$header.'.'.$body.'.'.ogipen_offline_b64($signature)],JSON_UNESCAPED_SLASHES|JSON_PRETTY_PRINT);
        if(!$json || $wpdb->update($activations,['license_json'=>$json,'state'=>'active'],['id'=>$id])!==1)throw new RuntimeException('Enregistrement de signature impossible.');
        $replace=$device?$wpdb->prepare("UPDATE $activations SET state='replaced' WHERE license_id=%d AND beneficiary_id=0 AND device_sha256=%s AND id<>%d AND state='active'",$s['license_id'],$request['device_sha256'],$id):$wpdb->prepare("UPDATE $activations SET state='replaced' WHERE license_id=%d AND beneficiary_id=%d AND id<>%d AND state='active'",$s['license_id'],$s['beneficiary_id'],$id);
        if($wpdb->query($replace)===false)throw new RuntimeException('Renouvellement impossible.');
        ogipen_offline_audit($license,$beneficiary,$device?'offline_device_issued':'offline_workstation_issued');
        if($wpdb->query('COMMIT')===false)throw new RuntimeException('Validation impossible.');
        return ['id'=>$id,'json'=>$json,'reused'=>false];
    }catch(Throwable $e){$wpdb->query('ROLLBACK');throw $e;}
}
function ogipen_workstation_existing($id,$revoke=false,$reason=''){
    ogipen_offline_authorized();global $wpdb;$t=ogipen_activation_table();
    if($wpdb->query('START TRANSACTION')===false)throw new RuntimeException('Transaction indisponible.');
    try{
        $hint=$wpdb->get_row($wpdb->prepare("SELECT license_id FROM $t WHERE id=%d",$id));
        if(!$hint)throw new DomainException('Activation introuvable.');
        $license=$wpdb->get_row($wpdb->prepare('SELECT * FROM '.slmms_table('license').' WHERE id=%d FOR UPDATE',$hint->license_id));
        $a=$wpdb->get_row($wpdb->prepare("SELECT * FROM $t WHERE id=%d FOR UPDATE",$id));
        $b=(int)$a->beneficiary_id===0?null:$wpdb->get_row($wpdb->prepare('SELECT * FROM '.slmms_table('users').' WHERE id=%d AND license_id=%d',$a->beneficiary_id,$hint->license_id));
        if($revoke){
            $reason=trim(sanitize_textarea_field($reason));
            if(!$reason || strlen($reason)>500)throw new DomainException('Un motif court de révocation est requis.');
            if($a->state!=='active')throw new DomainException('Cette activation n’est plus active.');
            if($wpdb->update($t,['state'=>'revoked','revoked_utc'=>gmdate('Y-m-d H:i:s'),'revocation_reason'=>$reason],['id'=>(int)$a->id])!==1)throw new RuntimeException('Révocation impossible.');
            if(!$license)throw new DomainException('Licence introuvable.');
            ogipen_offline_audit($license,$b,'offline_workstation_revoked');$json='';
        }else{
            if((int)$a->beneficiary_id>0 && !$b)throw new DomainException('Ancienne attribution introuvable.');
            $rights=ogipen_offline_rights($license,$b);
            if($a->state!=='active' || strtotime($a->expires_utc.' UTC')<=time() || !hash_equals($a->rights_sha256,$rights['hash']))throw new DomainException('Activation indisponible ou droits modifiés : générez une nouvelle demande.');
            $json=$a->license_json;
        }
        if($wpdb->query('COMMIT')===false)throw new RuntimeException('Validation impossible.');
        return $json;
    }catch(Throwable $e){$wpdb->query('ROLLBACK');throw $e;}
}

function ogipen_workstation_tabs($selected){
    echo '<nav class="nav-tab-wrapper" aria-label="Activation hors ligne">';
    foreach(['server'=>'Licence serveur','workstation'=>'Activer un poste (.ogreq)'] as $tab=>$label){
        echo '<a class="nav-tab '.($selected===$tab?'nav-tab-active':'').'" href="'.esc_url(admin_url('admin.php?page=ogipen-offline&tab='.$tab)).'">'.esc_html($label).'</a>';
    }echo '</nav>';
}
add_action('ogipen_slm_offline_tabs','ogipen_workstation_tabs');
function ogipen_workstation_page(){
    if(!current_user_can('manage_options'))return;
    global $wpdb;$t=ogipen_activation_table();
    echo '<div class="wrap"><h1>Activation hors ligne Ogipen</h1>';ogipen_workstation_tabs('workstation');
    if(isset($_GET['offline_notice'])){
        $ok=sanitize_key(wp_unslash($_GET['offline_notice']))==='revoked';
        echo '<div class="notice '.($ok?'notice-success':'notice-error').' inline"><p>'.($ok?'Révocation enregistrée. Un fichier déjà importé hors ligne reste utilisable jusqu’à son expiration.':'Opération refusée. Vérifiez les droits, la licence et la demande.').'</p></div>';
    }
    echo '<h2>Activer un poste avec une licence Ogipen</h2><p>Choisissez la licence et chargez le fichier .ogreq du poste. Aucun utilisateur à créer, sélectionner ou vérifier dans WordPress. La demande du poste, la licence, les modules et les places restent contrôlés.</p>';
    $licenses=$wpdb->get_results('SELECT * FROM '.slmms_table('license')." WHERE status='active' AND expires_utc>UTC_TIMESTAMP() ORDER BY id DESC LIMIT 200");
    $eligible=[];
    foreach($licenses as $l){if(get_post_type($l->software_id)==='slm_software' && get_post_status($l->software_id)==='publish' && get_post_field('post_name',$l->software_id)==='ogipen' && (int)$l->seats>0)$eligible[]=$l;}
    echo '<form method="post" enctype="multipart/form-data" action="'.esc_url(admin_url('admin-post.php')).'">';wp_nonce_field('ogipen_workstation_issue');
    echo '<input type="hidden" name="action" value="ogipen_workstation_issue"><table class="form-table"><tr><th><label for="ogipen-license">Licence Ogipen</label></th><td><select id="ogipen-license" name="license_id" required><option value="">Choisir une licence</option>';
    foreach($eligible as $l){$used=ogipen_activation_used_places($l->id);echo '<option value="'.(int)$l->id.'">'.esc_html(get_the_title($l->software_id).' — licence #'.$l->id.' — '.$used.' / '.$l->seats.' places').'</option>';}
    echo '</select></td></tr><tr><th><label for="ogipen-request">Demande du poste</label></th><td><input id="ogipen-request" type="file" name="request" accept=".ogreq,.json,application/json" required><p class="description">8 Ko maximum. Ne chargez aucune clé privée.</p></td></tr><tr><th><label for="ogipen-days">Validité maximale (jours)</label></th><td><input id="ogipen-days" type="number" name="days" value="30" min="1" max="365" required><p class="description">La date reste plafonnée par l’expiration de la licence commerciale.</p></td></tr></table>';
    if($eligible)submit_button('Vérifier la demande et télécharger le .oglic');
    else echo '<div class="notice notice-warning inline"><p>Aucune licence Ogipen active et non expirée. Créez ou renouvelez la licence avant de générer le fichier du poste.</p></div>';
    echo '</form><p>Chaque nouvelle clé de poste activée consomme une place. Renouveler la même clé ne consomme pas de place supplémentaire. Les anciennes places nominatives restent réservées tant qu’elles sont actives ; aucune donnée existante n’est supprimée.</p><p><strong>Après le téléchargement :</strong> dans le client Ogipen 0.4.12 ou ultérieur, ouvrir Activation hors ligne puis Importer la licence, et choisir le .oglic téléchargé.</p><p><strong>Hors ligne :</strong> une révocation ne peut pas supprimer à distance un fichier déjà importé. Choisissez une durée adaptée.</p>';
    echo '<p><a class="button" href="'.esc_url(admin_url('admin.php?page=slmms-licenses')).'">Gérer les licences</a></p><h2>Historique des activations de postes</h2>';
    $rows=$wpdb->get_results("SELECT id,license_id,beneficiary_id,device_sha256,issued_utc,expires_utc,state FROM $t ORDER BY id DESC LIMIT 50");
    echo '<table class="widefat striped"><thead><tr><th>Activation</th><th>Licence / mode</th><th>Empreinte de clé</th><th>Expiration UTC</th><th>État</th><th>Actions</th></tr></thead><tbody>';
    if(!$rows)echo '<tr><td colspan="6">Aucune activation de poste enregistrée.</td></tr>';
    foreach($rows as $a){echo '<tr><td>#'.(int)$a->id.'</td><td>Licence #'.(int)$a->license_id.' / '.((int)$a->beneficiary_id===0?'Poste':'Ancienne attribution #'.(int)$a->beneficiary_id).'</td><td><code>'.esc_html(substr($a->device_sha256,0,16)).'…</code></td><td>'.esc_html($a->expires_utc).'</td><td>'.esc_html(['active'=>'Active','revoked'=>'Révoquée','replaced'=>'Remplacée','pending'=>'En attente'][$a->state]??$a->state).'</td><td>';
        if($a->state==='active'){
            foreach(['download'=>'Télécharger','revoke'=>'Révoquer'] as $op=>$label){echo '<form method="post" action="'.esc_url(admin_url('admin-post.php')).'" style="display:inline-block;margin:3px">';wp_nonce_field('ogipen_workstation_'.$op.'_'.$a->id);echo '<input type="hidden" name="action" value="ogipen_workstation_'.$op.'"><input type="hidden" name="activation_id" value="'.(int)$a->id.'">';if($op==='revoke')echo '<input name="reason" required maxlength="300" placeholder="Motif de révocation" aria-label="Motif de révocation"> ';echo '<button class="button">'.$label.'</button></form>';}
        }echo '</td></tr>';}
    echo '</tbody></table></div>';
}
function ogipen_workstation_send($json){nocache_headers();header('Content-Type: application/json');header('Content-Disposition: attachment; filename="ogipen-poste.oglic"');header('X-Content-Type-Options: nosniff');echo $json;exit;}
add_action('admin_post_ogipen_workstation_issue',function(){
    if(!current_user_can('manage_options'))wp_die('Accès refusé.','',['response'=>403]);
    if($_SERVER['REQUEST_METHOD']!=='POST')wp_die('Méthode refusée.','',['response'=>405]);
    check_admin_referer('ogipen_workstation_issue');ogipen_activation_schema();
    try{
        $f=$_FILES['request']??null;
        if(!$f || $f['error']!==UPLOAD_ERR_OK || $f['size']>8192 || !is_uploaded_file($f['tmp_name']))throw new DomainException('Fichier de demande invalide (8 Ko maximum).');
        $days=wp_unslash($_POST['days']??'');if(!is_string($days) || !preg_match('/^[1-9][0-9]{0,2}$/D',$days))throw new DomainException('Durée invalide.');
        $license_id=absint($_POST['license_id']??0);if(!$license_id)throw new DomainException('Choisissez une licence Ogipen.');
        $result=ogipen_issue_workstation(0,file_get_contents($f['tmp_name']),(int)$days,$license_id);ogipen_workstation_send($result['json']);
    }catch(DomainException $e){wp_die(esc_html($e->getMessage()),'Activation refusée',['response'=>400,'back_link'=>true]);}
    catch(Throwable $e){wp_die('Activation annulée : signature, base ou journal indisponible.','Activation refusée',['response'=>500,'back_link'=>true]);}
});
foreach(['download','revoke'] as $operation)add_action('admin_post_ogipen_workstation_'.$operation,function()use($operation){
    if(!current_user_can('manage_options'))wp_die('Accès refusé.','',['response'=>403]);
    if($_SERVER['REQUEST_METHOD']!=='POST')wp_die('Méthode refusée.','',['response'=>405]);
    $id=absint($_POST['activation_id']??0);check_admin_referer('ogipen_workstation_'.$operation.'_'.$id);
    try{$json=ogipen_workstation_existing($id,$operation==='revoke',wp_unslash($_POST['reason']??''));if($operation==='download')ogipen_workstation_send($json);$notice='revoked';}
    catch(Throwable $e){$notice='error';}
    wp_safe_redirect(add_query_arg(['page'=>'ogipen-offline','tab'=>'workstation','offline_notice'=>$notice],admin_url('admin.php')));exit;
});
