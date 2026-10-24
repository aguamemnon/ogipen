import pathlib,subprocess,os
cfg=dict(line.split('=',1) for line in pathlib.Path('/etc/webmin/mysql/config').read_text().splitlines() if '=' in line)
env=os.environ.copy();env['TEST_DB_USER']=cfg.get('login','root');env['TEST_DB_PASSWORD']=cfg.get('pass','')
p=subprocess.run(['php','/root/ogipen-v047/tests/test-collaboration.php'],env=env,capture_output=True,text=True)
print(p.stdout)
if p.returncode:print(p.stderr)
raise SystemExit(p.returncode)
