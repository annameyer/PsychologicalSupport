
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class PersonalProtagonistAizenkoesController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();

        [Authorize]
        public ActionResult Index()
        {
            var personalProtagonistAizenkoes = db.PersonalProtagonistAizenkoes.Include(p => p.Student);
            return View(personalProtagonistAizenkoes.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var personalProtagonistAizenko = db.PersonalProtagonistAizenkoes.Find(id);
            if (personalProtagonistAizenko == null)
            {
                return HttpNotFound();
            }
            return View(personalProtagonistAizenko);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,Temperament,Type")] PersonalProtagonistAizenko personalProtagonistAizenko)
        {
            if (ModelState.IsValid)
            {
                db.PersonalProtagonistAizenkoes.Add(personalProtagonistAizenko);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", personalProtagonistAizenko.StudentID);
            return View(personalProtagonistAizenko);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var personalProtagonistAizenko = db.PersonalProtagonistAizenkoes.Find(id);
            if (personalProtagonistAizenko == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", personalProtagonistAizenko.StudentID);
            return View(personalProtagonistAizenko);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,Temperament,Type")] PersonalProtagonistAizenko personalProtagonistAizenko)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalProtagonistAizenko).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", personalProtagonistAizenko.StudentID);
            return View(personalProtagonistAizenko);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var personalProtagonistAizenko = db.PersonalProtagonistAizenkoes.Find(id);
            if (personalProtagonistAizenko == null)
            {
                return HttpNotFound();
            }
            return View(personalProtagonistAizenko);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var personalProtagonistAizenko = db.PersonalProtagonistAizenkoes.Find(id);
            db.PersonalProtagonistAizenkoes.Remove(personalProtagonistAizenko);
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
