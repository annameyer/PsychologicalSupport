using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class Interests_Card_50Controller : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();
        [Authorize]
        public ActionResult Index()
        {
            var interests_Card_50 = db.Interests_Card_50.Include(i => i.Student);
            return View(interests_Card_50.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var interests_Card_50 = db.Interests_Card_50.Find(id);
            if (interests_Card_50 == null)
            {
                return HttpNotFound();
            }
            return View(interests_Card_50);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,PhysicsMathematics,ChemistryBiology,RadioEngineeringElectronics,MechanicsDesign,GeographyGeology,LiteratureArt,HistoryPolitics,PedagogyMedicine,EntrepreneurshiHomeEconomics,SportsMilitary")] Interests_Card_50 interests_Card_50)
        {
            if (ModelState.IsValid)
            {
                db.Interests_Card_50.Add(interests_Card_50);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", interests_Card_50.StudentID);
            return View(interests_Card_50);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var interests_Card_50 = db.Interests_Card_50.Find(id);
            if (interests_Card_50 == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", interests_Card_50.StudentID);
            return View(interests_Card_50);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,PhysicsMathematics,ChemistryBiology,RadioEngineeringElectronics,MechanicsDesign,GeographyGeology,LiteratureArt,HistoryPolitics,PedagogyMedicine,EntrepreneurshiHomeEconomics,SportsMilitary")] Interests_Card_50 interests_Card_50)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interests_Card_50).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", interests_Card_50.StudentID);
            return View(interests_Card_50);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var interests_Card_50 = db.Interests_Card_50.Find(id);
            if (interests_Card_50 == null)
            {
                return HttpNotFound();
            }
            return View(interests_Card_50);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var interests_Card_50 = db.Interests_Card_50.Find(id);
            db.Interests_Card_50.Remove(interests_Card_50);
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
