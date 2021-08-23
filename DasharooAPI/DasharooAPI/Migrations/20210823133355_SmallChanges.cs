using Microsoft.EntityFrameworkCore.Migrations;

namespace DasharooAPI.Migrations
{
    public partial class SmallChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorFollower_AspNetUsers_AuthorId",
                table: "AuthorFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorFollower_AspNetUsers_FollowerId",
                table: "AuthorFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordAuthor_AspNetUsers_AuthorId",
                table: "RecordAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordAuthor_Records_RecordId",
                table: "RecordAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordPlaylist_Playlists_PlaylistId",
                table: "RecordPlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordPlaylist_Records_RecordId",
                table: "RecordPlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordSupporter_AspNetUsers_SupporterId",
                table: "RecordSupporter");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordSupporter_Records_RecordId",
                table: "RecordSupporter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordSupporter",
                table: "RecordSupporter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordPlaylist",
                table: "RecordPlaylist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordAuthor",
                table: "RecordAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorFollower",
                table: "AuthorFollower");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7bc237d-37c1-41a0-b8d7-d27209b308fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfe97351-cab5-4ff7-94c1-80ed819466b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2a33d33-fd82-4c46-a11b-7882e6607582");

            migrationBuilder.RenameTable(
                name: "RecordSupporter",
                newName: "RecordSupporters");

            migrationBuilder.RenameTable(
                name: "RecordPlaylist",
                newName: "RecordPlaylists");

            migrationBuilder.RenameTable(
                name: "RecordAuthor",
                newName: "RecordAuthors");

            migrationBuilder.RenameTable(
                name: "AuthorFollower",
                newName: "AuthorFollowers");

            migrationBuilder.RenameIndex(
                name: "IX_RecordSupporter_SupporterId",
                table: "RecordSupporters",
                newName: "IX_RecordSupporters_SupporterId");

            migrationBuilder.RenameIndex(
                name: "IX_RecordPlaylist_PlaylistId",
                table: "RecordPlaylists",
                newName: "IX_RecordPlaylists_PlaylistId");

            migrationBuilder.RenameIndex(
                name: "IX_RecordAuthor_AuthorId",
                table: "RecordAuthors",
                newName: "IX_RecordAuthors_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorFollower_FollowerId",
                table: "AuthorFollowers",
                newName: "IX_AuthorFollowers_FollowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordSupporters",
                table: "RecordSupporters",
                columns: new[] { "RecordId", "SupporterId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordPlaylists",
                table: "RecordPlaylists",
                columns: new[] { "RecordId", "PlaylistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordAuthors",
                table: "RecordAuthors",
                columns: new[] { "RecordId", "AuthorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorFollowers",
                table: "AuthorFollowers",
                columns: new[] { "AuthorId", "FollowerId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9e7f5b23-caed-4be5-9af9-2853f690fcb3", "54263d66-181c-4aeb-873e-f3f871668d47", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aec4e3f8-b392-41bc-969a-e9b0867c6fac", "5ab38c2e-8b0c-4269-85ba-f7554a785e3f", "Premium_User", "PREMIUM_USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8caf3b8c-1c91-42b6-8729-0acb804ccfd5", "28dde8fb-85cb-4155-8dfc-420a086e8f19", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorFollowers_AspNetUsers_AuthorId",
                table: "AuthorFollowers",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorFollowers_AspNetUsers_FollowerId",
                table: "AuthorFollowers",
                column: "FollowerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordAuthors_AspNetUsers_AuthorId",
                table: "RecordAuthors",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordAuthors_Records_RecordId",
                table: "RecordAuthors",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordPlaylists_Playlists_PlaylistId",
                table: "RecordPlaylists",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordPlaylists_Records_RecordId",
                table: "RecordPlaylists",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordSupporters_AspNetUsers_SupporterId",
                table: "RecordSupporters",
                column: "SupporterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordSupporters_Records_RecordId",
                table: "RecordSupporters",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorFollowers_AspNetUsers_AuthorId",
                table: "AuthorFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorFollowers_AspNetUsers_FollowerId",
                table: "AuthorFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordAuthors_AspNetUsers_AuthorId",
                table: "RecordAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordAuthors_Records_RecordId",
                table: "RecordAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordPlaylists_Playlists_PlaylistId",
                table: "RecordPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordPlaylists_Records_RecordId",
                table: "RecordPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordSupporters_AspNetUsers_SupporterId",
                table: "RecordSupporters");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordSupporters_Records_RecordId",
                table: "RecordSupporters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordSupporters",
                table: "RecordSupporters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordPlaylists",
                table: "RecordPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordAuthors",
                table: "RecordAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorFollowers",
                table: "AuthorFollowers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8caf3b8c-1c91-42b6-8729-0acb804ccfd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e7f5b23-caed-4be5-9af9-2853f690fcb3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec4e3f8-b392-41bc-969a-e9b0867c6fac");

            migrationBuilder.RenameTable(
                name: "RecordSupporters",
                newName: "RecordSupporter");

            migrationBuilder.RenameTable(
                name: "RecordPlaylists",
                newName: "RecordPlaylist");

            migrationBuilder.RenameTable(
                name: "RecordAuthors",
                newName: "RecordAuthor");

            migrationBuilder.RenameTable(
                name: "AuthorFollowers",
                newName: "AuthorFollower");

            migrationBuilder.RenameIndex(
                name: "IX_RecordSupporters_SupporterId",
                table: "RecordSupporter",
                newName: "IX_RecordSupporter_SupporterId");

            migrationBuilder.RenameIndex(
                name: "IX_RecordPlaylists_PlaylistId",
                table: "RecordPlaylist",
                newName: "IX_RecordPlaylist_PlaylistId");

            migrationBuilder.RenameIndex(
                name: "IX_RecordAuthors_AuthorId",
                table: "RecordAuthor",
                newName: "IX_RecordAuthor_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorFollowers_FollowerId",
                table: "AuthorFollower",
                newName: "IX_AuthorFollower_FollowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordSupporter",
                table: "RecordSupporter",
                columns: new[] { "RecordId", "SupporterId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordPlaylist",
                table: "RecordPlaylist",
                columns: new[] { "RecordId", "PlaylistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordAuthor",
                table: "RecordAuthor",
                columns: new[] { "RecordId", "AuthorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorFollower",
                table: "AuthorFollower",
                columns: new[] { "AuthorId", "FollowerId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dfe97351-cab5-4ff7-94c1-80ed819466b9", "985e4066-6f79-4196-bf3a-17757ba8cc6e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7bc237d-37c1-41a0-b8d7-d27209b308fe", "b1c0bd48-abb4-4ac3-83ee-f7609e364e32", "Premium_User", "PREMIUM_USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e2a33d33-fd82-4c46-a11b-7882e6607582", "24edc0a8-2360-4a70-aab0-01fa68f66581", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorFollower_AspNetUsers_AuthorId",
                table: "AuthorFollower",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorFollower_AspNetUsers_FollowerId",
                table: "AuthorFollower",
                column: "FollowerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordAuthor_AspNetUsers_AuthorId",
                table: "RecordAuthor",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordAuthor_Records_RecordId",
                table: "RecordAuthor",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordPlaylist_Playlists_PlaylistId",
                table: "RecordPlaylist",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordPlaylist_Records_RecordId",
                table: "RecordPlaylist",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordSupporter_AspNetUsers_SupporterId",
                table: "RecordSupporter",
                column: "SupporterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordSupporter_Records_RecordId",
                table: "RecordSupporter",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
