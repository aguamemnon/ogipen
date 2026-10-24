import pathlib,subprocess,urllib.request,urllib.error,urllib.parse,http.cookiejar,re,json,base64,socket,struct,os,time
from concurrent.futures import ThreadPoolExecutor
os.umask(0o077)
root=pathlib.Path('/root/ogipen-v045');results=[];prefix=os.environ.get('OGIPEN_TEST_PORTAL_URL','http://127.0.0.1:8080')
ids=['v045-selftest-a','v045-selftest-b','v045-selftest-c'];sockets=[]
def check(name,ok):
    results.append({'test':name,'pass':bool(ok)})
    if not ok:raise AssertionError(name)
def sql(query):
    r=subprocess.run(['mysql','--defaults-extra-file='+str(root/'db-client.cnf'),'-N','-B','ogp_test_001'],input=query,text=True,capture_output=True)
    if r.returncode:raise RuntimeError('Self-test SQL failed')
    return r.stdout.strip()
def request(web,url,data=None,headers=None,method=None):
    try:
        with web.open(urllib.request.Request(url,data=data,headers=headers or {},method=method),timeout=15) as r:return r.status,r.read().decode()
    except urllib.error.HTTPError as e:return e.code,e.read().decode()
web=urllib.request.build_opener(urllib.request.HTTPCookieProcessor(http.cookiejar.CookieJar()))
api=urllib.request.build_opener()
def call(path,data=None,token=None,method=None):
    h={}
    if data is not None:h['Content-Type']='application/json';data=json.dumps(data).encode()
    if token:h['Authorization']='Bearer '+token
    return request(api,'http://127.0.0.1:5088'+path,data,h,method)
def csrf(html):return re.search(r'name="csrf" value="([^"]+)"',html).group(1)
def post(values,path='/?page=identities'):
    _,html=request(web,prefix+path)
    values={'csrf':csrf(html),**values}
    return request(web,prefix+path,urllib.parse.urlencode(values).encode(),{'Content-Type':'application/x-www-form-urlencoded'})
def revision(identity):return sql("SELECT auth_version FROM ogp_identity WHERE id='"+identity+"'")
def toggle(identity,on):return post({'action':'identity_toggle','identity_id':identity,'revision':revision(identity),'enabled':str(on)})
def save(identity,role='reader',pem='',on=1,rev=None):return post({'action':'identity_save','identity_id':identity,'revision':revision(identity) if rev is None else rev,'display_name':'Utilisateur de test','role':role,'public_key':pem,'enabled':str(on)})
def key(name,curve='prime256v1'):
    private=root/(name+'.pem');public=root/(name+'.pub')
    subprocess.run(['openssl','ecparam','-name',curve,'-genkey','-noout','-out',str(private)],check=True)
    subprocess.run(['openssl','pkey','-in',str(private),'-pubout','-out',str(public)],check=True)
    return private,public.read_text()
def signature(private,text):
    d=subprocess.run(['openssl','dgst','-sha256','-sign',str(private)],input=text.encode(),capture_output=True,check=True).stdout
    assert d[0]==48;pos=2;assert d[pos]==2;n=d[pos+1];r=d[pos+2:pos+2+n];pos+=2+n
    assert d[pos]==2;n=d[pos+1];s=d[pos+2:pos+2+n]
    return base64.b64encode(r.lstrip(b'\0').rjust(32,b'\0')+s.lstrip(b'\0').rjust(32,b'\0')).decode()
def authenticate(identity,private):
    c,b=call('/auth/challenge',{'identityId':identity})
    if c!=200:return c,None
    d=json.loads(b);c,b=call('/auth/complete',{'identityId':identity,'nonce':d['nonce'],'signature':signature(private,d['signingText'])})
    return c,json.loads(b).get('accessToken') if c==200 else None
def ws_send(s,data):
    data=data.encode();mask=os.urandom(4);n=len(data)
    header=bytes([0x81,0x80|n]) if n<126 else bytes([0x81,0x80|126])+struct.pack('!H',n)
    s.sendall(header+mask+bytes(v^mask[i%4] for i,v in enumerate(data)))
