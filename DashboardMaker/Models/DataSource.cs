using System;
using System.ComponentModel.DataAnnotations;

namespace DashboardMaker.Models
{
    public class DataSource
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Source Name is required")]
        [Display(Name ="Source Name")]
        public string SourceName { get; set; }

        [Required(ErrorMessage = "Data Source Type is required")]
        [Display(Name = "Data Source Type")]
        public string DataSourceType { get; set; }

        public string? ConnectionString { get; set; }

        public string? FileName { get; set; } // File name with extension
        public byte[]? FileData { get; set; } // Actual file data
    }
}
