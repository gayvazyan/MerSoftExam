using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopAppMerSoftExam.Core.Migrations
{
    public partial class changeRowType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValideDate",
                table: "SaleItemDb");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "SaleItemDb",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "SaleItemDb");

            migrationBuilder.AddColumn<DateTime>(
                name: "ValideDate",
                table: "SaleItemDb",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
