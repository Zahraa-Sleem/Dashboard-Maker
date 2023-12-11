using System.ComponentModel.DataAnnotations;

namespace DashboardMaker.Models
{
    public class Dashboard
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        [Display(Name = "Dashboard Title")]
        public string Title { get; set; }
		//public int UserId { get; set; }

		//[Display(Name = "Owner")]
		//public IdentityUser Owner { get; set; }
	}
}
