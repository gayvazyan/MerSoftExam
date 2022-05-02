using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopAppMerSoftExam.Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GrupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDb_GrupDb_GrupId",
                        column: x => x.GrupId,
                        principalTable: "GrupDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Overhead = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<int>(type: "int", nullable: false),
                    ValideDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItemDb_OrderDb_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<int>(type: "int", nullable: false),
                    DiscountedPrice = table.Column<int>(type: "int", nullable: false),
                    ChekNumber = table.Column<int>(type: "int", nullable: false),
                    Overhead = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ValideDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleDb_ClientDb_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleDb_OrderItemDb_ProductId",
                        column: x => x.ProductId,
                        principalTable: "OrderItemDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDb_OrderId",
                table: "OrderItemDb",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDb_GrupId",
                table: "ProductDb",
                column: "GrupId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDb_ClientId",
                table: "SaleDb",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDb_ProductId",
                table: "SaleDb",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDb");

            migrationBuilder.DropTable(
                name: "SaleDb");

            migrationBuilder.DropTable(
                name: "GrupDb");

            migrationBuilder.DropTable(
                name: "ClientDb");

            migrationBuilder.DropTable(
                name: "OrderItemDb");

            migrationBuilder.DropTable(
                name: "OrderDb");
        }
    }
}
