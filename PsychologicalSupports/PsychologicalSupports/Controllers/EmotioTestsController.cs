using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class EmotioTestsController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();
        [Authorize]
        public ActionResult Index()
        {
            var emotioTests = db.EmotioTests.Include(e => e.Student);
            return View(emotioTests.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var emotioTest = db.EmotioTests.Find(id);
            if (emotioTest == null)
            {
                return HttpNotFound();
            }
            return View(emotioTest);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,PhysicalAggression,IndirectAggression,Irritability,Negativism,Touchiness,Suspicion,VerbalAggression,Guilt")] EmotioTest emotioTest)
        {
            if (ModelState.IsValid)
            {
                db.EmotioTests.Add(emotioTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", emotioTest.StudentID);
            return View(emotioTest);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var emotioTest = db.EmotioTests.Find(id);
            if (emotioTest == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", emotioTest.StudentID);
            return View(emotioTest);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,PhysicalAggression,IndirectAggression,Irritability,Negativism,Touchiness,Suspicion,VerbalAggression,Guilt")] EmotioTest emotioTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emotioTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", emotioTest.StudentID);
            return View(emotioTest);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var emotioTest = db.EmotioTests.Find(id);
            if (emotioTest == null)
            {
                return HttpNotFound();
            }
            return View(emotioTest);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var emotioTest = db.EmotioTests.Find(id);
            db.EmotioTests.Remove(emotioTest);
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
