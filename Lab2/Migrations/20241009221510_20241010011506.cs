using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2.Migrations
{
    /// <inheritdoc />
    public partial class _20241010011506 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_song_songs_collection_songs_SongsId",
                table: "song_songs_collection");

            migrationBuilder.DropForeignKey(
                name: "FK_songs_album_AlbumId",
                table: "songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_songs",
                table: "songs");

            migrationBuilder.RenameTable(
                name: "songs",
                newName: "song");

            migrationBuilder.RenameIndex(
                name: "IX_songs_AlbumId",
                table: "song",
                newName: "IX_song_AlbumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_song",
                table: "song",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_song_album_AlbumId",
                table: "song",
                column: "AlbumId",
                principalTable: "album",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_song_songs_collection_song_SongsId",
                table: "song_songs_collection",
                column: "SongsId",
                principalTable: "song",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_song_album_AlbumId",
                table: "song");

            migrationBuilder.DropForeignKey(
                name: "FK_song_songs_collection_song_SongsId",
                table: "song_songs_collection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_song",
                table: "song");

            migrationBuilder.RenameTable(
                name: "song",
                newName: "songs");

            migrationBuilder.RenameIndex(
                name: "IX_song_AlbumId",
                table: "songs",
                newName: "IX_songs_AlbumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_songs",
                table: "songs",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_song_songs_collection_songs_SongsId",
                table: "song_songs_collection",
                column: "SongsId",
                principalTable: "songs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_songs_album_AlbumId",
                table: "songs",
                column: "AlbumId",
                principalTable: "album",
                principalColumn: "id");
        }
    }
}
