import pathlib,os,subprocess,json,base64,hashlib,hmac,datetime,time,urllib.request,urllib.error,socket,struct
os.umask(0o077)
root=pathlib.Path('/root/ogipen-v0411/tests');results=[];process=None;created=False;sockets=[]
cfg=dict(l.split('=',1) for l in pathlib.Path('/etc/webmin/mysql/config').read_text().splitlines() if '=' in l)
def quote(s):return '"'+s.replace('\\','\\\\').replace('"','\\"').replace('\n','\\n')+'"'
client=root/'test-db.cnf';client.write_text('[client]\nuser='+quote(cfg.get('login','root'))+'\npassword='+quote(cfg.get('pass',''))+'\n')
database='ogp_v0411_selftest'
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
 number=None
 try:
  part=json.loads(licence)['token'].split('.')[1];number=json.loads(base64.urlsafe_b64decode(part+'='*((4-len(part)%4)%4)))['lic']
 except (TypeError,ValueError,KeyError):pass
 metadata={'computerName':'SELFTEST-PC-'+identity,'userName':'SELFTEST\\'+identity,'licenseId':number}
 code,body=call('/auth/challenge',{'identityId':identity,**metadata})
 if code!=200:return code,None
 challenge=json.loads(body);form={'identityId':identity,'nonce':challenge['nonce'],'signature':p1363(sign(device[0],challenge['signingText'].encode())),**metadata}
 if licence is not None:form['licenseJson']=licence
 code,body=call('/auth/complete',form);return code,json.loads(body).get('accessToken') if code==200 else None
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
 authority=key('issuer');a=key('a');b=key('b');other=key('other')
 sa=server(2,[10]);sb=server(8,[20]);ga=grant(2,101,a,[10]);gb=grant(8,202,b,[20])
 (root/'initial-server.oglic').write_text(sa)
 sql("INSERT INTO "+database+".ogp_collaboration_config(id,requested_mode,effective_mode) VALUES(1,'multi','multi')")
 for id,lic,blob in [(1,2,sa),(2,8,sb)]:sql('INSERT INTO '+database+'.ogp_project_company(id,company_code,display_name,slm_license_id,server_license_json) VALUES('+str(id)+','+lit('company-'+str(id))+','+lit('Company '+str(id))+','+str(lic)+','+lit(blob)+')')
 for name,device,company_id,benef in [('a',a,1,101),('b',b,2,202)]:
  sql('INSERT INTO '+database+'.ogp_identity(id,display_name,public_key_pem,public_key_sha256,enabled,company_id,license_beneficiary_id) VALUES('+lit(name)+','+lit(name)+','+lit(device[1].read_text())+','+lit(hashlib.sha256(device[2]).hexdigest())+',1,'+str(company_id)+','+str(benef)+')')
  sql('INSERT INTO '+database+'.ogp_permission(identity_id,can_read,can_edit) VALUES('+lit(name)+',1,'+('1' if name=='b' else '0')+')')
 sql('INSERT INTO '+database+".ogp_demo_cable(id,reference) VALUES(425,'ISOLATED-425')")
 env=os.environ.copy();env.update({'OGIPEN_DB_CONNECTION':'Server=localhost;Database='+database+';User ID='+cfg.get('login','root')+';Password="'+cfg.get('pass','').replace('"','""')+'"','OGIPEN_SESSION_KEY':base64.b64encode(os.urandom(32)).decode(),'OGIPEN_LICENSE_PUBLIC_KEY':str(authority[1]),'OGIPEN_SERVER_ID':'isolated-v048','OGIPEN_SOFTWARE_ID':'405','OGIPEN_LICENSE_ISSUER':issuer+'/','OGIPEN_AUTH_AUDIENCE':'https://isolated-ogipen-test.invalid/client-api/','ASPNETCORE_URLS':'http://127.0.0.1:5089','DOTNET_ENVIRONMENT':'Production'})
 env['OGIPEN_LICENSE_PATH']=str(root/'initial-server.oglic')
 log=open(root/'api-test.log','w');process=subprocess.Popen(['dotnet','/root/ogipen-v0411/publish/Ogipen.Api.dll'],env=env,stdout=log,stderr=log)
 for _ in range(50):
  try:
   if call('/health')[0]==200:break
  except OSError:pass
  if process.poll() is not None:raise RuntimeError('Isolated API startup failed; inspect protected log')
  time.sleep(.2)
 check('anonymous_api_denied',call('/cables/425')[0]==404 and call('/api/cables/425')[0]==401)
 check('missing_client_licence_denied',authenticate('a',a,None)[0]==401)
 check('company_a_authenticated',authenticate('a',a,ga)[0]==200);_,ta=authenticate('a',a,ga)
 row=audit('a');check('success_audit_computer_user_ip',row['computerName']=='SELFTEST-PC-a' and row['userName']=='SELFTEST\\a' and row['ip']=='127.0.0.1' and row['success'])
 check('success_audit_verified_licence',row['licenseId']==2 and row['serverLicenseId']==2 and row['licenseSignatureVerified'] and row['identityProofVerified'])
 check('company_b_same_project_authenticated',authenticate('b',b,gb)[0]==200);_,tb=authenticate('b',b,gb)
 (root/'client-fixture.oglic').write_text(ga)
 client_env=env.copy();client_env.update({'OGIPEN_CHECK_KEY':str(a[0]),'OGIPEN_CHECK_LICENSE':str(root/'client-fixture.oglic'),'OGIPEN_CHECK_ISSUER_KEY':str(authority[1]),'OGIPEN_CHECK_ISSUER':issuer})
 live=subprocess.run(['dotnet','/root/ogipen-v0411/client/tests/OGIPEN.LicensedSession.Checks/bin/Release/net10.0/OGIPEN.LicensedSession.Checks.dll','--integration'],env=client_env,text=True,capture_output=True)
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
 try:urllib.request.urlopen(urllib.request.Request('http://127.0.0.1:5089/auth/challenge',data=b'{"identityId":',headers={'Content-Type':'application/json'}),timeout=10);bad_status=200
 except urllib.error.HTTPError as e:bad_status=e.code
 check('malformed_request_still_audited',bad_status==400 and audit('ANONYMOUS')['reason']=='malformed_request')
 stamp=sql('SELECT DATE_FORMAT(happened_utc,\'%Y-%m-%dT%H:%i:%sZ\') FROM '+database+".ogp_audit_event WHERE actor_id='local-refusal' ORDER BY id DESC LIMIT 1")
 check('audit_timestamp_utc',abs(datetime.datetime.fromisoformat(stamp.replace('Z','+00:00')).timestamp()-time.time())<15)
 bad=json.loads(ga);parts=bad['token'].split('.');bad['token']=parts[0]+'.'+parts[1]+'.'+b64(sign(other[0],(parts[0]+'.'+parts[1]).encode()))
 check('untrusted_signing_key_denied',authenticate('a',a,json.dumps(bad))[0]==401)
 code,challenge=call('/auth/challenge',{'identityId':'a'});challenge=json.loads(challenge)
 form={'identityId':'a','nonce':challenge['nonce'],'signature':p1363(sign(a[0],challenge['signingText'].encode())),'licenseJson':ga}
 check('challenge_first_use_succeeds',call('/auth/complete',form)[0]==200)
 check('challenge_replay_denied',call('/auth/complete',form)[0]==401)
 _,audience_challenge=call('/auth/challenge',{'identityId':'a'});audience_challenge=json.loads(audience_challenge)
 for label,text in [('v1','OGIPEN-AUTH-v1:a:'+audience_challenge['nonce']),('foreign-audience','OGIPEN-AUTH-v2:https://other.invalid/:a:'+audience_challenge['nonce'])]:
  denied_form={'identityId':'a','nonce':audience_challenge['nonce'],'signature':p1363(sign(a[0],text.encode())),'licenseJson':ga}
  check('server_rejects_'+label,call('/auth/complete',denied_form)[0]==401)
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
 php=subprocess.run(['php','/root/ogipen-v0411/tests/test-portal-services.php'],env=php_env,capture_output=True,text=True)
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
