using GameHub.ViewModels;
using System.Data.Entity;

namespace GameHub.Data
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<PlayersView> PlayersView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
