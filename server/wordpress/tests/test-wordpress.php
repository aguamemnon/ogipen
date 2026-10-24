<?php
define('WP_USE_THEMES',false);
require '/var/www/wordpress-recovered-20261023/wp-load.php';
if(!function_exists('ogipen_issue_workstation'))require '/tmp/ogipen-workstation-v046.php';
$admin=get_users(['role'=>'administrator','number'=>1,'orderby'=>'ID'])[0];wp_set_current_user($admin->ID);
ogipen_activation_schema();global $wpdb;$results=[];$created=[];
$snapshot=$wpdb->get_results('SELECT id,seats,status,expires_utc,modules_json FROM '.slmms_table('license'),ARRAY_A);
function check_offline($name,$pass){global $results;$results[]=['test'=>$name,'pass'=>(bool)$pass];if(!$pass)throw new RuntimeException('Test failed: '.$name);}
function reject_offline($name,$fn){try{$fn();$pass=false;}catch(DomainException $e){$pass=true;}check_offline($name,$pass);}
try{
    foreach([slmms_table('license'),slmms_table('users'),slmms_table('audit'),ogipen_activation_table()] as $t){
        $definition=$wpdb->get_row("SHOW CREATE TABLE `$t`",ARRAY_N);
        if(!$definition || $wpdb->query(preg_replace('/^CREATE TABLE /','CREATE TEMPORARY TABLE ',$definition[1],1))===false)throw new RuntimeException('Cannot create isolated test table');
        $created[]=$t;
    }
    $lic=700001;$benef=700001;$other=700002;$software=(int)get_option('ogipen_slm_software_id');
    $wpdb->insert(slmms_table('license'),['id'=>$lic,'license_key'=>'OFFLINE-ISOLATED-TEST','owner_id'=>$admin->ID,
        'software_id'=>$software,'major_version'=>1,'seats'=>1,'modules_json'=>'[]','expires_utc'=>gmdate('Y-m-d H:i:s',time()+600),
        'status'=>'active','created_utc'=>gmdate('Y-m-d H:i:s'),'updated_utc'=>gmdate('Y-m-d H:i:s')]);
    $wpdb->insert(slmms_table('users'),['id'=>$benef,'license_id'=>$lic,'provider'=>'ogipen','subject'=>'isolated-offline',
        'display_name'=>'Offline isolated test','active'=>1,'identity_verified'=>1,'identity_wp_user_id'=>$admin->ID,
        'created_utc'=>gmdate('Y-m-d H:i:s'),'updated_utc'=>gmdate('Y-m-d H:i:s')]);
    $request=file_get_contents('/etc/ogipen-licensing/v046-request.ogreq');
    $second=file_get_contents('/etc/ogipen-licensing/v046-second.ogreq');
    $renew=file_get_contents('/etc/ogipen-licensing/v046-renew.ogreq');
    $wrong=file_get_contents('/etc/ogipen-licensing/v046-wrong-software.ogreq');
    $parsed=ogipen_parse_offline_request($request);check_offline('client_request_proof_verified',$parsed['software_id']===$software && strlen($parsed['device_sha256'])===64);
    reject_offline('malformed_request_rejected',fn()=>ogipen_parse_offline_request('{}'));
    reject_offline('oversized_request_rejected',fn()=>ogipen_parse_offline_request(str_repeat('x',8193)));
    $broken=json_decode($request,true);$broken['major']=2;
    reject_offline('tampered_request_proof_rejected',fn()=>ogipen_parse_offline_request(json_encode($broken)));
    $broken=json_decode($request,true);$broken['nonce'].='=';
    reject_offline('noncanonical_base64_rejected',fn()=>ogipen_parse_offline_request(json_encode($broken)));
    $broken=json_decode($request,true);$broken['hostname']='not-allowed';
    reject_offline('extra_identifying_fields_rejected',fn()=>ogipen_parse_offline_request(json_encode($broken)));
    reject_offline('duration_bound_enforced',fn()=>ogipen_issue_workstation($benef,$request,366));
    reject_offline('wrong_software_rejected',fn()=>ogipen_issue_workstation($benef,$wrong,1));
    $users=slmms_table('users');$licenses=slmms_table('license');$table=ogipen_activation_table();
    $wpdb->update($users,['identity_verified'=>0],['id'=>$benef]);
    reject_offline('unverified_beneficiary_rejected',fn()=>ogipen_issue_workstation($benef,$request,1));
    $wpdb->update($users,['identity_verified'=>1,'active'=>0],['id'=>$benef]);
    reject_offline('inactive_beneficiary_rejected',fn()=>ogipen_issue_workstation($benef,$request,1));
    $wpdb->update($users,['active'=>1],['id'=>$benef]);$wpdb->update($licenses,['status'=>'blocked'],['id'=>$lic]);
    reject_offline('blocked_license_rejected',fn()=>ogipen_issue_workstation($benef,$request,1));
    $wpdb->update($licenses,['status'=>'active','expires_utc'=>'2020-01-01 00:00:00'],['id'=>$lic]);
    reject_offline('expired_license_rejected',fn()=>ogipen_issue_workstation($benef,$request,1));
    $expiry=gmdate('Y-m-d H:i:s',time()+600);$wpdb->update($licenses,['expires_utc'=>$expiry],['id'=>$lic]);
    $wpdb->update($licenses,['seats'=>0],['id'=>$lic]);
    reject_offline('zero_quota_rejected',fn()=>ogipen_issue_workstation($benef,$request,1));
    $wpdb->update($licenses,['seats'=>1],['id'=>$lic]);
    wp_set_current_user(0);reject_offline('anonymous_issuance_rejected',fn()=>ogipen_issue_workstation($benef,$request,1));wp_set_current_user($admin->ID);
    $issued=ogipen_issue_workstation($benef,$request,365);
    check_offline('wordpress_issues_client_wrapper',json_decode($issued['json'],true)['type']==='OGIPEN-OFFLINE-LICENSE');
    $row=$wpdb->get_row($wpdb->prepare("SELECT * FROM $table WHERE id=%d",$issued['id']));
    check_offline('activation_recorded_and_expiry_capped',$row->state==='active' && $row->expires_utc===$expiry);
    $parts=explode('.',json_decode($issued['json'],true)['token']);$claims=json_decode(ogipen_offline_decode($parts[1]),true);
    check_offline('rights_and_subject_come_from_slm',$claims['lic']===$lic && $claims['sub']===$benef && $claims['software_id']===$software && $claims['modules']===[]);
    $pub=openssl_pkey_get_public('file:///etc/ogipen-licensing/public.pem');
    check_offline('issuer_signature_valid',openssl_verify($parts[0].'.'.$parts[1],ogipen_offline_decode($parts[2]),$pub,OPENSSL_ALGO_SHA256)===1);
    file_put_contents('/etc/ogipen-licensing/v046-interop-test.oglic',$issued['json']);chmod('/etc/ogipen-licensing/v046-interop-test.oglic',0600);
    $repeat=ogipen_issue_workstation($benef,$request,365);
    check_offline('retry_idempotent',$repeat['reused'] && $repeat['json']===$issued['json'] && (int)$wpdb->get_var("SELECT COUNT(*) FROM $table")===1);
    reject_offline('different_key_requires_explicit_reassignment',fn()=>ogipen_issue_workstation($benef,$second,1));
    check_offline('authenticated_download_matches',ogipen_workstation_existing($issued['id'])===$issued['json']);
    $wpdb->update($licenses,['seats'=>2],['id'=>$lic]);
    reject_offline('stale_rights_block_redownload',fn()=>ogipen_workstation_existing($issued['id']));
    reject_offline('replay_after_rights_change_rejected',fn()=>ogipen_issue_workstation($benef,$request,1));
    $wpdb->update($licenses,['seats'=>1],['id'=>$lic]);
    $replacement=ogipen_issue_workstation($benef,$renew,1);
    check_offline('same_key_renewal_replaces_prior_activation',$replacement['id']!==$issued['id'] && $wpdb->get_var($wpdb->prepare("SELECT state FROM $table WHERE id=%d",$issued['id']))==='replaced');
    reject_offline('replaced_request_cannot_replay',fn()=>ogipen_issue_workstation($benef,$request,1));
    reject_offline('revocation_reason_required',fn()=>ogipen_workstation_existing($replacement['id'],true,''));
    ogipen_workstation_existing($replacement['id'],true,'Contrôle isolé');
    check_offline('revocation_recorded',$wpdb->get_var($wpdb->prepare("SELECT state FROM $table WHERE id=%d",$replacement['id']))==='revoked');
    reject_offline('revoked_download_rejected',fn()=>ogipen_workstation_existing($replacement['id']));
    reject_offline('revoked_request_replay_rejected',fn()=>ogipen_issue_workstation($benef,$renew,1));
    check_offline('new_key_after_revocation_allowed',ogipen_issue_workstation($benef,$second,1)['id']>0);
    check_offline('issuance_and_revocation_audited',(int)$wpdb->get_var('SELECT COUNT(*) FROM '.slmms_table('audit')." WHERE action='offline_workstation_issued'")===3 && (int)$wpdb->get_var('SELECT COUNT(*) FROM '.slmms_table('audit')." WHERE action='offline_workstation_revoked'")===1);
    ob_start();ogipen_workstation_page();$html=ob_get_clean();
    check_offline('workstation_tab_integrated',str_contains($html,'nav-tab-active') && str_contains($html,'Activer un poste (.ogreq)') && str_contains($html,'Historique des activations'));
    preg_match('/name="_wpnonce" value="([^"]+)"/',$html,$m);
    check_offline('issuance_form_nonce',!empty($m[1]) && wp_verify_nonce($m[1],'ogipen_workstation_issue')!==false);
    $previous=$wpdb->suppress_errors(true);
    $wpdb->query('ALTER TABLE '.slmms_table('audit').' CHANGE action missing_action varchar(48) NOT NULL');
    $wpdb->update($table,['state'=>'revoked'],['state'=>'active']);
    $before=(int)$wpdb->get_var("SELECT COUNT(*) FROM $table");
    // Verify audit failure using a fresh, valid proof that has not been consumed.
    $fresh=file_get_contents('/etc/ogipen-licensing/v046-fresh.ogreq');
    ogipen_parse_offline_request($fresh);
    try{ogipen_issue_workstation($benef,$fresh,1);$failed=false;}catch(RuntimeException $e){$failed=true;}
    $wpdb->suppress_errors($previous);
    check_offline('audit_failure_rolls_back_issuance',$failed && (int)$wpdb->get_var("SELECT COUNT(*) FROM $table")===$before);
}finally{
    foreach(array_reverse($created) as $t)$wpdb->query("DROP TEMPORARY TABLE IF EXISTS $t");
    $after=$wpdb->get_results('SELECT id,seats,status,expires_utc,modules_json FROM '.slmms_table('license'),ARRAY_A);
    check_offline('real_licenses_unchanged',$snapshot===$after);
    echo json_encode($results,JSON_PRETTY_PRINT|JSON_UNESCAPED_UNICODE),PHP_EOL;
}
