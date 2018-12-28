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

        // GET: Interests_Card_50
        public ActionResult Index()
        {
            var interests_Card_50 = db.Interests_Card_50.Include(i => i.Student);
            return View(interests_Card_50.ToList());
        }

        // GET: Interests_Card_50/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interests_Card_50 interests_Card_50 = db.Interests_Card_50.Find(id);
            if (interests_Card_50 == null)
            {
                return HttpNotFound();
            }
            return View(interests_Card_50);
        }

        // GET: Interests_Card_50/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        // POST: Interests_Card_50/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Interests_Card_50ID,StudentID,PhysicsMathematics,ChemistryBiology,RadioEngineeringElectronics,MechanicsDesign,GeographyGeology,LiteratureArt,HistoryPolitics,PedagogyMedicine,EntrepreneurshiHomeEconomics,SportsMilitary")] Interests_Card_50 interests_Card_50)
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

        // GET: Interests_Card_50/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interests_Card_50 interests_Card_50 = db.Interests_Card_50.Find(id);
            if (interests_Card_50 == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", interests_Card_50.StudentID);
            return View(interests_Card_50);
        }

        // POST: Interests_Card_50/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Interests_Card_50ID,StudentID,PhysicsMathematics,ChemistryBiology,RadioEngineeringElectronics,MechanicsDesign,GeographyGeology,LiteratureArt,HistoryPolitics,PedagogyMedicine,EntrepreneurshiHomeEconomics,SportsMilitary")] Interests_Card_50 interests_Card_50)
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

        // GET: Interests_Card_50/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interests_Card_50 interests_Card_50 = db.Interests_Card_50.Find(id);
            if (interests_Card_50 == null)
            {
                return HttpNotFound();
            }
            return View(interests_Card_50);
        }

        // POST: Interests_Card_50/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Interests_Card_50 interests_Card_50 = db.Interests_Card_50.Find(id);
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
