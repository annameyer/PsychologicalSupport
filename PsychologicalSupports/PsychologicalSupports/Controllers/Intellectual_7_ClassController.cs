
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class Intellectual_7_ClassController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();
        [Authorize]
        public ActionResult Index()
        {
            var intellectual_7_Class = db.Intellectual_7_Class.Include(i => i.Student);
            return View(intellectual_7_Class.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var intellectual_7_Class = db.Intellectual_7_Class.Find(id);
            if (intellectual_7_Class == null)
            {
                return HttpNotFound();
            }
            return View(intellectual_7_Class);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,IQ,Level,AveragePointСommon,AveragePointMath")] Intellectual_7_Class intellectual_7_Class)
        {
            if (ModelState.IsValid)
            {
                db.Intellectual_7_Class.Add(intellectual_7_Class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", intellectual_7_Class.StudentID);
            return View(intellectual_7_Class);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var intellectual_7_Class = db.Intellectual_7_Class.Find(id);
            if (intellectual_7_Class == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", intellectual_7_Class.StudentID);
            return View(intellectual_7_Class);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,IQ,Level,AveragePointСommon,AveragePointMath")] Intellectual_7_Class intellectual_7_Class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intellectual_7_Class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", intellectual_7_Class.StudentID);
            return View(intellectual_7_Class);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var intellectual_7_Class = db.Intellectual_7_Class.Find(id);
            if (intellectual_7_Class == null)
            {
                return HttpNotFound();
            }
            return View(intellectual_7_Class);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var intellectual_7_Class = db.Intellectual_7_Class.Find(id);
            db.Intellectual_7_Class.Remove(intellectual_7_Class);
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
