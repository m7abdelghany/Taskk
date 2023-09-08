using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taskk.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "debtMangments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeOfEvd",
                table: "debtMangments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "acountantName",
                table: "debtMangments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "debtCalculations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "debtMangments");

            migrationBuilder.DropColumn(
                name: "TypeOfEvd",
                table: "debtMangments");

            migrationBuilder.DropColumn(
                name: "acountantName",
                table: "debtMangments");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "debtCalculations");
        }
    }
}
