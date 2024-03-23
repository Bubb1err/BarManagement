using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarManagment.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coctail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coctail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefaultMeasure",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Measure = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultMeasure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commodity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commodity_DefaultMeasure_DefaultMeasureId",
                        column: x => x.DefaultMeasureId,
                        principalTable: "DefaultMeasure",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BarmenSchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReadOnly = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarmenSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarmenSchedule_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaidTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    BarmenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipt_User_BarmenId",
                        column: x => x.BarmenId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoctailIngredient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoctailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommodityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountInDefaultMeasure = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoctailIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoctailIngredient_Coctail_CoctailId",
                        column: x => x.CoctailId,
                        principalTable: "Coctail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoctailIngredient_Commodity_CommodityId",
                        column: x => x.CommodityId,
                        principalTable: "Commodity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Drink",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CommodityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountInDefaultMeasure = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drink_Commodity_CommodityId",
                        column: x => x.CommodityId,
                        principalTable: "Commodity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CoctailReceipt",
                columns: table => new
                {
                    CoctailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoctailReceipt", x => new { x.CoctailsId, x.ReceiptId });
                    table.ForeignKey(
                        name: "FK_CoctailReceipt_Coctail_CoctailsId",
                        column: x => x.CoctailsId,
                        principalTable: "Coctail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoctailReceipt_Receipt_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrinkReceipt",
                columns: table => new
                {
                    DrinksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkReceipt", x => new { x.DrinksId, x.ReceiptId });
                    table.ForeignKey(
                        name: "FK_DrinkReceipt_Drink_DrinksId",
                        column: x => x.DrinksId,
                        principalTable: "Drink",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkReceipt_Receipt_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarmenSchedule_UserId",
                table: "BarmenSchedule",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoctailIngredient_CoctailId",
                table: "CoctailIngredient",
                column: "CoctailId");

            migrationBuilder.CreateIndex(
                name: "IX_CoctailIngredient_CommodityId",
                table: "CoctailIngredient",
                column: "CommodityId");

            migrationBuilder.CreateIndex(
                name: "IX_CoctailReceipt_ReceiptId",
                table: "CoctailReceipt",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_DefaultMeasureId",
                table: "Commodity",
                column: "DefaultMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Drink_CommodityId",
                table: "Drink",
                column: "CommodityId");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkReceipt_ReceiptId",
                table: "DrinkReceipt",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_BarmenId",
                table: "Receipt",
                column: "BarmenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarmenSchedule");

            migrationBuilder.DropTable(
                name: "CoctailIngredient");

            migrationBuilder.DropTable(
                name: "CoctailReceipt");

            migrationBuilder.DropTable(
                name: "DrinkReceipt");

            migrationBuilder.DropTable(
                name: "Coctail");

            migrationBuilder.DropTable(
                name: "Drink");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "Commodity");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "DefaultMeasure");
        }
    }
}
