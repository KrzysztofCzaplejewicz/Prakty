using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class League
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string LeagueName { get; set; }

        public ICollection<Team> Teams { get; set; }

        public League()
        {
            Teams = new Collection<Team>();
        }


    }
}