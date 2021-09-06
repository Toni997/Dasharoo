using Microsoft.EntityFrameworkCore.Migrations;

namespace DasharooAPI.Migrations
{
    public partial class AddedArtistName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "ArtistName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f61ffed-4edb-42e1-ad15-da95b344c644", "9082b10e-6e93-4812-80f7-89ecd487cc40", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a47cff96-dc06-41cd-9b9c-368088689197", "2f5d8e3d-1b28-4410-b6f7-da0efbfe842c", "Premium_User", "PREMIUM_USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d885a605-711a-420e-98bd-586aebb02f89", "cb10ef77-34ec-4e61-918f-3fb90f48e3f6", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f61ffed-4edb-42e1-ad15-da95b344c644");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a47cff96-dc06-41cd-9b9c-368088689197");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d885a605-711a-420e-98bd-586aebb02f89");

            migrationBuilder.DropColumn(
                name: "ArtistName",
                table: "AspNetUsers");

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
        }
    }
}
