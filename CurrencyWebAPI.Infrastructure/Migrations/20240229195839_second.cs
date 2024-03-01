using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyWebAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyDetailDailys",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Value = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    AvarageValue = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    MaxValue = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    MinValue = table.Column<string>(type: "VARCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyDetailDailys", x => new { x.CurrencyId, x.Date });
                    table.ForeignKey(
                        name: "FK_CurrencyDetailDailys_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyDetailHourlys",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Value = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    AvarageValue = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    MaxValue = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    MinValue = table.Column<string>(type: "VARCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyDetailHourlys", x => new { x.CurrencyId, x.Date });
                    table.ForeignKey(
                        name: "FK_CurrencyDetailHourlys_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyDetailDailys");

            migrationBuilder.DropTable(
                name: "CurrencyDetailHourlys");
        }
    }
}
