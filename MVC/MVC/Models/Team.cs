using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Team
    {
        public Team()
        {

            Players = new List<Player>();
        }
        public int Id { get; set; }
        [Required]
        public string TeamName { get; set; }

        [Required]
        public string Town { get; set; }


        public virtual IList<Player> Players { get; set; }

        public string TeamCode => TeamName.Substring(0, 1) + Town.Substring(0, 1);
    }
}