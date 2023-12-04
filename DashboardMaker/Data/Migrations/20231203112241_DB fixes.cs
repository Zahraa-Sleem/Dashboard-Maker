using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashboardMaker.Data.Migrations
{
    /// <inheritdoc />
    public partial class DBfixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_ColorPalettes_ColorPaletteId",
                table: "Colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "Alpha",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "Blue",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "Green",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "HexCode",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "Red",
                table: "Colors");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "Color");

            migrationBuilder.RenameIndex(
                name: "IX_Colors_ColorPaletteId",
                table: "Color",
                newName: "IX_Color_ColorPaletteId");

            migrationBuilder.AlterColumn<string>(
                name: "FileData",
                table: "DataSources",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "hexadecimalValue",
                table: "Color",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_ColorPalettes_ColorPaletteId",
                table: "Color",
                column: "ColorPaletteId",
                principalTable: "ColorPalettes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_ColorPalettes_ColorPaletteId",
                table: "Color");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "hexadecimalValue",
                table: "Color");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "Colors");

            migrationBuilder.RenameIndex(
                name: "IX_Color_ColorPaletteId",
                table: "Colors",
                newName: "IX_Colors_ColorPaletteId");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FileData",
                table: "DataSources",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Alpha",
                table: "Colors",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Blue",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Green",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HexCode",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Colors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Red",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_ColorPalettes_ColorPaletteId",
                table: "Colors",
                column: "ColorPaletteId",
                principalTable: "ColorPalettes",
                principalColumn: "Id");
        }
    }
}
