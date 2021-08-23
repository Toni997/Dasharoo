using Microsoft.EntityFrameworkCore.Migrations;

namespace DasharooAPI.Migrations
{
    public partial class AuthorFollower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "AuthorFollower",
                columns: table => new
                {
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FollowerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorFollower", x => new { x.AuthorId, x.FollowerId });
                    table.ForeignKey(
                        name: "FK_AuthorFollower_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorFollower_AspNetUsers_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AuthorFollower_FollowerId",
                table: "AuthorFollower",
                column: "FollowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorFollower");

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
        }
    }
}
