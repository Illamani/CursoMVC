using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIndio.Migrations
{
    public partial class AlterEmployeeSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "Peter@gmail.com", "Peter" });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 2, 3, "John@gmail.com", "John" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "gurmiax@gmail.com", "Ezequiel" });
        }
    }
}
