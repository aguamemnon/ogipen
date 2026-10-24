<?php
declare(strict_types=1);
if(!function_exists('h')){http_response_code(404);exit;}
function authentication_event_table(array $events):string {
 try{$timezone=new DateTimeZone(getenv('OGIPEN_PORTAL_TIMEZONE')?:'Europe/Paris');}catch(Throwable $e){$timezone=new DateTimeZone('UTC');}
 ob_start();echo '<div class="table-scroll"><table class="authentication-events"><thead><tr><th>Date / heure '.h($timezone->getName()).'</th><th>Résultat / phase</th><th>PC déclaré</th><th>Utilisateur déclaré / identifiant</th><th>IP source</th><th>Licence présentée</th><th>Licence attendue</th><th>Vérification</th></tr></thead><tbody>';
 $count=0;
 foreach($events as $event){
  if(($event['entity_type']??'')!=='authentication')continue;
  $data=json_decode((string)($event['details']??''),true);if(!is_array($data) || ($data['schema']??'')!=='ogipen-auth-audit-v1')continue;
  $count++;$success=($data['success']??false)===true;$phase=$data['phase']??'';
  $label=$phase==='client'?'Refus local signalé':($phase==='challenge'?($success?'Challenge émis':'Challenge refusé'):($success?'Connexion réussie':'Connexion refusée'));
  $presented=isset($data['licenseId'])?'SLM '.(int)$data['licenseId']:'Non communiquée';
  $expected=isset($data['serverLicenseId'])?'SLM '.(int)$data['serverLicenseId']:'Non déterminée';
  try{$when=(new DateTimeImmutable($event['happened_utc'],new DateTimeZone('UTC')))->setTimezone($timezone)->format('d/m/Y H:i:s P');}catch(Throwable $e){$when=$event['happened_utc'];}
  echo '<tr><td>'.h($when).'</td><td>'.h($label).'<br><small>'.h($phase==='portal'?'Portail administrateur':'Logiciel Ogipen').'</small></td><td>'.h(($data['computerName']??'')?:'Non communiqué').'</td><td>'.h(($data['userName']??'')?:'Non communiqué').'<br><code>'.h($data['identityId']??$event['actor_id']).'</code></td><td>'.h($data['ip']??'Non déterminée').'</td><td>'.h($presented);
  if(($data['licenseMismatch']??null)===true)echo '<br><strong>Différente de celle attendue</strong>';
  echo '</td><td>'.h($expected);
  if(($data['serverLicenseSource']??'')==='instance_initial')echo '<br><small>Référence initiale de l’instance ; utilisateur non rattaché</small>';
  echo '</td><td>'.h(($data['licenseSignatureVerified']??false)?'Signature vérifiée':'Licence annoncée / non vérifiée');
  if(($data['licenseExpired']??false)===true)echo '<br>Licence expirée';
  if(($data['identityProofVerified']??false)===true)echo '<br>Clé utilisateur prouvée';
  $reasons=['authenticated'=>'Authentification validée','challenge_issued'=>'Preuve de clé demandée','identity_invalid'=>'Identifiant invalide','identity_not_enrolled_or_disabled'=>'Utilisateur non inscrit ou désactivé','company_entitlement_unavailable'=>'Droits de l’entreprise indisponibles','nonce_invalid_or_replayed'=>'Challenge expiré, invalide ou déjà utilisé','identity_proof_refused'=>'Preuve de clé refusée','client_entitlement_refused'=>'Licence poste non autorisée','client_local_license_refused'=>'Licence locale absente ou refusée par le client','credentials_refused'=>'Identifiants administrateur refusés','rate_limited'=>'Trop de tentatives','validation_refused'=>'Validation de formulaire refusée'];
  echo '<br><small>'.h($reasons[$data['reason']??'']??($data['reason']??'')).'</small></td></tr>';
 }
 if(!$count)echo '<tr><td colspan="8">Aucune tentative de connexion enregistrée dans cette sélection.</td></tr>';
 echo '</tbody></table></div>';return (string)ob_get_clean();
}
