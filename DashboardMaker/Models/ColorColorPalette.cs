namespace DashboardMaker.Models
{
    public class ColorColorPalette
    {
        public int ColorPaletteId { get; set; }
        public ColorPalette Palette { get; set; }
        public string hexadecimal { get; set; }
        public Color Color { get; set; }

        public ColorColorPalette(string hexadecimal,int ColorPaletteId)
        {
            this.hexadecimal = hexadecimal;
            this.ColorPaletteId = ColorPaletteId;
        }
    }
}
