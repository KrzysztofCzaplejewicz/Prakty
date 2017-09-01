using AutoMapper;
using Core.Controllers.Resources;
using Core.Models;
using Core.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Controllers
{
    [Produces("application/json")]
    [Route("api/Teams")]
    public class TeamsController : Controller
    {
        private readonly CoreDbContext context;
        private readonly IMapper mapper;

        public TeamsController(CoreDbContext context, IMapper mapper )
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] SaveTeamResource teamResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var team = mapper.Map<SaveTeamResource, Team>(teamResource);

            context.Teams.Add(team);
            await context.SaveChangesAsync();

            var result = mapper.Map<Team, TeamResource>(team);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] SaveTeamResource teamResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var team = await context.Teams.FindAsync(id);

            if (team == null)
                return NotFound();
           

            mapper.Map<SaveTeamResource, Team>(teamResource, team);

            
            await context.SaveChangesAsync();


            var result = mapper.Map<Team, TeamResource>(team);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await context.Teams.FindAsync(id);
            if (team == null)
                return NotFound();
            context.Teams.Remove(team);
            await context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var team = await context.Teams.Include(x=>x.Players).SingleOrDefaultAsync(x => x.Id == id);

            if (team == null)
            return NotFound();

            var teamResource = mapper.Map<Team, TeamResource>(team);
            return Ok(teamResource);
        }

       [HttpGet]
       public async Task<IEnumerable<TeamResource>> GetTeams(TeamQueryResource teamResource )
       {
           var resource = mapper.Map<TeamQueryResource, TeamQuery>(teamResource);
           var teams = context.Teams.Include(x=> x.Players).AsQueryable();
           var sru = await teams.ToListAsync();

          return mapper.Map<IEnumerable<Team>, IEnumerable<TeamResource>>(sru);
       
       }
    }
}