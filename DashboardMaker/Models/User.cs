using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DashboardMaker.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
    }
}