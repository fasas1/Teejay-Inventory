using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeejayInventory.Migrations
{
    /// <inheritdoc />
    public partial class AddNewModelToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Warehouse_WarehouseId",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Warehouse",
                newName: "Warehouses");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Stock",
                newName: "Stocks");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_WarehouseId",
                table: "Stocks",
                newName: "IX_Stocks_WarehouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses",
                column: "WarehouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "TransactionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "SupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "StockId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Warehouses_WarehouseId",
                table: "Stocks",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Warehouses_WarehouseId",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Warehouses",
                newName: "Warehouse");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Supplier");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "Stock");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_WarehouseId",
                table: "Stock",
                newName: "IX_Stock_WarehouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "WarehouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "TransactionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "SupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "StockId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryId");

            migrationBuilder.UpdateData(
                table: "Stock",
                keyColumn: "StockId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 27, 14, 37, 15, 799, DateTimeKind.Utc).AddTicks(813));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2024, 10, 27, 14, 37, 15, 799, DateTimeKind.Utc).AddTicks(603));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "TransactionDate",
                value: new DateTime(2024, 10, 27, 14, 37, 15, 799, DateTimeKind.Utc).AddTicks(609));

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Warehouse_WarehouseId",
                table: "Stock",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
