using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using MVC.Models;

namespace MVC.Data
{
    public class Context : DbContext  
    {
        public Context() : base("name=MVC") { }
     
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }
    }
}