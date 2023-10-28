using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Seller = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ThumbnailHd = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalToPay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Cvv = table.Column<int>(type: "int", nullable: false),
                    CardHolderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpDate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PurchaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCards_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Date", "Price", "Seller", "ThumbnailHd", "Title", "ZipCode" },
                values: new object[] { new Guid("4f9a5cf4-20f6-4652-8d8c-891793dd3f07"), "26/11/2015", 7990, "Joana", "https://cdn.awsli.com.br/1000x1000/21/21351/produto/7234148/55692a941d.jpg", "Blusa Han Shot First", "13500-110" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Date", "Price", "Seller", "ThumbnailHd", "Title", "ZipCode" },
                values: new object[] { new Guid("a99808e6-7f74-485b-9fe9-45bd0d819b40"), "26/11/2015", 150000, "Mario Mota", "http://www.obrigadopelospeixes.com/wp-content/uploads/2015/12/kalippe_lightsaber_by_jnetrocks-d4dyzpo1-1024x600.jpg", "Sabre de luz", "13537-000" });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "ClientId", "ClientName", "TotalToPay" },
                values: new object[] { new Guid("ec9da1c8-8771-4065-b9f3-f200abdc7eed"), "7e655c6e-e8e5-4349-8348-e51e0ff3072e", "Luke Skywalker", 1236 });

            migrationBuilder.InsertData(
                table: "CreditCards",
                columns: new[] { "Id", "CardHolderName", "CardNumber", "Cvv", "ExpDate", "PurchaseId", "Value" },
                values: new object[] { new Guid("c48871ec-5df8-41c9-b62f-b6a60e83969f"), "Luke Skywalker", "1234123412341234", 789, "12/24", new Guid("ec9da1c8-8771-4065-b9f3-f200abdc7eed"), 7990 });

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_PurchaseId",
                table: "CreditCards",
                column: "PurchaseId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Purchases");
        }
    }
}
