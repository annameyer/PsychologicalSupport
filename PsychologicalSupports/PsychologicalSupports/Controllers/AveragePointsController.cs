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

        // GET: AveragePoints
        public ActionResult Index()
        {
            var averagePoints = db.AveragePoints.Include(a => a.Student);
            return View(averagePoints.ToList());
        }

        // GET: AveragePoints/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AveragePoint averagePoint = db.AveragePoints.Find(id);
            if (averagePoint == null)
            {
                return HttpNotFound();
            }
            return View(averagePoint);
        }

        // GET: AveragePoints/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        // POST: AveragePoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AveragePointID,StudentID,AveragePoint_6,AveragePoint_7,AveragePoint_8,AveragePoint_9")] AveragePoint averagePoint)
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

        // GET: AveragePoints/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AveragePoint averagePoint = db.AveragePoints.Find(id);
            if (averagePoint == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", averagePoint.StudentID);
            return View(averagePoint);
        }

        // POST: AveragePoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AveragePointID,StudentID,AveragePoint_6,AveragePoint_7,AveragePoint_8,AveragePoint_9")] AveragePoint averagePoint)
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

        // GET: AveragePoints/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AveragePoint averagePoint = db.AveragePoints.Find(id);
            if (averagePoint == null)
            {
                return HttpNotFound();
            }
            return View(averagePoint);
        }

        // POST: AveragePoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            AveragePoint averagePoint = db.AveragePoints.Find(id);
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
