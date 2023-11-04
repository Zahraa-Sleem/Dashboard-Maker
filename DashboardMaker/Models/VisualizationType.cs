using System.ComponentModel.DataAnnotations;

namespace DashboardMaker.Models
{
    public class VisualizationType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Type is required")]
        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters")]
        [Display(Name = "Type")]
        public string Type { get; set; }
    }
}

