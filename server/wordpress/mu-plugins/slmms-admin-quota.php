<?php
/** Plugin Name: SLM Plus — modification administrative des quotas
 * Version: 0.4.4
 * Description: Modification auditée du nombre de places des licences multi-logiciels.
 */
if(!defined('ABSPATH')){exit;}

function slmms_quota_history_table(){global $wpdb;return $wpdb->prefix.'slmms_quota_changes';}
function slmms_quota_schema(){
    if(!current_user_can('manage_options') || !function_exists('slmms_table'))return;
    if(get_option('slmms_quota_schema')==='1')return;
    global $wpdb;
    $table=slmms_quota_history_table();$charset=$wpdb->get_charset_collate();
    $ok=$wpdb->query("CREATE TABLE IF NOT EXISTS $table (
        id bigint unsigned NOT NULL AUTO_INCREMENT,
        license_id bigint unsigned NOT NULL,
        actor_user_id bigint unsigned NOT NULL,
        old_seats int unsigned NOT NULL,
        new_seats int unsigned NOT NULL,
        active_users int unsigned NOT NULL,
        reason varchar(500) NOT NULL,
        changed_utc datetime NOT NULL,
        PRIMARY KEY(id), KEY license_id(license_id)
    ) ENGINE=InnoDB $charset");
    if($ok!==false)update_option('slmms_quota_schema','1',false);
}
add_action('admin_init','slmms_quota_schema',30);

function slmms_quota_number($value){
    $value=(string)$value;
    return preg_match('/^[1-9][0-9]{0,5}$/D',$value) && (int)$value<=100000 ? (int)$value : 0;
}
function slmms_admin_set_seats($license_id,$new_seats,$expected_seats,$reason,$actor){
    if(!$actor || $actor!==get_current_user_id() || !user_can($actor,'manage_options'))return 'forbidden';
    $new=slmms_quota_number($new_seats);$expected=slmms_quota_number($expected_seats);
    $reason=trim(sanitize_textarea_field($reason));
    if(!$new || !$expected || !$license_id || !$reason || strlen($reason)>500)return 'invalid';
    global $wpdb;
    $licenses=slmms_table('license');$users=slmms_table('users');
    if($wpdb->query('START TRANSACTION')===false)return 'db';
    try{
        // The existing user-allocation handler locks the same parent row.
        $row=$wpdb->get_row($wpdb->prepare("SELECT * FROM $licenses WHERE id=%d FOR UPDATE",$license_id));
        if(!$row){$wpdb->query('ROLLBACK');return 'missing';}
        if((int)$row->seats!==$expected){$wpdb->query('ROLLBACK');return 'stale';}
        $used=(int)$wpdb->get_var($wpdb->prepare("SELECT COUNT(*) FROM $users WHERE license_id=%d AND active=1",$license_id));
        if(function_exists('ogipen_activation_used_places'))$used=ogipen_activation_used_places($license_id);
        if($new<$used){$wpdb->query('ROLLBACK');return 'in_use';}
        if($new===(int)$row->seats){$wpdb->query('ROLLBACK');return 'unchanged';}
        if($wpdb->update($licenses,['seats'=>$new,'updated_utc'=>gmdate('Y-m-d H:i:s')],['id'=>(int)$row->id])!==1)throw new RuntimeException('Update failed');
        if($wpdb->insert(slmms_quota_history_table(),[
            'license_id'=>(int)$row->id,'actor_user_id'=>$actor,
            'old_seats'=>(int)$row->seats,'new_seats'=>$new,'active_users'=>$used,
            'reason'=>$reason,'changed_utc'=>gmdate('Y-m-d H:i:s')
        ])===false)throw new RuntimeException('History failed');
        if($wpdb->insert(slmms_table('audit'),[
            'owner_id'=>(int)$row->owner_id,'actor_user_id'=>$actor,
            'license_id'=>(int)$row->id,'action'=>'license_seats_adjusted',
            'subject_id'=>0,'occurred_utc'=>gmdate('Y-m-d H:i:s')
        ])===false)throw new RuntimeException('Audit failed');
        if($wpdb->query('COMMIT')===false)throw new RuntimeException('Commit failed');
        return 'saved';
    }catch(Throwable $e){$wpdb->query('ROLLBACK');return 'db';}
}

