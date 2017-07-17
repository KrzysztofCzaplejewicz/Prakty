using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }


        public virtual ICollection<Team> Teams { get; set; }

        [DisplayName("Team")]
        [Required]
        public int TeamId { get; set; }


        public virtual Team Team { get; set; }

        [DisplayName("League")]
        [Required]
        public int LeagueId { get; set; }


        public virtual League League { get; set; }
    }
}