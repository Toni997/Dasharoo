using Microsoft.EntityFrameworkCore.Migrations;

namespace DasharooAPI.Migrations
{
    public partial class SubtleChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "785299ee-756b-4727-b31c-0c66a3ee3763");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b9e2a83-944a-4e3c-a5eb-287eea42a89b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba4df68b-9b66-4d58-9954-e7190cc24450");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "ba4df68b-9b66-4d58-9954-e7190cc24450", "95c8865f-61f9-4ecc-bb54-4f44cdba25d2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "785299ee-756b-4727-b31c-0c66a3ee3763", "948167eb-c3ae-4f3a-9ae3-58505b78cfe7", "Premium_User", "PREMIUM_USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8b9e2a83-944a-4e3c-a5eb-287eea42a89b", "50d6a66e-94e4-4a5f-b356-b34282c15968", "Administrator", "ADMINISTRATOR" });
        }
    }
}
