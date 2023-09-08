using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taskk.Data.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfDebt",
                table: "debtMangments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfDebt",
                table: "debtMangments");
        }
    }
}
