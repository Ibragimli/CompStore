using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompStore.Data.Migrations
{
    public partial class GoruntuDiagonalFrequencySystemCahceGhz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GörüntüImkanıId",
                table: "ProductParametr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OperationSystemId",
                table: "ProductParametr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProcessorCacheId",
                table: "ProductParametr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProcessorGhzId",
                table: "ProductParametr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScreenDiagonalId",
                table: "ProductParametr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScreenFrequencyId",
                table: "ProductParametr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GörüntüImkanı",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capability = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GörüntüImkanı", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    System = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationSystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessorCache",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cache = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessorCache", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessorGhz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ghz = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessorGhz", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScreenDiagonal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagonal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenDiagonal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScreenFrequency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Frequency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenFrequency", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductParametr_GörüntüImkanıId",
                table: "ProductParametr",
                column: "GörüntüImkanıId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductParametr_OperationSystemId",
                table: "ProductParametr",
                column: "OperationSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductParametr_ProcessorCacheId",
                table: "ProductParametr",
                column: "ProcessorCacheId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductParametr_ProcessorGhzId",
                table: "ProductParametr",
                column: "ProcessorGhzId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductParametr_ScreenDiagonalId",
                table: "ProductParametr",
                column: "ScreenDiagonalId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductParametr_ScreenFrequencyId",
                table: "ProductParametr",
                column: "ScreenFrequencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_GörüntüImkanı_GörüntüImkanıId",
                table: "ProductParametr",
                column: "GörüntüImkanıId",
                principalTable: "GörüntüImkanı",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_OperationSystem_OperationSystemId",
                table: "ProductParametr",
                column: "OperationSystemId",
                principalTable: "OperationSystem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_ProcessorCache_ProcessorCacheId",
                table: "ProductParametr",
                column: "ProcessorCacheId",
                principalTable: "ProcessorCache",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_ProcessorGhz_ProcessorGhzId",
                table: "ProductParametr",
                column: "ProcessorGhzId",
                principalTable: "ProcessorGhz",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_ScreenDiagonal_ScreenDiagonalId",
                table: "ProductParametr",
                column: "ScreenDiagonalId",
                principalTable: "ScreenDiagonal",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_ScreenFrequency_ScreenFrequencyId",
                table: "ProductParametr",
                column: "ScreenFrequencyId",
                principalTable: "ScreenFrequency",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_GörüntüImkanı_GörüntüImkanıId",
                table: "ProductParametr");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_OperationSystem_OperationSystemId",
                table: "ProductParametr");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_ProcessorCache_ProcessorCacheId",
                table: "ProductParametr");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_ProcessorGhz_ProcessorGhzId",
                table: "ProductParametr");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_ScreenDiagonal_ScreenDiagonalId",
                table: "ProductParametr");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_ScreenFrequency_ScreenFrequencyId",
                table: "ProductParametr");

            migrationBuilder.DropTable(
                name: "GörüntüImkanı");

            migrationBuilder.DropTable(
                name: "OperationSystem");

            migrationBuilder.DropTable(
                name: "ProcessorCache");

            migrationBuilder.DropTable(
                name: "ProcessorGhz");

            migrationBuilder.DropTable(
                name: "ScreenDiagonal");

            migrationBuilder.DropTable(
                name: "ScreenFrequency");

            migrationBuilder.DropIndex(
                name: "IX_ProductParametr_GörüntüImkanıId",
                table: "ProductParametr");

            migrationBuilder.DropIndex(
                name: "IX_ProductParametr_OperationSystemId",
                table: "ProductParametr");

            migrationBuilder.DropIndex(
                name: "IX_ProductParametr_ProcessorCacheId",
                table: "ProductParametr");

            migrationBuilder.DropIndex(
                name: "IX_ProductParametr_ProcessorGhzId",
                table: "ProductParametr");

            migrationBuilder.DropIndex(
                name: "IX_ProductParametr_ScreenDiagonalId",
                table: "ProductParametr");

            migrationBuilder.DropIndex(
                name: "IX_ProductParametr_ScreenFrequencyId",
                table: "ProductParametr");

            migrationBuilder.DropColumn(
                name: "GörüntüImkanıId",
                table: "ProductParametr");

            migrationBuilder.DropColumn(
                name: "OperationSystemId",
                table: "ProductParametr");

            migrationBuilder.DropColumn(
                name: "ProcessorCacheId",
                table: "ProductParametr");

            migrationBuilder.DropColumn(
                name: "ProcessorGhzId",
                table: "ProductParametr");

            migrationBuilder.DropColumn(
                name: "ScreenDiagonalId",
                table: "ProductParametr");

            migrationBuilder.DropColumn(
                name: "ScreenFrequencyId",
                table: "ProductParametr");
        }
    }
}
