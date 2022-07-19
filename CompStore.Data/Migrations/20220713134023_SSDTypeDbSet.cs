using Microsoft.EntityFrameworkCore.Migrations;

namespace CompStore.Data.Migrations
{
    public partial class SSDTypeDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaxiliYaddaşs_SSDType_SSDTypeId",
                table: "DaxiliYaddaşs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SSDType",
                table: "SSDType");

            migrationBuilder.RenameTable(
                name: "SSDType",
                newName: "SSDTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SSDTypes",
                table: "SSDTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DaxiliYaddaşs_SSDTypes_SSDTypeId",
                table: "DaxiliYaddaşs",
                column: "SSDTypeId",
                principalTable: "SSDTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaxiliYaddaşs_SSDTypes_SSDTypeId",
                table: "DaxiliYaddaşs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SSDTypes",
                table: "SSDTypes");

            migrationBuilder.RenameTable(
                name: "SSDTypes",
                newName: "SSDType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SSDType",
                table: "SSDType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DaxiliYaddaşs_SSDType_SSDTypeId",
                table: "DaxiliYaddaşs",
                column: "SSDTypeId",
                principalTable: "SSDType",
                principalColumn: "Id");
        }
    }
}
