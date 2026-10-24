-- Project-local collaboration metadata. No business data or existing rights changed.
CREATE TABLE IF NOT EXISTS ogp_collaboration_config (
 id TINYINT UNSIGNED NOT NULL PRIMARY KEY,
 requested_mode ENUM('single','multi') NOT NULL DEFAULT 'single',
 revision INT UNSIGNED NOT NULL DEFAULT 1,
 CHECK(id=1)
) ENGINE=InnoDB;
INSERT IGNORE INTO ogp_collaboration_config(id) VALUES(1);
CREATE TABLE IF NOT EXISTS ogp_project_company (
 id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
 company_code VARCHAR(64) CHARACTER SET ascii COLLATE ascii_bin NOT NULL UNIQUE,
 display_name VARCHAR(180) NOT NULL,
 work_package VARCHAR(180) NOT NULL DEFAULT '',
 slm_license_id BIGINT UNSIGNED NULL,
 state ENUM('prepared','archived') NOT NULL DEFAULT 'prepared',
 revision INT UNSIGNED NOT NULL DEFAULT 1,
 created_utc DATETIME(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6)
) ENGINE=InnoDB;
