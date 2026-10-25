import pathlib,subprocess,os,base64,json
r=pathlib.Path('/root/ogipen-v0412');os.umask(0o077)
def b64(b):return base64.urlsafe_b64encode(b).decode().rstrip('=')
for key in ['device','other']:
 if (r/(key+'.pem')).exists():continue
 subprocess.run(['openssl','ecparam','-name','prime256v1','-genkey','-noout','-out',str(r/(key+'.pem'))],check=True)
for name,key,sw in [('request','device',405),('renew','device',405),('fresh','device',405),('second','other',405),('wrong','device',391),('rollback','device',405)]:
 pub=subprocess.check_output(['openssl','pkey','-in',str(r/(key+'.pem')),'-pubout','-outform','DER']);nonce=b64(os.urandom(32));pub=b64(pub)
 text=f'OGIPEN-OFFLINE-REQUEST-v1\n{sw}\n1\n{nonce}\n{pub}\n'
 sig=subprocess.run(['openssl','dgst','-sha256','-sign',str(r/(key+'.pem'))],input=text.encode(),capture_output=True,check=True).stdout
 (r/(name+'.ogreq')).write_text(json.dumps({'type':'OGIPEN-OFFLINE-REQUEST','version':1,'software_id':sw,'major':1,'nonce':nonce,'public_key_spki':pub,'proof':b64(sig)}))
print('Public requests generated; private test keys remain on this host')
