using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string TeamName { get; set; }
        [Required]
        [StringLength(255)]
        public string Town { get; set; }
        public int Seasons { get; set; }

        public int LeagueId { get; set; }
        public League League { get; set; }

        public ICollection<Player> Players { get; set; }

        public Team()
        {
            Players = new Collection<Player>();
        }
        
    }
}
