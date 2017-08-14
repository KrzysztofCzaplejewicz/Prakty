using AutoMapper;
using GameHub.Data;
using GameHub.Models;
using GameHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace GameHub.Controllers
{
    public class GamesController : ApiController
    {
        private Context db = new Context();

        // GET: api/Games
        [System.Web.Mvc.Authorize(Users = "czaplej@czaplej.com")]
        [System.Web.Http.ActionName("get")]
        [System.Web.Http.HttpGet]
        public IEnumerable<GamesViewModel> GetGames()
        {
            var query = db.Games
                .Include(x=> x.Teams1)
                .Include(x=>x.Teams)
                .Include(x=>x.Leagues)
               
                .AsQueryable();
            var list = query.ToList();

             return list.Select(Mapper.Map<Games, GamesViewModel>);

        //    var result = new List<GamesViewModel>();

        //    list.ForEach(x =>
        //    {
        //        var game = new GamesViewModel();
                
        //        game.Id = x.Id;
        //        game.Host = x.Host;
        //        game.Visitor = x.Visitor;
        //        game.Town = x.Teams.Town;
        //        game.LeagueId = x.LeagueId;
        //        game.TeamName = x.Teams.TeamName;
        //        game.TeamName1 = x.Teams1.TeamName;
        //        game.LeagueName = x.Leagues.LeagueName;
        //        game.Date = x.DateTime.ToString("dd/MM/yyyy");
        //        game.Time = x.DateTime.ToString("HH:mm");
        //        game.ScoreHost = x.ScoreHost;
        //        game.ScoreVisitor = x.ScoreVisitor;
        //        game.Quatr1Host = x.Quatr1Host;
        //        game.Quatr2Host = x.Quatr2Host;
        //        game.Quatr3Host = x.Quatr3Host;
        //        game.Quatr4Host = x.Quatr4Host;
        //        game.Quatr1Visitor = x.Quatr1Visitor;
        //        game.Quatr2Visitor = x.Quatr2Visitor;
        //        game.Quatr3Visitor = x.Quatr3Visitor;
        //        game.Quatr4Visitor = x.Quatr4Visitor;
                
        //        result.Add(game);
        //});

          
        //    return result;
        }

        // GET: api/Games/5
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(GamesViewModel))]
        public GamesViewModel GetGames(int id)
        {
            var game = db.Games.FirstOrDefault(x => x.Id == id);
            if (game != null)
            {
               //var view = Mapper.Map<GamesViewModel>(game);
                //return view;
                GamesViewModel viewModel = new GamesViewModel();
            
                viewModel.Id = game.Id;

                viewModel.Host = game.Host;
                viewModel.Visitor = game.Visitor;
                viewModel.TeamName = game.Teams.TeamName;
                viewModel.TeamName1 = game.Teams1.TeamName;
                viewModel.Town = game.Teams.Town;

                viewModel.LeagueId = game.LeagueId;
                viewModel.LeagueName = game.Leagues.LeagueName;

                viewModel.Date = game.DateTime.ToString("dd/MM/yyyy");
                viewModel.Time = game.DateTime.ToString("HH:mm");

                viewModel.ScoreHost = game.ScoreHost;
                viewModel.ScoreVisitor = game.ScoreVisitor;

                viewModel.Quatr1Host = game.Quatr1Host;
                viewModel.Quatr2Host = game.Quatr2Host;
                viewModel.Quatr3Host = game.Quatr3Host;
                viewModel.Quatr4Host = game.Quatr4Host;
                viewModel.Quatr1Visitor = game.Quatr1Visitor;
                viewModel.Quatr2Visitor = game.Quatr2Visitor;
                viewModel.Quatr3Visitor = game.Quatr3Visitor;
                viewModel.Quatr4Visitor = game.Quatr4Visitor;
                viewModel.UrlIconHost = game.Teams1.UrlIcon;
                viewModel.UrlIconVisitor = game.Teams.UrlIcon;

                

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
       [System.Web.Http.HttpPost]
       [ValidateAntiForgeryToken]
        public HttpResponseMessage CreateGame(GamesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                   // var galgan =   Mapper.Map<Games>(model);


                    Games viewModel = new Games()
                    {
                        Id = model.Id,
                        DateTime = DateTime.Parse($"{model.Date} {model.Time}"),
                        Host = model.Host,
                        Visitor = model.Visitor,
                        ScoreHost = model.ScoreHost,
                        ScoreVisitor = model.ScoreVisitor,
                        Quatr1Host = model.Quatr1Host,
                        Quatr2Host = model.Quatr2Host,
                        Quatr3Host = model.Quatr3Host,
                        Quatr4Host = model.Quatr4Host,
                        Quatr1Visitor = model.Quatr1Visitor,
                        Quatr2Visitor = model.Quatr2Visitor,
                        Quatr3Visitor = model.Quatr3Visitor,
                        Quatr4Visitor = model.Quatr4Visitor,
                        LeagueId = model.LeagueId
                        
                    };
                    db.Games.Add(viewModel);
                   // db.Configuration.ValidateOnSaveEnabled = false;
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