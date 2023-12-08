namespace DashboardMaker.Models
{
    public class ColorPalette
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Color> Colors { get; set; }
    }
}