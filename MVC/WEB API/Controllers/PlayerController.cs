using MVC_API.Models;
using MVC_API.ViewModels;
using System.Web.Mvc;

namespace MVC_API.Controllers
{
    public class PlayerController : Controller
    {
        public ActionResult Index()
        {
            PlayerClient PC = new PlayerClient();
            ViewBag.listPlayers = PC.FindAll();

            return View();

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(PlayerViewModel pvm)
        {
            PlayerClient PC = new PlayerClient();
            PC.Create(pvm.Player);

            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            PlayerClient PC = new PlayerClient();
            PC.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            PlayerClient PC =  new PlayerClient();
            PlayerViewModel PVM = new PlayerViewModel();
            PVM.Player = PC.Find(id);
            return View("Edit", PVM);
        }

        [HttpPost]
        public ActionResult Edit(PlayerViewModel PVM)
        {
            PlayerClient PC = new PlayerClient();
            PC.Edit(PVM.Player);
            return  RedirectToAction("Index");
        }


    }
}
