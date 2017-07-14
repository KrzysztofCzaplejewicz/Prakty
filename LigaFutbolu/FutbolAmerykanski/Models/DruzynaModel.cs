using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutbolAmerykanski.Models
{
    public class DruzynaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDruzyny { get; set; }
        public string Nazwa { get; set; }
        public string Miasto { get; set; }

        public int IdZawodnik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
//      public ICollection<Zawodnik> Zawodniks { get; set; }
        public List<Zawodnik> Zawodniks { get; set; }
    }

    
}
