namespace GameHub.ViewModels
{
    public class GamesViewModel
    {
        public int Id { get; set; }
        public int Host { get; set; }
        public int Visitor { get; set; }
        
        public int? LeagueId { get; set; }

        public LeaguesViewModel Leagues { get; set; }
        public TeamsViewModel Teams { get; set; }
        public TeamsViewModel Teams1 { get; set; }

        

        public string Town { get; set; }
        public string TeamName { get; set; }
        public string TeamName1 { get; set; }
        public string LeagueName { get; set; }

        [FutureDate]
        public string Date { get; set; }

        [ValidTime]
        public string Time { get; set; }    

        public int? ScoreHost { get; set; }
        public int? ScoreVisitor { get; set; }
        
        public int? Quatr1Host { get; set; }

        public int? Quatr1Visitor { get; set; }

        public int? Quatr2Host { get; set; }

        public int? Quatr3Host { get; set; }

        public int? Quatr4Host { get; set; }

        public int? Quatr2Visitor { get; set; }

        public int? Quatr3Visitor { get; set; }

        public int? Quatr4Visitor { get; set; }

        public string UrlIconHost { get; set; }
        public string UrlIconVisitor { get; set; }
    }
}