using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppShop.Business.Migrations
{
    /// <inheritdoc />
    public partial class shop003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderBuy_Product_ProductEntityId",
                table: "OrderBuy");

            migrationBuilder.DropIndex(
                name: "IX_OrderBuy_ProductEntityId",
                table: "OrderBuy");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "OrderBuy");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "OrderBuy");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderBuy");

            migrationBuilder.DropColumn(
                name: "ProductEntityId",
                table: "OrderBuy");

            migrationBuilder.DropColumn(
                name: "TimeDelivery",
                table: "OrderBuy");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrder",
                table: "OrderBuy",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AddColumn<decimal>(
                name: "TrackingCode",
                table: "OrderBuy",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 1000m);

            migrationBuilder.CreateTable(
                name: "ItemBuyMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    OrderBuyEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBuyMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemBuyMapping_OrderBuy_OrderBuyEntityId",
                        column: x => x.OrderBuyEntityId,
                        principalTable: "OrderBuy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderBuyStatues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    DateStatues = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Statues = table.Column<int>(type: "int", nullable: false),
                    OrderBuyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderBuyStatues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderBuyStatues_OrderBuy_OrderBuyId",
                        column: x => x.OrderBuyId,
                        principalTable: "OrderBuy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemBuyMapping_OrderBuyEntityId",
                table: "ItemBuyMapping",
                column: "OrderBuyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBuyStatues_OrderBuyId",
                table: "OrderBuyStatues",
                column: "OrderBuyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemBuyMapping");

            migrationBuilder.DropTable(
                name: "OrderBuyStatues");

            migrationBuilder.DropColumn(
                name: "TrackingCode",
                table: "OrderBuy");

            migrationBuilder.AlterColumn<string>(
                name: "DateOrder",
                table: "OrderBuy",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "OrderBuy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "OrderBuy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "OrderBuy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductEntityId",
                table: "OrderBuy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TimeDelivery",
                table: "OrderBuy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBuy_ProductEntityId",
                table: "OrderBuy",
                column: "ProductEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderBuy_Product_ProductEntityId",
                table: "OrderBuy",
                column: "ProductEntityId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
