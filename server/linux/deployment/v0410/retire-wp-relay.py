import pathlib,re,subprocess,os,stat
root=pathlib.Path('/var/backups/ogipen-retire-relay-v0410');root.mkdir(mode=0o700,exist_ok=False)
p=pathlib.Path('/etc/apache2/ogipen-portal-v042.conf');old=p.read_bytes();(root/'before.conf').write_bytes(old);(root/'before.conf').chmod(0o600)
s=old.decode()
if 'ProxyPass /ogipen/' not in s:raise SystemExit('Unexpected relay state; no configuration changed')
s,n=re.subn(r'<Location "/ogipen/">.*?</Location>','',s,count=1,flags=re.S)
if n!=1:raise SystemExit('Unexpected relay scope; no configuration changed')
s=re.sub(r'^ProxyPass(?:Reverse)? /ogipen/[^\n]*\n','',s,flags=re.M)
s=re.sub(r'^RedirectMatch 302[^\n]*\n','',s,flags=re.M)
s+='\n# Ogipen API and portal belong to each company server. Retire this legacy relay.\nRedirectMatch 410 "^/ogipen(?:/|$)"\n'
info=p.stat()
def replace(data):
 t=p.with_name(p.name+'.v0410-tmp');t.write_bytes(data);os.chmod(t,stat.S_IMODE(info.st_mode));os.chown(t,info.st_uid,info.st_gid);os.replace(t,p)
try:
 replace(s.encode());check=subprocess.run(['apache2ctl','configtest'],capture_output=True)
 if check.returncode:raise RuntimeError('Apache syntax failed')
 subprocess.run(['systemctl','reload','apache2'],check=True,capture_output=True);print('WORDPRESS_OGIPEN_RELAY_RETIRED')
except Exception:
 replace(old);subprocess.run(['systemctl','reload','apache2'],capture_output=True);raise SystemExit('Relay retirement failed; configuration restored')
