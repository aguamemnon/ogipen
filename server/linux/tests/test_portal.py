import os
import urllib.request,urllib.error,urllib.parse,http.cookiejar,re,json,pathlib,hashlib
results=[]
password=re.search(r'Mot de passe: (.+)',pathlib.Path('/root/ogipen-admin-access.txt').read_text()).group(1)
def check(name,ok):
    results.append({'test':name,'pass':bool(ok)})
    if not ok:raise AssertionError(name)
def client():return urllib.request.build_opener(urllib.request.HTTPCookieProcessor(http.cookiejar.CookieJar()))
def request(web,url,data=None,headers=None):
    try:
        with web.open(urllib.request.Request(url,data=data,headers=headers or {}),timeout=15) as r:return r.status,r.read().decode(),r.headers,r.url
    except urllib.error.HTTPError as e:return e.code,e.read().decode(),e.headers,e.url
def form(web,url,values):return request(web,url,urllib.parse.urlencode(values).encode(),{'Content-Type':'application/x-www-form-urlencoded'})
def token(html):return re.search(r'name="csrf" value="([^"]+)"',html).group(1)
try:
    for prefix,label in [(os.environ.get('OGIPEN_TEST_PORTAL_URL','http://127.0.0.1:8080'),'direct_8080'),('https://www.trueshield.fr/ogipen','https_proxy')]:
        web=client()
        code,html,headers,final=request(web,prefix+'/login.php')
        check(label+'_login_page',code==200 and "Portail d'administration" in html)
        cookie=headers.get('Set-Cookie','').lower()
        check(label+'_cookie_policy','httponly' in cookie and 'samesite=strict' in cookie and (('secure' in cookie)==prefix.startswith('https')))
        expected=('/ogipen' if label=='https_proxy' else '')+'/style.css'
        check(label+'_asset_url',('href="'+expected+'"') in html)
        check(label+'_stylesheet',request(web,prefix+'/style.css')[0]==200)
        for helper in ['lib.php','license-verify.php','api.env','.git/config']:
            check(label+'_private_'+helper.replace('/','_'),request(web,prefix+'/'+helper)[0]==404)
        check(label+'_authentication_required',request(web,prefix+'/status.php')[3].endswith('/login.php'))
        code,dashboard,_,final=form(web,prefix+'/login.php',{'csrf':token(html),'password':password})
        check(label+'_authenticated_login',code==200 and 'Administration connectée' in dashboard and 'CAB-00425' in dashboard)
        check(label+'_live_dashboard','État du serveur' in dashboard and 'Connectée' in dashboard and 'v0.4.5' in dashboard)
        code,data,_,_=request(web,prefix+'/status.php');state=json.loads(data)
        check(label+'_database_and_api_status',code==200 and state['database'] and state['api']['online'] and state['api']['licensed'])
        code,data,_,_=request(web,prefix+'/license-status.php')
        check(label+'_wordpress_license_page',code==200 and 'Licence valide' in data and 'ogipen-test-112' in data)
        code,license_html,_,canonical=request(web,prefix+'/?page=license')
        check(label+'_canonical_license',code==200 and canonical.endswith('/?page=license'))
        check(label+'_license_inside_shared_portal','<aside>' in license_html and '<main>' in license_html and 'Navigation principale' in license_html and 'class="standalone"' not in license_html)
        check(label+'_license_active_navigation',bool(re.search(r'class="active"[^>]*aria-current="page"[^>]*href="[^"]*page=license"',license_html)))
        check(label+'_legacy_license_redirect',request(web,prefix+'/license-status.php')[3].endswith('/?page=license'))
        for section in ['overview','events','locks','identities','settings']:
            c,body,_,_=request(web,prefix+'/?page='+section)
            check(label+'_shared_navigation_'+section,c==200 and 'page=license' in body and 'Navigation principale' in body)
        license_path=pathlib.Path('/var/lib/ogipen/licensing/server.oglic')
        original=license_path.read_bytes()
        def upload_license(blob,csrf_value,target):
            boundary='OgipenIntegratedLicenseTest'
            body=('--'+boundary+'\r\nContent-Disposition: form-data; name="csrf"\r\n\r\n'+csrf_value+'\r\n--'+boundary+'\r\nContent-Disposition: form-data; name="license"; filename="server.oglic"\r\nContent-Type: application/json\r\n\r\n').encode()+blob+('\r\n--'+boundary+'--\r\n').encode()
            return request(web,prefix+target,body,{'Content-Type':'multipart/form-data; boundary='+boundary})
        c,body,_,_=upload_license(original,token(license_html),'/?page=license')
        check(label+'_integrated_import',c==200 and 'vérifiée et installée' in body and '<aside>' in body and 'aria-current="page"' in body)
        c,body,_,_=upload_license(b'{"invalid":true}',token(license_html),'/?page=license')
        check(label+'_integrated_import_error',c==200 and 'Import refusé' in body and '<aside>' in body and license_path.read_bytes()==original)
        c,body,_,_=upload_license(original,'invalid-csrf','/?page=license')
        check(label+'_integrated_import_csrf','Import refusé' in body and license_path.read_bytes()==original)
        check(label+'_logout_requires_post',request(web,prefix+'/logout.php')[0]==405)
        check(label+'_logout_csrf',form(web,prefix+'/logout.php',{'csrf':'invalid'})[0]==403)
        code,html,_,final=form(web,prefix+'/logout.php',{'csrf':token(dashboard)})
        check(label+'_logout',code==200 and final.endswith('/login.php'))
        check(label+'_session_ended',request(web,prefix+'/status.php')[3].endswith('/login.php'))
    # A new browser cookie must not bypass the IP-based rate limit.
    prefix=os.environ.get('OGIPEN_TEST_PORTAL_URL','http://127.0.0.1:8080')
    for attempt in range(6):
        web=client();_,html,_,_=request(web,prefix+'/login.php')
        _,answer,_,_=form(web,prefix+'/login.php',{'csrf':token(html),'password':'deliberately-invalid-deployment-test'})
    check('rate_limit_survives_new_cookies','Trop de tentatives' in answer)
    web=client();_,html,_,_=request(web,prefix+'/login.php')
    _,answer,_,_=form(web,prefix+'/login.php',{'csrf':token(html),'password':password})
    check('rate_limit_temporarily_blocks_correct_password','Trop de tentatives' in answer)
finally:
    # Only clear the self-test host's throttle record, never the user's address.
    for address in ['192.168.2.216','127.0.0.1']:
        f=pathlib.Path('/var/lib/ogipen/licensing/.portal-state/rate-limit')/(hashlib.sha256(address.encode()).hexdigest()+'.json')
        f.unlink(missing_ok=True)
    pathlib.Path('/root/ogipen-v045/portal-test-results.json').write_text(json.dumps(results,indent=2))
    print(json.dumps(results,indent=2))
