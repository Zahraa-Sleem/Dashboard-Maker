using System.ComponentModel.DataAnnotations;

namespace DashboardMaker.Models
{
    public class Color
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        [Display(Name = "Color Name")]
        public string? Name { get; set; }

        [RegularExpression("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{8})$", ErrorMessage = "Invalid Hex Code")]
        [Display(Name = "Hex Code")]
        public string? HexCode { get; set; }

        [Range(0, 255, ErrorMessage = "Red value must be between 0 and 255")]
        public int? Red { get; set; }

        [Range(0, 255, ErrorMessage = "Green value must be between 0 and 255")]
        public int? Green { get; set; }

        [Range(0, 255, ErrorMessage = "Blue value must be between 0 and 255")]
        public int? Blue { get; set; }

        [Range(0.0, 1.0, ErrorMessage = "Alpha value must be between 0.0 and 1.0")]
        public float? Alpha { get; set; }
    }
}
