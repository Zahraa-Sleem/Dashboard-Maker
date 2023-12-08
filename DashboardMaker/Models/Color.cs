using System.ComponentModel.DataAnnotations;

namespace DashboardMaker.Models
{
    public class Color
    {
        [Key]
        public string HexadecimalValue { get; set; }
        public ICollection<ColorPalette> ColorPalettes { get; set; }
    }
}

