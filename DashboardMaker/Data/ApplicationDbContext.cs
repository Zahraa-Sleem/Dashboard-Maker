using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DashboardMaker.Models;

namespace DashboardMaker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<ColorPalette> ColorPalettes{ get; set; }
        public DbSet<VisualizationType> VisualizationTypes{ get; set; }
        public DbSet<DataSource> DataSources { get; set; }
        public DbSet<Visualization> Visualization { get; set; }

    }
}