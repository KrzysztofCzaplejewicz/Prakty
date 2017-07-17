using MVC.Models;
using System.Data.Entity;

namespace MVC.Data
{
    public class Context : DbContext  
    {
        public Context() : base("name=MVC") { }
     
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}