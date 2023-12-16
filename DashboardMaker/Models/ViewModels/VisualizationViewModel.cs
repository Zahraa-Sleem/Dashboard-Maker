namespace DashboardMaker.Models.ViewModels
{
	public class VisualizationViewModel
	{
		public Visualization Visualization { get; set; }
		public List<VisualizationType> Types { get; set; }
		public List<ColorPalette> ColorPalettes { get; set; }
	}
}
