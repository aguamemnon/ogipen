import pathlib,os,subprocess,json,base64,hashlib,hmac,datetime,time,urllib.request,urllib.error,socket,struct
os.umask(0o077)
root=pathlib.Path('/root/ogipen-v0416/tests');results=[];process=None;created=False;sockets=[]
cfg=dict(l.split('=',1) for l in pathlib.Path('/etc/webmin/mysql/config').read_text().splitlines() if '=' in l)
def quote(s):return '"'+s.replace('\\','\\\\').replace('"','\\"').replace('\n','\\n')+'"'
client=root/'test-db.cnf';client.write_text('[client]\nuser='+quote(cfg.get('login','root'))+'\npassword='+quote(cfg.get('pass',''))+'\n')
database='ogp_v0416_selftest'
password='isolated-'+os.urandom(24).hex()
def sql(q):
 p=subprocess.run(['mysql','--defaults-extra-file='+str(client),'-N','-B','--raw'],input=q,text=True,capture_output=True)
 if p.returncode:
  (root/'sql-test-error.txt').write_text(p.stderr)
  raise RuntimeError('Isolated test SQL failed; protected diagnostics saved')
 return p.stdout.strip()
def lit(s):return "CONVERT(0x"+s.encode().hex()+" USING utf8mb4)"
def check(name,ok):
 results.append({'test':name,'pass':bool(ok)})
 if not ok:raise AssertionError(name)
def b64(b):return base64.urlsafe_b64encode(b).decode().rstrip('=')
def key(name):
 p=root/(name+'.pem');pub=root/(name+'.pub');subprocess.run(['openssl','ecparam','-name','prime256v1','-genkey','-noout','-out',str(p)],check=True,capture_output=True)
 subprocess.run(['openssl','pkey','-in',str(p),'-pubout','-out',str(pub)],check=True,capture_output=True)
 der=subprocess.run(['openssl','pkey','-in',str(p),'-pubout','-outform','DER'],check=True,capture_output=True).stdout
 return p,pub,der
def sign(p,data):return subprocess.run(['openssl','dgst','-sha256','-sign',str(p)],input=data,capture_output=True,check=True).stdout
def p1363(der):
 pos=2;n=der[pos+1];r=der[pos+2:pos+2+n];pos+=2+n;n=der[pos+1];s=der[pos+2:pos+2+n]
 return base64.b64encode(r.lstrip(b'\0').rjust(32,b'\0')+s.lstrip(b'\0').rjust(32,b'\0')).decode()
now=int(time.time());issuer='https://isolated-ogipen-test.invalid'
def server(lic,modules,**changes):
 d={'schema':'ogipen-entitlement-v1','issuer':issuer+'/','license_id':'slmms:'+str(lic),'software_id':405,'major_version':1,'subject_type':'server','subject_id':'isolated-v048','expires_utc':datetime.datetime.fromtimestamp(now+3600,datetime.timezone.utc).strftime('%Y-%m-%dT%H:%M:%SZ'),'seats':1,'modules':modules};d.update(changes)
 raw=json.dumps(d,separators=(',',':')).encode();return json.dumps({'format':'ogipen-license-v1','alg':'ES256','payload':b64(raw),'signature':b64(sign(authority[0],raw))})
def grant(lic,beneficiary,device,modules,**changes):
 d={'aud':'ogipen-offline','iss':issuer,'software_id':405,'software':'ogipen','major':1,'lic':lic,'sub':beneficiary,'activation':1,'device_sha256':hashlib.sha256(device[2]).hexdigest(),'nonce':b64(os.urandom(32)),'iat':now,'exp':now+1800,'modules':modules};d.update(changes)
 h=b64(json.dumps({'alg':'ES256-DER','typ':'SLMMS-OFFLINE','v':1}).encode());p=b64(json.dumps(d).encode());token=h+'.'+p
 return json.dumps({'type':'OGIPEN-OFFLINE-LICENSE','version':1,'token':token+'.'+b64(sign(authority[0],token.encode()))})
def call(path,data=None,token=None,method=None):
 headers={};body=None
 if data is not None:headers['Content-Type']='application/json';body=json.dumps(data).encode()
 if token:headers['Authorization']='Bearer '+token
 try:
  with urllib.request.urlopen(urllib.request.Request('http://127.0.0.1:5089'+path,data=body,headers=headers,method=method),timeout=10) as r:return r.status,r.read().decode()
 except urllib.error.HTTPError as e:return e.code,e.read().decode()
def authenticate(identity,device,licence):
 sql('DELETE FROM '+database+'.ogp_login_attempt')
 number=None
 try:
  part=json.loads(licence)['token'].split('.')[1];number=json.loads(base64.urlsafe_b64decode(part+'='*((4-len(part)%4)%4)))['lic']
 except (TypeError,ValueError,KeyError):pass
 metadata={'computerName':'SELFTEST-PC-'+identity,'userName':'SELFTEST\\'+identity,'licenseId':number}
 code,body=call('/auth/v3/challenge',{'provider':'ogipen','login':identity,'identityId':identity,'deviceIdentityId':identity,**metadata})
 if code!=200:return code,None
 challenge=json.loads(body);form={'provider':'ogipen','login':identity,'identityId':identity,'deviceIdentityId':identity,'password':password,'nonce':challenge['nonce'],'deviceSignature':p1363(sign(device[0],challenge['signingText'].encode())),**metadata}
 if licence is not None:form['licenseJson']=licence
 code,body=call('/auth/v3/complete',form);return code,json.loads(body).get('accessToken') if code==200 else None