def exact(s,n):
    data=b''
    while len(data)<n:
        part=s.recv(n-len(data))
        if not part:raise EOFError()
        data+=part
    return data
def ws_frame(s):
    h=exact(s,2);n=h[1]&127
    if n==126:n=struct.unpack('!H',exact(s,2))[0]
    elif n==127:n=struct.unpack('!Q',exact(s,8))[0]
    return h[0]&15,exact(s,n)
def connect_hub(token):
    c,b=call('/hubs/events/negotiate?negotiateVersion=1&access_token='+urllib.parse.quote(token,safe=''),{})
    check('signalr_negotiation',c==200)
    id=json.loads(b)['connectionToken'];s=socket.create_connection(('127.0.0.1',5088),timeout=5)
    path='/hubs/events?id='+urllib.parse.quote(id,safe='')+'&access_token='+urllib.parse.quote(token,safe='')
    k=base64.b64encode(os.urandom(16)).decode()
    s.sendall(('GET '+path+' HTTP/1.1\r\nHost: 127.0.0.1:5088\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Key: '+k+'\r\nSec-WebSocket-Version: 13\r\n\r\n').encode())
    h=b''
    while b'\r\n\r\n' not in h:h+=s.recv(1)
    check('signalr_websocket_upgraded',b'101' in h.split(b'\r\n')[0])
    ws_send(s,'{"protocol":"json","version":1}\x1e');op,body=ws_frame(s)
    check('signalr_protocol_handshake',op==1 and b'{}\x1e' in body)
    sockets.append(s);return s
