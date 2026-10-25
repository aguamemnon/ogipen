import pathlib,os,subprocess,shutil,json,time,urllib.request,hashlib
os.umask(0o077);r=pathlib.Path('/root/ogipen-v0415')
def run(args):return subprocess.run(args,check=True,capture_output=True,text=True).stdout.strip()
cfg=dict(l.split('=',1) for l in pathlib.Path('/etc/webmin/mysql/config').read_text().splitlines() if '=' in l)
def quote(s):return '"'+s.replace('\\','\\\\').replace('"','\\"')+'"'
cnf=r/'db.cnf';cnf.write_text('[client]\nuser='+quote(cfg.get('login','root'))+'\npassword='+quote(cfg.get('pass',''))+'\n')
try:
 backup=r/'before-project.sql'
 if backup.exists():raise RuntimeError('Backup already exists; inspect previous deployment first')
 with backup.open('wb') as f:subprocess.run(['mysqldump','--defaults-extra-file='+str(cnf),'--single-transaction','--no-tablespaces','--set-gtid-purged=OFF','ogp_test_001'],stdout=f,stderr=subprocess.PIPE,check=True)
finally:cnf.unlink(missing_ok=True)
pid=run(['systemctl','show','mysql','-p','MainPID','--value'])
old=pathlib.Path('/opt/ogipen/api');shutil.copytree(old,r/'api-before-final')
try:
 run(['systemctl','stop','ogipen-api'])
 for p in (r/'publish').iterdir():
  if p.is_file():
   d=old/p.name;shutil.copy2(p,d);shutil.chown(d,user='root',group='ogipen-api');d.chmod(0o640)
 run(['systemctl','start','ogipen-api'])
 healthy=False
 for _ in range(25):
  try:
   with urllib.request.urlopen('http://127.0.0.1:5088/health',timeout=2) as response:healthy=json.load(response).get('version')=='0.4.15-test'
   if healthy:break
  except (OSError,ValueError):pass
  time.sleep(.2)
 if not healthy:raise RuntimeError('API health check failed')
except:
 run(['systemctl','stop','ogipen-api']);shutil.copytree(r/'api-before-final',old,dirs_exist_ok=True);run(['systemctl','start','ogipen-api']);raise
assert pid==run(['systemctl','show','mysql','-p','MainPID','--value'])
print(json.dumps({'deployed':'0.4.15','api_sha256':hashlib.sha256((old/'Ogipen.Api.dll').read_bytes()).hexdigest(),'mysql_pid_unchanged':pid,'schema_changed':False,'customer_accounts_changed':False}))
