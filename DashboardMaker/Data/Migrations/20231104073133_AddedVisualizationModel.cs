using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashboardMaker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedVisualizationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visualization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataSourceId = table.Column<int>(type: "int", nullable: false),
                    VisualizationTypeId = table.Column<int>(type: "int", nullable: false),
                    ColorPaletteId = table.Column<int>(type: "int", nullable: false),
                    DashboardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visualization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visualization_ColorPalettes_ColorPaletteId",
                        column: x => x.ColorPaletteId,
                        principalTable: "ColorPalettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visualization_Dashboards_DashboardId",
                        column: x => x.DashboardId,
                        principalTable: "Dashboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visualization_DataSources_DataSourceId",
                        column: x => x.DataSourceId,
                        principalTable: "DataSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visualization_VisualizationTypes_VisualizationTypeId",
                        column: x => x.VisualizationTypeId,
                        principalTable: "VisualizationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visualization_ColorPaletteId",
                table: "Visualization",
                column: "ColorPaletteId");

            migrationBuilder.CreateIndex(
                name: "IX_Visualization_DashboardId",
                table: "Visualization",
                column: "DashboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Visualization_DataSourceId",
                table: "Visualization",
                column: "DataSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Visualization_VisualizationTypeId",
                table: "Visualization",
                column: "VisualizationTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visualization");
        }
    }
}
