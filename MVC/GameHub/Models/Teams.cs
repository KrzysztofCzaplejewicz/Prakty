using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public class Teams
    {
        public Teams()
        {
            Games = new HashSet<Games>();
            Players = new HashSet<Players>();
        }

        public int Id { get; set; }

        [Required]
        public string TeamName { get; set; }

        [Required]
        public string Town { get; set; }
        
        public int? LeagueId { get; set; }
        
        public virtual Leagues Leagues { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Players> Players { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Games> Games { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Games> Games1 { get; set; }

    }
}
