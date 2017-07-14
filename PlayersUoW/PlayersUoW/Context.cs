using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersUoW
{
    class Context : DbContext
    {
        public DbSet<Teams> Teamss { get; set; }
        public DbSet<Players> Playerss { get; set; }
    }
}
