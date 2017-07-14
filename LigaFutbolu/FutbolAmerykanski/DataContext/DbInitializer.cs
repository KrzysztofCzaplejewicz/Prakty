using System.Linq;
using FutbolAmerykanski.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FutbolAmerykanski.DataContext
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
           
            };
            foreach (Zawodnik z in zawodnicy)
            {
                context.Zawodniks.Add(z);
            }
            
            context.SaveChanges();

            var druzyna = new DruzynaModel[]
            {
              
            };
            foreach (DruzynaModel d in druzyna)
            {
                context.DruzynaModels.Add(d);
            }
            context.SaveChanges();

            var ligi = new Liga[]
            {
               
            };
            foreach (Liga l in ligi)
            {
                context.Ligas.Add(l);
            }
            context.SaveChanges();

        }
    }
}