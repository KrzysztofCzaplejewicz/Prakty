using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JetBrains.Annotations;
using LigaData;
using System.Data.Entity;

namespace LigaFutbolu.DataContexts
{
    public class DruzynyDb : DbContext
    {
        public DruzynyDb()
            : base("Default Connection")
        {
            
        }

        public DbSet<Ligi> Ligis { get; set; }
    }
    
}