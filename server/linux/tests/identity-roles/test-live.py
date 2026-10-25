import urllib.request,urllib.error,urllib.parse,http.cookiejar,pathlib,re,json
results=[]
def check(name,ok):
 results.append({'test':name,'pass':bool(ok)})
 if not ok:raise AssertionError(name)
def get(web,url,data=None):
 try:
  with web.open(url,urllib.parse.urlencode(data).encode() if data is not None else None,timeout=10) as r:return r.status,r.read().decode(),r.url
 except urllib.error.HTTPError as e:return e.code,e.read().decode(),e.url
web=urllib.request.build_opener(urllib.request.HTTPCookieProcessor(http.cookiejar.CookieJar()));base='http://192.168.2.216:8080'
try:
 _,body,where=get(web,base+'/?page=identities');check('users_require_portal_admin',where.endswith('/login.php'))
 csrf=re.search(r'name="csrf" value="([^"]+)"',body).group(1);password=re.search(r'Mot de passe: (.+)',pathlib.Path('/root/ogipen-admin-access.txt').read_text()).group(1)
 status,body,_=get(web,base+'/login.php',{'csrf':csrf,'password':password});check('admin_login',status==200)
 status,body,_=get(web,base+'/?page=identities');check('unified_users_page',status==200 and 'Utilisateurs et rôles' in body)
 check('native_and_internal_accounts_visible','Windows / AD' in body and 'Ogipen : admin' in body and 'Ogipen : ossi' in body)
 check('inline_technical_role_selector',body.count('value="identity_system_role"')>=3 and 'Administrateur logiciel' in body and 'OSSI' in body)
 check('technical_and_project_roles_separate','Rôle technique' in body and 'Droits du projet' in body)
 first=re.search(r'name="identity_id" value="([^"]+)"',body).group(1)
 native=re.search(r'edit=(win-sid[^"&]+)',body).group(1)
 status,edit,_=get(web,base+'/?page=identities&edit='+native);check('native_edit_has_role_and_key',status==200 and 'name="system_role"' in edit and 'id="identity-public-key"' in edit)
 internal=re.search(r'edit=(ogipen%3Aadmin)',body).group(1)
 status,edit,_=get(web,base+'/?page=identities&edit='+internal);check('internal_edit_needs_no_windows_key',status==200 and 'name="system_role"' in edit and 'id="identity-public-key"' not in edit)
 status,refused,_=get(web,base+'/?page=identities',{'csrf':'invalid','action':'identity_system_role','identity_id':'nonexistent-role-selftest','revision':'0','system_role':'admin'});check('invalid_csrf_role_update_refused','Modification refusée' in refused)
 for page in ['accounts','companies','license','events','settings']:
  status,body,_=get(web,base+'/?page='+page);check('regression_'+page,status==200 and '<main>' in body)
 check('technical_helper_not_public',get(web,base+'/technical-role-service.php')[0]==404)
 status,style,_=get(web,base+'/style.css');check('updated_table_style_served',status==200 and '.identity-roles' in style)
finally:
 pathlib.Path('/root/ogipen-v0416/tests/results-live.json').write_text(json.dumps(results,indent=2));print(json.dumps(results,indent=2))
