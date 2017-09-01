using AutoMapper;
using Core.Controllers.Resources;
using Core.Models;
using Core.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Controllers
{
    [Produces("application/json")]
    [Route("api/Players")]
    public class PlayersController : Controller
    {
        private readonly CoreDbContext context;
        private readonly IMapper mapper;

        public PlayersController(CoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] SavePlayerResource playerResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var player = mapper.Map<SavePlayerResource, Player>(playerResource);

            context.Players.Add(player);
            await context.SaveChangesAsync();

            var result = mapper.Map<Player, PlayerResource>(player);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(int id,[FromBody] SavePlayerResource playerResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var player = await context.Players.FindAsync(id);

            if (player == null)
                return NotFound();

            mapper.Map<SavePlayerResource, Player>(playerResource, player);

            await context.SaveChangesAsync();

            var result = mapper.Map<Player, PlayerResource>(player);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var player = await context.Players.FindAsync(id);

            if (player == null)
                return NotFound();
            context.Players.Remove(player);
            await context.SaveChangesAsync();

            return Ok(id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer(int id)
        {
            var player = await context.Players.SingleOrDefaultAsync(x=>x.Id == id);

            if (player == null)
                return NotFound();
            var result = mapper.Map<Player, PlayerResource>(player);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IEnumerable<PlayerResource>> GetPlayers()
        {
            var players = await context.Players.ToListAsync();
            return mapper.Map<List<Player>, List<PlayerResource>>(players);
           
        }
    }
}