﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Songs" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Title" text,
    CONSTRAINT "PK_Songs" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241009203558_20241009233554', '8.0.10');

COMMIT;

START TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241009204221_20241009234215', '8.0.10');

COMMIT;

START TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241009204523_20241009234518', '8.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE "Songs" DROP CONSTRAINT "PK_Songs";

ALTER TABLE "Songs" RENAME TO song;

ALTER TABLE song ADD CONSTRAINT "PK_song" PRIMARY KEY ("Id");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241009204851_20241009234848', '8.0.10');

COMMIT;

