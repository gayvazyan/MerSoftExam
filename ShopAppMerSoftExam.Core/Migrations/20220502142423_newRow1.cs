using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopAppMerSoftExam.Core.Migrations
{
    public partial class newRow1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleDb_OrderItemDb_ProductId",
                table: "SaleDb");

            migrationBuilder.DropIndex(
                name: "IX_SaleDb_ProductId",
                table: "SaleDb");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "SaleDb");

            migrationBuilder.DropColumn(
                name: "DiscountedPrice",
                table: "SaleDb");

            migrationBuilder.DropColumn(
                name: "Overhead",
                table: "SaleDb");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SaleDb");

            migrationBuilder.RenameColumn(
                name: "SalePrice",
                table: "SaleDb",
                newName: "ClientDiscounte");

            migrationBuilder.CreateTable(
                name: "SaleItemDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<int>(type: "int", nullable: false),
                    DiscountedPrice = table.Column<int>(type: "int", nullable: false),
                    ValideDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItemDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleItemDb_OrderItemDb_ProductId",
                        column: x => x.ProductId,
                        principalTable: "OrderItemDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleItemDb_ProductId",
                table: "SaleItemDb",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleItemDb");

            migrationBuilder.RenameColumn(
                name: "ClientDiscounte",
                table: "SaleDb",
                newName: "SalePrice");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "SaleDb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiscountedPrice",
                table: "SaleDb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Overhead",
                table: "SaleDb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SaleDb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SaleDb_ProductId",
                table: "SaleDb",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDb_OrderItemDb_ProductId",
                table: "SaleDb",
                column: "ProductId",
                principalTable: "OrderItemDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
