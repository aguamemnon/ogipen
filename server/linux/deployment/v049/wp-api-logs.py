import pathlib,subprocess,os,stat,datetime
root=pathlib.Path('/var/backups/ogipen-api-v049');root.mkdir(mode=0o700,exist_ok=False)
site=pathlib.Path('/etc/apache2/sites-enabled/trueshield.fr.ssl.conf').resolve();inc=pathlib.Path('/etc/apache2/ogipen-portal-v042.conf')
site_before=site.read_bytes();inc_before=inc.read_bytes()
for name,data in [('ssl-before.conf',site_before),('portal-before.conf',inc_before)]:
 f=root/name;f.write_bytes(data);f.chmod(0o600)
old='        CustomLog ${APACHE_LOG_DIR}/trueshield-access.log combined\n'
if site_before.decode().count(old)!=1:raise SystemExit('Unexpected access log configuration; no files changed')
addition='\n# Ogipen API access logs omit query strings and authentication headers.\nSetEnvIf Request_URI "^/ogipen/client-api/" ogipen_api_request\nCustomLog /var/log/apache2/ogipen-api-access.log "%a %t \\"%m %U %H\\" %>s %b" env=ogipen_api_request\n'
# Apache uses escaped double quotes inside the quoted LogFormat.
addition=addition.replace('\\\\"','\\"')
def replace(path,data):
 info=path.stat();temp=path.with_name(path.name+'.ogipen-v049-tmp');temp.write_bytes(data);os.chmod(temp,stat.S_IMODE(info.st_mode));os.chown(temp,info.st_uid,info.st_gid);os.replace(temp,path)
try:
 replace(site,site_before.decode().replace(old,old.rstrip()+' env=!ogipen_api_request\n').encode())
 replace(inc,inc_before+addition.encode())
 p=subprocess.run(['apache2ctl','configtest'],capture_output=True)
 if p.returncode:raise RuntimeError('Apache syntax check failed')
 subprocess.run(['systemctl','reload','apache2'],check=True,capture_output=True)
 print('SCOPED_API_ACCESS_LOGS_INSTALLED')
except Exception:
 replace(site,site_before);replace(inc,inc_before);subprocess.run(['systemctl','reload','apache2'],capture_output=True)
 raise SystemExit('Apache log configuration rolled back')
