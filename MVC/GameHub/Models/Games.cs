using System;
using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public  class Games
    {
        public int Id { get; set; }

        
        public DateTime DateTime { get; set; }

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
