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

START TRANSACTION;

ALTER TABLE song RENAME COLUMN "Title" TO title;

ALTER TABLE song RENAME COLUMN "Id" TO id;

ALTER TABLE song ADD genre text;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241009210307_20241010000303', '8.0.10');

COMMIT;

START TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241009210359_20241010000355', '8.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE song ADD "AlbumId" integer;

CREATE TABLE artist (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    name text,
    genre text,
    CONSTRAINT "PK_artist" PRIMARY KEY (id)
);

CREATE TABLE genre (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    name text,
    CONSTRAINT "PK_genre" PRIMARY KEY (id)
);

CREATE TABLE album (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    title text,
    "ArtistId" integer,
    CONSTRAINT "PK_album" PRIMARY KEY (id),
    CONSTRAINT "FK_album_artist_ArtistId" FOREIGN KEY ("ArtistId") REFERENCES artist (id)
);

CREATE INDEX "IX_song_AlbumId" ON song ("AlbumId");

CREATE INDEX "IX_album_ArtistId" ON album ("ArtistId");

ALTER TABLE song ADD CONSTRAINT "FK_song_album_AlbumId" FOREIGN KEY ("AlbumId") REFERENCES album (id);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241009210502_20241010000459', '8.0.10');

COMMIT;

START TRANSACTION;

