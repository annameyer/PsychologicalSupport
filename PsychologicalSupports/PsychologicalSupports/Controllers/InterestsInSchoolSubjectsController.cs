using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class InterestsInSchoolSubjectsController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();
        [Authorize]
        public ActionResult Index()
        {
            var interestsInSchoolSubjects = db.InterestsInSchoolSubjects.Include(i => i.Student);
            return View(interestsInSchoolSubjects.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var interestsInSchoolSubject = db.InterestsInSchoolSubjects.Find(id);
            if (interestsInSchoolSubject == null)
            {
                return HttpNotFound();
            }
            return View(interestsInSchoolSubject);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,Russian,Belorussian,Physics,Story,SocialScientist,Biology,Chemistry,ComputerScience,English")] InterestsInSchoolSubject interestsInSchoolSubject)
        {
            if (ModelState.IsValid)
            {
                db.InterestsInSchoolSubjects.Add(interestsInSchoolSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", interestsInSchoolSubject.StudentID);
            return View(interestsInSchoolSubject);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var interestsInSchoolSubject = db.InterestsInSchoolSubjects.Find(id);
            if (interestsInSchoolSubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", interestsInSchoolSubject.StudentID);
            return View(interestsInSchoolSubject);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,Russian,Belorussian,Physics,Story,SocialScientist,Biology,Chemistry,ComputerScience,English")] InterestsInSchoolSubject interestsInSchoolSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interestsInSchoolSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", interestsInSchoolSubject.StudentID);
            return View(interestsInSchoolSubject);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var interestsInSchoolSubject = db.InterestsInSchoolSubjects.Find(id);
            if (interestsInSchoolSubject == null)
            {
                return HttpNotFound();
            }
            return View(interestsInSchoolSubject);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var interestsInSchoolSubject = db.InterestsInSchoolSubjects.Find(id);
            db.InterestsInSchoolSubjects.Remove(interestsInSchoolSubject);
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
