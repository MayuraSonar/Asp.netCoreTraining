using Microsoft.EntityFrameworkCore.Migrations;

namespace CandyOnlineShopping.Migrations
{
    public partial class firstmigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    CategoryDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Candy",
                columns: table => new
                {
                    CandyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandyName = table.Column<string>(nullable: true),
                    CandyDescription = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ImageThumbnailUrl = table.Column<string>(nullable: true),
                    IsOnSale = table.Column<bool>(nullable: false),
                    IsInStock = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candy", x => x.CandyId);
                    table.ForeignKey(
                        name: "FK_Candy_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartId = table.Column<string>(nullable: true),
                    CandyId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Candy_CandyId",
                        column: x => x.CandyId,
                        principalTable: "Candy",
                        principalColumn: "CandyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Chocolate Candy", "Chocolate Candy" },
                    { 2, "Fruit Candy", "Fruit Candy" },
                    { 3, "Gummy Candy", "Gummy Candy" },
                    { 4, "Halloween Candy", "Halloween Candy" },
                    { 5, "Hardy Candy", "Hard Candy" }
                });

            migrationBuilder.InsertData(
                table: "Candy",
                columns: new[] { "CandyId", "CategoryId", "CandyDescription", "ImageThumbnailUrl", "ImageUrl", "IsInStock", "IsOnSale", "CandyName", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Assorted Chocolate Candy", "\\Images\\thumbnail\\chocolateCandy-small.jpg", "\\Images\\chocolateCandy.jpg", true, false, "Assorted Chocolate Candy", 4.95m },
                    { 2, 1, "Another Assorted Chocolate Candy", "\\Images\\thumbnail\\chocolateCandy2-small.jpg", "\\Images\\chocolateCandy2.jpg", true, true, "Another Assorted Chocolate Candy", 3.95m },
                    { 3, 1, "Another Chocolate Candy.", "\\Images\\thumbnail\\chocolateCandy3-small.jpg", "\\Images\\chocolateCandy3.jpg", true, false, "Another Chocolate Candy", 5.75m },
                    { 4, 2, "Assorted Fruit Candy", "\\Images\\thumbnail\\fruitCandy-small.jpg", "\\Images\\fruitCandy.jpg", true, false, "Assorted Fruit Candy", 3.95m },
                    { 5, 2, "Fruit Candy.", "\\Images\\thumbnail\\fruitCandy2-small.jpg", "\\Images\\fruitCandy2.jpg", true, true, "Fruit Candy", 7.00m },
                    { 6, 2, "Another Assorted Fruit Candy ", "\\Images\\thumbnail\\fruitCandy3-small.jpg", "\\Images\\fruitCandy3.jpg", true, true, "Another Assorted Fruit Candy", 11.25m },
                    { 7, 3, "Assorted Gummy Candy.", "\\Images\\thumbnail\\gummyCandy-small.jpg", "\\Images\\gummyCandy.jpg", true, true, "Assorted Gummy Candy", 3.95m },
                    { 8, 3, "Another Assorted Gummy Candy", "\\Images\\thumbnail\\gummyCandy2-small.jpg", "\\Images\\gummyCandy2.jpg", true, false, "Another Assorted Gummy Candy", 1.95m },
                    { 9, 3, "Gummy Candy", "\\Images\\thumbnail\\gummyCandy3-small.jpg", "\\Images\\gummyCandy3.jpg", true, false, "Gummy Candy", 13.95m },
                    { 10, 4, "Halloween Candy.", "\\Images\\thumbnail\\halloweenCandy-small.jpg", "\\Images\\halloweenCandy.jpg", true, true, "Halloween Candy", 1.95m },
                    { 11, 4, "Assorted Halloween Candy", "\\Images\\thumbnail\\halloweenCandy2-small.jpg", "\\Images\\halloweenCandy2.jpg", true, true, "Assorted Halloween Candy", 12.95m },
                    { 12, 4, "Another Halloween Candy", "\\Images\\thumbnail\\halloweenCandy3-small.jpg", "\\Images\\halloweenCandy3.jpg", true, true, "Another Halloween Candy", 21.95m },
                    { 13, 5, "Hard Candy", "\\Images\\thumbnail\\hardCandy-small.jpg", "\\Images\\hardCandy.jpg", true, false, "Hard Candy", 6.95m },
                    { 14, 5, "Another Hard Candy.", "\\Images\\thumbnail\\hardCandy2-small.jpg", "\\Images\\hardCandy2.jpg", true, true, "Another Hard Candy", 2.95m },
                    { 15, 5, "Best Hard Candy", "\\Images\\thumbnail\\hardCandy3-small.jpg", "\\Images\\hardCandy3.jpg", true, false, "Best Hard Candy", 16.95m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candy_CategoryId",
                table: "Candy",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_CandyId",
                table: "ShoppingCartItem",
                column: "CandyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "Candy");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
