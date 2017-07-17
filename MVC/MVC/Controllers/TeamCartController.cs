using MVC.Data;
using MVC.Models;
using MVC.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class TeamCartController : Controller
    {
        Context _db= new Context();
        // GET: TeamCart
        public ActionResult Index()
        {

            var cart = TeamCart.GetCart(HttpContext);

            var viewModel = new TeamCartViewModel
            {
                CartItems = cart.GetCartItems(),

            };
            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var addedTeam = _db.Teams
                .Single(team => team.Id == id);

            // Add it to the shopping cart
            var cart = TeamCart.GetCart(HttpContext);
            cart.AddToCart(addedTeam);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
       
        [HttpPost]
        public ActionResult Remove(int id)
        {
            // Remove the item from the cart
            var cart = TeamCart.GetCart(HttpContext);

            // Get the name of the album to display confirmation

            var teamName = _db.Carts
                .Single(item => item.RecordId == id).Team.TeamName;

            // Remove from cart
            var itemCount = cart.Remove(id);
            cart.Remove(itemCount);

            // Display the confirmation message
            var results = new TeamCartRemoveViewModel
            {
                Message = Server.HtmlEncode(teamName) +
                          " has been removed from your team cart.",
                
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
      
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = TeamCart.GetCart(HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

        
    }

}
