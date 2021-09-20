using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DasharooAPI.Migrations
{
    public partial class AddedRefreshTokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8088034-e68b-4532-96da-dad3edbb7d48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abaacdcb-5a8a-4ee5-89d5-21e7860d6287");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdfc1dc4-33c9-40fa-aa5d-8f54d58e2f5d");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd28cf0b-9f0c-4e78-b33c-1b87d5cdc238", "06cd8a81-e885-42b2-a258-eaf2f9a6290c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b6cd1e4-67f1-4e5c-bcbd-3b53a81efa99", "436ba919-d201-42ff-8819-5e088e67efbf", "Premium_User", "PREMIUM_USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b7ee8368-2295-4b82-a678-e3bb8e9ae7ea", "d615c72e-3d69-420b-8f59-51f6abf56136", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b6cd1e4-67f1-4e5c-bcbd-3b53a81efa99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7ee8368-2295-4b82-a678-e3bb8e9ae7ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd28cf0b-9f0c-4e78-b33c-1b87d5cdc238");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "abaacdcb-5a8a-4ee5-89d5-21e7860d6287", "c5fac506-15ea-4c14-a6f5-c405acf010f5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8088034-e68b-4532-96da-dad3edbb7d48", "2d713028-d747-4c39-b4bf-3fa0ff708296", "Premium_User", "PREMIUM_USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cdfc1dc4-33c9-40fa-aa5d-8f54d58e2f5d", "19160b1c-231d-41ed-8bfe-ea9792d4f5c7", "Administrator", "ADMINISTRATOR" });
        }
    }
}
