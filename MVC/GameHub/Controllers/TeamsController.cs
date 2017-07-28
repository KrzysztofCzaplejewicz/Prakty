using GameHub.Data;
using GameHub.Models;
using GameHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace GameHub.Controllers
{
    public class TeamsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Teams
        [ActionName("get"), HttpGet]
        public IEnumerable<TeamsViewModel> GetTeams()
        {
            var query = db.Teams.Include(x => x.Leagues).AsQueryable();
            var list = query.ToList();

            var result = new List<TeamsViewModel>();

            list.ForEach(x =>
            {
                result.Add(new TeamsViewModel()
                {
                    TeamName = x.TeamName,
                    Town = x.Town,
                    Id = x.Id,
                    LeagueId = x.LeagueId,
                    LeagueName = x.Leagues.LeagueName
                });
            });


            return result;
        }

        // GET: api/Teams/5
        [HttpGet]
        [ResponseType(typeof(TeamsViewModel))]
        public TeamsViewModel GetTeams(int id)
        {
            var team = db.Teams.FirstOrDefault(x => x.Id == id);
            if (team != null)
            {
                TeamsViewModel viewModel = new TeamsViewModel();
                viewModel.Id = team.Id;
                viewModel.TeamName = team.TeamName;
                viewModel.Town = team.Town;
                viewModel.LeagueId = team.LeagueId;


                return viewModel;
            }
            else
            {
                throw  new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

        }

        // PUT: api/Teams/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public HttpResponseMessage UpdateTeams(TeamsViewModel model)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    Teams viewModel = new Teams
                    {
                        Id = model.Id,
                        TeamName = model.TeamName,
                        Town = model.Town,
                        LeagueId = model.LeagueId
                    };

                    db.Entry(viewModel).State = EntityState.Modified;
                    var result = db.SaveChanges();
                    if (result > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated Successfully");
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something wrong !");
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
            // POST: api/Teams
        [ResponseType(typeof(TeamsViewModel))]
        public IHttpActionResult PostTeams(Teams teams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teams.Add(teams);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teams.Id }, teams);
        }

        // DELETE: api/Teams/5
        [ResponseType(typeof(TeamsViewModel))]
        public IHttpActionResult DeleteTeams(int id)
        {
            Teams teams = db.Teams.Find(id);
            if (teams == null)
            {
                return NotFound();
            }

            db.Teams.Remove(teams);
            db.SaveChanges();

            return Ok(teams);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeamsExists(int id)
        {
            return db.Teams.Count(e => e.Id == id) > 0;
        }
    }
}