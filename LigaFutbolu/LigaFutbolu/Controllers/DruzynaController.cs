using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LigaFutbolu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LigaFutbolu.Controllers
{
    public class DruzynaController : Controller
    {
       
        
        LigaFutboluJednostki storeDB = new LigaFutboluJednostki();
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: Druzyna
        public ActionResult Druzyna(string druzyna)
        {


            var Druzyny = storeDB.Druzyny.ToList();
         
            return View(Druzyny);



        }
    }
}