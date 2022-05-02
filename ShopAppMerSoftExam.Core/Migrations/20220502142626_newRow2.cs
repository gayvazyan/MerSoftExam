using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopAppMerSoftExam.Core.Migrations
{
    public partial class newRow2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItemDb_OrderItemDb_ProductId",
                table: "SaleItemDb");

            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "SaleItemDb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SaleItemDb_SaleId",
                table: "SaleItemDb",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItemDb_ProductDb_ProductId",
                table: "SaleItemDb",
                column: "ProductId",
                principalTable: "ProductDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItemDb_SaleDb_SaleId",
                table: "SaleItemDb",
                column: "SaleId",
                principalTable: "SaleDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItemDb_ProductDb_ProductId",
                table: "SaleItemDb");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleItemDb_SaleDb_SaleId",
                table: "SaleItemDb");

            migrationBuilder.DropIndex(
                name: "IX_SaleItemDb_SaleId",
                table: "SaleItemDb");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "SaleItemDb");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItemDb_OrderItemDb_ProductId",
                table: "SaleItemDb",
                column: "ProductId",
                principalTable: "OrderItemDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
