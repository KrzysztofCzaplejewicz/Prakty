using MVC_API.Models;
using System.Data.Entity;

namespace MVC_API.Data
{
    public class Context : DbContext
    {
        public Context() : base("name=MVC") { }

        public DbSet<Player> Players { get; set; }


    }
}