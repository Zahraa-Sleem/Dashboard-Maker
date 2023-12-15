using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashboardMaker.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Visualization_ColorPalettes_ColorPaletteId",
                table: "Visualization");

            migrationBuilder.DropForeignKey(
                name: "FK_Visualization_Dashboards_DashboardId",
                table: "Visualization");

            migrationBuilder.DropForeignKey(
                name: "FK_Visualization_DataSources_DataSourceId",
                table: "Visualization");

            migrationBuilder.DropForeignKey(
                name: "FK_Visualization_VisualizationTypes_VisualizationTypeId",
                table: "Visualization");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_OwnerId1",
                table: "Dashboards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visualization",
                table: "Visualization");

            migrationBuilder.RenameTable(
                name: "Visualization",
                newName: "Visualizations");

            migrationBuilder.RenameIndex(
                name: "IX_Visualization_VisualizationTypeId",
                table: "Visualizations",
                newName: "IX_Visualizations_VisualizationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Visualization_DataSourceId",
                table: "Visualizations",
                newName: "IX_Visualizations_DataSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Visualization_DashboardId",
                table: "Visualizations",
                newName: "IX_Visualizations_DashboardId");

            migrationBuilder.RenameIndex(
                name: "IX_Visualization_ColorPaletteId",
                table: "Visualizations",
                newName: "IX_Visualizations_ColorPaletteId");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Dashboards",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visualizations",
                table: "Visualizations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_OwnerId",
                table: "Dashboards",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_AspNetUsers_OwnerId",
                table: "Dashboards",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visualizations_ColorPalettes_ColorPaletteId",
                table: "Visualizations",
                column: "ColorPaletteId",
                principalTable: "ColorPalettes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visualizations_Dashboards_DashboardId",
                table: "Visualizations",
                column: "DashboardId",
                principalTable: "Dashboards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visualizations_DataSources_DataSourceId",
                table: "Visualizations",
                column: "DataSourceId",
                principalTable: "DataSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visualizations_VisualizationTypes_VisualizationTypeId",
                table: "Visualizations",
                column: "VisualizationTypeId",
                principalTable: "VisualizationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_AspNetUsers_OwnerId",
                table: "Dashboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Visualizations_ColorPalettes_ColorPaletteId",
                table: "Visualizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Visualizations_Dashboards_DashboardId",
                table: "Visualizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Visualizations_DataSources_DataSourceId",
                table: "Visualizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Visualizations_VisualizationTypes_VisualizationTypeId",
                table: "Visualizations");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_OwnerId",
                table: "Dashboards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visualizations",
                table: "Visualizations");

            migrationBuilder.RenameTable(
                name: "Visualizations",
                newName: "Visualization");

            migrationBuilder.RenameIndex(
                name: "IX_Visualizations_VisualizationTypeId",
                table: "Visualization",
                newName: "IX_Visualization_VisualizationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Visualizations_DataSourceId",
                table: "Visualization",
                newName: "IX_Visualization_DataSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Visualizations_DashboardId",
                table: "Visualization",
                newName: "IX_Visualization_DashboardId");

            migrationBuilder.RenameIndex(
                name: "IX_Visualizations_ColorPaletteId",
                table: "Visualization",
                newName: "IX_Visualization_ColorPaletteId");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Dashboards",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Dashboards",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visualization",
                table: "Visualization",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Visualization_ColorPalettes_ColorPaletteId",
                table: "Visualization",
                column: "ColorPaletteId",
                principalTable: "ColorPalettes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visualization_Dashboards_DashboardId",
                table: "Visualization",
                column: "DashboardId",
                principalTable: "Dashboards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visualization_DataSources_DataSourceId",
                table: "Visualization",
                column: "DataSourceId",
                principalTable: "DataSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visualization_VisualizationTypes_VisualizationTypeId",
                table: "Visualization",
                column: "VisualizationTypeId",
                principalTable: "VisualizationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
