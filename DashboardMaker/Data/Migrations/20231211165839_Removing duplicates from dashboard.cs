using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashboardMaker.Data.Migrations
{
    /// <inheritdoc />
    public partial class Removingduplicatesfromdashboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_AspNetUsers_OwnerId",
                table: "Dashboards");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_OwnerId",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Dashboards");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Dashboards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Dashboards",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_OwnerId1",
                table: "Dashboards",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_AspNetUsers_OwnerId1",
                table: "Dashboards",
                column: "OwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_AspNetUsers_OwnerId1",
                table: "Dashboards");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_OwnerId1",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Dashboards");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Dashboards",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Dashboards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_OwnerId",
                table: "Dashboards",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_AspNetUsers_OwnerId",
                table: "Dashboards",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
