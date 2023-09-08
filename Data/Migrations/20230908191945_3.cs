using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taskk.Data.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "acountantName",
                table: "debtMangments",
                newName: "TypeOfDept");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeOfDept",
                table: "debtMangments",
                newName: "acountantName");
        }
    }
}
