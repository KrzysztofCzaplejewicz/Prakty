using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class League
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string LeaugeName { get; set; }
        //public virtual ICollection<Team> Teams { get; set; }
        //public virtual ICollection<Player> Players { get; set; }
    }
}