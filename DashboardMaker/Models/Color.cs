using System.ComponentModel.DataAnnotations;

namespace DashboardMaker.Models
{
    public class Color
    {
        [Key]
        public string HexadecimalValue { get; set; }
        public ICollection<ColorColorPalette> ColorPalettes { get; set; }

        // Default constructor for Entity Framework
        public Color()
        {
        }

        // Constructor with parameters
        public Color(string hexadecimal)
        {
            HexadecimalValue = hexadecimal;
        }
    }
}

