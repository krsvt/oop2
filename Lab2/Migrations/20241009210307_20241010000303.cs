using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2.Migrations
{
    /// <inheritdoc />
    public partial class _20241010000303 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "song",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "song",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "genre",
                table: "song",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "genre",
                table: "song");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "song",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "song",
                newName: "Id");
        }
    }
}
