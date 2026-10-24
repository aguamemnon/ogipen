import pathlib,tempfile,subprocess,os
cfg=dict(line.split('=',1) for line in pathlib.Path('/etc/webmin/mysql/config').read_text().splitlines() if '=' in line)
def quote(s):return '"'+s.replace('\\','\\\\').replace('"','\\"').replace('\n','\\n')+'"'
fd,name=tempfile.mkstemp(prefix='ogipen-state-',dir='/root/ogipen-v049');os.close(fd);p=pathlib.Path(name)
try:
 p.write_text('[client]\nuser='+quote(cfg.get('login','root'))+'\npassword='+quote(cfg.get('pass',''))+'\n');p.chmod(0o600)
 query="SELECT CONCAT('IDENTITIES=',COUNT(*)) FROM ogp_identity; SELECT CONCAT('COMPANIES=',COUNT(*)) FROM ogp_project_company; SELECT CONCAT('REAL_SESSIONS=',COUNT(*)) FROM ogp_auth_session; SELECT CONCAT('SELFTEST_DATABASES=',COUNT(*)) FROM information_schema.schemata WHERE schema_name='ogp_v049_selftest';"
 r=subprocess.run(['mysql','--defaults-extra-file='+str(p),'-N','-B','ogp_test_001'],input=query,text=True,capture_output=True)
 if r.returncode:raise SystemExit('Read-only state check failed')
 print(r.stdout.strip())
finally:p.unlink(missing_ok=True)
