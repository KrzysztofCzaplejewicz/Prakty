using System;
using System.Linq;
using LigaFutbolu.Models;

namespace LigaFutbolu.DataContexts
{
    public static class DbInitializer
    {
        public static void Initialize(LigaContext context)
        {
            context.Database.EnsureCreated();

            if (context.Zawodniks.Any())
            {
                return;
            }

            var zawodnicy = new Zawodnik[]
            {
                new Zawodnik {IdZawodnik = 1,Imie = "Krzysztof", Nazwisko = "Czaplej" },
                new Zawodnik {IdZawodnik = 2,Imie = "Karol", Nazwisko = "Małecki" },
                new Zawodnik {IdZawodnik = 3,Imie = "Paweł", Nazwisko = "Kondzior"},
                new Zawodnik {IdZawodnik = 4,Imie = "Karcio", Nazwisko = "Ruchacz"},
                new Zawodnik {IdZawodnik = 5,Imie = "Paweł", Nazwisko = "Czaplej" },
                new Zawodnik {IdZawodnik = 6,Imie = "Eryk", Nazwisko = "Skweryk"},

            };
            foreach (Zawodnik z in zawodnicy)
            {
                context.Zawodniks.Add(z);
            }
            context.SaveChanges();

            var druzyna = new DruzynyModel[]
            {
                new DruzynyModel {IdDruzyny = 1,Nazwa = "Lowlanders", Miasto = "Białystok"},
                new DruzynyModel {IdDruzyny = 2,Nazwa = "Panters", Miasto = "Wrocław"},
                new DruzynyModel {IdDruzyny = 3,Nazwa = "Barbariens", Miasto = "Janów"},
                new DruzynyModel {IdDruzyny = 4,Nazwa = "Łorriors", Miasto = "Knyszyn"},
            };
            foreach (DruzynyModel d in druzyna)
            {
                context.DruzynyModels.Add(d);
            }
            context.SaveChanges();

            var ligi = new Liga[]
            {
                new Liga {Grade = Grade.TOPLIGA, IdZawodnik = 1, IdDruzyny = 1},
                new Liga {Grade = Grade.PLFA1, IdZawodnik = 2, IdDruzyny = 3},
                new Liga {Grade = Grade.PLFA2, IdZawodnik = 4, IdDruzyny = 4},
                new Liga {Grade = Grade.TOPLIGA, IdZawodnik = 3, IdDruzyny = 2},
            };
            foreach (Liga l in ligi)
            {
                context.Ligas.Add(l);
            }
            context.SaveChanges();

        }
    }
}