using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompStore.Data.Migrations
{
    public partial class ProcessorVideokartRamColorTeyinat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessorModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessorModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teyinat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teyinat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideokartRam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ram = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideokartRam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductParametr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kamera = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Bluetooth = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    TeyinatId = table.Column<int>(type: "int", nullable: false),
                    ProcessorModelId = table.Column<int>(type: "int", nullable: false),
                    VideokartRamId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductParametr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductParametr_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductParametr_ProcessorModel_ProcessorModelId",
                        column: x => x.ProcessorModelId,
                        principalTable: "ProcessorModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductParametr_Teyinat_TeyinatId",
                        column: x => x.TeyinatId,
                        principalTable: "Teyinat",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductParametr_VideokartRam_VideokartRamId",
                        column: x => x.VideokartRamId,
                        principalTable: "VideokartRam",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductParametr_ColorId",
                table: "ProductParametr",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductParametr_ProcessorModelId",
                table: "ProductParametr",
                column: "ProcessorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductParametr_TeyinatId",
                table: "ProductParametr",
                column: "TeyinatId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductParametr_VideokartRamId",
                table: "ProductParametr",
                column: "VideokartRamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductParametr");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "ProcessorModel");

            migrationBuilder.DropTable(
                name: "Teyinat");

            migrationBuilder.DropTable(
                name: "VideokartRam");
        }
    }
}
