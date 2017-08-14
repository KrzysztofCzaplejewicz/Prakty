using System.Web.Mvc;

namespace GameHu.Controllers
{

    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        [Authorize]
        public ActionResult About()
        {
            return PartialView("about");
        }

            
    }
}
