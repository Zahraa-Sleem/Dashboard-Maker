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
        public DbSet<Color> Colors { get; set; }
        public DbSet<ColorPalette> ColorPalettes{ get; set; }
        public DbSet<VisualizationType> VisualizationTypes{ get; set; }
        public DbSet<DataSource> DataSources { get; set; }
        public DbSet<Visualization> Visualization { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the many-to-many relationship
            modelBuilder.Entity<ColorPalette>()
                     .HasMany(cp => cp.Colors)
                     .WithMany(c => c.ColorPalettes);

            // Call the base class implementation to ensure Identity configuration is applied
            base.OnModelCreating(modelBuilder);
        }
    }
}