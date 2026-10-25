ALTER TABLE ogp_identity ADD COLUMN system_role enum('user','admin','ossi') NOT NULL DEFAULT 'user';
UPDATE ogp_identity i JOIN ogp_app_account a ON a.identity_id=i.id SET i.system_role=a.system_role;
