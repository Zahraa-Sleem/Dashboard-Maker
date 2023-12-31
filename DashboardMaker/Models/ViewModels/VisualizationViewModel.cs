namespace DashboardMaker.Models.ViewModels
{
	public class VisualizationViewModel
	{
		public Visualization Visualization { get; set; }
		public List<ColorPalette> ColorPalettes { get; set; }
		public List<DataSource> DataSources { get; set; }
	}
}
