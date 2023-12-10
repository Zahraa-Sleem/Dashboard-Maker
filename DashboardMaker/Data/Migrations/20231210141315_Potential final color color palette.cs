using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashboardMaker.Data.Migrations
{
    /// <inheritdoc />
    public partial class Potentialfinalcolorcolorpalette : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "ColorColorPalettes",
                columns: table => new
                {
                    ColorPaletteId = table.Column<int>(type: "int", nullable: false),
                    hexadecimal = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorColorPalettes", x => new { x.ColorPaletteId, x.hexadecimal });
                    table.ForeignKey(
                        name: "FK_ColorColorPalettes_ColorPalettes_ColorPaletteId",
                        column: x => x.ColorPaletteId,
                        principalTable: "ColorPalettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorColorPalettes_Colors_hexadecimal",
                        column: x => x.hexadecimal,
                        principalTable: "Colors",
                        principalColumn: "HexadecimalValue",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorColorPalettes_hexadecimal",
                table: "ColorColorPalettes",
                column: "hexadecimal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ColorsColorPalettes",
                columns: table => new
                {
                    ColorPalettesId = table.Column<int>(type: "int", nullable: false),
                    ColorsHexadecimalValue = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorsColorPalettes", x => new { x.ColorPalettesId, x.ColorsHexadecimalValue });
                    table.ForeignKey(
                        name: "FK_ColorsColorPalettes_ColorPalettes_ColorPalettesId",
                        column: x => x.ColorPalettesId,
                        principalTable: "ColorPalettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorsColorPalettes_Colors_ColorsHexadecimalValue",
                        column: x => x.ColorsHexadecimalValue,
                        principalTable: "Colors",
                        principalColumn: "HexadecimalValue",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorsColorPalettes_ColorsHexadecimalValue",
                table: "ColorsColorPalettes",
                column: "ColorsHexadecimalValue");
        }
    }
}
