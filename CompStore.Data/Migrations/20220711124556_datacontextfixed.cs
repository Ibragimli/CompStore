using Microsoft.EntityFrameworkCore.Migrations;

namespace CompStore.Data.Migrations
{
    public partial class datacontextfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaxiliYaddaş_DaxiliYaddasHecm_DaxiliYaddasHecmId",
                table: "DaxiliYaddaş");

            migrationBuilder.DropForeignKey(
                name: "FK_DaxiliYaddaş_SSDType_SSDTypeId",
                table: "DaxiliYaddaş");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_Color_ColorId",
                table: "ProductParametr");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_DaxiliYaddaş_DaxiliYaddaşId",
                table: "ProductParametr");

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
                name: "FK_ProductParametr_ProcessorModel_ProcessorModelId",
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
                name: "FK_ProductParametr_ScreenDiagonal_ScreenDiagonalId",
                table: "ProductParametr");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_ScreenFrequency_ScreenFrequencyId",
                table: "ProductParametr");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_Teyinat_TeyinatId",
                table: "ProductParametr");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_Videokart_VideokartId",
                table: "ProductParametr");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametr_VideokartRam_VideokartRamId",
                table: "ProductParametr");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductParametr_ProductParametrId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideokartRam",
                table: "VideokartRam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videokart",
                table: "Videokart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teyinat",
                table: "Teyinat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScreenFrequency",
                table: "ScreenFrequency");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScreenDiagonal",
                table: "ScreenDiagonal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RamMhz",
                table: "RamMhz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RamGB",
                table: "RamGB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RamDDR",
                table: "RamDDR");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductParametr",
                table: "ProductParametr");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationSystem",
                table: "OperationSystem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DaxiliYaddaş",
                table: "DaxiliYaddaş");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DaxiliYaddasHecm",
                table: "DaxiliYaddasHecm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.RenameTable(
                name: "VideokartRam",
                newName: "VideokartRams");

            migrationBuilder.RenameTable(
                name: "Videokart",
                newName: "Videokarts");

            migrationBuilder.RenameTable(
                name: "Teyinat",
                newName: "Teyinats");

            migrationBuilder.RenameTable(
                name: "ScreenFrequency",
                newName: "ScreenFrequencies");

            migrationBuilder.RenameTable(
                name: "ScreenDiagonal",
                newName: "ScreenDiagonals");

            migrationBuilder.RenameTable(
                name: "RamMhz",
                newName: "RamMhzs");

            migrationBuilder.RenameTable(
                name: "RamGB",
                newName: "RamGBs");

            migrationBuilder.RenameTable(
                name: "RamDDR",
                newName: "RamDDRs");

            migrationBuilder.RenameTable(
                name: "ProductParametr",
                newName: "ProductParametrs");

            migrationBuilder.RenameTable(
                name: "OperationSystem",
                newName: "OperationSystems");

            migrationBuilder.RenameTable(
                name: "DaxiliYaddaş",
                newName: "DaxiliYaddaşs");

            migrationBuilder.RenameTable(
                name: "DaxiliYaddasHecm",
                newName: "DaxiliYaddasHecms");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "Colors");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametr_VideokartRamId",
                table: "ProductParametrs",
                newName: "IX_ProductParametrs_VideokartRamId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametr_VideokartId",
                table: "ProductParametrs",
                newName: "IX_ProductParametrs_VideokartId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametr_TeyinatId",
                table: "ProductParametrs",
                newName: "IX_ProductParametrs_TeyinatId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametr_ScreenFrequencyId",
                table: "ProductParametrs",
                newName: "IX_ProductParametrs_ScreenFrequencyId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametr_ScreenDiagonalId",
                table: "ProductParametrs",
                newName: "IX_ProductParametrs_ScreenDiagonalId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametr_RamMhzId",
                table: "ProductParametrs",
                newName: "IX_ProductParametrs_RamMhzId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametr_RamGBId",
                table: "ProductParametrs",
                newName: "IX_ProductParametrs_RamGBId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametr_RamDDRId",
                table: "ProductParametrs",
                newName: "IX_ProductParametrs_RamDDRId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametr_ProcessorModelId",
                table: "ProductParametrs",
                newName: "IX_ProductParametrs_ProcessorModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametr_ProcessorGhzId",
                table: "ProductParametrs",
                newName: "IX_ProductParametrs_ProcessorGhzId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametr_ProcessorCacheId",
                table: "ProductParametrs",
                newName: "IX_ProductParametrs_ProcessorCacheId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametr_OperationSystemId",
                table: "ProductParametrs",
                newName: "IX_ProductParametrs_OperationSystemId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametr_GörüntüImkanıId",
                table: "ProductParametrs",
                newName: "IX_ProductParametrs_GörüntüImkanıId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametr_DaxiliYaddaşId",
                table: "ProductParametrs",
                newName: "IX_ProductParametrs_DaxiliYaddaşId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametr_ColorId",
                table: "ProductParametrs",
                newName: "IX_ProductParametrs_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_DaxiliYaddaş_SSDTypeId",
                table: "DaxiliYaddaşs",
                newName: "IX_DaxiliYaddaşs_SSDTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_DaxiliYaddaş_DaxiliYaddasHecmId",
                table: "DaxiliYaddaşs",
                newName: "IX_DaxiliYaddaşs_DaxiliYaddasHecmId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideokartRams",
                table: "VideokartRams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videokarts",
                table: "Videokarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teyinats",
                table: "Teyinats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScreenFrequencies",
                table: "ScreenFrequencies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScreenDiagonals",
                table: "ScreenDiagonals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RamMhzs",
                table: "RamMhzs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RamGBs",
                table: "RamGBs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RamDDRs",
                table: "RamDDRs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductParametrs",
                table: "ProductParametrs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationSystems",
                table: "OperationSystems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DaxiliYaddaşs",
                table: "DaxiliYaddaşs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DaxiliYaddasHecms",
                table: "DaxiliYaddasHecms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DaxiliYaddaşs_DaxiliYaddasHecms_DaxiliYaddasHecmId",
                table: "DaxiliYaddaşs",
                column: "DaxiliYaddasHecmId",
                principalTable: "DaxiliYaddasHecms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DaxiliYaddaşs_SSDType_SSDTypeId",
                table: "DaxiliYaddaşs",
                column: "SSDTypeId",
                principalTable: "SSDType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_Colors_ColorId",
                table: "ProductParametrs",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_DaxiliYaddaşs_DaxiliYaddaşId",
                table: "ProductParametrs",
                column: "DaxiliYaddaşId",
                principalTable: "DaxiliYaddaşs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_GörüntüImkanı_GörüntüImkanıId",
                table: "ProductParametrs",
                column: "GörüntüImkanıId",
                principalTable: "GörüntüImkanı",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_OperationSystems_OperationSystemId",
                table: "ProductParametrs",
                column: "OperationSystemId",
                principalTable: "OperationSystems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_ProcessorCache_ProcessorCacheId",
                table: "ProductParametrs",
                column: "ProcessorCacheId",
                principalTable: "ProcessorCache",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_ProcessorGhz_ProcessorGhzId",
                table: "ProductParametrs",
                column: "ProcessorGhzId",
                principalTable: "ProcessorGhz",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_ProcessorModel_ProcessorModelId",
                table: "ProductParametrs",
                column: "ProcessorModelId",
                principalTable: "ProcessorModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_RamDDRs_RamDDRId",
                table: "ProductParametrs",
                column: "RamDDRId",
                principalTable: "RamDDRs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_RamGBs_RamGBId",
                table: "ProductParametrs",
                column: "RamGBId",
                principalTable: "RamGBs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_RamMhzs_RamMhzId",
                table: "ProductParametrs",
                column: "RamMhzId",
                principalTable: "RamMhzs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_ScreenDiagonals_ScreenDiagonalId",
                table: "ProductParametrs",
                column: "ScreenDiagonalId",
                principalTable: "ScreenDiagonals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_ScreenFrequencies_ScreenFrequencyId",
                table: "ProductParametrs",
                column: "ScreenFrequencyId",
                principalTable: "ScreenFrequencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_Teyinats_TeyinatId",
                table: "ProductParametrs",
                column: "TeyinatId",
                principalTable: "Teyinats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_VideokartRams_VideokartRamId",
                table: "ProductParametrs",
                column: "VideokartRamId",
                principalTable: "VideokartRams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametrs_Videokarts_VideokartId",
                table: "ProductParametrs",
                column: "VideokartId",
                principalTable: "Videokarts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductParametrs_ProductParametrId",
                table: "Products",
                column: "ProductParametrId",
                principalTable: "ProductParametrs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaxiliYaddaşs_DaxiliYaddasHecms_DaxiliYaddasHecmId",
                table: "DaxiliYaddaşs");

            migrationBuilder.DropForeignKey(
                name: "FK_DaxiliYaddaşs_SSDType_SSDTypeId",
                table: "DaxiliYaddaşs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_Colors_ColorId",
                table: "ProductParametrs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_DaxiliYaddaşs_DaxiliYaddaşId",
                table: "ProductParametrs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_GörüntüImkanı_GörüntüImkanıId",
                table: "ProductParametrs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_OperationSystems_OperationSystemId",
                table: "ProductParametrs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_ProcessorCache_ProcessorCacheId",
                table: "ProductParametrs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_ProcessorGhz_ProcessorGhzId",
                table: "ProductParametrs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_ProcessorModel_ProcessorModelId",
                table: "ProductParametrs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_RamDDRs_RamDDRId",
                table: "ProductParametrs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_RamGBs_RamGBId",
                table: "ProductParametrs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_RamMhzs_RamMhzId",
                table: "ProductParametrs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_ScreenDiagonals_ScreenDiagonalId",
                table: "ProductParametrs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_ScreenFrequencies_ScreenFrequencyId",
                table: "ProductParametrs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_Teyinats_TeyinatId",
                table: "ProductParametrs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_VideokartRams_VideokartRamId",
                table: "ProductParametrs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParametrs_Videokarts_VideokartId",
                table: "ProductParametrs");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductParametrs_ProductParametrId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videokarts",
                table: "Videokarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideokartRams",
                table: "VideokartRams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teyinats",
                table: "Teyinats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScreenFrequencies",
                table: "ScreenFrequencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScreenDiagonals",
                table: "ScreenDiagonals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RamMhzs",
                table: "RamMhzs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RamGBs",
                table: "RamGBs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RamDDRs",
                table: "RamDDRs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductParametrs",
                table: "ProductParametrs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationSystems",
                table: "OperationSystems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DaxiliYaddaşs",
                table: "DaxiliYaddaşs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DaxiliYaddasHecms",
                table: "DaxiliYaddasHecms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.RenameTable(
                name: "Videokarts",
                newName: "Videokart");

            migrationBuilder.RenameTable(
                name: "VideokartRams",
                newName: "VideokartRam");

            migrationBuilder.RenameTable(
                name: "Teyinats",
                newName: "Teyinat");

            migrationBuilder.RenameTable(
                name: "ScreenFrequencies",
                newName: "ScreenFrequency");

            migrationBuilder.RenameTable(
                name: "ScreenDiagonals",
                newName: "ScreenDiagonal");

            migrationBuilder.RenameTable(
                name: "RamMhzs",
                newName: "RamMhz");

            migrationBuilder.RenameTable(
                name: "RamGBs",
                newName: "RamGB");

            migrationBuilder.RenameTable(
                name: "RamDDRs",
                newName: "RamDDR");

            migrationBuilder.RenameTable(
                name: "ProductParametrs",
                newName: "ProductParametr");

            migrationBuilder.RenameTable(
                name: "OperationSystems",
                newName: "OperationSystem");

            migrationBuilder.RenameTable(
                name: "DaxiliYaddaşs",
                newName: "DaxiliYaddaş");

            migrationBuilder.RenameTable(
                name: "DaxiliYaddasHecms",
                newName: "DaxiliYaddasHecm");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "Color");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametrs_VideokartRamId",
                table: "ProductParametr",
                newName: "IX_ProductParametr_VideokartRamId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametrs_VideokartId",
                table: "ProductParametr",
                newName: "IX_ProductParametr_VideokartId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametrs_TeyinatId",
                table: "ProductParametr",
                newName: "IX_ProductParametr_TeyinatId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametrs_ScreenFrequencyId",
                table: "ProductParametr",
                newName: "IX_ProductParametr_ScreenFrequencyId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametrs_ScreenDiagonalId",
                table: "ProductParametr",
                newName: "IX_ProductParametr_ScreenDiagonalId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametrs_RamMhzId",
                table: "ProductParametr",
                newName: "IX_ProductParametr_RamMhzId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametrs_RamGBId",
                table: "ProductParametr",
                newName: "IX_ProductParametr_RamGBId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametrs_RamDDRId",
                table: "ProductParametr",
                newName: "IX_ProductParametr_RamDDRId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametrs_ProcessorModelId",
                table: "ProductParametr",
                newName: "IX_ProductParametr_ProcessorModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametrs_ProcessorGhzId",
                table: "ProductParametr",
                newName: "IX_ProductParametr_ProcessorGhzId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametrs_ProcessorCacheId",
                table: "ProductParametr",
                newName: "IX_ProductParametr_ProcessorCacheId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametrs_OperationSystemId",
                table: "ProductParametr",
                newName: "IX_ProductParametr_OperationSystemId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametrs_GörüntüImkanıId",
                table: "ProductParametr",
                newName: "IX_ProductParametr_GörüntüImkanıId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametrs_DaxiliYaddaşId",
                table: "ProductParametr",
                newName: "IX_ProductParametr_DaxiliYaddaşId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParametrs_ColorId",
                table: "ProductParametr",
                newName: "IX_ProductParametr_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_DaxiliYaddaşs_SSDTypeId",
                table: "DaxiliYaddaş",
                newName: "IX_DaxiliYaddaş_SSDTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_DaxiliYaddaşs_DaxiliYaddasHecmId",
                table: "DaxiliYaddaş",
                newName: "IX_DaxiliYaddaş_DaxiliYaddasHecmId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videokart",
                table: "Videokart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideokartRam",
                table: "VideokartRam",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teyinat",
                table: "Teyinat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScreenFrequency",
                table: "ScreenFrequency",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScreenDiagonal",
                table: "ScreenDiagonal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RamMhz",
                table: "RamMhz",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RamGB",
                table: "RamGB",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RamDDR",
                table: "RamDDR",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductParametr",
                table: "ProductParametr",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationSystem",
                table: "OperationSystem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DaxiliYaddaş",
                table: "DaxiliYaddaş",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DaxiliYaddasHecm",
                table: "DaxiliYaddasHecm",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DaxiliYaddaş_DaxiliYaddasHecm_DaxiliYaddasHecmId",
                table: "DaxiliYaddaş",
                column: "DaxiliYaddasHecmId",
                principalTable: "DaxiliYaddasHecm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DaxiliYaddaş_SSDType_SSDTypeId",
                table: "DaxiliYaddaş",
                column: "SSDTypeId",
                principalTable: "SSDType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_Color_ColorId",
                table: "ProductParametr",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_DaxiliYaddaş_DaxiliYaddaşId",
                table: "ProductParametr",
                column: "DaxiliYaddaşId",
                principalTable: "DaxiliYaddaş",
                principalColumn: "Id");

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
                name: "FK_ProductParametr_ProcessorModel_ProcessorModelId",
                table: "ProductParametr",
                column: "ProcessorModelId",
                principalTable: "ProcessorModel",
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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_Teyinat_TeyinatId",
                table: "ProductParametr",
                column: "TeyinatId",
                principalTable: "Teyinat",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_Videokart_VideokartId",
                table: "ProductParametr",
                column: "VideokartId",
                principalTable: "Videokart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParametr_VideokartRam_VideokartRamId",
                table: "ProductParametr",
                column: "VideokartRamId",
                principalTable: "VideokartRam",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductParametr_ProductParametrId",
                table: "Products",
                column: "ProductParametrId",
                principalTable: "ProductParametr",
                principalColumn: "Id");
        }
    }
}
