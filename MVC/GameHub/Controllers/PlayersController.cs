using AutoMapper;
using GameHub.Models;
using GameHub.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Context = GameHub.Data.Context;

namespace GameHub.Controllers
{
    [Authorize()]
    public class PlayersController : ApiController
    {
        private Context db = new Context();

        // GET: api/Players
        [HttpGet]
        public IEnumerable<PlayersViewModel> GetPlayers()
        {
            var query = db.Players.Include(x=> x.Teams).AsQueryable();
            var list = query.ToList();
            return list.Select(Mapper.Map<Players, PlayersViewModel>);


            var result = new List<PlayersViewModel>();

            list.ForEach(x =>
            {
                result.Add(new PlayersViewModel()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    Id = x.Id,
                   // TeamId = x.TeamId,
                   // TeamName = x.Teams.TeamName
                });
            });


            return result;
        }

        // GET: api/Players/5
        [HttpGet]
        [ResponseType(typeof(PlayersViewModel))]
        public PlayersViewModel GetPlayer(int id)
        {
            var player = db.Players.SingleOrDefault(x => x.Id == id);
            
            if (player != null)
            {
                
                PlayersViewModel viewModel = new PlayersViewModel
                {
                    Id = player.Id,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    Age = player.Age,
                    //TeamId = player.TeamId,
                    
                    
                };

                return viewModel;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
        }

        // PUT: api/Players/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayer(int id, Players player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.Id)
            {
                return BadRequest();
            }

            db.Entry(player).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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
        [HttpPost]
        [ResponseType(typeof(PlayersViewModel))]

        //public HttpResponseMessage PostPlayer(PlayersViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            Players viewModel = new Players()
        //            {
        //                FirstName = model.FirstName,
        //                LastName = model.LastName,
        //                Age = model.Age,
        //                TeamId = model.TeamId
        //            };
        //            db.Players.Add(viewModel);
        //            var result = db.SaveChanges();
        //            if (result > 0)
        //            {
        //                return Request.CreateResponse(HttpStatusCode.Created, "Submitted Successfully");
        //            }
        //            else
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !");
        //            }
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !");
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !", ex);
        //    }
        //}

        public IHttpActionResult PostPlayer(Players player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Players.Add(player);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = player.Id }, player);
        }

        // DELETE: api/Players/5
        [HttpDelete]
        [ResponseType(typeof(Players))]
        public IHttpActionResult DeletePlayer(int id)
        {
            Players player = db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
            db.SaveChanges();

            return Ok(player);
        }

        
       

    protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerExists(int id)
        {
            return db.Players.Count(e => e.Id == id) > 0;
        }
    }
}