using Microsoft.EntityFrameworkCore.Migrations;

namespace DasharooAPI.Migrations
{
    public partial class RecordGenreV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Records_RecordId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_RecordId",
                table: "Genres");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b8474ae-9f3f-44af-8cf1-b6eedd9b6705");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d90fd45c-f6f9-411a-8e40-9b653de9406c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f276d47d-8057-4e58-88c2-2026b5a411d6");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "Genres");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "RecordId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f276d47d-8057-4e58-88c2-2026b5a411d6", "c5b2d082-8fda-4ca3-829d-abc0fd7be650", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1b8474ae-9f3f-44af-8cf1-b6eedd9b6705", "23085256-3da9-49c8-92e1-58eae5535e45", "Premium_User", "PREMIUM_USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d90fd45c-f6f9-411a-8e40-9b653de9406c", "f20845c1-8583-4c9b-88f1-11204c0e0d69", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_RecordId",
                table: "Genres",
                column: "RecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Records_RecordId",
                table: "Genres",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
