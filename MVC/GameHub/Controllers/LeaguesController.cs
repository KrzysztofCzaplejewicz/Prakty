using GameHub.Data;
using GameHub.Models;
using GameHub.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace GameHub.Controllers
{
    public class LeaguesController : ApiController
    {
        private Context db = new Context();

        // GET: api/Leagues
        [ActionName("get"), HttpGet]
        public IEnumerable<LeaguesViewModel> GetLeagues()
        {
            var query = db.Leagues.AsQueryable();
            var list = query.ToList();

            var result = new List<LeaguesViewModel>();

            list.ForEach(x =>
            {
                result.Add(new LeaguesViewModel()
                {
                    LeagueName = x.LeagueName,
                    Id = x.Id
                });
            });

            return result;
        }

        // GET: api/Leagues/5
        [ResponseType(typeof(Leagues))]
        public IHttpActionResult GetLeague(int id)
        {
            Leagues league = db.Leagues.Find(id);
            if (league == null)
            {
                return NotFound();
            }

            return Ok(league);
        }

        // PUT: api/Leagues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLeague(int id, Leagues league)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != league.Id)
            {
                return BadRequest();
            }

            db.Entry(league).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeagueExists(id))
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

        // POST: api/Leagues
        [ResponseType(typeof(Leagues))]
        public IHttpActionResult PostLeague(Leagues league)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Leagues.Add(league);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = league.Id }, league);
        }

        // DELETE: api/Leagues/5
        [ResponseType(typeof(Leagues))]
        public IHttpActionResult DeleteLeague(int id)
        {
            Leagues league = db.Leagues.Find(id);
            if (league == null)
            {
                return NotFound();
            }

            db.Leagues.Remove(league);
            db.SaveChanges();

            return Ok(league);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeagueExists(int id)
        {
            return db.Leagues.Count(e => e.Id == id) > 0;
        }
    }
}