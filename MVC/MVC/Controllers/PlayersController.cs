using MVC.Data;
using MVC.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class PlayersController : Controller
    {
        private Context _db = new Context();

        // GET: Players
        public ActionResult Index()
        {
            var players = _db.Players.Include(p => p.League).Include(p => p.Team);
            return View(players.ToList());
        }
        public ActionResult Api()
        {
            var players = _db.Players.Include(p => p.League).Include(p => p.Team);
            return View(players.ToList());
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Players/Create

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.LeagueId = new SelectList(_db.Leagues, "Id", "LeaugeName");
            ViewBag.TeamId = new SelectList(_db.Teams, "Id", "TeamName");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Age,TeamId,LeagueId")] Player player)
        {
            if (!ModelState.IsValid)
            {
                _db.Players.Add(player);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LeagueId = new SelectList(_db.Leagues, "Id", "LeaugeName", player.LeagueId);
            ViewBag.TeamId = new SelectList(_db.Teams, "Id", "TeamName", player.TeamId);
            return View(player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeagueId = new SelectList(_db.Leagues, "Id", "LeaugeName", player.LeagueId);
            ViewBag.TeamId = new SelectList(_db.Teams, "Id", "TeamName", player.TeamId);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Age,TeamId,LeagueId")] Player player)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(player).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeagueId = new SelectList(_db.Leagues, "Id", "LeaugeName", player.LeagueId);
            ViewBag.TeamId = new SelectList(_db.Teams, "Id", "TeamName", player.TeamId);
            return View(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = _db.Players.Find(id);
            _db.Players.Remove(player);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
