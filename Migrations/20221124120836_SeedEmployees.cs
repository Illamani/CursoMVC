using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIndio.Migrations
{
    public partial class SeedEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 1, 2, "gurmiax@gmail.com", "Ezequiel" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
