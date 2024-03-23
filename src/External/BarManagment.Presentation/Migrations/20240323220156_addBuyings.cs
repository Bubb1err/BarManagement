using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarManagment.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addBuyings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buying",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommodityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableAmount = table.Column<double>(type: "float", nullable: false),
                    PurchaseAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buying", x => x.Id);
                    table.CheckConstraint("CK_BuyingAvailableAmount_GreaterOrEqualZero", "AvailableAmount >= 0");
                    table.CheckConstraint("CK_BuyingPurchaseAmount_GreaterOrEqualZero", "PurchaseAmount >= 0");
                    table.ForeignKey(
                        name: "FK_Buying_Commodity_CommodityId",
                        column: x => x.CommodityId,
                        principalTable: "Commodity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buying_CommodityId",
                table: "Buying",
                column: "CommodityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buying");
        }
    }
}
