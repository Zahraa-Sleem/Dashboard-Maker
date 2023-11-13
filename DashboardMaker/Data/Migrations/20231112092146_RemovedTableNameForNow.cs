using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashboardMaker.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTableNameForNow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableName",
                table: "DataSources");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TableName",
                table: "DataSources",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
