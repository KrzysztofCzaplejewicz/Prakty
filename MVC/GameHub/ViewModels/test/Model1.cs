namespace GameHub.ViewModels.test
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model14")
        {
        }

        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Leagues> Leagues { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leagues>()
                .HasMany(e => e.Games)
                .WithOptional(e => e.Leagues)
                .HasForeignKey(e => e.LeagueId);

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
                .WithOptional(e => e.Teams)
                .HasForeignKey(e => e.TeamId);
        }
    }
}
