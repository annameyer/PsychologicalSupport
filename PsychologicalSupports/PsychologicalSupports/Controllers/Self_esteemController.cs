using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class Self_esteemController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();

        [Authorize]
        public ActionResult Index()
        {
            var self_esteem = db.Self_esteem.Include(s => s.Student);
            return View(self_esteem.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var self_esteem = db.Self_esteem.Find(id);
            if (self_esteem == null)
            {
                return HttpNotFound();
            }
            return View(self_esteem);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,Indicator")] Self_esteem self_esteem)
        {
            if (ModelState.IsValid)
            {
                db.Self_esteem.Add(self_esteem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", self_esteem.StudentID);
            return View(self_esteem);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var self_esteem = db.Self_esteem.Find(id);
            if (self_esteem == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", self_esteem.StudentID);
            return View(self_esteem);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,Indicator")] Self_esteem self_esteem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(self_esteem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", self_esteem.StudentID);
            return View(self_esteem);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var self_esteem = db.Self_esteem.Find(id);
            if (self_esteem == null)
            {
                return HttpNotFound();
            }
            return View(self_esteem);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var self_esteem = db.Self_esteem.Find(id);
            db.Self_esteem.Remove(self_esteem);
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
