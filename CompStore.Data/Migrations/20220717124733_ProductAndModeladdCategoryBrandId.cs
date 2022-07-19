using Microsoft.EntityFrameworkCore.Migrations;

namespace CompStore.Data.Migrations
{
    public partial class ProductAndModeladdCategoryBrandId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "CategoryBrandIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryBrandIdId");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Models",
                newName: "CategoryBrandIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                newName: "IX_Models_CategoryBrandIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_CategoryBrandIds_CategoryBrandIdId",
                table: "Models",
                column: "CategoryBrandIdId",
                principalTable: "CategoryBrandIds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryBrandIds_CategoryBrandIdId",
                table: "Products",
                column: "CategoryBrandIdId",
                principalTable: "CategoryBrandIds",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_CategoryBrandIds_CategoryBrandIdId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryBrandIds_CategoryBrandIdId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryBrandIdId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryBrandIdId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryBrandIdId",
                table: "Models",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Models_CategoryBrandIdId",
                table: "Models",
                newName: "IX_Models_BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
