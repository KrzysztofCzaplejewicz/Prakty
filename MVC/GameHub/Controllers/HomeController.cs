using log4net;
using System.Web.Mvc;

namespace GameHub.Controllers
{


    public class HomeController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Teams()
        {
            ViewBag.Title = "Teams";
            
            return View();
        }

        public ActionResult List()
        {

           
            
            return PartialView("List");
        }

        public ActionResult Edit()
        {

            
           
            return PartialView("Edit");
        }

        public ActionResult Delete()
        {
          
            

            return PartialView("Delete");
        }

        public ActionResult GameList()
        {
            
            
            return PartialView("GameList");
        }

        public ActionResult GameEdit()
        {
            
            
            return PartialView("GameEdit");
        }

        public ActionResult GameDelete()
        {
           
            
            return PartialView("GameDelete");
        }

        public ActionResult PlayerList()
        {
            
            return PartialView("PlayerList");
        }

        public ActionResult PlayerEdit()
        {
            

            return PartialView("PlayerEdit");
        }

        public ActionResult PlayerDelete()
        {
           
            return PartialView("PlayerDelete");
        }

        public ActionResult PlayersViewsList()
        {
           
            return PartialView("PlayersViewsList");
        }

    }
}
