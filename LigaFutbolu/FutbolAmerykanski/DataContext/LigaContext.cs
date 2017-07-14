using FutbolAmerykanski.Models;
using Microsoft.EntityFrameworkCore;

namespace FutbolAmerykanski.DataContext
{
    public class  LigaContext : DbContext
    {
        public LigaContext(DbContextOptions<LigaContext> options) : base(options)
        {

        }
        public DbSet<Zawodnik> Zawodniks { get; set; }
        public DbSet<DruzynaModel> DruzynaModels { get; set; }
        public DbSet<Liga> Ligas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DruzynaModel>()
                .HasMany(z => z.Zawodniks)
                .WithOne();
            
            modelBuilder.Entity<Liga>().ToTable("liga");
            modelBuilder.Entity<Zawodnik>().ToTable("Zawodnik");
            
        }
    }
}
