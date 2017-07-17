//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Mvc;
//using MVC.Data;

//namespace MVC.Controllers
//{
//    public class APIController : ApiController
//    {
//        private Context db = new Context();

//        public ActionResult Index()
//        {
//            var players = db.Players.Include(p => p.Team);
//            return View(players.ToList());
//        }

//    }
//}
