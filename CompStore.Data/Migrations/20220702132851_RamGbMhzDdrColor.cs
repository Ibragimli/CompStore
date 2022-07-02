using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompStore.Data.Migrations
{
    public partial class RamGbMhzDdrColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_Color_ColorId",
                table: "ProductParametr");

            migrationBuilder.AddColumn<int>(
                name: "RamDDRId",
                table: "ProductParametr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RamGBId",
                table: "ProductParametr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RamMhzId",
                table: "ProductParametr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VideokartId",
                table: "ProductParametr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RamDDR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DDR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RamDDR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RamGB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GB = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RamGB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RamMhz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mhz = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RamMhz", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videokart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videokart", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductParametr_RamDDRId",
                table: "ProductParametr",
                column: "RamDDRId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductParametr_RamGBId",
                table: "ProductParametr",
                column: "RamGBId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductParametr_RamMhzId",
                table: "ProductParametr",
                column: "RamMhzId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductParametr_VideokartId",
                table: "ProductParametr",
                column: "VideokartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_Color_ColorId",
                table: "ProductParametr",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_RamDDR_RamDDRId",
                table: "ProductParametr",
                column: "RamDDRId",
                principalTable: "RamDDR",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_RamGB_RamGBId",
                table: "ProductParametr",
                column: "RamGBId",
                principalTable: "RamGB",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_RamMhz_RamMhzId",
                table: "ProductParametr",
                column: "RamMhzId",
                principalTable: "RamMhz",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_Videokart_VideokartId",
                table: "ProductParametr",
                column: "VideokartId",
                principalTable: "Videokart",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_Color_ColorId",
                table: "ProductParametr");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_RamDDR_RamDDRId",
                table: "ProductParametr");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_RamGB_RamGBId",
                table: "ProductParametr");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_RamMhz_RamMhzId",
                table: "ProductParametr");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_Videokart_VideokartId",
                table: "ProductParametr");

            migrationBuilder.DropTable(
                name: "RamDDR");

            migrationBuilder.DropTable(
                name: "RamGB");

            migrationBuilder.DropTable(
                name: "RamMhz");

            migrationBuilder.DropTable(
                name: "Videokart");

            migrationBuilder.DropIndex(
                name: "IX_ProductParametr_RamDDRId",
                table: "ProductParametr");

            migrationBuilder.DropIndex(
                name: "IX_ProductParametr_RamGBId",
                table: "ProductParametr");

            migrationBuilder.DropIndex(
                name: "IX_ProductParametr_RamMhzId",
                table: "ProductParametr");

            migrationBuilder.DropIndex(
                name: "IX_ProductParametr_VideokartId",
                table: "ProductParametr");

            migrationBuilder.DropColumn(
                name: "RamDDRId",
                table: "ProductParametr");

            migrationBuilder.DropColumn(
                name: "RamGBId",
                table: "ProductParametr");

            migrationBuilder.DropColumn(
                name: "RamMhzId",
                table: "ProductParametr");

            migrationBuilder.DropColumn(
                name: "VideokartId",
                table: "ProductParametr");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_Color_ColorId",
                table: "ProductParametr",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
