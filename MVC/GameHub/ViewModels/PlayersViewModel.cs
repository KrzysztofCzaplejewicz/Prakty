namespace GameHub.ViewModels
{
    public class PlayersViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       // public string TeamName { get; set; }
        public int Age { get; set; }
        //public int TeamId { get; set; }
        public TeamsViewModel Teams { get; set; }
    }
}