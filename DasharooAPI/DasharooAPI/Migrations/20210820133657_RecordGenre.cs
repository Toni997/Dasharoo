using Microsoft.EntityFrameworkCore.Migrations;

namespace DasharooAPI.Migrations
{
    public partial class RecordGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistRecord_Playlists_PlaylistsId",
                table: "PlaylistRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_AspNetUsers_AuthorId",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Visibility_VisibilityId",
                table: "Playlists");

            migrationBuilder.DropTable(
                name: "GenreRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Playlists",
                table: "Playlists");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8437e347-3a3e-462b-8f92-2a16e79c84bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7c8fcbf-4e6d-4034-bc7c-984a0b7e8fd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d91114e8-35e0-4005-a864-972da3dfe629");

            migrationBuilder.RenameTable(
                name: "Playlists",
                newName: "Playlist");

            migrationBuilder.RenameIndex(
                name: "IX_Playlists_VisibilityId",
                table: "Playlist",
                newName: "IX_Playlist_VisibilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Playlists_AuthorId",
                table: "Playlist",
                newName: "IX_Playlist_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playlist",
                table: "Playlist",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RecordGenre",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordGenre", x => new { x.RecordId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_RecordGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordGenre_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba4df68b-9b66-4d58-9954-e7190cc24450", "95c8865f-61f9-4ecc-bb54-4f44cdba25d2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "785299ee-756b-4727-b31c-0c66a3ee3763", "948167eb-c3ae-4f3a-9ae3-58505b78cfe7", "Premium_User", "PREMIUM_USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8b9e2a83-944a-4e3c-a5eb-287eea42a89b", "50d6a66e-94e4-4a5f-b356-b34282c15968", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_RecordGenre_GenreId",
                table: "RecordGenre",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_AspNetUsers_AuthorId",
                table: "Playlist",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_Visibility_VisibilityId",
                table: "Playlist",
                column: "VisibilityId",
                principalTable: "Visibility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistRecord_Playlist_PlaylistsId",
                table: "PlaylistRecord",
                column: "PlaylistsId",
                principalTable: "Playlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_AspNetUsers_AuthorId",
                table: "Playlist");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_Visibility_VisibilityId",
                table: "Playlist");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistRecord_Playlist_PlaylistsId",
                table: "PlaylistRecord");

            migrationBuilder.DropTable(
                name: "RecordGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Playlist",
                table: "Playlist");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "785299ee-756b-4727-b31c-0c66a3ee3763");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b9e2a83-944a-4e3c-a5eb-287eea42a89b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba4df68b-9b66-4d58-9954-e7190cc24450");

            migrationBuilder.RenameTable(
                name: "Playlist",
                newName: "Playlists");

            migrationBuilder.RenameIndex(
                name: "IX_Playlist_VisibilityId",
                table: "Playlists",
                newName: "IX_Playlists_VisibilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Playlist_AuthorId",
                table: "Playlists",
                newName: "IX_Playlists_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playlists",
                table: "Playlists",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GenreRecord",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    RecordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreRecord", x => new { x.GenresId, x.RecordsId });
                    table.ForeignKey(
                        name: "FK_GenreRecord_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreRecord_Records_RecordsId",
                        column: x => x.RecordsId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d91114e8-35e0-4005-a864-972da3dfe629", "08cca114-6fd5-4b52-b239-58fcba897961", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8437e347-3a3e-462b-8f92-2a16e79c84bc", "d1969dd5-ae34-4242-9983-c95d480aebc2", "Premium_User", "PREMIUM_USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7c8fcbf-4e6d-4034-bc7c-984a0b7e8fd3", "ae429126-678c-4df8-b45e-96e37b921402", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_GenreRecord_RecordsId",
                table: "GenreRecord",
                column: "RecordsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistRecord_Playlists_PlaylistsId",
                table: "PlaylistRecord",
                column: "PlaylistsId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_AspNetUsers_AuthorId",
                table: "Playlists",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Visibility_VisibilityId",
                table: "Playlists",
                column: "VisibilityId",
                principalTable: "Visibility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
