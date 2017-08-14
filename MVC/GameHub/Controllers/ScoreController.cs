//using GameHub.Data;
//using GameHub.Models;
//using System.Web.Http;

//namespace GameHub.Controllers
//{
//    public class ScoreController : ApiController
//    {
//        private Context db = new Context();

//        [HttpPost]
//        public IHttpActionResult AddScore(Scores scores)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.Scores.Add(scores);
//            db.SaveChanges();

//            return CreatedAtRoute("DefaultApi", new { id = scores.Id }, scores);
//        }
//    }
//}
