using System.ComponentModel.DataAnnotations;

namespace vega.Models
{
    
    public class Feature
    {
        [Required]
        [StringLength(255)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}