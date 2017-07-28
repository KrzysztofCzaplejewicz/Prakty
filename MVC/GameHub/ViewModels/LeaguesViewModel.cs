using System.ComponentModel.DataAnnotations;

namespace GameHub.ViewModels
{
    public class LeaguesViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string LeagueName { get; set; }
    }
}