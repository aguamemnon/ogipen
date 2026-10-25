import pathlib,subprocess,os,shutil,hashlib,json,time,urllib.request
os.umask(0o077);r=pathlib.Path('/root/ogipen-v0416')
def run(args):return subprocess.run(args,check=True,text=True,capture_output=True).stdout.strip()
cfg=dict(l.split('=',1) for l in pathlib.Path('/etc/webmin/mysql/config').read_text().splitlines() if '=' in l)
def quote(s):return '"'+s.replace('\\','\\\\').replace('"','\\"')+'"'
cnf=r/'db.cnf';cnf.write_text('[client]\nuser='+quote(cfg.get('login','root'))+'\npassword='+quote(cfg.get('pass',''))+'\n')
def sql(q):
 p=subprocess.run(['mysql','--defaults-extra-file='+str(cnf),'-N','-B','--raw','ogp_test_001'],input=q,text=True,capture_output=True)
 if p.returncode:(r/'sql-error.log').write_text(p.stderr);raise RuntimeError('SQL failed; protected diagnostic saved')
 return p.stdout.strip()
def snapshot(role):return sql("SELECT i.id,i.auth_version,i.enabled,"+role+",COALESCE(i.company_id,0),COALESCE(i.public_key_sha256,''),COALESCE(p.can_read,0),COALESCE(p.can_edit,0),COALESCE(a.password_hash,'') FROM ogp_identity i LEFT JOIN ogp_app_account a ON a.identity_id=i.id LEFT JOIN ogp_permission p ON p.identity_id=i.id ORDER BY i.id")
changed=['identity-service.php','identity-controller.php','identity-view.php','account-service.php','account-controller.php','technical-role-service.php','portal-header.php','index.php']
pid=run(['systemctl','show','mysql','-p','MainPID','--value'])
try:
 if sql("SELECT COUNT(*) FROM information_schema.columns WHERE table_schema='ogp_test_001' AND table_name='ogp_identity' AND column_name='system_role'")!='0':raise RuntimeError('Role migration already exists; inspect previous run')
 for name in changed:run(['php','-l',str(r/'admin'/name)])
 backup=r/'before-project.sql'
 if backup.exists():raise RuntimeError('Backup exists; inspect previous run')
 with backup.open('wb') as f:subprocess.run(['mysqldump','--defaults-extra-file='+str(cnf),'--single-transaction','--no-tablespaces','--set-gtid-purged=OFF','ogp_test_001'],stdout=f,stderr=subprocess.PIPE,check=True)
 shutil.copytree('/opt/ogipen/api',r/'api-before-final');shutil.copytree('/opt/ogipen/admin',r/'admin-before-final');shutil.copy2('/opt/ogipen/public/style.css',r/'style-before.css')
 try:
  run(['systemctl','stop','ogipen-api','ogipen-admin'])
  before=snapshot("COALESCE(a.system_role,'user')")
  sql((r/'schema-role.sql').read_text())
  sql("GRANT SELECT (identity_id) ON ogp_test_001.ogp_auth_session TO 'ogp_admin_php'@'localhost'")
  if before!=snapshot('i.system_role'):raise RuntimeError('Migration changed an existing role, password, key or project right')
  for p in (r/'publish').iterdir():
   if p.is_file():
    d=pathlib.Path('/opt/ogipen/api')/p.name;shutil.copy2(p,d);shutil.chown(d,user='root',group='ogipen-api');d.chmod(0o640)
  for name in changed:
   d=pathlib.Path('/opt/ogipen/admin')/name;shutil.copy2(r/'admin'/name,d);shutil.chown(d,user='root',group='ogipen-admin');d.chmod(0o640)
  shutil.copy2(r/'admin/style.css','/opt/ogipen/public/style.css');os.chmod('/opt/ogipen/public/style.css',0o644)
  run(['systemctl','start','ogipen-api','ogipen-admin'])
  healthy=False
  for _ in range(25):
   try:
    with urllib.request.urlopen('http://127.0.0.1:5088/health',timeout=2) as response:healthy=json.load(response).get('version')=='0.4.16-test'
    if healthy:break
   except (OSError,ValueError):pass
   time.sleep(.2)
  if not healthy:raise RuntimeError('API health check failed')
 except:
  run(['systemctl','stop','ogipen-api','ogipen-admin']);shutil.copytree(r/'api-before-final','/opt/ogipen/api',dirs_exist_ok=True);shutil.copytree(r/'admin-before-final','/opt/ogipen/admin',dirs_exist_ok=True);shutil.copy2(r/'style-before.css','/opt/ogipen/public/style.css');run(['systemctl','start','ogipen-api','ogipen-admin']);raise
 assert pid==run(['systemctl','show','mysql','-p','MainPID','--value'])
 print(json.dumps({'version':'0.4.16','existing_roles_passwords_keys_project_rights_preserved':True,'mysql_pid_unchanged':pid,'api_sha256':hashlib.sha256(pathlib.Path('/opt/ogipen/api/Ogipen.Api.dll').read_bytes()).hexdigest(),'changed_portal_files':changed}))
finally:cnf.unlink(missing_ok=True)
