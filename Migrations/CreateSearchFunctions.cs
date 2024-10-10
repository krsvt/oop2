using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

// моё творение с другом chatgpt
namespace lab2.Migrations
{
    /// <inheritdoc />
    public partial class CreateSearchFunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
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
                    ");

            migrationBuilder.Sql(@"
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
                            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS SearchByArtist(TEXT);");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS SearchByAlbumsAndSongsCollections(TEXT);");
        }
    }
}
