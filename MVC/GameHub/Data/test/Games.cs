namespace GameHub.Data.test
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Games
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string DateTime { get; set; }

        [StringLength(50)]
        public string Town { get; set; }

        public int LeagueId { get; set; }

        public int Host { get; set; }

        public int Visitor { get; set; }

        public virtual Leagues Leagues { get; set; }

        public virtual Teams Teams { get; set; }

        public virtual Teams Teams1 { get; set; }
    }
}
