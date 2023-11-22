namespace DashboardMaker.Models
{
    public class ColorPalette
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<string> Colors { get; set; }

        // Constructor to initialize the Colors property with default values
        public ColorPalette()
        {
            // Consider Red,Green,Blue as the default colors
            Colors = new List<string> { "#FF0000", "#00FF00", "#0000FF" };
        }
    }
}

