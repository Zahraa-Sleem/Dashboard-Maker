using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashboardMaker.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addedownertodatasource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "DataSources",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DataSources_OwnerId",
                table: "DataSources",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataSources_AspNetUsers_OwnerId",
                table: "DataSources",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataSources_AspNetUsers_OwnerId",
                table: "DataSources");

            migrationBuilder.DropIndex(
                name: "IX_DataSources_OwnerId",
                table: "DataSources");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "DataSources");
        }
    }
}
