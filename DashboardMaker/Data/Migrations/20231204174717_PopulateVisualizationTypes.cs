using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashboardMaker.Data.Migrations
{
    /// <inheritdoc />
    public partial class PopulateVisualizationTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO dbo.VisualizationTypes(Type) VALUES ('Bar Chart')");
            migrationBuilder.Sql("INSERT INTO dbo.VisualizationTypes(Type) VALUES ('Line Chart')");
            migrationBuilder.Sql("INSERT INTO dbo.VisualizationTypes(Type) VALUES ('Pie Chart')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
