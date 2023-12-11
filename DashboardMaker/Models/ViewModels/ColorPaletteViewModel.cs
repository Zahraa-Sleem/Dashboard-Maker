namespace DashboardMaker.Models.ViewModels
{
    public class ColorPaletteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SelectedColors { get; set; }

        public ColorPaletteViewModel() { }
        public ColorPaletteViewModel(int Id,string Name,string SelectedColors) 
        {
            this.Id = Id;
            this.Name = Name;   
            this.SelectedColors = SelectedColors;
        }

    }
}
