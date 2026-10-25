<?php
define('WPMU_PLUGIN_DIR','/root/ogipen-v0412/mu');
define('WP_USE_THEMES',false);
require '/var/www/wordpress-recovered-20261023/wp-load.php';
$admin=get_users(['role'=>'administrator','number'=>1,'orderby'=>'ID'])[0];wp_set_current_user($admin->ID);
global $wpdb; $results=[];$created=[];
function check12($name,$pass){global $results;$results[]=['test'=>$name,'pass'=>(bool)$pass];if(!$pass)throw new RuntimeException($name);}
function reject12($name,$fn){try{$fn();$pass=false;}catch(DomainException $e){$pass=true;}check12($name,$pass);}
$snapshot=$wpdb->get_results('SELECT * FROM '.slmms_table('license'),ARRAY_A);
$usersBefore=$wpdb->get_results('SELECT * FROM '.slmms_table('users'),ARRAY_A);
try{
 foreach([slmms_table('license'),slmms_table('users'),slmms_table('audit'),ogipen_activation_table(),slmms_quota_history_table()] as $t){
  $def=$wpdb->get_row("SHOW CREATE TABLE `$t`",ARRAY_N);
  if(!$def || $wpdb->query(preg_replace('/^CREATE TABLE /','CREATE TEMPORARY TABLE ',$def[1],1))===false)throw new RuntimeException('Temporary isolation failed');$created[]=$t;
 }
 $lic=700001;$software=(int)get_option('ogipen_slm_software_id');$licenses=slmms_table('license');$users=slmms_table('users');$t=ogipen_activation_table();
 $expiry=gmdate('Y-m-d H:i:s',time()+1800);
 $wpdb->insert($licenses,['id'=>$lic,'license_key'=>'ISOLATED-0412','owner_id'=>$admin->ID,'software_id'=>$software,'major_version'=>1,'seats'=>1,'modules_json'=>'[]','expires_utc'=>$expiry,'status'=>'active','created_utc'=>gmdate('Y-m-d H:i:s'),'updated_utc'=>gmdate('Y-m-d H:i:s')]);
 foreach(['request','second','renew','fresh','wrong'] as $name)$$name=file_get_contents('/root/ogipen-v0412/'.$name.'.ogreq');
 $issue=fn($req)=>ogipen_issue_workstation(0,$req,30,$lic);
 check12('request_proof_valid',ogipen_parse_offline_request($request)['software_id']===$software);
 reject12('malformed_request_denied',fn()=>$issue('{}'));
 $bad=json_decode($request,true);$bad['major']=2;reject12('tampered_request_denied',fn()=>$issue(json_encode($bad)));
 reject12('wrong_software_denied',fn()=>$issue($wrong));
 reject12('invalid_duration_denied',fn()=>ogipen_issue_workstation(0,$request,366,$lic));
 wp_set_current_user(0);reject12('anonymous_denied',fn()=>$issue($request));wp_set_current_user($admin->ID);
 $wpdb->update($licenses,['status'=>'blocked'],['id'=>$lic]);reject12('blocked_license_denied',fn()=>$issue($request));
 $wpdb->update($licenses,['status'=>'active','expires_utc'=>'2020-01-01 00:00:00'],['id'=>$lic]);reject12('expired_license_denied',fn()=>$issue($request));
 $wpdb->update($licenses,['expires_utc'=>$expiry],['id'=>$lic]);
 $issued=$issue($request);$parts=explode('.',json_decode($issued['json'],true)['token']);$claims=json_decode(ogipen_offline_decode($parts[1]),true);
 check12('device_license_without_user',$claims['sub']===0 && $claims['binding']==='device' && $claims['lic']===$lic);
 check12('no_beneficiary_created',(int)$wpdb->get_var("SELECT COUNT(*) FROM $users")===0);
 check12('one_place_consumed',ogipen_activation_used_places($lic)===1);
 check12('expiry_capped',gmdate('Y-m-d H:i:s',$claims['exp'])===$expiry);
 check12('signature_valid',openssl_verify($parts[0].'.'.$parts[1],ogipen_offline_decode($parts[2]),openssl_pkey_get_public('file:///etc/ogipen-licensing/public.pem'),OPENSSL_ALGO_SHA256)===1);
 file_put_contents('/root/ogipen-v0412/device.oglic',$issued['json']);chmod('/root/ogipen-v0412/device.oglic',0600);
 check12('repeat_idempotent',$issue($request)['json']===$issued['json']);
 check12('download_works',ogipen_workstation_existing($issued['id'])===$issued['json']);
 reject12('second_device_over_quota_denied',fn()=>$issue($second));
 $renewed=$issue($renew);check12('renewal_no_extra_place',ogipen_activation_used_places($lic)===1 && $renewed['id']!==$issued['id']);
 check12('old_activation_replaced',$wpdb->get_var($wpdb->prepare("SELECT state FROM $t WHERE id=%d",$issued['id']))==='replaced');
 reject12('old_request_replay_denied',fn()=>$issue($request));
 check12('quota_zero_refused',slmms_admin_set_seats($lic,0,1,'Test isolated',$admin->ID)==='invalid');
 reject12('revoke_requires_reason',fn()=>ogipen_workstation_existing($renewed['id'],true,''));
 ogipen_workstation_existing($renewed['id'],true,'Isolated test');check12('revoked_device_frees_place',ogipen_activation_used_places($lic)===0);
 reject12('revoked_download_denied',fn()=>ogipen_workstation_existing($renewed['id']));
 $other=$issue($second);check12('new_device_after_revocation',$other['id']>0);
 $wpdb->update($licenses,['seats'=>2],['id'=>$lic]);
 $wpdb->insert($users,['id'=>700001,'license_id'=>$lic,'provider'=>'ogipen','subject'=>'legacy-unverified','display_name'=>'Legacy test','active'=>1,'identity_verified'=>0,'created_utc'=>gmdate('Y-m-d H:i:s'),'updated_utc'=>gmdate('Y-m-d H:i:s')]);
 check12('legacy_reservation_counted',ogipen_activation_used_places($lic)===2);
 check12('quota_below_devices_and_reservations_denied',slmms_admin_set_seats($lic,1,2,'Test isolated',$admin->ID)==='in_use');
 reject12('reserved_place_not_borrowed',fn()=>$issue($fresh));
 $legacy=ogipen_issue_workstation(700001,$fresh,1);check12('legacy_no_user_verification',!empty($legacy['json']) && (int)$wpdb->get_var("SELECT identity_verified FROM $users WHERE id=700001")===0);
 check12('legacy_download_preserved',ogipen_workstation_existing($legacy['id'])===$legacy['json']);
 ob_start();ogipen_workstation_page();$html=ob_get_clean();check12('form_uses_license_no_beneficiary',str_contains($html,'name="license_id"') && !str_contains($html,'name="beneficiary_id"'));
 preg_match('/name="_wpnonce" value="([^"]+)"/',$html,$m);check12('form_csrf_preserved',!empty($m[1]) && wp_verify_nonce($m[1],'ogipen_workstation_issue')!==false);
 check12('next_step_explained',str_contains($html,'Après le téléchargement') && str_contains($html,'Importer la licence'));
 check12('device_issuance_audited',(int)$wpdb->get_var('SELECT COUNT(*) FROM '.slmms_table('audit')." WHERE action='offline_device_issued'")===3);
 $wpdb->update($t,['state'=>'revoked'],['state'=>'active']);$wpdb->update($users,['active'=>0],['license_id'=>$lic]);
 $before=(int)$wpdb->get_var("SELECT COUNT(*) FROM $t");$previous=$wpdb->suppress_errors(true);
 $wpdb->query('ALTER TABLE '.slmms_table('audit').' CHANGE action missing_action varchar(48) NOT NULL');
 try{$issue(file_get_contents('/root/ogipen-v0412/rollback.ogreq'));$failed=false;}catch(RuntimeException $e){$failed=true;}
 $wpdb->suppress_errors($previous);check12('audit_failure_rolls_back_direct_issuance',$failed && (int)$wpdb->get_var("SELECT COUNT(*) FROM $t")===$before);
}finally{
 foreach(array_reverse($created) as $t)$wpdb->query("DROP TEMPORARY TABLE IF EXISTS $t");
 check12('real_licenses_unchanged',$snapshot===$wpdb->get_results('SELECT * FROM '.slmms_table('license'),ARRAY_A));
 check12('real_users_and_verification_unchanged',$usersBefore===$wpdb->get_results('SELECT * FROM '.slmms_table('users'),ARRAY_A));
 echo json_encode($results,JSON_PRETTY_PRINT|JSON_UNESCAPED_UNICODE),PHP_EOL;
}
