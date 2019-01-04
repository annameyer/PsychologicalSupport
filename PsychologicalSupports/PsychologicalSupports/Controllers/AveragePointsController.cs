using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class AveragePointsController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();
        [Authorize]
        public ActionResult Index()
        {
            var averagePoints = db.AveragePoints.Include(a => a.Student);
            return View(averagePoints.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var averagePoint = db.AveragePoints.Find(id);
            if (averagePoint == null)
            {
                return HttpNotFound();
            }
            return View(averagePoint);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,AveragePoint_6,AveragePoint_7,AveragePoint_8,AveragePoint_9")] AveragePoint averagePoint)
        {
            if (ModelState.IsValid)
            {
                db.AveragePoints.Add(averagePoint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", averagePoint.StudentID);
            return View(averagePoint);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var averagePoint = db.AveragePoints.Find(id);
            if (averagePoint == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", averagePoint.StudentID);
            return View(averagePoint);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,AveragePoint_6,AveragePoint_7,AveragePoint_8,AveragePoint_9")] AveragePoint averagePoint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(averagePoint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", averagePoint.StudentID);
            return View(averagePoint);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var averagePoint = db.AveragePoints.Find(id);
            if (averagePoint == null)
            {
                return HttpNotFound();
            }
            return View(averagePoint);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var averagePoint = db.AveragePoints.Find(id);
            db.AveragePoints.Remove(averagePoint);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
