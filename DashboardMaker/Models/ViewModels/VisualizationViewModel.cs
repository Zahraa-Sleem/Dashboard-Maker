namespace DashboardMaker.Models.ViewModels
{
	public class VisualizationViewModel
	{
		public Visualization Visualization { get; set; }
		public IEnumerable<ColorPaletteViewModel> ColorPalettes { get; set; }
		public List<DataSource> DataSources { get; set; }
	}
}