CREATE TABLE songs_collection (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    title text,
    CONSTRAINT "PK_songs_collection" PRIMARY KEY (id)
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241009210837_20241010000833', '8.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE song ADD "SongsCollectionId" integer;

CREATE INDEX "IX_song_SongsCollectionId" ON song ("SongsCollectionId");

ALTER TABLE song ADD CONSTRAINT "FK_song_songs_collection_SongsCollectionId" FOREIGN KEY ("SongsCollectionId") REFERENCES songs_collection (id);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241009211038_20241010001035', '8.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE song DROP CONSTRAINT "FK_song_album_AlbumId";

ALTER TABLE song DROP CONSTRAINT "FK_song_songs_collection_SongsCollectionId";

ALTER TABLE song DROP CONSTRAINT "PK_song";

DROP INDEX "IX_song_SongsCollectionId";

ALTER TABLE song DROP COLUMN "SongsCollectionId";

ALTER TABLE song DROP COLUMN genre;

ALTER TABLE song RENAME TO songs;

ALTER INDEX "IX_song_AlbumId" RENAME TO "IX_songs_AlbumId";

ALTER TABLE songs ADD CONSTRAINT "PK_songs" PRIMARY KEY (id);

CREATE TABLE song_songs_collection (
    "SongsCollectionsId" integer NOT NULL,
    "SongsId" integer NOT NULL,
    CONSTRAINT "PK_song_songs_collection" PRIMARY KEY ("SongsCollectionsId", "SongsId"),
    CONSTRAINT "FK_song_songs_collection_songs_SongsId" FOREIGN KEY ("SongsId") REFERENCES songs (id) ON DELETE CASCADE,
    CONSTRAINT "FK_song_songs_collection_songs_collection_SongsCollectionsId" FOREIGN KEY ("SongsCollectionsId") REFERENCES songs_collection (id) ON DELETE CASCADE
);

CREATE INDEX "IX_song_songs_collection_SongsId" ON song_songs_collection ("SongsId");

ALTER TABLE songs ADD CONSTRAINT "FK_songs_album_AlbumId" FOREIGN KEY ("AlbumId") REFERENCES album (id);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241009212923_20241010002919', '8.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE song_songs_collection DROP CONSTRAINT "FK_song_songs_collection_songs_SongsId";

ALTER TABLE songs DROP CONSTRAINT "FK_songs_album_AlbumId";

ALTER TABLE songs DROP CONSTRAINT "PK_songs";

ALTER TABLE songs RENAME TO song;

ALTER INDEX "IX_songs_AlbumId" RENAME TO "IX_song_AlbumId";

ALTER TABLE song ADD CONSTRAINT "PK_song" PRIMARY KEY (id);

ALTER TABLE song ADD CONSTRAINT "FK_song_album_AlbumId" FOREIGN KEY ("AlbumId") REFERENCES album (id);

ALTER TABLE song_songs_collection ADD CONSTRAINT "FK_song_songs_collection_song_SongsId" FOREIGN KEY ("SongsId") REFERENCES song (id) ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241009221510_20241010011506', '8.0.10');

COMMIT;

START TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241009221637_20241010011633', '8.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE artist DROP COLUMN genre;

ALTER TABLE artist ADD "GenreId" integer;

CREATE INDEX "IX_artist_GenreId" ON artist ("GenreId");

ALTER TABLE artist ADD CONSTRAINT "FK_artist_genre_GenreId" FOREIGN KEY ("GenreId") REFERENCES genre (id);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241009222135_20241010012132', '8.0.10');

COMMIT;

START TRANSACTION;


                    CREATE OR REPLACE FUNCTION SearchByArtist(query TEXT)
                    RETURNS TABLE(artist_id INT, artist_name TEXT) AS $$
                    BEGIN
                    RETURN QUERY
                    SELECT a.id, a.name
                    FROM artist a
                    WHERE to_tsvector('russian', a.name) @@ plainto_tsquery('russian', query)
                    OR SIMILARITY(a.name, query) > 0.3
                    OR a.name ILIKE '%' || query || '%'
                    ORDER BY ts_rank(to_tsvector('russian', a.name), plainto_tsquery('russian', query)) DESC,
                    SIMILARITY(a.name, query) DESC
                    LIMIT 5;
                    END;
                    $$ LANGUAGE plpgsql;
                    


                            CREATE OR REPLACE FUNCTION SearchByAlbumsAndSongsCollections(query TEXT)
                            RETURNS TABLE(id INT, title TEXT, type TEXT) AS $$
                            BEGIN
                            RETURN QUERY
                            SELECT a.id AS id, a.title AS title, 'album' AS type
                            FROM album a
                            WHERE to_tsvector('russian', a.title) @@ plainto_tsquery('russian', query)
                            OR SIMILARITY(a.title, query) > 0.3

                            UNION ALL

                            SELECT sc.id AS id, sc.title AS title, 'songs_collection' AS type
                            FROM songs_collection sc
                            WHERE to_tsvector('russian', sc.title) @@ plainto_tsquery('russian', query)
                            OR SIMILARITY(sc.title, query) > 0.3

                            ORDER BY title
                            LIMIT 5;
                            END;
                            $$ LANGUAGE plpgsql;
                            

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241009223718_CreateSearchFunctions', '8.0.10');

COMMIT;

START TRANSACTION;


                    ALTER SEQUENCE genre_id_seq RESTART;
                    


                    ALTER SEQUENCE album_id_seq RESTART;
                    


                    ALTER SEQUENCE artist_id_seq RESTART;
                    


                    ALTER SEQUENCE "Songs_Id_seq" RESTART;
                    


                    ALTER SEQUENCE songs_collection_id_seq RESTART;
                    


                    -- Заполнение таблицы жанров
                    INSERT INTO genre (name) VALUES
                    ('РЭП'),
                    ('ПОП'),
                    ('РОК'),
                    ('ДЖАЗ'),
                    ('КЛАССИКА'),
                    ('ЭЛЕКТРО'),
                    ('КАНТРИ'),
                    ('ХИП-ХОП'),
                    ('ТЕХНО'),
                    ( 'ФОЛК');
                    


                            -- Заполнение таблицы артистов
                            INSERT INTO artist (name, "GenreId") VALUES
                            ('Юрий Лоза', 1),
                            ('Александр Рева', 2),
                            ('Ольга Бузова', 3),
                            ('Шаман', 4),
                            ('Егор Крид', 5),
                            ('Максим', 6),
                            ('Владимир Высоцкий', 7),
                            ('Борис Гребенщиков', 8),
                            ('Егор Летов', 3),
                            ('Король и Шут', 3);
                            


                                    -- Заполнение таблицы альбомов
                                    INSERT INTO album (title, "ArtistId") VALUES
                                    ('Лоза на волне', 1),               -- Юрий Лоза
                                    ('Кумиры', 1),                      -- Юрий Лоза
                                    ('Творческий путь', 2),             -- Александр Рева
                                    ('Поёт о любви', 2),                -- Александр Рева
                                    ('Свет за окном', 3),               -- Ольга Бузова
                                    ('Разговоры', 3),                   -- Ольга Бузова
                                    ('Космический', 4),                 -- Шаман
                                    ('Свет и тень', 4),                 -- Шаман
                                    ('Эгоист', 5),                      -- Егор Крид
                                    ('Родная', 5),                      -- Егор Крид
                                    ('Гармония', 6),                    -- Максим
                                    ('Светлая душа', 6),                -- Максим
                                    ('Высоцкий Live', 7),               -- Владимир Высоцкий
                                    ('Грустные песни', 7),              -- Владимир Высоцкий
                                    ('Русский рок', 8),                 -- Борис Гребенщиков
                                    ('Акустика', 8),                    -- Борис Гребенщиков
                                    ('Светлый день', 9),                -- Егор Летов
                                    ('Забытые песни', 9),               -- Егор Летов
                                    ('Короли рока', 10),                -- Король и Шут
                                    ('Завет', 10);                      -- Король и Шут
                                    


                                    -- Заполнение таблицы песен
                                    INSERT INTO song (title, "AlbumId") VALUES
                                    ('Забудь и вспомни', 1),
                                    ('Песня о дружбе', 1),
                                    ('Счастье', 2),
                                    ('Надежда', 2),
                                    ('Привет, брат!', 3),
                                    ('Отдых', 3),
                                    ('Свет в окне', 4),
                                    ('Душа', 4),
                                    ('Летний дождь', 5),
                                    ('Снежинка', 5),
                                    ('Тайна', 6),
                                    ('Листопад', 6),
                                    ('Незабываемый вечер', 7),
                                    ('Здесь и сейчас', 7),
                                    ('Ветер свободы', 8),
                                    ('Путь', 8),
                                    ('Моя любовь', 9),
                                    ('Светлый вечер', 9),
                                    ('Мертвые птицы', 10),
                                    ('Карабкаться', 10);
                            


                                    -- Заполнение таблиц коллекций песен
                                    INSERT INTO songs_collection (title) VALUES
                                    ('Сборник 1'),
                                    ('Сборник 2'),
                                    ('Сборник 3'),
                                    ('Сборник 4'),
                                    ('Сборник 5');
                                    


                                            -- Заполнение таблицы связей песен и коллекций
                                            INSERT INTO song_songs_collection ("SongsId", "SongsCollectionsId") VALUES
                                            (1, 1),
                                            (2, 1),
                                            (3, 2),
                                            (4, 2),
                                            (5, 3),
                                            (6, 3),
                                            (7, 4),
                                            (8, 4),
                                            (9, 5),
                                            (10, 5);
                                            

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241009225402_SeedDataMigration', '8.0.10');

COMMIT;

