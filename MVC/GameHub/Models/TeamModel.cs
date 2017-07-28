using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public class TeamModel
    {
        public int Id { get; set; }

        [Required]
        public string TeamName { get; set; }

        [Required]
        public string Town { get; set; }


        public int? LeagueId { get; set; }


     
        


    }
}