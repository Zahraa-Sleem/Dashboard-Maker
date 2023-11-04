namespace DashboardMaker.Models
{
    public class ColorPalette
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Color> Colors { get; set; }

        // Constructor to initialize the Colors list
        public ColorPalette()
        {
            Colors = new List<Color>();
        }

        // Method to add a color to the palette
        public void AddColor(Color color)
        {
            Colors.Add(color);
        }
    }
}

