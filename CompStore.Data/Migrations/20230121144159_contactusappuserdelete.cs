using Microsoft.EntityFrameworkCore.Migrations;

namespace CompStore.Data.Migrations
{
    public partial class contactusappuserdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactUs_AspNetUsers_AppUserId",
                table: "ContactUs");

            migrationBuilder.DropIndex(
                name: "IX_ContactUs_AppUserId",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ContactUs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "ContactUs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_AppUserId",
                table: "ContactUs",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactUs_AspNetUsers_AppUserId",
                table: "ContactUs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
