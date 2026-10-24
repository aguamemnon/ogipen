<?php
/** Ogipen License format v1 - CLI library. License signature is over raw base64url decoded payload bytes. */
declare(strict_types=1);
function b64u_decode(string $s): string|false {
  if (!preg_match('/^[A-Za-z0-9_-]+$/D', $s)) return false;
  return base64_decode(strtr($s,'-_','+/').str_repeat('=', (4-strlen($s)%4)%4), true);
}
function b64u_encode(string $s): string { return rtrim(strtr(base64_encode($s), '+/', '-_'), '='); }
function verify_license(string $licensePath, string $publicKeyPath): array {
  $wrapper=json_decode(file_get_contents($licensePath) ?: '', true, 32, JSON_THROW_ON_ERROR);
  if (!is_array($wrapper) || ($wrapper['format']??'')!=='ogipen-license-v1' || ($wrapper['alg']??'')!=='ES256' || !is_string($wrapper['payload']??null) || !is_string($wrapper['signature']??null)) throw new RuntimeException('Format de licence invalide');
  $payload=b64u_decode($wrapper['payload']); $sig=b64u_decode($wrapper['signature']);
  if ($payload===false || $sig===false) throw new RuntimeException('Encodage invalide');
  $pk=openssl_pkey_get_public('file://'.$publicKeyPath);
  if ($pk===false || openssl_verify($payload, $sig, $pk, OPENSSL_ALGO_SHA256)!==1) throw new RuntimeException('Signature invalide');
  $data=json_decode($payload, true, 32, JSON_THROW_ON_ERROR);
  if (($data['schema']??null)!=='ogipen-entitlement-v1') throw new RuntimeException('Schéma non reconnu');
  foreach (['license_id','subject_type','subject_id','expires_utc','modules'] as $key) if (!array_key_exists($key,$data)) throw new RuntimeException("Champ manquant: $key");
  if (!in_array($data['subject_type'], ['server','device','user','site'],true)) throw new RuntimeException('Sujet invalide');
  $expires=DateTimeImmutable::createFromFormat('!Y-m-d\\TH:i:s\\Z', $data['expires_utc'], new DateTimeZone('UTC'));
  if (!$expires || $expires->format('Y-m-d\\TH:i:s\\Z')!==$data['expires_utc'] || $expires < new DateTimeImmutable('now',new DateTimeZone('UTC'))) throw new RuntimeException('Licence expirée ou date invalide');
  return $data;
}
