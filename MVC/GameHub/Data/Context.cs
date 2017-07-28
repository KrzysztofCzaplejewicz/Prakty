using GameHub.Models;
using System.Data.Entity;

namespace GameHub.Data
{
    public class Context : DbContext
    {
        public Context() : base("name=MVC") { }

        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Leagues> Leagues { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leagues>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.Leagues)
                .HasForeignKey(e => e.LeagueId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Leagues>()
                .HasMany(e => e.Teams)
                .WithOptional(e => e.Leagues)
                .HasForeignKey(e => e.LeagueId);


            modelBuilder.Entity<Teams>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.Teams)
                .HasForeignKey(e => e.Host)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teams>()
                .HasMany(e => e.Games1)
                .WithRequired(e => e.Teams1)
                .HasForeignKey(e => e.Visitor)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<Teams>()
                .HasMany(e => e.Players)
                .WithRequired(e => e.Teams)
                .HasForeignKey(e => e.TeamId);

            

        }
    }
        
    
}