using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2.Migrations
{
    /// <inheritdoc />
    public partial class _20241010001035 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SongsCollectionId",
                table: "song",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_song_SongsCollectionId",
                table: "song",
                column: "SongsCollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_song_songs_collection_SongsCollectionId",
                table: "song",
                column: "SongsCollectionId",
                principalTable: "songs_collection",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_song_songs_collection_SongsCollectionId",
                table: "song");

            migrationBuilder.DropIndex(
                name: "IX_song_SongsCollectionId",
                table: "song");

            migrationBuilder.DropColumn(
                name: "SongsCollectionId",
                table: "song");
        }
    }
}
