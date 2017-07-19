using MVC_API.Data;
using MVC_API.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace MVC_API.Controllers
{
    public class PlayersController : ApiController
    {
        public Context Db = new Context();

        // GET: api/Players
        public IQueryable<Player> GetPlayers()
        {
            return Db.Players;
        }

        // GET: api/Players/5
        [HttpGet()]
        [ResponseType(typeof(Player))]
        public IHttpActionResult Get()
        {
            IHttpActionResult ret = null;
            List<Player> list = new List<Player>();
            ret = Ok(list);
            return ret;
        }

        // PUT: api/Players/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayers(int id, Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.Id)
            {
                return BadRequest();
            }

            Db.Entry(player).State = EntityState.Modified;

            try
            {
                Db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Players
        [ResponseType(typeof(Player))]
        public IHttpActionResult PostPlayers(Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Db.Players.Add(player);
            Db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = player.Id }, player);
        }

        // DELETE: api/Players/5
        [ResponseType(typeof(Player))]
        public IHttpActionResult DeletePlayers(int id)
        {
            Player players = Db.Players.Find(id);
            if (players == null)
            {
                return NotFound();
            }

            Db.Players.Remove(players);
            Db.SaveChanges();

            return Ok(players);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayersExists(int id)
        {
            return Db.Players.Count(e => e.Id == id) > 0;
        }
    }
}