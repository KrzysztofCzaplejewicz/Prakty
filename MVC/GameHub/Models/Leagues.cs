using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public partial class Leagues
    {
        public Leagues()
        {
            Games = new HashSet<Games>();
            Teams = new HashSet<Teams>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string LeagueName { get; set; }

        public virtual ICollection<Games> Games { get; set; }

        public virtual ICollection<Teams> Teams { get; set; }
    }
}
