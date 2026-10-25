import urllib.request,urllib.error,urllib.parse,http.cookiejar,re,pathlib,json
os_results=[]
def check(name,ok):
 os_results.append({'test':name,'pass':bool(ok)})
 if not ok:raise AssertionError(name)
def get(web,url,data=None):
 try:
  with web.open(url,urllib.parse.urlencode(data).encode() if data is not None else None,timeout=10) as r:return r.status,r.read().decode(),r.url
 except urllib.error.HTTPError as e:return e.code,e.read().decode(),e.url
base='http://192.168.2.216:8080';web=urllib.request.build_opener(urllib.request.HTTPCookieProcessor(http.cookiejar.CookieJar()))
try:
 _,body,where=get(web,base+'/?page=accounts');check('accounts_require_portal_admin',where.endswith('/login.php'))
 csrf=re.search(r'name="csrf" value="([^"]+)"',body).group(1)
 password=re.search(r'Mot de passe: (.+)',pathlib.Path('/root/ogipen-admin-access.txt').read_text()).group(1)
 status,body,_=get(web,base+'/login.php',{'csrf':csrf,'password':password});check('portal_admin_login',status==200 and 'Administration connectée' in body)
 status,body,_=get(web,base+'/?page=accounts');check('accounts_page_integrated',status==200 and '<aside>' in body and 'Comptes internes Ogipen' in body)
 check('admin_and_ossi_seeded_without_password','admin' in body and 'ossi' in body and 'Mot de passe à définir' in body)
 check('password_field_never_prefilled',len(re.findall(r'type="password"[^>]*value=""',body))==3)
 check('password_not_echoed',password not in body)
 status,refused,_=get(web,base+'/?page=accounts',{'action':'account_save','csrf':'invalid','login':'must-not-create','new_password':'CSRF_SECRET_SENTINEL'})
 check('account_post_csrf_enforced','Modification annulée' in refused)
 check('password_not_echoed_on_error','CSRF_SECRET_SENTINEL' not in refused)
 for p in ['identities','companies','license','events','settings']:
  status,body,_=get(web,base+'/?page='+p);check('portal_regression_'+p,status==200 and '<main>' in body)
 for helper in ['account-service.php','account-view.php','account-controller.php']:
  check('private_'+helper,get(web,base+'/'+helper)[0]==404)
finally:
 pathlib.Path('/root/ogipen-v0413/tests/results-live-portal.json').write_text(json.dumps(os_results,indent=2));print(json.dumps(os_results,indent=2))