def company(id,blob=None,**values):
 if blob is not None:values['server_license_json']=blob
 sql('UPDATE '+database+'.ogp_project_company SET '+','.join(k+'='+lit(str(v)) for k,v in values.items())+' WHERE id='+str(id))
def audit(identity):return json.loads(sql('SELECT details FROM '+database+'.ogp_audit_event WHERE entity_type=\'authentication\' AND BINARY actor_id='+lit(identity)+' ORDER BY id DESC LIMIT 1'))
def send(s,text):
 d=text.encode();mask=os.urandom(4);n=len(d);h=bytes([129,128|n]) if n<126 else bytes([129,254])+struct.pack('!H',n)
 s.sendall(h+mask+bytes(v^mask[i%4] for i,v in enumerate(d)))
def exact(s,n):
 d=b''
 while len(d)<n:
  chunk=s.recv(n-len(d))
  if not chunk:raise EOFError()
  d+=chunk
 return d
def frame(s):
 h=exact(s,2);n=h[1]&127
 if n==126:n=struct.unpack('!H',exact(s,2))[0]
 if n==127:n=struct.unpack('!Q',exact(s,8))[0]
 return h[0]&15,exact(s,n)
def hub(token):
 import urllib.parse
 code,body=call('/hubs/events/negotiate?negotiateVersion=1&access_token='+urllib.parse.quote(token,safe=''),{})
 if code!=200:raise AssertionError('negotiate')
 connection=json.loads(body)['connectionToken'];s=socket.create_connection(('127.0.0.1',5089),timeout=5)
 path='/hubs/events?id='+urllib.parse.quote(connection,safe='')+'&access_token='+urllib.parse.quote(token,safe='')
 s.sendall(('GET '+path+' HTTP/1.1\r\nHost: localhost\r\nConnection: Upgrade\r\nUpgrade: websocket\r\nSec-WebSocket-Version: 13\r\nSec-WebSocket-Key: '+base64.b64encode(os.urandom(16)).decode()+'\r\n\r\n').encode())
 h=b''
 while not h.endswith(b'\r\n\r\n'):h+=exact(s,1)
 if b'101' not in h.split(b'\r\n')[0]:raise AssertionError('upgrade')
 send(s,'{"protocol":"json","version":1}\x1e');op,data=frame(s)
 if op!=1 or b'{}\x1e' not in data:raise AssertionError('handshake')
 sockets.append(s);return s
