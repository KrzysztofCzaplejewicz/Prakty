using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class League
    {
        public int Id { get; set; }
        public string LeaugeName { get; set; }
        //public virtual ICollection<Team> Teams { get; set; }
        //public virtual ICollection<Player> Players { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
       public virtual ICollection<Team> Teams { get; set; }


       [DisplayName("Team")]
        public int TeamId { get; set; }
       public virtual Team Team { get; set; }
       [DisplayName("League")]
        public int LeagueId { get; set; }
      public virtual League League { get; set; }
    }

    public class Team
    {
        public Team()
        {

            Players = new List<Player>();
        }
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string Town { get; set; }
        public virtual ICollection<Player> Players { get; set; }

        public string TeamCode => TeamName.Substring(0, 1) + ":" + Town.Substring(0, 1);
    }
}