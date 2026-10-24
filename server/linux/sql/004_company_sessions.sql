-- Executed conditionally by prepare-db.py (ALTERs require column checks).
CREATE TABLE IF NOT EXISTS ogp_auth_session (
 session_id CHAR(32) CHARACTER SET ascii COLLATE ascii_bin PRIMARY KEY,
 identity_id VARCHAR(80) NOT NULL,
 auth_version INT UNSIGNED NOT NULL,
 company_id BIGINT UNSIGNED NOT NULL,
 client_license_json TEXT NOT NULL,
 expires_utc DATETIME(6) NOT NULL,
 INDEX ix_session_identity(identity_id), INDEX ix_session_expiry(expires_utc)
) ENGINE=InnoDB;
