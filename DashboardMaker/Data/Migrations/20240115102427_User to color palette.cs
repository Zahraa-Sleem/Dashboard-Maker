using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashboardMaker.Data.Migrations
{
    /// <inheritdoc />
    public partial class Usertocolorpalette : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "ColorPalettes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ColorPalettes_OwnerId",
                table: "ColorPalettes",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorPalettes_AspNetUsers_OwnerId",
                table: "ColorPalettes",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorPalettes_AspNetUsers_OwnerId",
                table: "ColorPalettes");

            migrationBuilder.DropIndex(
                name: "IX_ColorPalettes_OwnerId",
                table: "ColorPalettes");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ColorPalettes");
        }
    }
}
