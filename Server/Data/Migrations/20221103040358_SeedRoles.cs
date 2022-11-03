using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Speed.Server.Data.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "982d211b-0a47-401b-bdf3-dd2bf2a6f067", "8bb42180-b2c6-4807-b710-118bd39f07f2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae0f162e-8edb-4e27-9fe5-bd42d0a03239", "178b7e5d-721e-40a4-8d97-2f834b85d404", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "982d211b-0a47-401b-bdf3-dd2bf2a6f067");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae0f162e-8edb-4e27-9fe5-bd42d0a03239");
        }
    }
}
