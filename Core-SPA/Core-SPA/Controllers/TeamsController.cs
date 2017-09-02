using AutoMapper;
using Core.Controllers.Resources;
using Core.Core;
using Core.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Controllers
{
    [Produces("application/json")]
    [Route("api/Teams")]
    public class TeamsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ITeamRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public TeamsController(IMapper mapper, ITeamRepository repository, IUnitOfWork unitOfWork )
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] SaveTeamResource teamResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var team = mapper.Map<SaveTeamResource, Team>(teamResource);

            repository.Add(team);
            
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Team, TeamResource>(team);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] SaveTeamResource teamResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var team = await repository.GetTeam(id);

            if (team == null)
                return NotFound();
           

            mapper.Map<SaveTeamResource, Team>(teamResource, team);


            await unitOfWork.CompleteAsync();


            var result = mapper.Map<Team, TeamResource>(team);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await repository.GetTeam(id);
            if (team == null)
                return NotFound();
            repository.Remove(team);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var team = await repository.GetTeam(id);

            if (team == null)
            return NotFound();

            var result = mapper.Map<Team, TeamResource>(team);
            return Ok(result);
        }

       [HttpGet]
       public async Task<IEnumerable<TeamResource>> GetTeams(TeamQueryResource teamResource )
       {
           
            var teams = await repository.GetTeams(teamResource);

          return mapper.Map<IEnumerable<Team>, IEnumerable<TeamResource>>(teams);
       
       }
    }
}