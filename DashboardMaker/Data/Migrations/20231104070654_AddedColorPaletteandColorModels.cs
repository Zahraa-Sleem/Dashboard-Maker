using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashboardMaker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedColorPaletteandColorModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColorPalettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorPalettes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HexCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Red = table.Column<int>(type: "int", nullable: true),
                    Green = table.Column<int>(type: "int", nullable: true),
                    Blue = table.Column<int>(type: "int", nullable: true),
                    Alpha = table.Column<float>(type: "real", nullable: true),
                    ColorPaletteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colors_ColorPalettes_ColorPaletteId",
                        column: x => x.ColorPaletteId,
                        principalTable: "ColorPalettes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ColorPaletteId",
                table: "Colors",
                column: "ColorPaletteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "ColorPalettes");
        }
    }
}
