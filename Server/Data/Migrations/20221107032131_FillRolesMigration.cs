using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Speed.Server.Data.Migrations
{
    public partial class FillRolesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c662762f-1c8a-4b77-9eb6-acd2774a0d3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e06b40dc-eef3-4804-a3d6-7e7ee076b7dd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54a23b50-4e81-43f0-8234-ab83e2b7ca56", "aa3af1d7-7231-41fc-9ec5-e45fd24f0dcb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc235f51-7bc9-494a-8fca-f5e3cfe59f9a", "c846461a-bf96-47fe-84a9-7a6c671c9d95", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54a23b50-4e81-43f0-8234-ab83e2b7ca56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc235f51-7bc9-494a-8fca-f5e3cfe59f9a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c662762f-1c8a-4b77-9eb6-acd2774a0d3e", "9adbf07f-9c2a-4d39-a28b-0f71ee1cb852", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e06b40dc-eef3-4804-a3d6-7e7ee076b7dd", "70a197ab-de61-4faf-b488-843bcc928d14", "Admin", "ADMIN" });
        }
    }
}