try:
 check('isolated_database_does_not_exist',sql("SELECT COUNT(*) FROM information_schema.schemata WHERE schema_name='"+database+"'")=='0')
 sql('CREATE DATABASE '+database+' CHARACTER SET utf8mb4');created=True
 for t in ['ogp_identity','ogp_permission','ogp_challenge','ogp_edit_lock','ogp_audit_event','ogp_demo_cable','ogp_project_company','ogp_collaboration_config','ogp_auth_session']:sql('CREATE TABLE '+database+'.'+t+' LIKE ogp_test_001.'+t)
 migration=pathlib.Path('/root/ogipen-v0416/schema.sql').read_text()
 exists=sql("SELECT COUNT(*) FROM information_schema.columns WHERE table_schema='"+database+"' AND table_name='ogp_auth_session' AND column_name='auth_method'")
 sql('USE '+database+';'+(migration.split('ALTER TABLE')[0] if exists=='1' else migration))
 sql(pathlib.Path('/root/ogipen-v0416/schema-role.sql').read_text().join(['USE '+database+';','']))
 authority=key('issuer');a=key('a');b=key('b');other=key('other')
 sa=server(2,[10]);sb=server(8,[20]);ga=grant(2,101,a,[10]);gb=grant(8,202,b,[20])
 (root/'initial-server.oglic').write_text(sa)
 sql("INSERT INTO "+database+".ogp_collaboration_config(id,requested_mode,effective_mode) VALUES(1,'multi','multi')")
 for id,lic,blob in [(1,2,sa),(2,8,sb)]:sql('INSERT INTO '+database+'.ogp_project_company(id,company_code,display_name,slm_license_id,server_license_json) VALUES('+str(id)+','+lit('company-'+str(id))+','+lit('Company '+str(id))+','+str(lic)+','+lit(blob)+')')
 for name,device,company_id,benef in [('a',a,1,101),('b',b,2,202)]:
  sql('INSERT INTO '+database+'.ogp_identity(id,display_name,public_key_pem,public_key_sha256,enabled,company_id,license_beneficiary_id) VALUES('+lit(name)+','+lit(name)+','+lit(device[1].read_text())+','+lit(hashlib.sha256(device[2]).hexdigest())+',1,'+str(company_id)+','+str(benef)+')')
  sql('INSERT INTO '+database+'.ogp_permission(identity_id,can_read,can_edit) VALUES('+lit(name)+',1,'+('1' if name=='b' else '0')+')')
 salt=os.urandom(32);digest=hashlib.pbkdf2_hmac('sha256',password.encode(),salt,600000);stored='pbkdf2-sha256$600000$'+base64.b64encode(salt).decode()+'$'+base64.b64encode(digest).decode()
 for name in ['a','b']:sql('INSERT INTO '+database+".ogp_app_account(identity_id,login_name,password_hash,system_role,enabled) VALUES("+lit(name)+','+lit(name)+','+lit(stored)+",'user',1)")
 sql('INSERT INTO '+database+".ogp_device(device_id,company_id,public_key_pem,legacy_beneficiary_id,enabled) SELECT id,company_id,public_key_pem,license_beneficiary_id,1 FROM "+database+".ogp_identity")
 sql('INSERT INTO '+database+".ogp_demo_cable(id,reference) VALUES(425,'ISOLATED-425')")
 env=os.environ.copy();env.update({'OGIPEN_DB_CONNECTION':'Server=localhost;Database='+database+';User ID='+cfg.get('login','root')+';Password="'+cfg.get('pass','').replace('"','""')+'"','OGIPEN_SESSION_KEY':base64.b64encode(os.urandom(32)).decode(),'OGIPEN_LICENSE_PUBLIC_KEY':str(authority[1]),'OGIPEN_SERVER_ID':'isolated-v048','OGIPEN_SOFTWARE_ID':'405','OGIPEN_LICENSE_ISSUER':issuer+'/','OGIPEN_AUTH_AUDIENCE':'https://isolated-ogipen-test.invalid/client-api/','ASPNETCORE_URLS':'http://127.0.0.1:5089','DOTNET_ENVIRONMENT':'Production'})
 env['OGIPEN_LICENSE_PATH']=str(root/'initial-server.oglic')
 log=open(root/'api-test.log','w');process=subprocess.Popen(['dotnet','/root/ogipen-v0416/publish/Ogipen.Api.dll'],env=env,stdout=log,stderr=log)
 for _ in range(50):
  try:
   if call('/health')[0]==200:break
  except OSError:pass
  if process.poll() is not None:raise RuntimeError('Isolated API startup failed; inspect protected log')
  time.sleep(.2)
 check('legacy_passwordless_challenge_disabled',call('/auth/challenge',{'identityId':'a'})[0]==426)
 check('legacy_passwordless_complete_disabled',call('/auth/complete',{})[0]==426)
 check('anonymous_api_denied',call('/cables/425')[0]==404 and call('/api/cables/425')[0]==401)
 check('missing_client_licence_denied',authenticate('a',a,None)[0] in (400,401))
 check('company_a_authenticated',authenticate('a',a,ga)[0]==200);_,ta=authenticate('a',a,ga)
 row=audit('a');check('success_audit_computer_user_ip',row['computerName']=='SELFTEST-PC-a' and row['userName']=='SELFTEST\\a' and row['ip']=='127.0.0.1' and row['success'])
 check('success_audit_verified_licence',row['licenseId']==2 and row['serverLicenseId']==2 and row['licenseSignatureVerified'] and row['identityProofVerified'])
 check('company_b_same_project_authenticated',authenticate('b',b,gb)[0]==200);_,tb=authenticate('b',b,gb)
 (root/'client-fixture.oglic').write_text(ga)
 client_env=env.copy();client_env.update({'OGIPEN_CHECK_KEY':str(a[0]),'OGIPEN_CHECK_LICENSE':str(root/'client-fixture.oglic'),'OGIPEN_CHECK_ISSUER_KEY':str(authority[1]),'OGIPEN_CHECK_ISSUER':issuer,'OGIPEN_CHECK_PASSWORD':password})
 live=subprocess.run(['dotnet','/root/ogipen-v0416/client/tests/OGIPEN.LicensedSession.Checks/bin/Release/net10.0/OGIPEN.LicensedSession.Checks.dll','--password-integration'],env=client_env,text=True,capture_output=True)
 if live.returncode:print(live.stderr);raise RuntimeError('Real C# client/API integration failed')
 (root/'results-client-live.json').write_text(live.stdout.strip());check('real_csharp_client_api_and_logout',True)
 check('logout_preserves_other_sessions',call('/api/session',token=ta)[0]==200)
 check('session_bound_to_company',json.loads(call('/api/session',token=ta)[1])['companyId']==1)
 check('shared_project_read_a',call('/api/cables/425',token=ta)[0]==200)
 check('shared_project_read_b',call('/api/cables/425',token=tb)[0]==200)
 check('a_own_module_allowed',call('/api/modules/10/access',token=ta)[0]==200)
 check('a_cannot_borrow_b_module',call('/api/modules/20/access',token=ta)[0]==403)
 check('b_cannot_borrow_a_module',call('/api/modules/10/access',token=tb)[0]==403)
 check('wrong_commercial_licence_denied',authenticate('a',a,grant(8,101,a,[10]))[0]==401)
 row=audit('a');check('mismatched_licence_retained_and_verified',row['licenseId']==8 and row['serverLicenseId']==2 and row['licenseMismatch'] and row['licenseSignatureVerified'] and not row['success'])
 device_grant=grant(2,0,a,[10],binding='device')
 code,td=authenticate('a',a,device_grant);check('device_activation_without_wp_beneficiary',code==200)
 check('device_context_is_not_legacy_beneficiary',json.loads(call('/api/session',token=td)[1])['beneficiaryId']==0)
 sql('UPDATE '+database+".ogp_identity SET license_beneficiary_id=NULL WHERE id='a'");sql('UPDATE '+database+".ogp_device SET legacy_beneficiary_id=NULL WHERE device_id='a'")
 check('device_session_survives_without_beneficiary_mapping',call('/api/cables/425',token=td)[0]==200)
 check('new_device_session_without_beneficiary_mapping',authenticate('a',a,device_grant)[0]==200)
 (root/'client-fixture.oglic').write_text(device_grant)
 live_device=subprocess.run(['dotnet','/root/ogipen-v0416/client/tests/OGIPEN.LicensedSession.Checks/bin/Release/net10.0/OGIPEN.LicensedSession.Checks.dll','--password-integration'],env=client_env,text=True,capture_output=True)
 check('real_csharp_device_without_beneficiary',live_device.returncode==0)
 (root/'results-client-device-live.json').write_text(live_device.stdout)
 check('legacy_still_requires_legacy_mapping',authenticate('a',a,ga)[0]==401)
 check('zero_subject_without_device_marker_denied',authenticate('a',a,grant(2,0,a,[10]))[0]==401)
 check('device_marker_positive_subject_denied',authenticate('a',a,grant(2,101,a,[10],binding='device'))[0]==401)
 check('device_wrong_licence_denied',authenticate('a',a,grant(8,0,a,[10],binding='device'))[0]==401)
 check('device_wrong_key_denied',authenticate('a',a,grant(2,0,b,[10],binding='device'))[0]==401)
 sql('UPDATE '+database+".ogp_identity SET license_beneficiary_id=101 WHERE id='a'");sql('UPDATE '+database+".ogp_device SET legacy_beneficiary_id=101 WHERE device_id='a'")
 # Account switching keeps the same device licence and its own project identity.
 sql('UPDATE '+database+".ogp_identity SET enabled=0 WHERE id='a'")
 sql('INSERT INTO '+database+".ogp_identity(id,display_name,public_key_pem,enabled,company_id) VALUES('switched','Switched account','',1,1)")
 sql('INSERT INTO '+database+".ogp_permission(identity_id,can_read,can_edit) VALUES('switched',1,0)")
 sql('INSERT INTO '+database+".ogp_app_account(identity_id,login_name,password_hash,system_role,enabled) VALUES('switched','admin',"+lit(stored)+",'admin',1)");sql('UPDATE '+database+".ogp_identity SET system_role='admin' WHERE id='switched'")
 sql('UPDATE '+database+".ogp_identity SET enabled=1 WHERE id='a'")
 # Temporarily raise the test-company quota with another isolated signed entitlement.
 company(1,server(2,[10],seats=2))
 def switched(pw,proof_device=a):
  code,body=call('/auth/v3/challenge',{'provider':'ogipen','login':'admin','identityId':'','deviceIdentityId':'a'})
  if code!=200:return code,None
  ch=json.loads(body);form={'provider':'ogipen','login':'admin','identityId':'switched','deviceIdentityId':'a','password':pw,'nonce':ch['nonce'],'deviceSignature':p1363(sign(proof_device[0],ch['signingText'].encode())),'licenseJson':device_grant}
  code,body=call('/auth/v3/complete',form);return code,json.loads(body).get('accessToken') if code==200 else None
 check('internal_password_required',switched('')[0]==401)
 check('wrong_internal_password_refused',switched('wrong-password')[0]==401)
 check('account_switch_still_requires_device_key',switched(password,other)[0]==401)
 code,sw=switched(password);check('internal_admin_login_on_same_activated_device',code==200)
 context=json.loads(call('/api/session',token=sw)[1]);check('session_uses_selected_account',context['identity']=='switched' and context['systemRole']=='admin')
 sql('UPDATE '+database+".ogp_identity SET enabled=0 WHERE id='a'")
 check('admin_switch_uses_device_independent_of_os_user_rights',switched(password)[0]==200)
 sql('UPDATE '+database+".ogp_identity SET enabled=1 WHERE id='a'")
 check('admin_has_technical_endpoint',call('/api/administration',token=sw)[0]==200)
 # The desktop account-management API is scoped to the authenticated company.
 endpoint='/api/administration/accounts'
 dummy={'identityId':None,'login':'managed-fixture','displayName':'Managed fixture','systemRole':'user','enabled':True,'revision':0,'newPassword':'isolated-'+os.urandom(24).hex()}
 check('account_list_requires_authentication',call(endpoint)[0]==401)
 check('ordinary_reader_cannot_list_accounts',call(endpoint,token=ta)[0]==403)
 check('ordinary_editor_cannot_manage_accounts',call(endpoint,dummy,tb)[0]==403)
 code,body=call(endpoint,token=sw);listed=json.loads(body)
 check('admin_lists_only_own_company',code==200 and listed['companyId']==1 and {x['login'] for x in listed['items']}=={'a','admin'})
 check('account_list_never_exposes_credentials','password' not in body.lower() and 'hash' not in body.lower())
 sql('UPDATE '+database+".ogp_app_account SET system_role='ossi' WHERE identity_id='switched'");sql('UPDATE '+database+".ogp_identity SET system_role='ossi' WHERE id='switched'")
 code,body=call(endpoint,token=sw);check('ossi_reads_without_write_permission',code==200 and not json.loads(body)['canManage'])
 check('ossi_cannot_post_account_mutations',call(endpoint,dummy,sw)[0]==403)
 sql('UPDATE '+database+".ogp_app_account SET system_role='admin' WHERE identity_id='switched'");sql('UPDATE '+database+".ogp_identity SET system_role='admin' WHERE id='switched'")
 check('new_active_account_respects_quota',call(endpoint,dummy,sw)[0]==409)
 cross=dict(dummy,identityId='b',login='b',revision=1)
 before_b=sql('SELECT auth_version FROM '+database+".ogp_identity WHERE id='b'")
 check('foreign_company_account_update_denied',call(endpoint,cross,sw)[0]==409)
 check('foreign_account_revision_unchanged',before_b==sql('SELECT auth_version FROM '+database+".ogp_identity WHERE id='b'"))
 inactive=dict(dummy,enabled=False,newPassword=None)
 code,body=call(endpoint,inactive,sw);check('create_inactive_account_without_password',code==200);newid=json.loads(body)['identityId']
 def item(login_name):return next(x for x in json.loads(call(endpoint,token=sw)[1])['items'] if x['login']==login_name)
 created_account=item(dummy['login']);check('new_account_has_no_implicit_project_rights',not created_account['canRead'] and not created_account['canEdit'])
 missing=dict(dummy,identityId=newid,revision=created_account['revision'],newPassword=None)
 company(1,server(2,[10],seats=3))
 check('activation_requires_initial_password',call(endpoint,missing,sw)[0]==400)
 short=dict(missing,newPassword='sixchars')
 check('short_password_rejected',call(endpoint,short,sw)[0]==400)
 unicode_short=dict(missing,newPassword='😀'*6)
 check('password_minimum_counts_unicode_characters',call(endpoint,unicode_short,sw)[0]==400)
 activate=dict(missing,newPassword=dummy['newPassword'])
 code,body=call(endpoint,activate,sw);check('enable_account_with_password',code==200)
 check('stale_account_update_rejected',call(endpoint,activate,sw)[0]==409)
 def login_as(login_name,pw):
  sql('DELETE FROM '+database+'.ogp_login_attempt')
  code,body=call('/auth/v3/challenge',{'provider':'ogipen','login':login_name,'identityId':'','deviceIdentityId':'a'})
  if code!=200:return code,None
  ch=json.loads(body);code,body=call('/auth/v3/complete',{'provider':'ogipen','login':login_name,'identityId':ch['identityId'],'deviceIdentityId':'a','password':pw,'nonce':ch['nonce'],'deviceSignature':p1363(sign(a[0],ch['signingText'].encode())),'licenseJson':device_grant})
  return code,json.loads(body).get('accessToken') if code==200 else None
 code,newtoken=login_as(dummy['login'],dummy['newPassword']);check('api_created_password_authenticates',code==200)
 check('new_user_cannot_read_business_data',call('/api/cables/425',token=newtoken)[0]==403)
 current=item(dummy['login']);change=dict(activate,revision=current['revision'],systemRole='ossi',newPassword=None)
 code,body=call(endpoint,change,sw);check('technical_role_change_saved',code==200)
 check('role_change_revokes_old_sessions',call('/api/session',token=newtoken)[0]==401)
 code,newtoken=login_as(dummy['login'],dummy['newPassword']);check('new_role_applied_after_login',code==200 and json.loads(call('/api/session',token=newtoken)[1])['systemRole']=='ossi')
 current=item(dummy['login']);replacement='replacement-'+os.urandom(24).hex()
 reset=dict(change,revision=current['revision'],newPassword=replacement)
 check('password_reset_saved',call(endpoint,reset,sw)[0]==200)
 check('password_reset_revokes_existing_session',call('/api/session',token=newtoken)[0]==401)
 check('old_password_stops_working',login_as(dummy['login'],dummy['newPassword'])[0]==401)
 code,newtoken=login_as(dummy['login'],replacement);check('replacement_password_works',code==200)
 stored_hash=sql('SELECT password_hash FROM '+database+'.ogp_app_account WHERE BINARY identity_id='+lit(newid)).split('$')
 check('csharp_hash_compatible_with_php_format',stored_hash[:2]==['pbkdf2-sha256','600000'] and hashlib.pbkdf2_hmac('sha256',replacement.encode(),base64.b64decode(stored_hash[2]),600000)==base64.b64decode(stored_hash[3]))
 current=item(dummy['login']);disabled=dict(reset,revision=current['revision'],enabled=False,newPassword=None)
 check('account_deactivation_saved',call(endpoint,disabled,sw)[0]==200)
 check('deactivation_revokes_current_session',call('/api/session',token=newtoken)[0]==401)
 check('disabled_account_login_refused',login_as(dummy['login'],replacement)[0]==401)
 current_admin=item('admin');self_edit={'identityId':'switched','login':'admin','displayName':'Switched account','systemRole':'admin','enabled':True,'revision':current_admin['revision'],'newPassword':None}
 check('last_admin_cannot_be_disabled',call(endpoint,dict(self_edit,enabled=False),sw)[0]==409)
 check('last_admin_cannot_be_demoted',call(endpoint,dict(self_edit,systemRole='user'),sw)[0]==409)
 before_failure=sql('SELECT CONCAT(i.auth_version,CHAR(124),a.password_hash) FROM '+database+'.ogp_app_account a JOIN '+database+'.ogp_identity i ON i.id=a.identity_id WHERE BINARY a.identity_id='+lit(newid))
 sql('CREATE TRIGGER '+database+".fail_account_audit BEFORE INSERT ON "+database+".ogp_audit_event FOR EACH ROW SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT='Isolated audit failure'")
 try:
  current=item(dummy['login']);audit_fail=dict(disabled,revision=current['revision'],newPassword='rollback-'+os.urandom(24).hex())
  failed_code=call(endpoint,audit_fail,sw)[0]
 finally:sql('DROP TRIGGER '+database+'.fail_account_audit')
 after_failure=sql('SELECT CONCAT(i.auth_version,CHAR(124),a.password_hash) FROM '+database+'.ogp_app_account a JOIN '+database+'.ogp_identity i ON i.id=a.identity_id WHERE BINARY a.identity_id='+lit(newid))
 check('audit_failure_rolls_back_account_password_and_revision',failed_code==500 and before_failure==after_failure)
 audit_contents=sql("SELECT details FROM "+database+".ogp_audit_event WHERE entity_type='account_administration'")
 check('account_audit_never_contains_passwords',dummy['newPassword'] not in audit_contents and replacement not in audit_contents and audit_fail['newPassword'] not in audit_contents)
 check('account_administration_not_in_business_feed',all(x['entityType']!='account_administration' for x in json.loads(call('/api/events?after=0',token=ta)[1])))
 code,body=call(endpoint,dict(self_edit,displayName='Admin renamed'),sw);check('self_change_requests_reauthentication',code==200 and json.loads(body)['reauthenticate'])
 check('self_change_revokes_current_session',call('/api/session',token=sw)[0]==401)
 code,sw=switched(password);check('admin_can_reconnect_after_self_change',code==200)
 for table,column in [('ogp_auth_session','identity_id'),('ogp_permission','identity_id'),('ogp_app_account','identity_id'),('ogp_identity','id')]:sql('DELETE FROM '+database+'.'+table+' WHERE BINARY '+column+'='+lit(newid))
 company(1,server(2,[10],seats=2))
 check('technical_admin_does_not_imply_project_edit',call('/api/locks/cable/425',{},sw,'POST')[0]==403)
 sql('UPDATE '+database+".ogp_identity SET auth_version=auth_version+1 WHERE id='switched'")
 check('password_reset_revision_revokes_session',call('/api/session',token=sw)[0]==401)
 sql('DELETE FROM '+database+'.ogp_login_attempt')
 limited_codes=[switched('wrong-password')[0] for _ in range(6)]
 check('password_bruteforce_limited',limited_codes[:5]==[401]*5 and limited_codes[5]==429)
 sql('DELETE FROM '+database+'.ogp_login_attempt')
 sql('DELETE FROM '+database+".ogp_permission WHERE identity_id='switched'");sql('DELETE FROM '+database+".ogp_identity WHERE id='switched'");sql('DELETE FROM '+database+".ogp_app_account WHERE identity_id='switched'");company(1,sa)
 company(1,server(2,[10],seats=2))
 windows_id='win-sid:S-1-5-21-999-999-999-1001'
 sql('INSERT INTO '+database+'.ogp_identity(id,display_name,public_key_pem,enabled,company_id) VALUES('+lit(windows_id)+",'Windows fixture',"+lit(other[1].read_text())+',1,1)')
 sql('INSERT INTO '+database+'.ogp_permission(identity_id,can_read,can_edit) VALUES('+lit(windows_id)+',1,0)')
 def windows(proof_key=other,extra_password=None):
  code,body=call('/auth/v3/challenge',{'provider':'windows','login':'DOMAIN\\fixture','identityId':windows_id,'deviceIdentityId':'a'})
  if code!=200:return code,None
  ch=json.loads(body);code,body=call('/auth/v3/complete',{'provider':'windows','login':'DOMAIN\\fixture','identityId':windows_id,'deviceIdentityId':'a','password':extra_password,'nonce':ch['nonce'],'deviceSignature':p1363(sign(a[0],ch['signingText'].encode())),'userSignature':p1363(sign(proof_key[0],ch['signingText'].encode())),'licenseJson':device_grant})
  return code,json.loads(body).get('accessToken') if code==200 else None
 code,tw=windows();check('different_windows_identity_with_own_proof',code==200)
 # Change a real-shaped enrolled Windows identity's role through the PHP portal service.
 role_env=env.copy();role_env['TEST_DB_USER']=cfg.get('login','root');role_env['TEST_DB_PASSWORD']=cfg.get('pass','')
 def portal_role(role):
  run=subprocess.run(['php','/root/ogipen-v0416/tests/mutate-role.php',windows_id,role],env=role_env,capture_output=True,text=True)
  if run.returncode:raise RuntimeError('Isolated role mutation failed')
  return json.loads(run.stdout)
 before_permission=sql('SELECT CONCAT(can_read,can_edit) FROM '+database+'.ogp_permission WHERE BINARY identity_id='+lit(windows_id))
 changed=portal_role('admin');check('portal_promotes_windows_identity_without_internal_account',changed['system_role']=='admin' and changed['internal_count']==0)
 check('technical_role_change_preserves_project_rights',before_permission==sql('SELECT CONCAT(can_read,can_edit) FROM '+database+'.ogp_permission WHERE BINARY identity_id='+lit(windows_id)))
 check('windows_role_change_revokes_old_session',call('/api/session',token=tw)[0]==401)
 code,tw=windows();check('windows_admin_role_returned_after_relogin',code==200 and json.loads(call('/api/session',token=tw)[1])['systemRole']=='admin')
 check('windows_admin_can_open_internal_account_administration',call('/api/administration/accounts',token=tw)[0]==200)
 native_create={'identityId':None,'login':'native-admin-probe','displayName':'Native admin probe','systemRole':'user','enabled':False,'revision':0,'newPassword':None}
 code,body=call('/api/administration/accounts',native_create,tw);check('windows_admin_can_manage_internal_accounts',code==200);probe=json.loads(body)['identityId']
 for table,column in [('ogp_permission','identity_id'),('ogp_app_account','identity_id'),('ogp_identity','id')]:sql('DELETE FROM '+database+'.'+table+' WHERE BINARY '+column+'='+lit(probe))
 sql('UPDATE '+database+".ogp_identity SET system_role='admin' WHERE id='a'");sql('UPDATE '+database+".ogp_app_account SET system_role='admin' WHERE identity_id='a'")
 changed=portal_role('ossi');check('portal_assigns_ossi_to_windows_identity',changed['system_role']=='ossi')
 code,tw=windows();snapshot=json.loads(call('/api/administration/accounts',token=tw)[1]);check('windows_ossi_is_read_only_after_relogin',code==200 and not snapshot['canManage'])
 check('windows_ossi_cannot_modify_accounts',call('/api/administration/accounts',native_create,tw)[0]==403)
 sql('UPDATE '+database+".ogp_identity SET system_role='user' WHERE id='a'");sql('UPDATE '+database+".ogp_app_account SET system_role='user' WHERE identity_id='a'")
 check('windows_session_uses_selected_sid',json.loads(call('/api/session',token=tw)[1])['identity']==windows_id)
 check('windows_account_cannot_be_replaced_by_device_identity',windows(a)[0]==401)
 check('windows_password_must_not_be_sent_to_server',windows(extra_password='WINDOWS_SECRET_SENTINEL')[0]==401)
 check('windows_password_not_journaled','WINDOWS_SECRET_SENTINEL' not in sql('SELECT details FROM '+database+'.ogp_audit_event WHERE BINARY actor_id='+lit(windows_id)))
 sql('DELETE FROM '+database+'.ogp_permission WHERE BINARY identity_id='+lit(windows_id));sql('DELETE FROM '+database+'.ogp_identity WHERE BINARY id='+lit(windows_id));company(1,sa)
 check('wrong_beneficiary_denied',authenticate('a',a,grant(2,999,a,[10]))[0]==401)
 check('wrong_device_denied',authenticate('a',a,grant(2,101,b,[10]))[0]==401)
 check('private_key_possession_required',authenticate('a',other,ga)[0]==401)
 check('expired_client_denied',authenticate('a',a,grant(2,101,a,[10],exp=now-1))[0]==401)
 check('wrong_software_denied',authenticate('a',a,grant(2,101,a,[10],software_id=391))[0]==401)
 check('wrong_issuer_denied',authenticate('a',a,grant(2,101,a,[10],iss='https://other.invalid'))[0]==401)
 malformed=json.loads(ga);malformed['token']=malformed['token'][:-1]+'!'
 check('tampered_client_signature_denied',authenticate('a',a,json.dumps(malformed))[0]==401)
 row=audit('a');check('tampered_licence_not_marked_verified',not row['licenseSignatureVerified'] and row['licenseId']==2 and not row['success'])
 sentinel='MUST_NOT_APPEAR_IN_AUTH_AUDIT';code,_=call('/auth/attempt',{'identityId':'local-refusal','computerName':'SELFTEST-LOCAL','userName':'SELFTEST-USER','licenseId':999,'password':sentinel,'accessToken':sentinel,'privateKey':sentinel,'ip':'203.0.113.99'})
 row=audit('local-refusal');check('local_refusal_recorded_without_session',code==202 and row['phase']=='client' and not row['success'] and row['licenseId']==999 and row['serverLicenseId']==2 and row['licenseMismatch'])
 check('body_ip_not_trusted',row['ip']=='127.0.0.1');check('sensitive_fields_not_journaled',sentinel not in sql('SELECT details FROM '+database+".ogp_audit_event WHERE actor_id='local-refusal' ORDER BY id DESC LIMIT 1"))
 code,_=call('/auth/attempt',{'IdentityId':'case-fixture','ComputerName':'CASE-PC','UserName':'CASE-USER','LicenseId':876});row=audit('case-fixture');check('audit_json_field_case_matches_api_binding',code==202 and row['computerName']=='CASE-PC' and row['licenseId']==876)
 code,_=call('/AUTH/ATTEMPT/',{'identityId':'route-case-fixture','computerName':'CASE-PC','licenseId':876});check('audit_route_case_and_trailing_slash',code==202 and audit('route-case-fixture')['licenseId']==876)
 try:urllib.request.urlopen(urllib.request.Request('http://127.0.0.1:5089/auth/v3/challenge',data=b'{"identityId":',headers={'Content-Type':'application/json'}),timeout=10);bad_status=200
 except urllib.error.HTTPError as e:bad_status=e.code
 check('malformed_request_still_audited',bad_status==400 and audit('ANONYMOUS')['reason']=='malformed_request')
 stamp=sql('SELECT DATE_FORMAT(happened_utc,\'%Y-%m-%dT%H:%i:%sZ\') FROM '+database+".ogp_audit_event WHERE actor_id='local-refusal' ORDER BY id DESC LIMIT 1")
 check('audit_timestamp_utc',abs(datetime.datetime.fromisoformat(stamp.replace('Z','+00:00')).timestamp()-time.time())<15)
 bad=json.loads(ga);parts=bad['token'].split('.');bad['token']=parts[0]+'.'+parts[1]+'.'+b64(sign(other[0],(parts[0]+'.'+parts[1]).encode()))
 check('untrusted_signing_key_denied',authenticate('a',a,json.dumps(bad))[0]==401)
 code,challenge=call('/auth/v3/challenge',{'provider':'ogipen','login':'a','identityId':'a','deviceIdentityId':'a'});challenge=json.loads(challenge)
 form={'provider':'ogipen','login':'a','identityId':'a','deviceIdentityId':'a','password':password,'nonce':challenge['nonce'],'deviceSignature':p1363(sign(a[0],challenge['signingText'].encode())),'licenseJson':ga}
 check('challenge_first_use_succeeds',call('/auth/v3/complete',form)[0]==200)
 check('challenge_replay_denied',call('/auth/v3/complete',form)[0]==401)
 _,audience_challenge=call('/auth/v3/challenge',{'provider':'ogipen','login':'a','identityId':'a','deviceIdentityId':'a'});audience_challenge=json.loads(audience_challenge)
 for label,text in [('v1','OGIPEN-AUTH-v1:a:'+audience_challenge['nonce']),('foreign-audience','OGIPEN-AUTH-v2:https://other.invalid/:a:'+audience_challenge['nonce'])]:
  denied_form={'provider':'ogipen','login':'a','deviceIdentityId':'a','password':password,'identityId':'a','nonce':audience_challenge['nonce'],'deviceSignature':p1363(sign(a[0],text.encode())),'licenseJson':ga}
  check('server_rejects_'+label,call('/auth/v3/complete',denied_form)[0]==401)
 payload=base64.b64encode(('a|1|'+str(now+600)+'|'+'0'*32).encode()).decode();oldtoken=payload+'.'+base64.b64encode(hmac.new(base64.b64decode(env['OGIPEN_SESSION_KEY']),payload.encode(),hashlib.sha256).digest()).decode()
 check('legacy_unbound_session_refused',call('/api/cables/425',token=oldtoken)[0]==401)
 code,short=authenticate('a',a,grant(2,101,a,[10],exp=int(time.time())+20));check('session_expiry_capped_by_client_licence',code==200 and int(base64.b64decode(short.split('.')[0]).decode().split('|')[3])<=int(time.time())+20)
 _,limited=authenticate('a',a,grant(2,101,a,[]));check('client_module_subset_enforced',call('/api/modules/10/access',token=limited)[0]==403)
 check('reader_cannot_edit',call('/api/locks/cable/425',{},ta,'POST')[0]==403)
 code,lease=call('/api/locks/cable/425',{},tb,'POST');check('editor_can_acquire_lease',code==200)
 code,_=call('/api/locks/cable/425',{'token':json.loads(lease)['token']},tb,'DELETE');check('editor_can_release_lease',code==204)
 check('events_authorized',call('/api/events?after=0',token=ta)[0]==200)
 check('authentication_audit_not_in_business_feed',all(e['entityType']!='authentication' for e in json.loads(call('/api/events?after=0',token=ta)[1])))
 ha=hub(ta);hb=hub(tb);check('both_company_hubs_connected',True)
 company(1,server(2,[10],subject_id='other-server'));check('wrong_server_binding_revokes_a',call('/api/cables/425',token=ta)[0]==401)
 check('other_company_survives_a_failure',call('/api/cables/425',token=tb)[0]==200)
 time.sleep(3)
 try:op,data=frame(ha);closed=op==8 or b'"type":7' in data
 except (EOFError,ConnectionError):closed=True
 check('invalid_company_hub_aborted',closed)
 send(hb,'{"type":1,"invocationId":"probe","target":"Unsupported","arguments":[]}\x1e');op,data=frame(hb);check('other_company_hub_remains_live',op==1 and b'probe' in data)
 company(1,sa)
 sql('INSERT INTO '+database+".ogp_identity(id,display_name,public_key_pem,enabled,company_id) VALUES('extra','extra',"+lit(other[1].read_text())+',1,1)')
 check('a_quota_overrun_denied',call('/api/cables/425',token=ta)[0]==401)
 check('b_quota_not_pooled',call('/api/cables/425',token=tb)[0]==200)
 sql('DELETE FROM '+database+".ogp_identity WHERE id='extra'")
 company(1,server(2,[10],expires_utc='2000-01-01T00:00:00Z'));check('expired_server_revokes_session',call('/api/cables/425',token=ta)[0]==401);company(1,sa)
 company(1,state='archived');check('archived_company_denied',call('/api/cables/425',token=ta)[0]==401);company(1,state='prepared')
 sql('UPDATE '+database+".ogp_identity SET auth_version=auth_version+1 WHERE id='a'");check('identity_revision_revokes_session',call('/api/cables/425',token=ta)[0]==401)
 check('b_still_accessible_after_a_revocation',call('/api/cables/425',token=tb)[0]==200)
 sql('UPDATE '+database+".ogp_collaboration_config SET effective_mode='single'");check('single_mode_blocks_two_licensed_companies',call('/api/cables/425',token=tb)[0]==401)
 php_env=env.copy();php_env['TEST_DB_USER']=cfg.get('login','root');php_env['TEST_DB_PASSWORD']=cfg.get('pass','')
 php_env['TEST_BAD_MODULE_GRANT']=server(2,[-1])
 php=subprocess.run(['php','/root/ogipen-v0416/tests/test-accounts.php'],env=php_env,capture_output=True,text=True)
 if php.returncode:print(php.stdout);print(php.stderr);raise RuntimeError('Portal service tests failed')
 check('portal_service_suite_passed',True)
finally:
 for s in sockets:s.close()
 if process is not None:
  process.terminate()
  try:process.wait(timeout=10)
  except subprocess.TimeoutExpired:process.kill();process.wait()
 if created:sql('DROP DATABASE '+database)
 client.unlink(missing_ok=True)
 (root/'client-fixture.oglic').unlink(missing_ok=True)
 (root/'initial-server.oglic').unlink(missing_ok=True)
 for name in ['issuer','a','b','other']:
  for suffix in ['.pem','.pub']:(root/(name+suffix)).unlink(missing_ok=True)
 (root/'results-api.json').write_text(json.dumps(results,indent=2));print(json.dumps(results,indent=2))
