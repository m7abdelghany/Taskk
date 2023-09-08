using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taskk.Data.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcountantName",
                table: "debtMangments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcountantName",
                table: "debtMangments");
        }
    }
}
