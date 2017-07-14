using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaData
{
    public class Ligi
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nazwa { get; set; }
        
        public Druzyny Lista { get; set; }

    }
}
