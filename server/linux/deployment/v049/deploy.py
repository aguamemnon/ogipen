import pathlib,os,stat,grp,shutil,subprocess,urllib.request,json,time,hashlib
root=pathlib.Path('/root/ogipen-v049');env_path=pathlib.Path('/etc/ogipen/api.env');nginx=pathlib.Path('/etc/nginx/sites-available/ogipen')
expected=(root/'nginx-before.conf').read_text().strip()
if nginx.read_text().strip()!=expected:raise SystemExit('Nginx changed; deployment stopped for review')
expected_api='b62847547f2ec9fe9420d78c3bfc92d0a60c9305c8b8ef35a26ff9955dc22037'
if hashlib.sha256(pathlib.Path('/opt/ogipen/api/Ogipen.Api.dll').read_bytes()).hexdigest()!=expected_api:raise SystemExit('API changed; deployment stopped for review')
backup=root/'api-env-before';backup.write_bytes(env_path.read_bytes());backup.chmod(0o600)
def replace(path,data):
 info=path.stat();tmp=path.with_name(path.name+'.ogipen-v049-tmp')
 try:
  with open(tmp,'wb') as f:f.write(data)
  os.chmod(tmp,stat.S_IMODE(info.st_mode));os.chown(tmp,info.st_uid,info.st_gid);os.replace(tmp,path)
 finally:tmp.unlink(missing_ok=True)
def run(args):
 p=subprocess.run(args,capture_output=True,text=True)
 if p.returncode:raise RuntimeError('Command failed; protected deployment diagnostics retained')
try:
 lines=[l for l in env_path.read_text().splitlines() if not l.startswith('OGIPEN_AUTH_AUDIENCE=')]
 lines.append('OGIPEN_AUTH_AUDIENCE=https://www.trueshield.fr/ogipen/client-api/')
 replace(env_path,('\n'.join(lines)+'\n').encode())
 replace(nginx,(root/'nginx-ogipen.conf').read_bytes());run(['nginx','-t'])
 for source in (root/'publish').iterdir():
  if source.suffix not in ['.dll','.json']:continue
  destination=pathlib.Path('/opt/ogipen/api')/source.name
  replace(destination,source.read_bytes())
 run(['systemctl','restart','ogipen-api'])
 for attempt in range(40):
  try:
   with urllib.request.urlopen('http://127.0.0.1:5088/health',timeout=2) as response:state=json.load(response)
   if state.get('version')=='0.4.9-test':break
  except (OSError,ValueError):pass
  time.sleep(.25)
 else:raise RuntimeError('API health check failed')
 run(['systemctl','reload','nginx'])
 print('API_049_DEPLOYED_AND_HTTPS_PATH_RELOADED')
except Exception:
 subprocess.run(['systemctl','stop','ogipen-api'],capture_output=True)
 subprocess.run(['tar','-xzf',str(root/'before.tgz'),'-C','/'],capture_output=True,check=True)
 replace(env_path,backup.read_bytes())
 subprocess.run(['systemctl','restart','ogipen-api'],capture_output=True)
 subprocess.run(['systemctl','reload','nginx'],capture_output=True)
 raise SystemExit('DEPLOYMENT_FAILED_ROLLED_BACK; inspect protected files')
