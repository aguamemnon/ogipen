"""Export public provisioning data for an independently hosted company API."""
import argparse,hashlib,json,pathlib,subprocess,urllib.parse
parser=argparse.ArgumentParser();parser.add_argument('--api-url',required=True);parser.add_argument('--name',required=True);parser.add_argument('--certificate',required=True);parser.add_argument('--output',required=True);args=parser.parse_args()
url=args.api_url.rstrip('/')+'/';parsed=urllib.parse.urlsplit(url)
if parsed.scheme!='https' or not parsed.hostname or parsed.username or parsed.password or parsed.query or parsed.fragment:raise SystemExit('Use a complete HTTPS API URL without credentials or query')
cert=pathlib.Path(args.certificate)
if b'PRIVATE KEY' in cert.read_bytes():raise SystemExit('Use only the public server certificate')
r=subprocess.run(['openssl','x509','-in',str(cert),'-outform','DER'],capture_output=True)
if r.returncode:raise SystemExit('Cannot read the public server certificate')
profile={'Id':'company-'+hashlib.sha256(url.encode()).hexdigest()[:24],'Name':args.name,'ApiBaseUrl':url,'CertificateSha256':hashlib.sha256(r.stdout).hexdigest().upper()}
pathlib.Path(args.output).write_text(json.dumps([profile],ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
print('PUBLIC_COMPANY_PROFILE_EXPORTED')
