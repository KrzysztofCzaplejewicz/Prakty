namespace GameHub.Data.test
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Leagues> Leagues { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<VersionInfo> VersionInfo { get; set; }

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
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Teams)
                .HasForeignKey(e => e.TeamId);

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
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Teams)
                .HasForeignKey(e => e.TeamId);

            modelBuilder.Entity<Teams>()
                .HasMany(e => e.Players)
                .WithRequired(e => e.Teams)
                .HasForeignKey(e => e.TeamId);
        }
    }
}
