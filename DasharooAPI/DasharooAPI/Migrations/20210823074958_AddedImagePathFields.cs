using Microsoft.EntityFrameworkCore.Migrations;

namespace DasharooAPI.Migrations
{
    public partial class AddedImagePathFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Records",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginalPlaylistId",
                table: "Records",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BackgroundPath",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BackgroundPath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "IX_Records_OriginalPlaylistId",
                table: "Records",
                column: "OriginalPlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Playlists_OriginalPlaylistId",
                table: "Records",
                column: "OriginalPlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Playlists_OriginalPlaylistId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_OriginalPlaylistId",
                table: "Records");

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

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "OriginalPlaylistId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "BackgroundPath",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "BackgroundPath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AspNetUsers");

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
        }
    }
}
