using GameHub.Data;
using GameHub.ViewModels;
using log4net;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace GameHub.Controllers
{
    public class PlayersViewsController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(PlayersViewsController));

        private Model1 db = new Model1();

        // GET: api/PlayersViews
        public IEnumerable<PlayersView> GetPlayersView()
        {
            
            
            return db.PlayersView.Where(x => x.TeamName == "LowlandersB").ToList();
        }

        // GET: api/PlayersViews/5
        [HttpGet]
        [ResponseType(typeof(PlayersView))]
        public IEnumerable<PlayersView> GetPlayersView(int id)
        {
            

            return db.PlayersView.Where(x => x.Id == id).ToList();
           
            
        }

        // PUT: api/PlayersViews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayersView(string id, PlayersView playersView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playersView.FirstName)
            {
                return BadRequest();
            }

            db.Entry(playersView).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayersViewExists(id))
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

        // POST: api/PlayersViews
        [ResponseType(typeof(PlayersView))]
        public IHttpActionResult PostPlayersView(PlayersView playersView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlayersView.Add(playersView);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PlayersViewExists(playersView.FirstName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = playersView.FirstName }, playersView);
        }

        // DELETE: api/PlayersViews/5
        [ResponseType(typeof(PlayersView))]
        public IHttpActionResult DeletePlayersView(string id)
        {
            PlayersView playersView = db.PlayersView.Find(id);
            if (playersView == null)
            {
                return NotFound();
            }

            db.PlayersView.Remove(playersView);
            db.SaveChanges();

            return Ok(playersView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayersViewExists(string id)
        {
            return db.PlayersView.Count(e => e.FirstName == id) > 0;
        }
    }
}