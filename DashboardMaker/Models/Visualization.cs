using System;
using System.ComponentModel.DataAnnotations;

namespace DashboardMaker.Models
{
    public class Visualization
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        [Display(Name = "Visualization Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Data Source is required")]
        [Display(Name = "Data Source")]
        public int DataSourceId { get; set; }
        public DataSource DataSource { get; set; }

        [Required(ErrorMessage = "Visualization Type is required")]
        [Display(Name = "Visualization Type")]
        public int VisualizationTypeId { get; set; }
        public VisualizationType VisualizationType { get; set; }

        [Display(Name = "Color Palette")]
        [Required(ErrorMessage = "Color Palette is required")]
        public int ColorPaletteId { get; set; }
        public ColorPalette ColorPalette { get; set; }

        [Display(Name = "Dashboard")]
        [Required(ErrorMessage = "Dashboard is required")]
        public int DashboardId { get; set; }
        public Dashboard Dashboard { get; set; }
        public string? TablesJoin { get; set; }
    }
}
