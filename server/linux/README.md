# État courant : v0.4.8

L’API impose désormais les licences serveur/poste et les affectations par entreprise. Voir [le déploiement v0.4.8](docs/licences-entreprises-v0.4.8.md), ses migrations obligatoires et ses limites avant toute installation. Les instructions v0.4.5 ci-dessous décrivent la base historique ; elles ne suffisent pas seules à configurer la nouvelle API.

# Ogipen Linux server — v0.4.5 prototype

This directory versions the ASP.NET Core API and PHP administration portal tested on the Linux test environment. It does not replace the Windows client in `src/OGIPEN.Desktop`.

## Boundaries

- WordPress / SLM Plus is the sole licence issuer. The server receives a pinned public key and a signed licence, never the issuer private key.
- The API currently serves one dedicated **demonstration project database**. Read/edit flags in `ogp_permission` are scoped to that database, not organisation-wide business roles.
- The PHP portal manages technical identity enrolment, access flags, audit, locks and licence import. It **must not create projects**.
- An enrolled public key proves key possession at authentication time. It does not, by itself, verify a Windows SID or Linux session. OS binding and authorised enrolment in the real clients are still required.
- No Kerberos or AD server dependency is introduced.

## Components

- `src/`: .NET 10 API; publish with `dotnet publish src/Ogipen.Api.csproj -c Release`.
- `admin/`: PHP 8.2+ portal, requiring PDO MySQL and OpenSSL. Serve only public entry points through Nginx/PHP-FPM; internal helper PHP files must not be exposed.
- `sql/001_project.sql`: fresh, dedicated demonstration database schema.
- `sql/002_identity_sessions.sql`: additive migration for an existing prototype schema; inspect columns/indexes and back up before applying. Do not run it blindly a second time.
- `tests/`: deployment integration checks requiring a disposable test environment and operator-supplied private configuration. No credentials or private keys are included.

## Identity changes

An administrator can add an identity with its P-256 public key, change read/edit access, activate or deactivate it, and replace its public key. Active identities consume licence seats. Inactive identities can be prepared without consuming a seat. Public keys cannot be shared between identities.

Mutations and licence imports share an administrative file lock; SQL mutations and audit are transactional. Licence imports refuse a seat limit lower than the number of active identities.

An identity revision is embedded in each signed API session. Edits, deactivation and key replacement invalidate old sessions; API calls check the revision against SQL. Live SignalR connections are rechecked every two seconds and aborted if the revision, permissions, licence, quota or session expiry no longer permits access. SQL failures close live connections rather than retaining access.

## Configuration

Keep configuration outside the web root and source tree. Required API environment variables are `OGIPEN_DB_CONNECTION`, `OGIPEN_SESSION_KEY`, `OGIPEN_SERVER_ID`, `OGIPEN_SOFTWARE_ID`, `OGIPEN_LICENSE_ISSUER`, `OGIPEN_LICENSE_PATH` and `OGIPEN_LICENSE_PUBLIC_KEY`.

The portal additionally requires `OGIPEN_ADMIN_DB_HOST`, `OGIPEN_ADMIN_DB_PORT`, `OGIPEN_ADMIN_DB_NAME`, `OGIPEN_ADMIN_DB_USER`, `OGIPEN_ADMIN_DB_PASSWORD` and `OGIPEN_ADMIN_PASSWORD_HASH`. Give its SQL account only the specific data privileges required by the portal. It has no provisioning/DDL privileges.

The portal state directory `/var/lib/ogipen/licensing/.portal-state/` must be private and writable by the portal worker. Sessions, rate-limit records and the administrative lock belong there. Preserve the deployed dedicated PHP-FPM pool, helper-file restrictions, session settings and web-server configuration when updating code.

The target portal port remains **8080**. Direct HTTPS on this port is deferred at the user's explicit request; this prototype's LAN HTTP access is not a production-security completion. A separate verified HTTPS proxy is available in the test environment. The API remains loopback-only pending a secure client-facing endpoint.

## Tests and compatibility

The v0.4.5 deployment passed 39 identity/API/SignalR checks and 60 portal regression checks. Temporary test identities and private authentication keys are removed after checks; audit entries remain.

Do not report the existing desktop client as connected to this API yet. The audit in `docs/deployment-audit.md` describes incompatible authentication and offline-licence contracts that must be reconciled before client integration.

An idempotent, versioned unified installer, per-project provisioning, project role templates and task-level permissions are still pending. These files are versioned deployment sources, not a completed universal installer.
