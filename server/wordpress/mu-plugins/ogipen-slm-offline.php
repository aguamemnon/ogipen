<?php
/** Plugin Name: Ogipen — export hors ligne SLM Plus
 * Version: 0.4.6
 * Description: Exporte les droits existants SLM Plus en licence serveur signée.
 */
if (!defined('ABSPATH')) { exit; }

function ogipen_slm_export($license_id, $subject) {
    global $wpdb;
    if (!current_user_can('manage_options') || !function_exists('slmms_table')) {
        throw new RuntimeException('Accès interdit ou SLM Plus indisponible.');
    }
    if (!is_string($subject) || !preg_match('/^[A-Za-z0-9_.:-]{8,128}$/D', $subject)) {
        throw new RuntimeException('Identifiant serveur invalide (8 à 128 caractères).');
    }
    $row = $wpdb->get_row($wpdb->prepare('SELECT * FROM '.slmms_table('license').' WHERE id=%d', $license_id));
    $software = (int)get_option('ogipen_slm_software_id', 0);
    if (!$software || !$row || (int)$row->software_id !== $software ||
        $row->status !== 'active' || (int)$row->seats < 1 ||
        strtotime($row->expires_utc.' UTC') <= time()) {
        throw new RuntimeException('Licence Ogipen active et non expirée requise.');
    }
    $modules = json_decode($row->modules_json, true, 32, JSON_THROW_ON_ERROR);
    if (!is_array($modules)) { throw new RuntimeException('Modules invalides.'); }
    $key = openssl_pkey_get_private('file:///etc/ogipen-licensing/signing.pem');
    if (!$key) { throw new RuntimeException('Clé de signature indisponible.'); }
    $details = openssl_pkey_get_details($key);
    if (($details['type'] ?? null) !== OPENSSL_KEYTYPE_EC ||
        ($details['ec']['curve_name'] ?? '') !== 'prime256v1') {
        throw new RuntimeException('Clé de signature P-256 requise.');
    }
    $payload = wp_json_encode(array(
        'schema'=>'ogipen-entitlement-v1', 'issuer'=>home_url('/'),
        'license_id'=>'slmms:'.(int)$row->id,
        'software_id'=>$software, 'major_version'=>(int)$row->major_version,
        'subject_type'=>'server', 'subject_id'=>$subject,
        'issued_utc'=>gmdate('Y-m-d\TH:i:s\Z'),
        'expires_utc'=>gmdate('Y-m-d\TH:i:s\Z', strtotime($row->expires_utc.' UTC')),
        'seats'=>(int)$row->seats, 'modules'=>array_values(array_map('intval', $modules))
    ), JSON_UNESCAPED_SLASHES);
    if (!$payload || !openssl_sign($payload, $sig, $key, OPENSSL_ALGO_SHA256)) {
        throw new RuntimeException('Signature impossible.');
    }
    if ($wpdb->insert(slmms_table('audit'), array('owner_id'=>(int)$row->owner_id,
        'actor_user_id'=>get_current_user_id(), 'license_id'=>(int)$row->id,
        'action'=>'offline_license_exported', 'subject_id'=>0,
        'occurred_utc'=>gmdate('Y-m-d H:i:s'))) === false) {
        throw new RuntimeException('Journalisation impossible.');
    }
    $b64 = static function($v) { return rtrim(strtr(base64_encode($v), '+/', '-_'), '='); };
    return wp_json_encode(array('format'=>'ogipen-license-v1', 'alg'=>'ES256',
        'payload'=>$b64($payload), 'signature'=>$b64($sig)), JSON_PRETTY_PRINT|JSON_UNESCAPED_SLASHES);
}

add_action('admin_menu', function() {
    add_submenu_page('slm_overview', 'Ogipen hors ligne', 'Ogipen hors ligne',
        'manage_options', 'ogipen-offline', 'ogipen_slm_page');
}, 99);
function ogipen_slm_page() {
    if (!current_user_can('manage_options')) { return; }
    if(function_exists('ogipen_workstation_page') && sanitize_key(wp_unslash($_GET['tab']??'server'))==='workstation') { ogipen_workstation_page(); return; }
    global $wpdb;
    echo '<div class="wrap"><h1>Activation hors ligne Ogipen</h1>';
    do_action('ogipen_slm_offline_tabs','server');
    echo '<p>Créez la licence dans SLM Plus, puis exportez ses droits pour le serveur concerné. Les places, modules et dates proviennent de SLM Plus.</p>';
    if (!function_exists('slmms_table')) { echo '<p>SLM Plus requis.</p></div>'; return; }
    $rows = $wpdb->get_results($wpdb->prepare('SELECT id,expires_utc,seats FROM '.slmms_table('license')." WHERE software_id=%d AND status='active' AND expires_utc>UTC_TIMESTAMP() ORDER BY id DESC", (int)get_option('ogipen_slm_software_id')));
    echo '<form method="post" action="'.esc_url(admin_url('admin-post.php')).'">';
    wp_nonce_field('ogipen_slm_export');
    echo '<input type="hidden" name="action" value="ogipen_slm_export"><p><label>Licence <select name="license_id" required>';
    foreach ($rows as $r) { echo '<option value="'.(int)$r->id.'">#'.(int)$r->id.' — '.(int)$r->seats.' places — '.esc_html($r->expires_utc).' UTC</option>'; }
    echo '</select></label></p><p><label>Identifiant du serveur <input name="subject_id" required minlength="8" maxlength="128" class="regular-text"></label></p>';
    if ($rows) { submit_button('Télécharger la licence signée'); }
    else { echo '<p>Aucune licence Ogipen active. Créez-en une dans SLM Plus.</p>'; }
    echo '</form><p>Importez ensuite le fichier dans la console Ogipen. Une révocation ou une modification dans WordPress nécessite un nouvel export ; hors ligne, la licence reste valable jusqu’à son expiration.</p></div>';
}
add_action('admin_post_ogipen_slm_export', function() {
    if ($_SERVER['REQUEST_METHOD'] !== 'POST' || !current_user_can('manage_options')) {
        wp_die('Accès interdit.', '', array('response'=>403));
    }
    check_admin_referer('ogipen_slm_export');
    try {
        $body = ogipen_slm_export(absint($_POST['license_id'] ?? 0), wp_unslash($_POST['subject_id'] ?? ''));
        nocache_headers();
        header('Content-Type: application/json');
        header('Content-Disposition: attachment; filename="ogipen-license.oglic"');
        header('X-Content-Type-Options: nosniff');
        echo $body;
        exit;
    } catch (Throwable $e) { wp_die(esc_html($e->getMessage()), '', array('response'=>400)); }
});
