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

        // GET: InterestsInSchoolSubjects
        public ActionResult Index()
        {
            var interestsInSchoolSubjects = db.InterestsInSchoolSubjects.Include(i => i.Student);
            return View(interestsInSchoolSubjects.ToList());
        }

        // GET: InterestsInSchoolSubjects/Details/5
        public ActionResult Details(long? id,long? id2)
        {
            if (id == null && id2==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterestsInSchoolSubject interestsInSchoolSubject = db.InterestsInSchoolSubjects.Find(id,id2);
            if (interestsInSchoolSubject == null)
            {
                return HttpNotFound();
            }
            return View(interestsInSchoolSubject);
        }

        // GET: InterestsInSchoolSubjects/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        // POST: InterestsInSchoolSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InterestsInSchoolSubjectsID,StudentID,Russian,Belorussian,Physics,Story,SocialScientist,Biology,Chemistry,ComputerScience,English")] InterestsInSchoolSubject interestsInSchoolSubject)
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

        // GET: InterestsInSchoolSubjects/Edit/5
        public ActionResult Edit(long? id,long? id2)
        {
            if (id == null && id2==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterestsInSchoolSubject interestsInSchoolSubject = db.InterestsInSchoolSubjects.Find(id,id2);
            if (interestsInSchoolSubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", interestsInSchoolSubject.StudentID);
            return View(interestsInSchoolSubject);
        }

        // POST: InterestsInSchoolSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InterestsInSchoolSubjectsID,StudentID,Russian,Belorussian,Physics,Story,SocialScientist,Biology,Chemistry,ComputerScience,English")] InterestsInSchoolSubject interestsInSchoolSubject)
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

        // GET: InterestsInSchoolSubjects/Delete/5
        public ActionResult Delete(long? id,long? id2)
        {
            if (id == null && id2==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterestsInSchoolSubject interestsInSchoolSubject = db.InterestsInSchoolSubjects.Find(id,id2);
            if (interestsInSchoolSubject == null)
            {
                return HttpNotFound();
            }
            return View(interestsInSchoolSubject);
        }

        // POST: InterestsInSchoolSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id,long id2)
        {
            InterestsInSchoolSubject interestsInSchoolSubject = db.InterestsInSchoolSubjects.Find(id,id2);
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
