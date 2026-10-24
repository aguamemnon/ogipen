import pathlib,subprocess,tempfile,os,json,ipaddress
cfg=dict(l.split('=',1) for l in pathlib.Path('/etc/webmin/mysql/config').read_text().splitlines() if '=' in l)
def quote(s):return '"'+s.replace('\\','\\\\').replace('"','\\"').replace('\n','\\n')+'"'
fd,name=tempfile.mkstemp(prefix='audit-read-',dir='/root/ogipen-v0411');os.close(fd);p=pathlib.Path(name)
results=[]
def check(name,ok):
 results.append({'test':name,'pass':bool(ok)})
 if not ok:raise AssertionError(name)
try:
 p.write_text('[client]\nuser='+quote(cfg.get('login','root'))+'\npassword='+quote(cfg.get('pass',''))+'\n');p.chmod(0o600)
 q="SELECT details FROM ogp_audit_event WHERE actor_id='nonexistent-v0411-selftest' AND entity_type='authentication' ORDER BY id DESC LIMIT 1;"
 r=subprocess.run(['mysql','--defaults-extra-file='+str(p),'-N','-B','--raw','ogp_test_001'],input=q,text=True,capture_output=True)
 if r.returncode:raise RuntimeError('Read-only audit check failed')
 row=json.loads(r.stdout.strip())
 check('live_computer_and_user_retained',row['computerName']=='SELFTEST-WINDOWS-PC' and row['userName']=='SELFTEST-USER')
 check('live_wrong_licence_number_retained',row['licenseId']==999 and row['serverLicenseId']==2 and row['licenseMismatch'])
 check('live_reference_provenance_visible',row.get('serverLicenseSource')=='instance_initial')
 check('live_unverified_licence_label',not row['licenseSignatureVerified'] and not row['success'])
 check('live_source_ip_cannot_be_forged',ipaddress.ip_address(row['ip']) in ipaddress.ip_network('192.168.2.0/24') and row['ip']!='203.0.113.99')
 check('live_sensitive_fields_absent','AUDIT_SECRET_SENTINEL' not in r.stdout and 'password' not in row and 'accessToken' not in row)
finally:
 p.unlink(missing_ok=True);pathlib.Path('/root/ogipen-v0411/tests/results-live-audit.json').write_text(json.dumps(results,indent=2));print(json.dumps(results,indent=2))
