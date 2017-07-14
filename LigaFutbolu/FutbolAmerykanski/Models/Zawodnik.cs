using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutbolAmerykanski.Models
{
    public class Zawodnik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int IdZawodnik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
     //   public DateTime LigaDateTime { get; set; }
     //   public string IdDruzyny { get; set; }

        public DruzynaModel DruzynaModel { get; set; }

     //   public List<DruzynaModel> DruzynaModelZawodniks { get; set; }
        public ICollection<Liga> Ligas { get; set; }
    }
}
