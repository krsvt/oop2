using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2.Migrations
{
    /// <inheritdoc />
    public partial class _20241010012132 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "genre",
                table: "artist");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "artist",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_artist_GenreId",
                table: "artist",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_artist_genre_GenreId",
                table: "artist",
                column: "GenreId",
                principalTable: "genre",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_artist_genre_GenreId",
                table: "artist");

            migrationBuilder.DropIndex(
                name: "IX_artist_GenreId",
                table: "artist");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "artist");

            migrationBuilder.AddColumn<string>(
                name: "genre",
                table: "artist",
                type: "text",
                nullable: true);
        }
    }
}
