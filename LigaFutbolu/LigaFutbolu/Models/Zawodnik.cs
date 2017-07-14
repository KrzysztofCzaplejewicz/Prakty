using System;
using System.Collections.Generic;

namespace LigaFutbolu.Models
{
    public class Zawodnik
    {
        public int IdZawodnik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime LigaDateTime { get; set; }

        public ICollection<Liga> Ligas { get; set; }
        
    }
}