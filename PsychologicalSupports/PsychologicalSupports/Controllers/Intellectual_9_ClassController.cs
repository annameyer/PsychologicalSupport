using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class Intellectual_9_ClassController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();
        [Authorize]
        public ActionResult Index()
        {
            var intellectual_9_Class = db.Intellectual_9_Class.Include(i => i.Student);
            return View(intellectual_9_Class.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var intellectual_9_Class = db.Intellectual_9_Class.Find(id);
            if (intellectual_9_Class == null)
            {
                return HttpNotFound();
            }
            return View(intellectual_9_Class);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,Profile")] Intellectual_9_Class intellectual_9_Class)
        {
            if (ModelState.IsValid)
            {
                db.Intellectual_9_Class.Add(intellectual_9_Class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", intellectual_9_Class.StudentID);
            return View(intellectual_9_Class);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var intellectual_9_Class = db.Intellectual_9_Class.Find(id);
            if (intellectual_9_Class == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", intellectual_9_Class.StudentID);
            return View(intellectual_9_Class);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,Profile")] Intellectual_9_Class intellectual_9_Class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intellectual_9_Class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", intellectual_9_Class.StudentID);
            return View(intellectual_9_Class);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var intellectual_9_Class = db.Intellectual_9_Class.Find(id);
            if (intellectual_9_Class == null)
            {
                return HttpNotFound();
            }
            return View(intellectual_9_Class);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var intellectual_9_Class = db.Intellectual_9_Class.Find(id);
            db.Intellectual_9_Class.Remove(intellectual_9_Class);
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
