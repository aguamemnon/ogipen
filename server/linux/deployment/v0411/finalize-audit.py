import pathlib,subprocess,stat,os,time,json,urllib.request
root=pathlib.Path('/root/ogipen-v0411')
subprocess.run(['tar','-czf',str(root/'before-final-refinement.tgz'),'-C','/','opt/ogipen/api','opt/ogipen/admin'],check=True,capture_output=True)
def replace(path,data):
 s=path.stat();tmp=path.with_name(path.name+'.final-tmp');tmp.write_bytes(data);os.chmod(tmp,stat.S_IMODE(s.st_mode));os.chown(tmp,s.st_uid,s.st_gid);os.replace(tmp,path)
try:
 for f in (root/'publish').glob('*.dll'):replace(pathlib.Path('/opt/ogipen/api')/f.name,f.read_bytes())
 replace(pathlib.Path('/opt/ogipen/admin/auth-event-view.php'),(root/'admin/auth-event-view.php').read_bytes())
 subprocess.run(['systemctl','restart','ogipen-api','ogipen-admin'],check=True,capture_output=True)
 for _ in range(40):
  try:
   with urllib.request.urlopen('http://127.0.0.1:5088/health',timeout=2) as r:state=json.load(r)
   if state.get('version')=='0.4.11-test':break
  except (OSError,ValueError):pass
  time.sleep(.25)
 else:raise RuntimeError('Health failed')
 print('AUDIT_FINAL_FILES_INSTALLED')
except Exception:
 subprocess.run(['systemctl','stop','ogipen-api','ogipen-admin'],capture_output=True);subprocess.run(['tar','-xzf',str(root/'before-final-refinement.tgz'),'-C','/'],check=True,capture_output=True);subprocess.run(['systemctl','restart','ogipen-api','ogipen-admin'],capture_output=True)
 raise SystemExit('Final update failed; previous audit version restored')
