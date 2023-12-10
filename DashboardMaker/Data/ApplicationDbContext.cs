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
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ColorPalette> ColorPalettes{ get; set; }
        public DbSet<ColorColorPalette> ColorColorPalettes { get; set; }
        public DbSet<VisualizationType> VisualizationTypes{ get; set; }
        public DbSet<DataSource> DataSources { get; set; }
        public DbSet<Visualization> Visualization { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ColorColorPalette>()
                 .HasKey(ccp => new { ccp.ColorPaletteId, ccp.hexadecimal });

            modelBuilder.Entity<ColorColorPalette>()
                .HasOne(ccp => ccp.Palette)
                .WithMany(p => p.ColorPalettes)
                .HasForeignKey(ccp => ccp.ColorPaletteId);


            modelBuilder.Entity<ColorColorPalette>()
                .HasOne(ccp => ccp.Color)
                .WithMany(c => c.ColorPalettes)
                .HasForeignKey(ccp => ccp.hexadecimal);


            // Call the base class implementation to ensure Identity configuration is applied
            base.OnModelCreating(modelBuilder);
        }
    }
}