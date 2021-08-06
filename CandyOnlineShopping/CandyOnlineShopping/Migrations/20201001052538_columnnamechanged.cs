using Microsoft.EntityFrameworkCore.Migrations;

namespace CandyOnlineShopping.Migrations
{
    public partial class columnnamechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderDetail");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderDetail",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderDetail");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
