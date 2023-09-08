using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taskk.Data.Migrations
{
    public partial class tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "debtMangments",
                columns: table => new
                {
                    DebtNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateNow = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalDebtValue = table.Column<int>(type: "int", nullable: false),
                    PaidForWho = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_debtMangments", x => x.DebtNumber);
                });

            migrationBuilder.CreateTable(
                name: "debtCalculations",
                columns: table => new
                {
                    DebtCalulationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_debtCalculations", x => x.DebtCalulationId);
                    table.ForeignKey(
                        name: "FK_debtCalculations_debtMangments_DebtID",
                        column: x => x.DebtID,
                        principalTable: "debtMangments",
                        principalColumn: "DebtNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_debtCalculations_DebtID",
                table: "debtCalculations",
                column: "DebtID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "debtCalculations");

            migrationBuilder.DropTable(
                name: "debtMangments");
        }
    }
}
