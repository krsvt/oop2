using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
                    ALTER SEQUENCE genre_id_seq RESTART;
                    ");

            migrationBuilder.Sql(@"
                    ALTER SEQUENCE album_id_seq RESTART;
                    ");

            migrationBuilder.Sql(@"
                    ALTER SEQUENCE artist_id_seq RESTART;
                    ");

            migrationBuilder.Sql(@"
                    ALTER SEQUENCE song_id_seq RESTART;
                    ");

            migrationBuilder.Sql(@"
                    ALTER SEQUENCE songs_collection_id_seq RESTART;
                    ");

            migrationBuilder.Sql(@"
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
                    ");
                    migrationBuilder.Sql(@"
                            -- Заполнение таблицы артистов
                            INSERT INTO artist (name, ""GenreId"") VALUES
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
                            ");
                            migrationBuilder.Sql(@"
                                    -- Заполнение таблицы альбомов
                                    INSERT INTO album (title, ""ArtistId"") VALUES
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
                                    ");

                            migrationBuilder.Sql(@"
                                    -- Заполнение таблицы песен
                                    INSERT INTO song (title, ""AlbumId"") VALUES
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
                            ");


                            migrationBuilder.Sql(@"
                                    -- Заполнение таблиц коллекций песен
                                    INSERT INTO songs_collection (title) VALUES
                                    ('Сборник 1'),
                                    ('Сборник 2'),
                                    ('Сборник 3'),
                                    ('Сборник 4'),
                                    ('Сборник 5');
                                    ");
                                    migrationBuilder.Sql(@"
                                            -- Заполнение таблицы связей песен и коллекций
                                            INSERT INTO song_songs_collection (""SongsId"", ""SongsCollectionsId"") VALUES
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
                                            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //         name: "AlbumAndCollectionSearchResults");
            //
            // migrationBuilder.DropTable(
            //         name: "ArtistSearchResults");
        }
    }
}
