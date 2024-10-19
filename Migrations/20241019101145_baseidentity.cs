using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2.Migrations
{
    /// <inheritdoc />
    public partial class baseidentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "songs_collection",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "song",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "genre",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "artist",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "album",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "AlbumAndCollectionSearchResultDto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ArtistSearchResults",
                columns: table => new
                {
                    artist_id = table.Column<int>(type: "integer", nullable: false),
                    artist_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumAndCollectionSearchResultDto");

            migrationBuilder.DropTable(
                name: "ArtistSearchResults");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "songs_collection",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "song",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "genre",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "artist",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "album",
                newName: "id");
        }
    }
}
