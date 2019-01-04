using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class ClassroomRelationshipsController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();

        [Authorize]
        public ActionResult Index()
        {
            var classroomRelationships = db.ClassroomRelationships.Include(c => c.Student);
            return View(classroomRelationships.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var classroomRelationship = db.ClassroomRelationships.Find(id);
            if (classroomRelationship == null)
            {
                return HttpNotFound();
            }
            return View(classroomRelationship);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,IGS_Sishora,Sociometry")] ClassroomRelationship classroomRelationship)
        {
            if (ModelState.IsValid)
            {
                db.ClassroomRelationships.Add(classroomRelationship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", classroomRelationship.StudentID);
            return View(classroomRelationship);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var classroomRelationship = db.ClassroomRelationships.Find(id);
            if (classroomRelationship == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", classroomRelationship.StudentID);
            return View(classroomRelationship);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,IGS_Sishora,Sociometry")] ClassroomRelationship classroomRelationship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classroomRelationship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", classroomRelationship.StudentID);
            return View(classroomRelationship);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var classroomRelationship = db.ClassroomRelationships.Find(id);
            if (classroomRelationship == null)
            {
                return HttpNotFound();
            }
            return View(classroomRelationship);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var classroomRelationship = db.ClassroomRelationships.Find(id);
            db.ClassroomRelationships.Remove(classroomRelationship);
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
