using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardMaker.Models
{
    public class ColorPalette
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<ColorColorPalette> ColorPalettes { get; set; }
        public string OwnerId { get; set; }
        public IdentityUser Owner { get; set; }

        [NotMapped]
        public List<Color> Colors { get; set; }

        public ColorPalette(string Name)
        {
            this.Name=Name;
        }

        public ColorPalette()
        {
            ColorPalettes = new List<ColorColorPalette>(); 
        }
    }
}