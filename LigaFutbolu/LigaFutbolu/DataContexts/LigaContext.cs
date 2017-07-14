using LigaFutbolu.Models;
using Microsoft.EntityFrameworkCore;

namespace LigaFutbolu.DataContexts
{
    public class LigaContext : DbContext
    {
        public LigaContext(DbContextOptions<LigaContext> options) : base(options)
        {

        }
        public DbSet<Zawodnik> Zawodniks { get; set; }
        public DbSet<DruzynyModel> DruzynyModels { get; set; }
        public DbSet<Liga> Ligas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zawodnik>().ToTable("Zawodnik");
            modelBuilder.Entity<DruzynyModel>().ToTable("Drużyna");
            modelBuilder.Entity<Liga>().ToTable("liga");
        }
    }
}