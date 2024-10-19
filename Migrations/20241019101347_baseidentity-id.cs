using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2.Migrations
{
    /// <inheritdoc />
    public partial class baseidentityid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
