using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HappyTrade.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    BalanceId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Fund = table.Column<decimal>(nullable: false),
                    BalanceTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.BalanceId);
                });

            migrationBuilder.CreateTable(
                name: "HoldingStocks",
                columns: table => new
                {
                    HoldingStockId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Symbol = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Shares = table.Column<int>(nullable: false),
                    AveragePrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoldingStocks", x => x.HoldingStockId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Symbol = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Shares = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    TransTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "WatchingStocks",
                columns: table => new
                {
                    WatchingStockId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchingStocks", x => x.WatchingStockId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DropTable(
                name: "HoldingStocks");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "WatchingStocks");
        }
    }
}
