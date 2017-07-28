using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public  class Players
    {
        

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int Age { get; set; }

        public int TeamId { get; set; }
        

         public virtual Teams Teams { get; set; }

      
    }
}
