using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LigaFutbolu.Controllers;

namespace LigaFutbolu.Models
{
    public class DruzynyData : DropCreateDatabaseIfModelChanges<LigaFutboluJednostki>
    {
        protected override void Seed(LigaFutboluJednostki context)
        {
            var druzynyNazwa = new List<DruzynyModel>
            {
                new DruzynyModel {Imie = "Lowlanders"},
                new DruzynyModel {Imie = "Panters"},
                new DruzynyModel {Imie = "Seahowks"},
                new DruzynyModel {Imie = "Barbarians"},
                new DruzynyModel {Imie = "Łorriors"},

            };

            var sklad = new List<Zawodnik>
            {
                new Zawodnik {Imie = "Stefan"},
                new Zawodnik {Imie = "Zdzisiek"},
                new Zawodnik {Imie = "Karcio"},
                new Zawodnik {Imie = "Alfons"},
                new Zawodnik {Imie = "Damian"},
                new Zawodnik {Imie = "Sebastian"},
                new Zawodnik {Imie = "Paweł"},

            };

            var skladNazwisko = new List<Zawodnik>
            {
                new Zawodnik {Nazwisko = "Kołpaczenko"},
                new Zawodnik {Nazwisko = "Krasnal"},
                new Zawodnik {Nazwisko = "Czaplej"},
                new Zawodnik {Nazwisko = "Kondzior"},
                new Zawodnik {Nazwisko = "Ruchacz"},

            };




        }
    }
}