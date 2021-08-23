using Microsoft.EntityFrameworkCore.Migrations;

namespace DasharooAPI.Migrations
{
    public partial class SetUpAllManyToManyTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistRecord");

            migrationBuilder.DropTable(
                name: "RecordUser");

            migrationBuilder.DropTable(
                name: "RecordUser1");

            migrationBuilder.DropTable(
                name: "UserUser");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "773c2a6d-a377-44fe-bb6c-23ff424a167e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d11514c-e5c0-4ade-a049-ed52bdc9ddfb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa108de1-dfc4-4277-a777-72110ca4f8d3");

            migrationBuilder.CreateTable(
                name: "RecordAuthor",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordAuthor", x => new { x.RecordId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_RecordAuthor_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordAuthor_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecordPlaylist",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    PlaylistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordPlaylist", x => new { x.RecordId, x.PlaylistId });
                    table.ForeignKey(
                        name: "FK_RecordPlaylist_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordPlaylist_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecordSupporter",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    SupporterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordSupporter", x => new { x.RecordId, x.SupporterId });
                    table.ForeignKey(
                        name: "FK_RecordSupporter_AspNetUsers_SupporterId",
                        column: x => x.SupporterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordSupporter_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6520e8c8-cc2a-4867-ab30-d75766dd2bf3", "ad4afeaf-c94c-4437-ac52-b4a084fdcf0b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e519458d-c71d-43f6-8473-f8aa329d3922", "5be4b3ad-4d6a-4c2f-9b0a-7293de8b60e9", "Premium_User", "PREMIUM_USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18c60b79-3ffa-44ac-a968-ce3dbebe16cf", "dcdca511-b44b-48e1-ae74-f2733337de4a", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_RecordAuthor_AuthorId",
                table: "RecordAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordPlaylist_PlaylistId",
                table: "RecordPlaylist",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordSupporter_SupporterId",
                table: "RecordSupporter",
                column: "SupporterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordAuthor");

            migrationBuilder.DropTable(
                name: "RecordPlaylist");

            migrationBuilder.DropTable(
                name: "RecordSupporter");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c60b79-3ffa-44ac-a968-ce3dbebe16cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6520e8c8-cc2a-4867-ab30-d75766dd2bf3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e519458d-c71d-43f6-8473-f8aa329d3922");

            migrationBuilder.CreateTable(
                name: "PlaylistRecord",
                columns: table => new
                {
                    PlaylistsId = table.Column<int>(type: "int", nullable: false),
                    RecordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistRecord", x => new { x.PlaylistsId, x.RecordsId });
                    table.ForeignKey(
                        name: "FK_PlaylistRecord_Playlists_PlaylistsId",
                        column: x => x.PlaylistsId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistRecord_Records_RecordsId",
                        column: x => x.RecordsId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecordUser",
                columns: table => new
                {
                    AuthorsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordUser", x => new { x.AuthorsId, x.RecordsId });
                    table.ForeignKey(
                        name: "FK_RecordUser_AspNetUsers_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordUser_Records_RecordsId",
                        column: x => x.RecordsId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecordUser1",
                columns: table => new
                {
                    SupportedRecordsId = table.Column<int>(type: "int", nullable: false),
                    SupportersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordUser1", x => new { x.SupportedRecordsId, x.SupportersId });
                    table.ForeignKey(
                        name: "FK_RecordUser1_AspNetUsers_SupportersId",
                        column: x => x.SupportersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordUser1_Records_SupportedRecordsId",
                        column: x => x.SupportedRecordsId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUser",
                columns: table => new
                {
                    FollowersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FollowingsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUser", x => new { x.FollowersId, x.FollowingsId });
                    table.ForeignKey(
                        name: "FK_UserUser_AspNetUsers_FollowersId",
                        column: x => x.FollowersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUser_AspNetUsers_FollowingsId",
                        column: x => x.FollowingsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d11514c-e5c0-4ade-a049-ed52bdc9ddfb", "1d7a3701-fbc9-4001-863b-f75af666c053", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "773c2a6d-a377-44fe-bb6c-23ff424a167e", "7b65ec3a-59cc-41de-b885-d9b3bcf700d3", "Premium_User", "PREMIUM_USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fa108de1-dfc4-4277-a777-72110ca4f8d3", "fb23a97b-72fd-4eba-b5c9-c7c1b401d4c6", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistRecord_RecordsId",
                table: "PlaylistRecord",
                column: "RecordsId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordUser_RecordsId",
                table: "RecordUser",
                column: "RecordsId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordUser1_SupportersId",
                table: "RecordUser1",
                column: "SupportersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUser_FollowingsId",
                table: "UserUser",
                column: "FollowingsId");
        }
    }
}
