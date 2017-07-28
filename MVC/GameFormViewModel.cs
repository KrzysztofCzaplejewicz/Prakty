using MVC.Models;
using System.Collections.Generic;

namespace GameHub.ViewModels
{
    public class GameFormViewModel
    {

        public string Town { get; set; }

        [FutureDate]
        public string Date { get; set; }

        [ValidTime]
        public string Time { get; set; }

        public byte Team { get; set; }

        public IEnumerable<Team> Teams { get; set; }
    }
}