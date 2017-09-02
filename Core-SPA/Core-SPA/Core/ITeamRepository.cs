using Core.Controllers.Resources;
using Core.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Core
{
    public interface ITeamRepository
    {
        Task<Team> GetTeam(int id, bool includeRelated = true);
        Task<IEnumerable<Team>> GetTeams(TeamQueryResource teamResource);
        void Add(Team team);
        void Remove(Team team);
        
    }
}