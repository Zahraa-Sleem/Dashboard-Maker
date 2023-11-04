using System;
using System.ComponentModel.DataAnnotations;

namespace DashboardMaker.Models
{
    public class DataSource
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Source Name is required")]
        public string SourceName { get; set; }

        [Required(ErrorMessage = "Data Source Type is required")]
        public string DataSourceType { get; set; }

        public string? ConnectionString { get; set; }

        public string? TableName { get; set; }

        // File properties
        public string FileName { get; set; } // File name with extension
        public byte[] FileData { get; set; } // Actual file data
    }
}
