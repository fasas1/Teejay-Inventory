using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeejayInventory.Migrations
{
    /// <inheritdoc />
    public partial class NewStockModelToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 31, 9, 40, 25, 842, DateTimeKind.Utc).AddTicks(9031));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2024, 10, 31, 9, 40, 25, 842, DateTimeKind.Utc).AddTicks(8987));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "TransactionDate",
                value: new DateTime(2024, 10, 31, 9, 40, 25, 842, DateTimeKind.Utc).AddTicks(8991));

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Products_ProductId",
                table: "Stocks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Products_ProductId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks");

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 30, 18, 30, 6, 334, DateTimeKind.Utc).AddTicks(27));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2024, 10, 30, 18, 30, 6, 333, DateTimeKind.Utc).AddTicks(9973));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "TransactionDate",
                value: new DateTime(2024, 10, 30, 18, 30, 6, 333, DateTimeKind.Utc).AddTicks(9977));
        }
    }
}
