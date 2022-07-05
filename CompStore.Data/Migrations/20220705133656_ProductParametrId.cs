using Microsoft.EntityFrameworkCore.Migrations;

namespace CompStore.Data.Migrations
{
    public partial class ProductParametrId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductParametrId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductParametrId",
                table: "Products",
                column: "ProductParametrId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductParametr_ProductParametrId",
                table: "Products",
                column: "ProductParametrId",
                principalTable: "ProductParametr",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductParametr_ProductParametrId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductParametrId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductParametrId",
                table: "Products");
        }
    }
}
