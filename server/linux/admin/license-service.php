<?php
declare(strict_types=1);
if(!function_exists('login_check')){http_response_code(404);exit;}
require_once __DIR__.'/license-verify.php';
function bound_license(string $path):array {
    $d=verify_license($path, getenv('OGIPEN_LICENSE_PUBLIC_KEY')?:'/etc/ogipen/licensing/public.pem');
    if (($d['subject_type']??'')!=='server' || ($d['subject_id']??'')!==getenv('OGIPEN_SERVER_ID') ||
        (string)($d['software_id']??'')!==getenv('OGIPEN_SOFTWARE_ID') ||
        ($d['major_version']??0)!==1 || ($d['issuer']??'')!==getenv('OGIPEN_LICENSE_ISSUER') ||
        !str_starts_with((string)($d['license_id']??''),'slmms:') ||
        !is_int($d['seats']??null) || $d['seats']<1 || $d['seats']>100000 || !is_array($d['modules']??null)) {
        throw new RuntimeException('Cette licence ne correspond pas au serveur Ogipen.');
    }
    return $d;
}
