using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2.Migrations
{
    /// <inheritdoc />
    public partial class _20241010002919 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_song_album_AlbumId",
                table: "song");

            migrationBuilder.DropForeignKey(
                name: "FK_song_songs_collection_SongsCollectionId",
                table: "song");

            migrationBuilder.DropPrimaryKey(
                name: "PK_song",
                table: "song");

            migrationBuilder.DropIndex(
                name: "IX_song_SongsCollectionId",
                table: "song");

            migrationBuilder.DropColumn(
                name: "SongsCollectionId",
                table: "song");

            migrationBuilder.DropColumn(
                name: "genre",
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
                        name: "FK_song_songs_collection_songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "songs",
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
                name: "IX_song_songs_collection_SongsId",
                table: "song_songs_collection",
                column: "SongsId");

            migrationBuilder.AddForeignKey(
                name: "FK_songs_album_AlbumId",
                table: "songs",
                column: "AlbumId",
                principalTable: "album",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_songs_album_AlbumId",
                table: "songs");

            migrationBuilder.DropTable(
                name: "song_songs_collection");

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

            migrationBuilder.AddColumn<int>(
                name: "SongsCollectionId",
                table: "song",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "genre",
                table: "song",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_song",
                table: "song",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_song_SongsCollectionId",
                table: "song",
                column: "SongsCollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_song_album_AlbumId",
                table: "song",
                column: "AlbumId",
                principalTable: "album",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_song_songs_collection_SongsCollectionId",
                table: "song",
                column: "SongsCollectionId",
                principalTable: "songs_collection",
                principalColumn: "id");
        }
    }
}
