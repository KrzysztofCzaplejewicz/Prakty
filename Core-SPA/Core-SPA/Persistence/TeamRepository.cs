using Core.Controllers.Resources;
using Core.Core;
using Core.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Persistence
{
    public class TeamRepository : ITeamRepository
    {
        private readonly CoreDbContext context;

        public TeamRepository(CoreDbContext context)
        {
            this.context = context;
        }
        public async Task<Team> GetTeam(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Teams.FindAsync(id);

            return await context.Teams.Include(x => x.Players).SingleOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<IEnumerable<Team>> GetTeams(TeamQueryResource teamResource)
        {
            
            var teams = context.Teams.Include(x => x.Players).AsQueryable();
            return await teams.ToListAsync();

            
        }

            public void Add(Team team)
        {
            context.Add(team);
        }

        public void Remove(Team team)
        {
            context.Remove(team);
        }

        
    }
    
}
