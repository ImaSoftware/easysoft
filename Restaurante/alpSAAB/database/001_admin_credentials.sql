-- Run once on the existing restaurant database before deploying this version.
-- Back up the database first. No business tables are deleted or recreated.
SET XACT_ABORT ON;
BEGIN TRANSACTION;
IF OBJECT_ID(N'dbo.SD_AdminCredenciales', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.SD_AdminCredenciales (
        Instancia int NOT NULL CONSTRAINT PK_SD_AdminCredenciales PRIMARY KEY,
        PasswordHash varchar(256) NOT NULL
    );
END;
COMMIT;
-- On the first successful configuration load the application hashes the legacy
-- administrator PIN, stores it here and clears SD_SysParam.ClaveAdmin atomically.
