using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core.Controllers.Resources
{
    public class SaveTeamResource
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string Town { get; set; }
        public int Seasons { get; set; }
        public int LeagueId { get; set; }
        public ICollection<PlayerResource> Players { get; set; }

        public SaveTeamResource()
        {
            Players = new Collection<PlayerResource>();
        }

    }
}
