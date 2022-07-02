using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompStore.Data.Migrations
{
    public partial class DaxiliYaddas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DaxiliYaddaşId",
                table: "ProductParametr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DaxiliYaddasHecm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cache = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaxiliYaddasHecm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SSDType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSDType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DaxiliYaddaş",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cache = table.Column<int>(type: "int", nullable: false),
                    IsHDD = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsSSD = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SSDTypeId = table.Column<int>(type: "int", nullable: false),
                    DaxiliYaddasHecmId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaxiliYaddaş", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaxiliYaddaş_DaxiliYaddasHecm_DaxiliYaddasHecmId",
                        column: x => x.DaxiliYaddasHecmId,
                        principalTable: "DaxiliYaddasHecm",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DaxiliYaddaş_SSDType_SSDTypeId",
                        column: x => x.SSDTypeId,
                        principalTable: "SSDType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductParametr_DaxiliYaddaşId",
                table: "ProductParametr",
                column: "DaxiliYaddaşId");

            migrationBuilder.CreateIndex(
                name: "IX_DaxiliYaddaş_DaxiliYaddasHecmId",
                table: "DaxiliYaddaş",
                column: "DaxiliYaddasHecmId");

            migrationBuilder.CreateIndex(
                name: "IX_DaxiliYaddaş_SSDTypeId",
                table: "DaxiliYaddaş",
                column: "SSDTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_DaxiliYaddaş_DaxiliYaddaşId",
                table: "ProductParametr",
                column: "DaxiliYaddaşId",
                principalTable: "DaxiliYaddaş",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_DaxiliYaddaş_DaxiliYaddaşId",
                table: "ProductParametr");

            migrationBuilder.DropTable(
                name: "DaxiliYaddaş");

            migrationBuilder.DropTable(
                name: "DaxiliYaddasHecm");

            migrationBuilder.DropTable(
                name: "SSDType");

            migrationBuilder.DropIndex(
                name: "IX_ProductParametr_DaxiliYaddaşId",
                table: "ProductParametr");

            migrationBuilder.DropColumn(
                name: "DaxiliYaddaşId",
                table: "ProductParametr");
        }
    }
}
