namespace GameHub.ViewModels
{
    public class TeamsViewModel
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string Town { get; set; }
        public int? LeagueId { get; set; }
        //public string LeagueName { get; set; }
        public string UrlIcon { get; set; }

        public LeaguesViewModel Leagues { get; set; }
        public string LeagueName { get; set; }
    }
}