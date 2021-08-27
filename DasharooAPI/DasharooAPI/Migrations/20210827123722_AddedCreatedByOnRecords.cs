using Microsoft.EntityFrameworkCore.Migrations;

namespace DasharooAPI.Migrations
{
    public partial class AddedCreatedByOnRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Records",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c659524-9f45-4212-8163-a7a9f150a988", "c66e4d31-db75-4fcb-9d5d-1ea84081010c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0225cd8b-b53b-4a20-a104-92067175c7fd", "7135af62-f821-47d1-a6a2-40a8d53974d9", "Premium_User", "PREMIUM_USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ca689af-1f8b-4e94-abcf-88c945da3938", "f0e05fe6-aa37-4b13-a24e-78b69ddcdd3d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Records_CreatedById",
                table: "Records",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_AspNetUsers_CreatedById",
                table: "Records",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_AspNetUsers_CreatedById",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_CreatedById",
                table: "Records");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0225cd8b-b53b-4a20-a104-92067175c7fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c659524-9f45-4212-8163-a7a9f150a988");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ca689af-1f8b-4e94-abcf-88c945da3938");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Records");

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
        }
    }
}