add_action('admin_post_slmms_admin_set_seats',function(){
    if(!current_user_can('manage_options'))wp_die('Accès refusé.','',['response'=>403]);
    if($_SERVER['REQUEST_METHOD']!=='POST')wp_die('Méthode refusée.','',['response'=>405]);
    $id=absint($_POST['license_id']??0);
    check_admin_referer('slmms_admin_quota_'.$id);
    slmms_quota_schema();
    $result=slmms_admin_set_seats($id,wp_unslash($_POST['seats']??''),
        wp_unslash($_POST['expected_seats']??''),wp_unslash($_POST['reason']??''),get_current_user_id());
    wp_safe_redirect(add_query_arg(['page'=>'slmms-licenses','license_id'=>$id,'slmms_quota_notice'=>$result],admin_url('admin.php')));
    exit;
});

function slmms_admin_quota_controls($license){
    if(!current_user_can('manage_options'))return;
    global $wpdb;
    $used=(int)$wpdb->get_var($wpdb->prepare('SELECT COUNT(*) FROM '.slmms_table('users').' WHERE license_id=%d AND active=1',$license->id));
    if(function_exists('ogipen_activation_used_places'))$used=ogipen_activation_used_places($license->id);
    $notices=[
        'saved'=>'Quota enregistré. Les autres paramètres de la licence sont conservés.',
        'unchanged'=>'Le quota est inchangé.',
        'stale'=>'Cette licence a été modifiée depuis l’ouverture du formulaire. Vérifiez la valeur actuelle avant de recommencer.',
        'in_use'=>'Réduction refusée : le quota ne peut pas être inférieur aux places réservées et aux postes activés. Libérez d’abord les places concernées.',
        'invalid'=>'Indiquez entre 1 et 100 000 places et un motif court.',
        'db'=>'Modification annulée : enregistrement ou journalisation impossible.',
        'missing'=>'Licence introuvable.','forbidden'=>'Modification réservée aux administrateurs.'
    ];
    if(isset($_GET['slmms_quota_notice'])){
        $code=sanitize_key(wp_unslash($_GET['slmms_quota_notice']));
        if(isset($notices[$code]))echo '<div class="notice notice-'.(in_array($code,['saved','unchanged'],true)?'success':'error').' inline"><p>'.esc_html($notices[$code]).'</p></div>';
    }
    echo '<section class="postbox" style="padding:16px;margin-top:20px"><h2>Nombre de places autorisées</h2>';
    echo '<p><strong>'.esc_html($used.' / '.$license->seats).'</strong> places affectées. Cette attribution administrative ne déclenche aucune commande ni facturation WooCommerce.</p>';
    echo '<form method="post" action="'.esc_url(admin_url('admin-post.php')).'">';
    wp_nonce_field('slmms_admin_quota_'.$license->id);
    echo '<input type="hidden" name="action" value="slmms_admin_set_seats"><input type="hidden" name="license_id" value="'.(int)$license->id.'"><input type="hidden" name="expected_seats" value="'.(int)$license->seats.'">';
    echo '<p><label for="slmms-quota-seats">Nombre de places</label><br><input id="slmms-quota-seats" name="seats" type="number" min="'.max(1,$used).'" max="100000" step="1" value="'.(int)$license->seats.'" required></p>';
    echo '<p><label for="slmms-quota-reason">Motif de la modification</label><br><textarea id="slmms-quota-reason" name="reason" rows="2" maxlength="300" class="large-text" required></textarea></p>';
    submit_button('Enregistrer le nombre de places','primary','submit',false);
    echo '</form>';
    if((int)$license->software_id===(int)get_option('ogipen_slm_software_id')){
        echo '<p><strong>Serveur Ogipen hors ligne :</strong> après modification, exportez de nouveau la licence et importez-la dans la rubrique Licence du portail. Un fichier déjà exporté conserve ses anciens droits.</p><a class="button" href="'.esc_url(admin_url('admin.php?page=ogipen-offline')).'">Exporter la licence Ogipen</a>';
    }
    $history=$wpdb->get_results($wpdb->prepare('SELECT old_seats,new_seats,reason,changed_utc,actor_user_id FROM '.slmms_quota_history_table().' WHERE license_id=%d ORDER BY id DESC LIMIT 10',$license->id));
    if($history){
        echo '<h3>Historique des quotas</h3><table class="widefat striped"><thead><tr><th>Date UTC</th><th>Ancien quota</th><th>Nouveau quota</th><th>Administrateur</th><th>Motif</th></tr></thead><tbody>';
        foreach($history as $h){echo '<tr><td>'.esc_html($h->changed_utc).'</td><td>'.(int)$h->old_seats.'</td><td>'.(int)$h->new_seats.'</td><td>#'.(int)$h->actor_user_id.'</td><td>'.esc_html($h->reason).'</td></tr>';}
        echo '</tbody></table>';
    }
    echo '</section>';
}
add_action('slmms_license_admin_controls','slmms_admin_quota_controls');
