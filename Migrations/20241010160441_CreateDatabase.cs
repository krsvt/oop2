using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace lab2.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlbumAndCollectionSearchResults",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ArtistSearchResults",
                columns: table => new
                {
                    artist_id = table.Column<int>(type: "integer", nullable: false),
                    artist_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "songs_collection",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_songs_collection", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "artist",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artist", x => x.id);
                    table.ForeignKey(
                        name: "FK_artist_genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genre",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "album",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    ArtistId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_album", x => x.id);
                    table.ForeignKey(
                        name: "FK_album_artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "artist",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "song",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    AlbumId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_song", x => x.id);
                    table.ForeignKey(
                        name: "FK_song_album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "album",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "song_songs_collection",
                columns: table => new
                {
                    SongsCollectionsId = table.Column<int>(type: "integer", nullable: false),
                    SongsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_song_songs_collection", x => new { x.SongsCollectionsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_song_songs_collection_song_SongsId",
                        column: x => x.SongsId,
                        principalTable: "song",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_song_songs_collection_songs_collection_SongsCollectionsId",
                        column: x => x.SongsCollectionsId,
                        principalTable: "songs_collection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_album_ArtistId",
                table: "album",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_artist_GenreId",
                table: "artist",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_song_AlbumId",
                table: "song",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_song_songs_collection_SongsId",
                table: "song_songs_collection",
                column: "SongsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumAndCollectionSearchResults");

            migrationBuilder.DropTable(
                name: "ArtistSearchResults");

            migrationBuilder.DropTable(
                name: "song_songs_collection");

            migrationBuilder.DropTable(
                name: "song");

            migrationBuilder.DropTable(
                name: "songs_collection");

            migrationBuilder.DropTable(
                name: "album");

            migrationBuilder.DropTable(
                name: "artist");

            migrationBuilder.DropTable(
                name: "genre");
        }
    }
}
