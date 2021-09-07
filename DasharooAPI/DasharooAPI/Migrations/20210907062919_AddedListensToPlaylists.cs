using Microsoft.EntityFrameworkCore.Migrations;

namespace DasharooAPI.Migrations
{
    public partial class AddedListensToPlaylists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<decimal>(
                name: "Listens",
                table: "Playlists",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Listens",
                table: "Playlists");

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
    }
}
