using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LigaFutbolu.Models;

namespace LigaFutbolu.Controllers
{
    public class DetailsController : Controller
    {
        // GET: Details
        public ActionResult Details(int id)
        {
            var zawodnik = new Zawodnicy {Title = "Zawodnik" + id};

            return View(zawodnik);
        }
    }
}