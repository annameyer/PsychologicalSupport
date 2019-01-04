using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class MindsetsController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();
        [Authorize]
        public ActionResult Index()
        {
            var mindsets = db.Mindsets.Include(m => m.Student);
            return View(mindsets.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mindset = db.Mindsets.Find(id);
            if (mindset == null)
            {
                return HttpNotFound();
            }
            return View(mindset);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,Subject_Effective,AbstractSymbolic,Verbal_Logical,Visually_Shaped,Creativity")] Mindset mindset)
        {
            if (ModelState.IsValid)
            {
                db.Mindsets.Add(mindset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", mindset.StudentID);
            return View(mindset);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mindset = db.Mindsets.Find(id);
            if (mindset == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", mindset.StudentID);
            return View(mindset);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,Subject_Effective,AbstractSymbolic,Verbal_Logical,Visually_Shaped,Creativity")] Mindset mindset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mindset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", mindset.StudentID);
            return View(mindset);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mindset = db.Mindsets.Find(id);
            if (mindset == null)
            {
                return HttpNotFound();
            }
            return View(mindset);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var mindset = db.Mindsets.Find(id);
            db.Mindsets.Remove(mindset);
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
