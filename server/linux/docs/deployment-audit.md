# Audit against the 24 October 2026 handover

Reference desktop branch inspected: `modernisation-csharp`, commit `7d92382f865460391e39656a1cb23cc8b0755c90`.

## Verified deployed state

- The Linux test server runs MySQL 8.4.2, .NET 10, Nginx and a dedicated PHP-FPM portal on port 8080.
- API and portal are v0.4.5. MySQL, Postfix, Webmin and the existing business databases remain operational. MySQL was not restarted for this release.
- Only the isolated `ogp_test_001` schema was migrated: identity revision and unique public-key fingerprint added. The portal SQL account received narrowly scoped enrolment/permission privileges; no DDL or business-database privilege was added.
- WordPress issues signed server licences; the Linux server verifies them. WordPress's administrative quota editor preserves the existing Progelec quota of 10. The Ogipen test quota remains 1.
- Identity enrolment, read/edit flags, quota enforcement, audit, key rotation and session revocation have been tested through HTTP and a real SignalR WebSocket connection.
- Neither the PHP portal nor this release adds project creation.

## Client/repository differences

1. `src/OGIPEN.Desktop/Infrastructure/AuthenticationClient.cs` still calls `POST api/v1/auth/login` with username/password. The deployed API instead uses `/auth/challenge` and `/auth/complete` with a pre-enrolled public key. The desktop login path must be replaced by OS-session-bound key possession; do not implement a password endpoint merely to satisfy the obsolete client.
2. `src/OGIPEN.Core/Security/OfflineLicenseActivation.cs` already implements an `OGIPEN-OFFLINE-REQUEST` request with nonce, SPKI key and signed proof, and expects an `OGIPEN-OFFLINE-LICENSE` wrapper containing an `ES256-DER` token. WordPress's deployed server export uses an `ogipen-license-v1` envelope over `ogipen-entitlement-v1` claims. These are different contracts; the current server licence is not a working desktop `.oglic` activation.
3. `SignedSoftwareEntitlement.cs` expects a short-lived, beneficiary-bound `SLMMS-ENT` token. The server deployment does not yet implement that per-beneficiary commercial authorisation flow.
4. The existing repository architecture notes describe some central permissions, but the newly supplied handover explicitly requires business roles and assignments **inside each project database**. Follow the handover when designing the central registry and project provisioning.

## Remaining work, in order

1. Align WordPress `.ogreq` import / `.oglic` issue with the existing portable client verifier, including proof verification, nonce/replay handling, beneficiary eligibility, activation audit and configured commercial licence models.
2. Replace the obsolete desktop password login with current Windows-session binding and protected per-installation/per-user keys. Add the corresponding Linux design without requiring Kerberos on the server.
3. Implement the central project registry and a recoverable provisioner invoked **from Ogipen**, with complete independent project schemas and manager assignment to the creator. PHP stays supervisory.
4. Implement per-project custom roles and task-level authorisation in the API, including preservation of at least one manager and project-isolated events.
5. Add persistent multi-server client profiles, project closure on server switches, missed-event recovery and actual multi-user client tests.
6. Consolidate an idempotent unified installer and versioned migrations for new and existing hosts; retain database backups and rollback paths.
7. Complete direct HTTPS on port 8080 when the user resumes that work. It was explicitly deferred during this release.

The local deployment report contains environment-specific addresses, backup locations and operator information. Secrets, licence files, operational database dumps and private keys are excluded from Git.
