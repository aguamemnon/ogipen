import urllib.request,urllib.error,urllib.parse,http.cookiejar,re,json,pathlib
results=[]
def check(name,ok):
 results.append({'test':name,'pass':bool(ok)})
 if not ok:raise AssertionError(name)
def request(web,url,data=None):
 try:
  with web.open(url,urllib.parse.urlencode(data).encode() if data is not None else None,timeout=15) as r:return r.status,r.read().decode(),r.url
 except urllib.error.HTTPError as e:return e.code,e.read().decode(),e.url
def token(s):return re.search(r'name="csrf" value="([^"]+)"',s).group(1)
password=re.search(r'Mot de passe: (.+)',pathlib.Path('/root/ogipen-admin-access.txt').read_text()).group(1)
try:
 for prefix,label in [('http://192.168.2.216:8080','direct'),('https://www.trueshield.fr/ogipen','proxy')]:
  web=urllib.request.build_opener(urllib.request.HTTPCookieProcessor(http.cookiejar.CookieJar()))
  check(label+'_authentication_required',request(web,prefix+'/?page=companies')[2].endswith('/login.php'))
  _,body,_=request(web,prefix+'/login.php')
  status,body,_=request(web,prefix+'/login.php',{'csrf':token(body),'password':password})
  check(label+'_login',status==200 and 'Administration connectée' in body)
  status,body,_=request(web,prefix+'/?page=companies')
  check(label+'_integrated_page',status==200 and 'Entreprises et projet partagé' in body and '<aside>' in body and 'aria-current="page"' in body)
  check(label+'_honest_effective_status','Mode effectif : mono-entreprise' in body and 'ne donnent aucun accès' in body)
  check(label+'_empty_real_company_registry','Aucune entreprise déclarée' in body)
  check(label+'_mode_form','Multi-entreprise — préparation' in body and 'Enregistrer le mode souhaité' in body)
  status,rejected,_=request(web,prefix+'/?page=companies',{'action':'collaboration_mode','csrf':'invalid','mode':'multi','revision':'1','reason':'Must not change'})
  check(label+'_csrf_refused','Déclaration refusée' in rejected and 'value="single" selected' in rejected)
  for helper in ['company-service.php','company-controller.php','company-view.php']:
   check(label+'_private_'+helper,request(web,prefix+'/'+helper)[0]==404)
  for page in ['overview','identities','license','settings','locks','events']:
   status,body,_=request(web,prefix+'/?page='+page)
   check(label+'_regression_'+page,status==200 and '<main>' in body and 'page=companies' in body)
  status,body,_=request(web,prefix+'/status.php');state=json.loads(body)
  check(label+'_api_and_database_unchanged',status==200 and state['database'] and state['api']['online'] and state['api']['licensed'])
  _,body,_=request(web,prefix+'/?page=companies')
  request(web,prefix+'/logout.php',{'csrf':token(body)})
finally:
 pathlib.Path('/root/ogipen-v047/tests/results-http.json').write_text(json.dumps(results,indent=2))
 print(json.dumps(results,indent=2))
