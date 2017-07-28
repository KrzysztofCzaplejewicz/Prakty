using MVC.Models;
using System.Data.Entity;

namespace GameHub.Models
{
    public class Context : DbContext
    {
        public Context() : base("name=MVC") { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }

    }
        
    
}