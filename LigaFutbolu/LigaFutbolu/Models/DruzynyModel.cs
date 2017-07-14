using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LigaFutbolu.Models
{
    public class DruzynyModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdDruzyny { get; set;  }
        public string Nazwa { get; set; }
        public string Miasto { get; set; }
        
        public ICollection<Liga> Ligas { get; set; }

    }
}