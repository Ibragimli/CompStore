using Microsoft.EntityFrameworkCore.Migrations;

namespace CompStore.Data.Migrations
{
    public partial class DbSetGoruntuImkani : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_GörüntüImkanı_GörüntüImkanıId",
                table: "ProductParametrs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GörüntüImkanı",
                table: "GörüntüImkanı");

            migrationBuilder.RenameTable(
                name: "GörüntüImkanı",
                newName: "GörüntüImkanıs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GörüntüImkanıs",
                table: "GörüntüImkanıs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_GörüntüImkanıs_GörüntüImkanıId",
                table: "ProductParametrs",
                column: "GörüntüImkanıId",
                principalTable: "GörüntüImkanıs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_GörüntüImkanıs_GörüntüImkanıId",
                table: "ProductParametrs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GörüntüImkanıs",
                table: "GörüntüImkanıs");

            migrationBuilder.RenameTable(
                name: "GörüntüImkanıs",
                newName: "GörüntüImkanı");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GörüntüImkanı",
                table: "GörüntüImkanı",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_GörüntüImkanı_GörüntüImkanıId",
                table: "ProductParametrs",
                column: "GörüntüImkanıId",
                principalTable: "GörüntüImkanı",
                principalColumn: "Id");
        }
    }
}
