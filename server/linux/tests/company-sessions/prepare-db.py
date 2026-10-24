import pathlib,subprocess,os,datetime
os.umask(0o077)
root=pathlib.Path('/root/ogipen-v048')
cfg=dict(line.split('=',1) for line in pathlib.Path('/etc/webmin/mysql/config').read_text().splitlines() if '=' in line)
def quote(s):return '"'+s.replace('\\','\\\\').replace('"','\\"').replace('\n','\\n')+'"'
client=root/'db-client.cnf';client.write_text('[client]\nuser='+quote(cfg.get('login','root'))+'\npassword='+quote(cfg.get('pass',''))+'\n');client.chmod(0o600)
opt='--defaults-extra-file='+str(client)
def sql(s):
 p=subprocess.run(['mysql',opt,'-N','-B','ogp_test_001'],input=s,text=True,capture_output=True)
 if p.returncode:raise RuntimeError('MySQL migration failed; no credentials printed')
 return p.stdout.strip()
try:
 backup=root/'project-before.sql'
 if backup.exists():backup=root/('project-before-'+datetime.datetime.now(datetime.timezone.utc).strftime('%Y%m%dT%H%M%S%fZ')+'.sql')
 with open(backup,'xb') as f:
  p=subprocess.run(['mysqldump',opt,'--single-transaction','--no-tablespaces','--set-gtid-purged=OFF','ogp_test_001'],stdout=f,stderr=subprocess.PIPE)
  if p.returncode:raise SystemExit('Backup failed')
 for table,column,definition in [
  ('ogp_collaboration_config','effective_mode',"ENUM('single','multi') NOT NULL DEFAULT 'single'"),
  ('ogp_project_company','server_license_json','TEXT NULL'),
  ('ogp_identity','company_id','BIGINT UNSIGNED NULL'),
  ('ogp_identity','license_beneficiary_id','BIGINT UNSIGNED NULL')]:
  if sql("SELECT COUNT(*) FROM information_schema.columns WHERE table_schema=DATABASE() AND table_name='"+table+"' AND column_name='"+column+"'")=='0':sql('ALTER TABLE '+table+' ADD COLUMN '+column+' '+definition)
 if sql("SELECT COUNT(*) FROM information_schema.statistics WHERE table_schema=DATABASE() AND table_name='ogp_identity' AND index_name='uq_company_beneficiary'")=='0':sql('ALTER TABLE ogp_identity ADD UNIQUE KEY uq_company_beneficiary(company_id,license_beneficiary_id)')
 sql((root/'sql/004_company_sessions.sql').read_text())
 # Resolve the existing API account internally; never print its connection string.
 import re
 api_env=dict(line.split('=',1) for line in pathlib.Path('/etc/ogipen/api.env').read_text().splitlines() if '=' in line and not line.startswith('#'))
 cs=api_env['OGIPEN_DB_CONNECTION'];account=re.search(r'(?:User ID|User|Uid|Username)\s*=\s*([^;]+)',cs,re.I).group(1).strip()
 if not re.fullmatch(r'[A-Za-z0-9_]+',account):raise RuntimeError('Unexpected API account')
 sql("GRANT SELECT ON ogp_test_001.ogp_project_company TO '"+account+"'@'localhost'; GRANT SELECT ON ogp_test_001.ogp_collaboration_config TO '"+account+"'@'localhost'; GRANT SELECT,INSERT,DELETE ON ogp_test_001.ogp_auth_session TO '"+account+"'@'localhost';")
 print('BACKUP_AND_ADDITIVE_MIGRATION_OK')
 print('ACTIVE_IDENTITIES='+sql('SELECT COUNT(*) FROM ogp_identity WHERE enabled=1'))
 print('DECLARED_COMPANIES='+sql('SELECT COUNT(*) FROM ogp_project_company'))
finally:client.unlink(missing_ok=True)
