using API_EXAMPLE.Models;
using System.Data.Entity;

namespace API_EXAMPLE.Data
{
    public class Context : DbContext
    {
        public Context() : base("name=MVC") { }

        public DbSet<Player> Players { get; set; }
    }
}