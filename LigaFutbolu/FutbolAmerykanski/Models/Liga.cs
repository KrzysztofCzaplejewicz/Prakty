using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace FutbolAmerykanski.Models
{
    public enum Grade
    {
        TOPLIGA, PLFA1, PLFA2
    }


    public class Liga
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LigaId { get; set; }
    //    public int IdZawodnik { get; set; }
   //     public int IdDruzyny { get; set; }
        public Grade? Grade { get; set; }
        public Zawodnik Zawodnik { get; set; }
        public DruzynaModel DruzynyModel { get; set; }

     //   public ICollection<Zawodnik> Zawodniks { get; set; }
     //   public ICollection<DruzynaModel> DruzynaModels { get; set; }
    }
}
