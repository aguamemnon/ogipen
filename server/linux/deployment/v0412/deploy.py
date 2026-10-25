import pathlib,subprocess,shutil,os,json,hashlib
os.umask(0o077);r=pathlib.Path('/root/ogipen-v0412')
def run(args):return subprocess.run(args,check=True,capture_output=True,text=True).stdout.strip()
pid=run(['systemctl','show','mysql','-p','MainPID','--value'])
for p in (r/'admin').glob('*.php'):run(['php','-l',str(p)])
run(['nginx','-t'])
cfg=dict(l.split('=',1) for l in pathlib.Path('/etc/webmin/mysql/config').read_text().splitlines() if '=' in l)
def quote(s):return '"'+s.replace('\\','\\\\').replace('"','\\"')+'"'
cnf=r/'backup-db.cnf';cnf.write_text('[client]\nuser='+quote(cfg.get('login','root'))+'\npassword='+quote(cfg.get('pass',''))+'\n')
try:
 with (r/'before-project.sql').open('wb') as f:
  subprocess.run(['mysqldump','--defaults-extra-file='+str(cnf),'--single-transaction','--no-tablespaces','--set-gtid-purged=OFF','ogp_test_001'],check=True,stdout=f,stderr=subprocess.PIPE)
finally:cnf.unlink(missing_ok=True)
changed=['index.php','portal-header.php','identity-service.php','identity-view.php','company-runtime-view.php']
try:
 run(['systemctl','stop','ogipen-api'])
 for p in (r/'publish').iterdir():
  if p.is_file():
   dest=pathlib.Path('/opt/ogipen/api')/p.name;shutil.copy2(p,dest);shutil.chown(dest,user='root',group='ogipen-api');dest.chmod(0o640)
 for name in changed:
  dest=pathlib.Path('/opt/ogipen/admin')/name;shutil.copy2(r/'admin'/name,dest);shutil.chown(dest,user='root',group='ogipen-admin');dest.chmod(0o640)
 run(['systemctl','start','ogipen-api']);run(['systemctl','restart','ogipen-admin'])
except Exception:
 run(['tar','xzf',str(r/'before.tgz'),'-C','/','opt/ogipen/api','opt/ogipen/admin']);run(['systemctl','restart','ogipen-api']);run(['systemctl','restart','ogipen-admin']);raise
assert pid==run(['systemctl','show','mysql','-p','MainPID','--value'])
print(json.dumps({'mysql_pid_unchanged':pid,'api_sha256':hashlib.sha256(pathlib.Path('/opt/ogipen/api/Ogipen.Api.dll').read_bytes()).hexdigest(),'portal_files':changed}))
