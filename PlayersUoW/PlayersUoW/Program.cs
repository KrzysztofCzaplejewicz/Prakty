using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URF.EntityFramework;

namespace PlayersUoW
{
    public class Program
    {


        static void Main(string[] args)
        {
          //  CreateTeams();
            AddPlayer();
        }

        private static void AddPlayer()
        {
            var db = new Context();
            var teams = db.Teamss.Find(1);
            teams.Playerss.Add(new Players {FirstName = "Krzysztof", LastName = "Czaplejewicz", Age = 24});
            db.SaveChanges();
        }

        private static void CreateTeams()
        {
            var teams = new Teams { TeamName = "Lowlanders", Town = "Białystok" };
            var db = new Context();
            db.Teamss.Add(teams);
            db.SaveChanges();
        }
}
}
