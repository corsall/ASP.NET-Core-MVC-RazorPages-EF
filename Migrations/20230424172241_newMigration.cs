using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c179007-348b-4741-b0a0-d62837e8b4d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaf84d89-3e71-47a1-8b57-ba1955f1365d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "698b6c78-6373-425c-906f-6b084d86823c", "334af6c4-6ed1-4749-8567-a37f743a80e7", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ffd60cb-929c-47fd-af27-c60700abe1b6", "a67d61ea-573c-4be0-84de-aba7e358540f", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "698b6c78-6373-425c-906f-6b084d86823c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ffd60cb-929c-47fd-af27-c60700abe1b6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c179007-348b-4741-b0a0-d62837e8b4d6", "cce7c9c4-9a27-410b-a83b-068ef0ab35f3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eaf84d89-3e71-47a1-8b57-ba1955f1365d", "802e3e6d-4659-49cd-b8c1-dcf77773b01e", "Administrator", "ADMINISTRATOR" });
        }
    }
}
