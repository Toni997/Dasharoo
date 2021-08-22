using Microsoft.EntityFrameworkCore.Migrations;

namespace DasharooAPI.Migrations
{
    public partial class RecordGenreV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_RecordGenre_Genres_GenreId",
                table: "RecordGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordGenre_Records_RecordId",
                table: "RecordGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordGenre",
                table: "RecordGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Playlist",
                table: "Playlist");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f97e5e6-2117-4cb0-b8e9-fefd14fd170a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e4c3769-39dd-4448-9e34-a4d45cc97afd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a28cc53b-3df9-4274-89dd-e991ae7810e9");

            migrationBuilder.RenameTable(
                name: "RecordGenre",
                newName: "RecordGenres");

            migrationBuilder.RenameTable(
                name: "Playlist",
                newName: "Playlists");

            migrationBuilder.RenameIndex(
                name: "IX_RecordGenre_GenreId",
                table: "RecordGenres",
                newName: "IX_RecordGenres_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Playlist_VisibilityId",
                table: "Playlists",
                newName: "IX_Playlists_VisibilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Playlist_AuthorId",
                table: "Playlists",
                newName: "IX_Playlists_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordGenres",
                table: "RecordGenres",
                columns: new[] { "RecordId", "GenreId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playlists",
                table: "Playlists",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5f33d45-7b1c-4fe1-a794-28f149ee0109", "701aeed1-d974-4576-8c54-ffa3af53c2bc", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e66d1149-b2a9-4735-a30e-af70294af102", "8e0e51cd-6dc0-490c-b3a5-e4ad15c403ea", "Premium_User", "PREMIUM_USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e535fee-561b-4242-b926-2c4f53fbf61e", "964cdfb6-1edd-4762-b2b4-b51770f33525", "Administrator", "ADMINISTRATOR" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_RecordGenres_Genres_GenreId",
                table: "RecordGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordGenres_Records_RecordId",
                table: "RecordGenres",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_RecordGenres_Genres_GenreId",
                table: "RecordGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordGenres_Records_RecordId",
                table: "RecordGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordGenres",
                table: "RecordGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Playlists",
                table: "Playlists");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e535fee-561b-4242-b926-2c4f53fbf61e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e66d1149-b2a9-4735-a30e-af70294af102");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5f33d45-7b1c-4fe1-a794-28f149ee0109");

            migrationBuilder.RenameTable(
                name: "RecordGenres",
                newName: "RecordGenre");

            migrationBuilder.RenameTable(
                name: "Playlists",
                newName: "Playlist");

            migrationBuilder.RenameIndex(
                name: "IX_RecordGenres_GenreId",
                table: "RecordGenre",
                newName: "IX_RecordGenre_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Playlists_VisibilityId",
                table: "Playlist",
                newName: "IX_Playlist_VisibilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Playlists_AuthorId",
                table: "Playlist",
                newName: "IX_Playlist_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordGenre",
                table: "RecordGenre",
                columns: new[] { "RecordId", "GenreId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playlist",
                table: "Playlist",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a28cc53b-3df9-4274-89dd-e991ae7810e9", "0c56d497-5643-4202-b534-5d413f90446f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e4c3769-39dd-4448-9e34-a4d45cc97afd", "e023779e-ab86-4fa3-97b8-2389ebb918f9", "Premium_User", "PREMIUM_USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f97e5e6-2117-4cb0-b8e9-fefd14fd170a", "469b59a2-3ad2-4352-8537-db407a86d8be", "Administrator", "ADMINISTRATOR" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_RecordGenre_Genres_GenreId",
                table: "RecordGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordGenre_Records_RecordId",
                table: "RecordGenre",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
