-- ONLY import into a newly created dedicated project database.
CREATE TABLE IF NOT EXISTS ogp_identity (
 id VARCHAR(80) PRIMARY KEY, display_name VARCHAR(180) NOT NULL,
 public_key_pem TEXT NOT NULL, public_key_sha256 CHAR(64) NULL UNIQUE,
 auth_version INT UNSIGNED NOT NULL DEFAULT 1, enabled BOOLEAN NOT NULL DEFAULT 1,
 created_utc DATETIME(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6)
) ENGINE=InnoDB;
CREATE TABLE IF NOT EXISTS ogp_challenge (
 nonce_hash CHAR(64) PRIMARY KEY, identity_id VARCHAR(80) NOT NULL,
 expires_utc DATETIME(6) NOT NULL, consumed BOOLEAN NOT NULL DEFAULT 0,
 INDEX ix_chal_identity(identity_id)
) ENGINE=InnoDB;
CREATE TABLE IF NOT EXISTS ogp_permission (
 identity_id VARCHAR(80) PRIMARY KEY, can_read BOOLEAN NOT NULL DEFAULT 0,
 can_edit BOOLEAN NOT NULL DEFAULT 0
) ENGINE=InnoDB;
CREATE TABLE IF NOT EXISTS ogp_edit_lock (
 entity_type VARCHAR(40) NOT NULL,entity_id BIGINT NOT NULL,
 token CHAR(36) NOT NULL,owner_id VARCHAR(80) NOT NULL,
 session_id CHAR(36) NOT NULL, expires_utc DATETIME(6) NOT NULL,
 PRIMARY KEY(entity_type,entity_id), UNIQUE KEY uq_lock_token(token)
) ENGINE=InnoDB;
CREATE TABLE IF NOT EXISTS ogp_audit_event (
 id BIGINT AUTO_INCREMENT PRIMARY KEY,happened_utc DATETIME(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
 actor_id VARCHAR(80) NOT NULL, action_code VARCHAR(80) NOT NULL,
 entity_type VARCHAR(40) NOT NULL,entity_id BIGINT NOT NULL,details JSON NULL,
 INDEX ix_events(id),INDEX ix_entity(entity_type,entity_id)
) ENGINE=InnoDB;
CREATE TABLE IF NOT EXISTS ogp_demo_cable (
 id BIGINT PRIMARY KEY,reference VARCHAR(100) NOT NULL,
 description VARCHAR(1000) NOT NULL DEFAULT '',row_version BIGINT NOT NULL DEFAULT 1
) ENGINE=InnoDB;
INSERT IGNORE INTO ogp_demo_cable(id,reference,description) VALUES (425,'CAB-00425','Démonstration');
