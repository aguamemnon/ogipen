CREATE TABLE IF NOT EXISTS ogp_device (
 device_id varchar(80) NOT NULL PRIMARY KEY,
 company_id bigint unsigned NOT NULL,
 public_key_pem text NOT NULL,
 legacy_beneficiary_id bigint unsigned NULL,
 enabled tinyint NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
CREATE TABLE IF NOT EXISTS ogp_app_account (
 identity_id varchar(80) NOT NULL PRIMARY KEY,
 login_name varchar(180) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL UNIQUE,
 password_hash varchar(255) DEFAULT NULL,
 system_role enum('user','admin','ossi') NOT NULL DEFAULT 'user',
 enabled tinyint NOT NULL DEFAULT 0,
 updated_utc datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
CREATE TABLE IF NOT EXISTS ogp_login_attempt (
 bucket char(64) CHARACTER SET ascii NOT NULL PRIMARY KEY,
 attempts int unsigned NOT NULL,
 window_end datetime NOT NULL,
 KEY window_end(window_end)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
ALTER TABLE ogp_auth_session ADD COLUMN device_identity_id varchar(80) NULL, ADD COLUMN auth_method varchar(16) NOT NULL DEFAULT 'legacy';
