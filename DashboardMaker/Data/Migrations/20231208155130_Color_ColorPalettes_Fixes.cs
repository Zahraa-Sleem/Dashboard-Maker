using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashboardMaker.Data.Migrations
{
    /// <inheritdoc />
    public partial class Color_ColorPalettes_Fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_ColorPalettes_ColorPaletteId",
                table: "Color");

            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_Users_UserId",
                table: "Dashboards");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_UserId",
                table: "Dashboards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Color_ColorPaletteId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "ColorPaletteId",
                table: "Color");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "Colors");

            migrationBuilder.RenameColumn(
                name: "hexadecimalValue",
                table: "Colors",
                newName: "HexadecimalValue");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HexadecimalValue",
                table: "Colors",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "HexadecimalValue");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorsColorPalettes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "HexadecimalValue",
                table: "Color",
                newName: "hexadecimalValue");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Dashboards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "hexadecimalValue",
                table: "Color",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Color",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ColorPaletteId",
                table: "Color",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_UserId",
                table: "Dashboards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Color_ColorPaletteId",
                table: "Color",
                column: "ColorPaletteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_ColorPalettes_ColorPaletteId",
                table: "Color",
                column: "ColorPaletteId",
                principalTable: "ColorPalettes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_Users_UserId",
                table: "Dashboards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
