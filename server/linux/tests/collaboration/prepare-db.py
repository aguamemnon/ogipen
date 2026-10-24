import pathlib,subprocess,os
os.umask(0o077)
root=pathlib.Path('/root/ogipen-v047')
cfg=dict(line.split('=',1) for line in pathlib.Path('/etc/webmin/mysql/config').read_text().splitlines() if '=' in line)
def quote(s):return '"'+s.replace('\\','\\\\').replace('"','\\"').replace('\n','\\n')+'"'
client=root/'db-client.cnf'
client.write_text('[client]\nuser='+quote(cfg.get('login','root'))+'\npassword='+quote(cfg.get('pass',''))+'\n')
client.chmod(0o600)
opt='--defaults-extra-file='+str(client)
try:
 with open(root/'project-before.sql','wb') as f:
  p=subprocess.run(['mysqldump',opt,'--single-transaction','--no-tablespaces','--set-gtid-purged=OFF','ogp_test_001'],stdout=f,stderr=subprocess.PIPE)
  if p.returncode:raise SystemExit('Backup failed; no migration applied')
 sql=(root/'sql/003_collaboration_preparation.sql').read_text()
 sql+="\nGRANT SELECT,INSERT,UPDATE ON ogp_test_001.ogp_collaboration_config TO 'ogp_admin_php'@'localhost';\nGRANT SELECT,INSERT,UPDATE ON ogp_test_001.ogp_project_company TO 'ogp_admin_php'@'localhost';"
 p=subprocess.run(['mysql',opt,'ogp_test_001'],input=sql,text=True,capture_output=True)
 if p.returncode:raise SystemExit('Migration failed; inspect protected MySQL diagnostics')
 print('PROJECT_BACKUP_AND_ADDITIVE_MIGRATION_OK')
finally:client.unlink(missing_ok=True)
