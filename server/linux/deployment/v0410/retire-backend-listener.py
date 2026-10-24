import pathlib,subprocess,os,stat
p=pathlib.Path('/etc/nginx/sites-available/ogipen');old=p.read_bytes();s=old.decode();start=s.index('server {');level=0;end=None
for i in range(s.index('{',start),len(s)):
 if s[i]=='{':level+=1
 elif s[i]=='}':
  level-=1
  if level==0:end=i+1;break
if end is None or 'listen 192.168.2.216:8443 ssl;' not in s[start:end]:raise SystemExit('Unexpected backend block; no files changed')
backup=pathlib.Path('/root/ogipen-v0410/nginx-before-retiring-8443.conf');backup.write_bytes(old);backup.chmod(0o600)
info=p.stat()
def replace(data):
 t=p.with_name(p.name+'.retire-tmp');t.write_bytes(data);os.chmod(t,stat.S_IMODE(info.st_mode));os.chown(t,info.st_uid,info.st_gid);os.replace(t,p)
try:
 replace((s[:start]+s[end:]).encode());r=subprocess.run(['nginx','-t'],capture_output=True)
 if r.returncode:raise RuntimeError('Nginx syntax failed')
 subprocess.run(['systemctl','reload','nginx'],check=True,capture_output=True);print('LEGACY_8443_LISTENER_RETIRED')
except Exception:
 replace(old);subprocess.run(['systemctl','reload','nginx'],capture_output=True);raise SystemExit('Backend retirement failed; restored')
