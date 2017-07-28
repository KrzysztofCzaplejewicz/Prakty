using MVC.Models;
using System;

namespace GameHub.Models
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Town { get; set; }

        public Team Team { get; set; }
        public byte TeamId { get; set; }

        public League League { get; set; }
        public byte LeagueId { get; set; }

    }
}