namespace GameHub.ViewModels.test
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Games
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        public int Host { get; set; }

        public int Visitor { get; set; }

        public int? ScoreHost { get; set; }

        public int? ScoreVisitor { get; set; }

        public int? Quatr1Host { get; set; }

        public int? Quatr1Visitor { get; set; }

        public int? Quatr2Host { get; set; }

        public int? Quatr3Host { get; set; }

        public int? Quatr4Host { get; set; }

        public int? Quatr2Visitor { get; set; }

        public int? Quatr3Visitor { get; set; }

        public int? Quatr4Visitor { get; set; }

        public int? LeagueId { get; set; }

        public virtual Leagues Leagues { get; set; }

        public virtual Teams Teams { get; set; }

        public virtual Teams Teams1 { get; set; }
    }
}
