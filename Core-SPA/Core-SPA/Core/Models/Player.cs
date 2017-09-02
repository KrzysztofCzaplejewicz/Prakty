using System.ComponentModel.DataAnnotations;

namespace Core.Core.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        public bool IsRegistered { get; set; }
        
        public int TeamId { get; set; }
        public Team Team { get; set; }

    }
}