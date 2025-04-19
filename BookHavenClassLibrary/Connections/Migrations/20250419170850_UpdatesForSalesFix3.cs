using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHavenClassLibrary.Connections.Migrations
{
    /// <inheritdoc />
    public partial class UpdatesForSalesFix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrders_SupplierId",
                table: "SupplierOrders",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierOrders_Suppliers_SupplierId",
                table: "SupplierOrders",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierOrders_Suppliers_SupplierId",
                table: "SupplierOrders");

            migrationBuilder.DropIndex(
                name: "IX_SupplierOrders_SupplierId",
                table: "SupplierOrders");
        }
    }
}
