import pathlib,stat,grp,os,subprocess,time,json,urllib.request
root=pathlib.Path('/root/ogipen-v0411');site=pathlib.Path('/etc/nginx/sites-available/ogipen');css=pathlib.Path('/opt/ogipen/public/style.css')
before=site.read_bytes();old_css=css.read_bytes();(root/'style-before.css').write_bytes(old_css)
def replace(path,data,group='ogipen-admin',mode=0o640):
 if path.exists():s=path.stat();uid,gid,mode=s.st_uid,s.st_gid,stat.S_IMODE(s.st_mode)
 else:uid,gid=0,grp.getgrnam(group).gr_gid
 temp=path.with_name(path.name+'.v0411-tmp');temp.write_bytes(data);os.chmod(temp,mode);os.chown(temp,uid,gid);os.replace(temp,path)
def run(args):
 p=subprocess.run(args,capture_output=True)
 if p.returncode:raise RuntimeError('Deployment command failed')
if before.strip()!=(root/'nginx-before.conf').read_bytes().strip():raise SystemExit('Nginx changed; stop for review')
try:
 replace(site,(root/'nginx-ogipen.conf').read_bytes());run(['nginx','-t'])
 for f in (root/'publish').iterdir():
  if f.suffix in ['.dll','.json']:replace(pathlib.Path('/opt/ogipen/api')/f.name,f.read_bytes(),'ogipen-api')
 for name in ['lib.php','login.php','auth-event-view.php','index.php','portal-header.php','style.css']:replace(pathlib.Path('/opt/ogipen/admin')/name,(root/'admin'/name).read_bytes())
 replace(css,(root/'admin/style.css').read_bytes())
 run(['systemctl','restart','ogipen-api','ogipen-admin'])
 for _ in range(40):
  try:
   with urllib.request.urlopen('http://127.0.0.1:5088/health',timeout=2) as r:d=json.load(r)
   if d.get('version')=='0.4.11-test':break
  except (OSError,ValueError):pass
  time.sleep(.25)
 else:raise RuntimeError('API health failed')
 run(['systemctl','reload','nginx']);print('AUTHENTICATION_AUDIT_DEPLOYED')
except Exception:
 subprocess.run(['systemctl','stop','ogipen-api','ogipen-admin'],capture_output=True)
 subprocess.run(['tar','-xzf',str(root/'before.tgz'),'-C','/'],check=True,capture_output=True)
 replace(css,old_css);subprocess.run(['systemctl','restart','ogipen-api','ogipen-admin'],capture_output=True);subprocess.run(['systemctl','reload','nginx'],capture_output=True)
 raise SystemExit('Audit deployment failed; previous files restored')
