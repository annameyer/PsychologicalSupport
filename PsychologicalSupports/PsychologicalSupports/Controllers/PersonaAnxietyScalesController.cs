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

        // GET: PersonaAnxietyScales
        public ActionResult Index()
        {
            var personaAnxietyScales = db.PersonaAnxietyScales.Include(p => p.Student);
            return View(personaAnxietyScales.ToList());
        }

        // GET: PersonaAnxietyScales/Details/5
        public ActionResult Details(long? id)
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
            return View(personaAnxietyScale);
        }

        // GET: PersonaAnxietyScales/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        // POST: PersonaAnxietyScales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonaAnxietyScaleID,StudentID,School,Interpersonal,Self_assessment,General")] PersonaAnxietyScale personaAnxietyScale)
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

        // GET: PersonaAnxietyScales/Edit/5
        public ActionResult Edit(long? id)
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

        // POST: PersonaAnxietyScales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonaAnxietyScaleID,StudentID,School,Interpersonal,Self_assessment,General")] PersonaAnxietyScale personaAnxietyScale)
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

        // GET: PersonaAnxietyScales/Delete/5
        public ActionResult Delete(long? id)
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
            return View(personaAnxietyScale);
        }

        // POST: PersonaAnxietyScales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PersonaAnxietyScale personaAnxietyScale = db.PersonaAnxietyScales.Find(id);
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
