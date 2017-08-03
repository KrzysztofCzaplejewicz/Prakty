using GameHub.Data;
using GameHub.Models;
using GameHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace GameHub.Controllers
{
    public class GamesController : ApiController
    {
        private Context db = new Context();

        // GET: api/Games
        [ActionName("get"), HttpGet]
        public IEnumerable<GamesViewModel> GetGames()
        {
            var query = db.Games
                .Include(x=> x.Teams1)
                .Include(x=>x.Teams)
                .Include(x=>x.Leagues)
                .AsQueryable();
            var list = query.ToList();
            var result = new List<GamesViewModel>();
            list.ForEach(x =>
                {
                    result.Add(item: new GamesViewModel()
                    {
                        Id = x.Id,
                        Host = x.Host,
                        Visitor = x.Visitor,
                        Town = x.Teams.Town,
                        LeagueId = x.LeagueId,
                        TeamName= x.Teams.TeamName,
                        TeamName1= x.Teams1.TeamName,
                        LeagueName = x.Leagues.LeagueName,
                        Date = x.DateTime.Date.ToString(CultureInfo.CurrentCulture),
                        Time = x.DateTime.ToString(CultureInfo.CurrentCulture)
                    });
                });
            return result;
        }

        // GET: api/Games/5
        [HttpGet]
        [ResponseType(typeof(GamesViewModel))]
        public GamesViewModel GetGames(int id)
        {
            var game = db.Games.FirstOrDefault(x => x.Id == id);
            if (game != null)
            {
                GamesViewModel viewModel = new GamesViewModel();
                viewModel.Id = game.Id;
                viewModel.Host = game.Host;
                viewModel.Visitor = game.Visitor;
                viewModel.Town = game.Town;
                viewModel.LeagueId = game.LeagueId;
                viewModel.Date = game.DateTime.ToString(CultureInfo.CurrentCulture);
                viewModel.Time = game.DateTime.ToString(CultureInfo.CurrentCulture);
                

                return viewModel;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }


        }

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGame(int id, Games game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game.Id)
            {
                return BadRequest();
            }

            db.Entry(game).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // POST: api/Games
        [ResponseType(typeof(Games))]
        //public IHttpActionResult PostGame(Games game)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    //game.LeagueId = 1;
        //    //game.TeamId = 1;
            

        //    db.Games.Add(game);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = game.Id }, game);
        //}

           [HttpPost]
        public HttpResponseMessage CreateGame(GamesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Games viewModel = new Games()
                    {
                        Id = model.Id,
                        Host = model.Host,
                        Visitor = model.Visitor,
                        Town = model.Town,
                        LeagueId = model.LeagueId,
                        DateTime = DateTime.Parse($"{model.Date} {model.Time}")
                        
                        
                    };
                    db.Games.Add(viewModel);
                    var result = db.SaveChanges();
                    if (result > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, "Submitted Successfully");
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !");
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !", ex);
            }
        }



        // DELETE: api/Games/5
        [ResponseType(typeof(Games))]
        public IHttpActionResult DeleteGame(int id)
        {
            Games game = db.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            db.Games.Remove(game);
            db.SaveChanges();

            return Ok(game);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(int id)
        {
            return db.Games.Count(e => e.Id == id) > 0;
        }
    }
}