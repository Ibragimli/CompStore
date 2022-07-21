using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompStore.Data.Migrations
{
    public partial class HDDHecmSSDHecmUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaxiliYaddaşs_DaxiliYaddasHecms_DaxiliYaddasHecmId",
                table: "DaxiliYaddaşs");

            migrationBuilder.DropTable(
                name: "DaxiliYaddasHecms");

            migrationBuilder.DropIndex(
                name: "IX_DaxiliYaddaşs_DaxiliYaddasHecmId",
                table: "DaxiliYaddaşs");

            migrationBuilder.DropColumn(
                name: "Cache",
                table: "DaxiliYaddaşs");

            migrationBuilder.DropColumn(
                name: "DaxiliYaddasHecmId",
                table: "DaxiliYaddaşs");

            migrationBuilder.AddColumn<int>(
                name: "HDDHecmId",
                table: "DaxiliYaddaşs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SSDHecmId",
                table: "DaxiliYaddaşs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HDDHecms",
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
                    table.PrimaryKey("PK_HDDHecms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SSDHecms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cache = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSDHecms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaxiliYaddaşs_HDDHecmId",
                table: "DaxiliYaddaşs",
                column: "HDDHecmId");

            migrationBuilder.CreateIndex(
                name: "IX_DaxiliYaddaşs_SSDHecmId",
                table: "DaxiliYaddaşs",
                column: "SSDHecmId");

            migrationBuilder.AddForeignKey(
                name: "FK_DaxiliYaddaşs_HDDHecms_HDDHecmId",
                table: "DaxiliYaddaşs",
                column: "HDDHecmId",
                principalTable: "HDDHecms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DaxiliYaddaşs_SSDHecms_SSDHecmId",
                table: "DaxiliYaddaşs",
                column: "SSDHecmId",
                principalTable: "SSDHecms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaxiliYaddaşs_HDDHecms_HDDHecmId",
                table: "DaxiliYaddaşs");

            migrationBuilder.DropForeignKey(
                name: "FK_DaxiliYaddaşs_SSDHecms_SSDHecmId",
                table: "DaxiliYaddaşs");

            migrationBuilder.DropTable(
                name: "HDDHecms");

            migrationBuilder.DropTable(
                name: "SSDHecms");

            migrationBuilder.DropIndex(
                name: "IX_DaxiliYaddaşs_HDDHecmId",
                table: "DaxiliYaddaşs");

            migrationBuilder.DropIndex(
                name: "IX_DaxiliYaddaşs_SSDHecmId",
                table: "DaxiliYaddaşs");

            migrationBuilder.DropColumn(
                name: "HDDHecmId",
                table: "DaxiliYaddaşs");

            migrationBuilder.DropColumn(
                name: "SSDHecmId",
                table: "DaxiliYaddaşs");

            migrationBuilder.AddColumn<int>(
                name: "Cache",
                table: "DaxiliYaddaşs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DaxiliYaddasHecmId",
                table: "DaxiliYaddaşs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DaxiliYaddasHecms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cache = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaxiliYaddasHecms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaxiliYaddaşs_DaxiliYaddasHecmId",
                table: "DaxiliYaddaşs",
                column: "DaxiliYaddasHecmId");

            migrationBuilder.AddForeignKey(
                name: "FK_DaxiliYaddaşs_DaxiliYaddasHecms_DaxiliYaddasHecmId",
                table: "DaxiliYaddaşs",
                column: "DaxiliYaddasHecmId",
                principalTable: "DaxiliYaddasHecms",
                principalColumn: "Id");
        }
    }
}
