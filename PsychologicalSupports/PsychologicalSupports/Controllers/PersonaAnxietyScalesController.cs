using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class PersonaAnxietyScalesController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();
        [Authorize]
        public ActionResult Index()
        {
            var personaAnxietyScales = db.PersonaAnxietyScales.Include(p => p.Student);
            return View(personaAnxietyScales.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var personaAnxietyScale = db.PersonaAnxietyScales.Find(id);
            if (personaAnxietyScale == null)
            {
                return HttpNotFound();
            }
            return View(personaAnxietyScale);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,School,Interpersonal,Self_assessment,General")] PersonaAnxietyScale personaAnxietyScale)
        {
            if (ModelState.IsValid)
            {
                db.PersonaAnxietyScales.Add(personaAnxietyScale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", personaAnxietyScale.StudentID);
            return View(personaAnxietyScale);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonaAnxietyScale personaAnxietyScale = db.PersonaAnxietyScales.Find(id);
            if (personaAnxietyScale == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", personaAnxietyScale.StudentID);
            return View(personaAnxietyScale);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,School,Interpersonal,Self_assessment,General")] PersonaAnxietyScale personaAnxietyScale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personaAnxietyScale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", personaAnxietyScale.StudentID);
            return View(personaAnxietyScale);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var personaAnxietyScale = db.PersonaAnxietyScales.Find(id);
            if (personaAnxietyScale == null)
            {
                return HttpNotFound();
            }
            return View(personaAnxietyScale);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var personaAnxietyScale = db.PersonaAnxietyScales.Find(id);
            db.PersonaAnxietyScales.Remove(personaAnxietyScale);
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
