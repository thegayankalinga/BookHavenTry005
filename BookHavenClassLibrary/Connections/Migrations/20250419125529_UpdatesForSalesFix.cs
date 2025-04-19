using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHavenClassLibrary.Connections.Migrations
{
    /// <inheritdoc />
    public partial class UpdatesForSalesFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_SaleItems_SaleItemId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_SaleItemId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SaleItemId",
                table: "Sales");

            migrationBuilder.AddColumn<DateTime>(
                name: "SaleDate",
                table: "Sales",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SalesId",
                table: "SaleItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_SalesId",
                table: "SaleItems",
                column: "SalesId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_Sales_SalesId",
                table: "SaleItems",
                column: "SalesId",
                principalTable: "Sales",
                principalColumn: "SalesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_Sales_SalesId",
                table: "SaleItems");

            migrationBuilder.DropIndex(
                name: "IX_SaleItems_SalesId",
                table: "SaleItems");

            migrationBuilder.DropColumn(
                name: "SaleDate",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SalesId",
                table: "SaleItems");

            migrationBuilder.AddColumn<int>(
                name: "SaleItemId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SaleItemId",
                table: "Sales",
                column: "SaleItemId",
                unique: true,
                filter: "[SaleItemId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_SaleItems_SaleItemId",
                table: "Sales",
                column: "SaleItemId",
                principalTable: "SaleItems",
                principalColumn: "SaleItemId");
        }
    }
}