try:
    check('no_preexisting_test_identities',sql("SELECT COUNT(*) FROM ogp_identity WHERE id IN ('"+"','".join(ids)+"')")=='0')
    check('test_has_one_free_seat',sql('SELECT COUNT(*) FROM ogp_identity WHERE enabled=1')=='0')
    _,html=request(web,prefix+'/login.php')
    password=re.search(r'Mot de passe: (.+)',pathlib.Path('/root/ogipen-admin-access.txt').read_text()).group(1)
    c,html=request(web,prefix+'/login.php',urllib.parse.urlencode({'csrf':csrf(html),'password':password}).encode(),{'Content-Type':'application/x-www-form-urlencoded'})
    check('portal_authenticated',c==200 and 'Administration connectée' in html)
    c,html=request(web,prefix+'/?page=identities')
    check('user_management_integrated',c==200 and 'Ajouter un utilisateur' in html and 'Navigation principale' in html)
    a,puba=key('test-a');b,pubb=key('test-b');rotated,pubrotated=key('test-rotated');wrong,pubwrong=key('test-wrong','secp384r1')
    c,html=post({'action':'identity_create','identity_id':ids[0],'display_name':'<b>Nom de test</b>','public_key':puba,'role':'reader','enabled':'1'})
    check('enroll_reader_from_portal',c==200 and 'Utilisateur ajouté' in html)
    check('display_name_escaped','&lt;b&gt;Nom de test&lt;/b&gt;' in html and '<b>Nom de test</b>' not in html)
    check('key_fingerprint_saved',len(sql("SELECT public_key_sha256 FROM ogp_identity WHERE id='"+ids[0]+"'"))==64)
    c,html=post({'action':'identity_create','identity_id':ids[1],'display_name':'Autre utilisateur','public_key':pubb,'role':'reader','enabled':'1'})
    check('active_enrollment_quota_enforced','Quota atteint' in html)
    c,html=post({'action':'identity_create','identity_id':ids[1],'display_name':'Autre utilisateur','public_key':pubb,'role':'reader','enabled':'0'})
    check('inactive_enrollment_allowed','Utilisateur ajouté' in html)
    check('activation_quota_enforced','Quota atteint' in toggle(ids[1],1)[1])
    c,html=post({'action':'identity_create','identity_id':ids[2],'display_name':'Duplication de clé','public_key':puba,'role':'reader','enabled':'0'})
    check('duplicate_public_key_rejected','clé publique est déjà attribué' in html)
    c,html=post({'action':'identity_create','identity_id':ids[2],'display_name':'Mauvaise courbe','public_key':pubwrong,'role':'reader','enabled':'0'})
    check('non_p256_key_rejected','courbe ECDSA P-256' in html)
    c,html=post({'action':'identity_create','identity_id':ids[2],'display_name':'Clé privée refusée','public_key':a.read_text(),'role':'reader','enabled':'0'})
    check('private_key_rejected_and_not_reflected','Collez uniquement une clé publique' in html and a.read_text() not in html)
    _,html=request(web,prefix+'/?page=identities&edit='+ids[0])
    check('edit_form_displays_revision','name="revision" value="1"' in html and 'readonly' in html)
    check('stale_user_edit_rejected','Rechargez sa fiche' in save(ids[0],rev='9999')[1])
    c,tok=authenticate(ids[0],a);check('reader_cryptographic_auth',c==200)
    check('reader_can_read',call('/api/cables/425',token=tok)[0]==200)
    check('reader_cannot_edit',call('/api/locks/cable/425',{},tok)[0]==403)
    ws=connect_hub(tok)
    check('change_role_in_portal','Utilisateur mis à jour' in save(ids[0],role='editor')[1])
    check('role_change_revokes_http_session',call('/api/cables/425',token=tok)[0]==401)
    start=time.monotonic();closed=False;ws.settimeout(5)
    try:
        while time.monotonic()-start<5:
            op,body=ws_frame(ws)
            if op==8 or (op==1 and b'"type":7' in body):closed=True;break
    except (EOFError,ConnectionResetError):closed=True
    check('role_change_closes_live_signalr_connection',closed)
    c,editor=authenticate(ids[0],a);check('editor_reauthenticates',c==200)
    c,body=call('/api/locks/cable/425',{},editor);check('editor_can_lock',c==200)
    lease=json.loads(body)['token'];check('editor_can_unlock',call('/api/locks/cable/425',{'token':lease},editor,'DELETE')[0]==204)
    check('rotate_key_in_portal','Utilisateur mis à jour' in save(ids[0],role='editor',pem=pubrotated)[1])
    check('key_rotation_revokes_http_session',call('/api/cables/425',token=editor)[0]==401)
    check('old_key_cannot_authenticate',authenticate(ids[0],a)[0]==401)
    c,newtoken=authenticate(ids[0],rotated);check('new_key_authenticates',c==200)
    check('disable_from_portal','Utilisateur mis à jour' in toggle(ids[0],0)[1])
    check('disabled_user_session_revoked',call('/api/cables/425',token=newtoken)[0]==401)
    check('disabled_user_cannot_challenge',call('/auth/challenge',{'identityId':ids[0]})[0]==404)
    check('freed_seat_reassignable','Utilisateur mis à jour' in toggle(ids[1],1)[1])
    check('quota_still_one_active_user',sql('SELECT COUNT(*) FROM ogp_identity WHERE enabled=1')=='1')
    v=revision(ids[1]);_,html=post({'action':'identity_toggle','identity_id':ids[1],'revision':v,'enabled':'0','csrf':'bad'})
    check('csrf_rejection_preserves_identity',revision(ids[1])==v)
    _,html=post({'action':'set_identity','identity_id':ids[1],'enabled':'0'},'/?page=overview')
    check('legacy_action_cannot_bypass_control',revision(ids[1])==v)
    check('administrative_audit_present',int(sql("SELECT COUNT(*) FROM ogp_audit_event WHERE action_code='IDENTITY_UPDATED' AND details LIKE '%v045-selftest%'"))>=4)
finally:
    for s in sockets:s.close()
    values="('"+"','".join(ids)+"')"
    sql('DELETE FROM ogp_edit_lock WHERE owner_id IN '+values+'; DELETE FROM ogp_challenge WHERE identity_id IN '+values+'; DELETE FROM ogp_permission WHERE identity_id IN '+values+'; DELETE FROM ogp_identity WHERE id IN '+values+';')
    for name in ['test-a','test-b','test-rotated','test-wrong']:
        for suffix in ['.pem','.pub']:(root/(name+suffix)).unlink(missing_ok=True)
    (root/'user-test-results.json').write_text(json.dumps(results,indent=2))
    print(json.dumps(results,indent=2))
