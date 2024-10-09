using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace lab2.Migrations
{
    /// <inheritdoc />
    public partial class _20241010000459 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "song",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "artist",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    genre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artist", x => x.id);
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

            migrationBuilder.CreateIndex(
                name: "IX_song_AlbumId",
                table: "song",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_album_ArtistId",
                table: "album",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_song_album_AlbumId",
                table: "song",
                column: "AlbumId",
                principalTable: "album",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_song_album_AlbumId",
                table: "song");

            migrationBuilder.DropTable(
                name: "album");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "artist");

            migrationBuilder.DropIndex(
                name: "IX_song_AlbumId",
                table: "song");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "song");
        }
    }
}
