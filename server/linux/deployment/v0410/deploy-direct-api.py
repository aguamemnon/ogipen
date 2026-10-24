import pathlib,os,stat,subprocess,re,json,time,urllib.request
os.umask(0o077)
root=pathlib.Path('/root/ogipen-v0410');conf=pathlib.Path('/etc/nginx/sites-available/ogipen');env=pathlib.Path('/etc/ogipen/api.env')
before=conf.read_bytes();before_env=env.read_bytes()
if 'listen 192.168.2.216:443 ' in before.decode():raise SystemExit('Direct endpoint already exists; inspect before changing')
(root/'nginx-before.conf').write_bytes(before);(root/'api-env-before').write_bytes(before_env)
cert=pathlib.Path('/etc/ogipen/tls/company-server.crt');key=cert.with_suffix('.key')
if cert.exists() or key.exists():raise SystemExit('Existing company certificate; no automatic replacement')
p=subprocess.run(['openssl','req','-x509','-newkey','rsa:3072','-nodes','-sha256','-days','365','-keyout',str(key),'-out',str(cert),'-subj','/CN=Ogipen company server','-addext','subjectAltName=IP:192.168.2.216','-addext','basicConstraints=critical,CA:FALSE','-addext','keyUsage=critical,digitalSignature,keyEncipherment','-addext','extendedKeyUsage=serverAuth'],capture_output=True)
if p.returncode:raise SystemExit('Certificate creation failed; no configuration changed')
key.chmod(0o600);cert.chmod(0o644)
block='''
# Company-local API: no WordPress relay and no SQL exposure.
server {
    listen 192.168.2.216:443 ssl;
    server_name 192.168.2.216;
    ssl_certificate /etc/ogipen/tls/company-server.crt;
    ssl_certificate_key /etc/ogipen/tls/company-server.key;
    ssl_protocols TLSv1.2 TLSv1.3;
    server_tokens off;
    allow 192.168.2.0/24;
    deny all;
    client_max_body_size 80k;
    access_log /var/log/nginx/ogipen-api-access.log ogipen_api_sanitized;
    location = / { return 302 /health; }
    location / {
        proxy_pass http://127.0.0.1:5088;
        proxy_http_version 1.1;
        proxy_set_header Host $host;
        proxy_set_header X-Forwarded-Proto https;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection $ogipen_api_connection;
        proxy_read_timeout 65s;
        proxy_buffering off;
        add_header Cache-Control "no-store" always;
    }
}
'''
updated,n=re.subn(r'    # Licensed API[^\n]*\n    location \^~ /client-api/ \{.*?\n    \}', '    # Retired WordPress relay. Use the company API directly.\n    location ^~ /client-api/ { return 410; }',before.decode(),count=1,flags=re.S)
if n!=1:raise SystemExit('Unexpected existing relay configuration; no files changed')
def replace(path,data):
 info=path.stat();tmp=path.with_name(path.name+'.v0410-tmp');tmp.write_bytes(data);os.chmod(tmp,stat.S_IMODE(info.st_mode));os.chown(tmp,info.st_uid,info.st_gid);os.replace(tmp,path)
try:
 replace(conf,(updated+block).encode())
 p=subprocess.run(['nginx','-t'],capture_output=True)
 if p.returncode:raise RuntimeError('Nginx syntax failed')
 lines=[x for x in before_env.decode().splitlines() if not x.startswith('OGIPEN_AUTH_AUDIENCE=')];lines.append('OGIPEN_AUTH_AUDIENCE=https://192.168.2.216/')
 replace(env,('\n'.join(lines)+'\n').encode())
 subprocess.run(['systemctl','restart','ogipen-api'],check=True,capture_output=True)
 for _ in range(40):
  try:
   with urllib.request.urlopen('http://127.0.0.1:5088/health',timeout=2) as r:json.load(r)
   break
  except (OSError,ValueError):time.sleep(.25)
 else:raise RuntimeError('API did not restart')
 subprocess.run(['systemctl','reload','nginx'],check=True,capture_output=True)
 print('DIRECT_COMPANY_API_CONFIGURED https://192.168.2.216/')
 print(subprocess.run(['openssl','x509','-in',str(cert),'-noout','-fingerprint','-sha256'],capture_output=True,text=True,check=True).stdout.strip())
except Exception:
 replace(conf,before);replace(env,before_env);subprocess.run(['systemctl','restart','ogipen-api'],capture_output=True);subprocess.run(['systemctl','reload','nginx'],capture_output=True)
 raise SystemExit('Direct endpoint deployment failed; previous configuration restored')
