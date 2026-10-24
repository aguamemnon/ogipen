-- Existing prototype database only. Back up first and inspect each column/index.
-- These ALTER statements are additive but are NOT safe to repeat blindly.
-- Do not apply to progelec or another existing business schema.
ALTER TABLE ogp_identity ADD COLUMN auth_version INT UNSIGNED NOT NULL DEFAULT 1;
ALTER TABLE ogp_identity ADD COLUMN public_key_sha256 CHAR(64) NULL;
ALTER TABLE ogp_identity ADD UNIQUE KEY uq_identity_public_key(public_key_sha256);
-- Existing keys must be audited and their SHA-256 SPKI fingerprints populated
-- before treating enrolment as migrated. Detect duplicates before backfilling.
-- The deployed test environment had no existing identities at migration time.
