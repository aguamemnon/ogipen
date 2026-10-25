import os,pathlib,subprocess,shutil,json
os.umask(0o077);r=pathlib.Path('/root/ogipen-v0413')
def run(args):return subprocess.run(args,check=True,capture_output=True,text=True).stdout.strip()
cfg=dict(l.split('=',1) for l in pathlib.Path('/etc/webmin/mysql/config').read_text().splitlines() if '=' in l)
def quote(s):return '"'+s.replace('\\','\\\\').replace('"','\\"')+'"'
cnf=r/'db.cnf';cnf.write_text('[client]\nuser='+quote(cfg.get('login','root'))+'\npassword='+quote(cfg.get('pass',''))+'\n')
def sql(q):
 x=subprocess.run(['mysql','--defaults-extra-file='+str(cnf),'-N','-B','ogp_test_001'],input=q,text=True,capture_output=True)
 if x.returncode:(r/'sql-error.log').write_text(x.stderr);raise RuntimeError('SQL failed; protected diagnostic saved')
 return x.stdout.strip()
pid=run(['systemctl','show','mysql','-p','MainPID','--value'])
try:
 if sql("SELECT COUNT(*) FROM information_schema.tables WHERE table_schema='ogp_test_001' AND table_name='ogp_app_account'")!='0':raise RuntimeError('Migration already applied; inspect first')
 for p in (r/'admin').glob('*.php'):run(['php','-l',str(p)])
 with (r/'before-project.sql').open('wb') as f:subprocess.run(['mysqldump','--defaults-extra-file='+str(cnf),'--single-transaction','--no-tablespaces','--set-gtid-purged=OFF','ogp_test_001'],stdout=f,stderr=subprocess.PIPE,check=True)
 sql((r/'schema.sql').read_text())
 sql("INSERT INTO ogp_device(device_id,company_id,public_key_pem,legacy_beneficiary_id,enabled) SELECT id,company_id,public_key_pem,license_beneficiary_id,1 FROM ogp_identity WHERE enabled=1 AND company_id IS NOT NULL AND public_key_pem<>''")
 sql("GRANT SELECT,INSERT,UPDATE ON ogp_test_001.ogp_device TO 'ogp_admin_php'@'localhost'")
 sql("GRANT DELETE ON ogp_test_001.ogp_auth_session TO 'ogp_admin_php'@'localhost'")
 sql("GRANT SELECT,INSERT,UPDATE,DELETE ON ogp_test_001.ogp_app_account TO 'ogp_admin_php'@'localhost'")
 # Seed inactive internal accounts without any password or implicit project permission.
 sql("START TRANSACTION; INSERT INTO ogp_identity(id,display_name,public_key_pem,public_key_sha256,enabled,company_id,auth_version) VALUES('ogipen:admin','Administrateur Ogipen','',NULL,0,1,1),('ogipen:ossi','OSSI','',NULL,0,1,1); INSERT INTO ogp_app_account(identity_id,login_name,system_role,enabled) VALUES('ogipen:admin','admin','admin',0),('ogipen:ossi','ossi','ossi',0); INSERT INTO ogp_permission(identity_id,can_read,can_edit) VALUES('ogipen:admin',0,0),('ogipen:ossi',0,0); INSERT INTO ogp_audit_event(actor_id,action_code,entity_type,entity_id,details) VALUES('ADMIN:deployment','PASSWORD_LOGIN_ENABLED','administration',0,'{\"version\":\"0.4.13\",\"seededAccounts\":\"admin,ossi\",\"defaultPassword\":false}'); COMMIT;")
 try:
  run(['systemctl','stop','ogipen-api'])
  for p in (r/'publish').iterdir():
   if p.is_file():
    d=pathlib.Path('/opt/ogipen/api')/p.name;shutil.copy2(p,d);shutil.chown(d,user='root',group='ogipen-api');d.chmod(0o640)
  changed=['account-service.php','account-controller.php','account-view.php','index.php','portal-header.php','identity-controller.php','identity-service.php']
  for name in changed:
   d=pathlib.Path('/opt/ogipen/admin')/name;shutil.copy2(r/'admin'/name,d);shutil.chown(d,user='root',group='ogipen-admin');d.chmod(0o640)
  run(['systemctl','start','ogipen-api']);run(['systemctl','restart','ogipen-admin'])
 except:
  run(['tar','xzf',str(r/'before.tgz'),'-C','/','opt/ogipen/api','opt/ogipen/admin']);run(['systemctl','restart','ogipen-api']);run(['systemctl','restart','ogipen-admin']);raise
 assert run(['systemctl','show','mysql','-p','MainPID','--value'])==pid
 print(json.dumps({'deployed':'0.4.13','mysql_pid_unchanged':pid,'internalAccounts':'admin,ossi: inactive until password set','legacyLoginDisabled':True}))
finally:cnf.unlink(missing_ok=True)
