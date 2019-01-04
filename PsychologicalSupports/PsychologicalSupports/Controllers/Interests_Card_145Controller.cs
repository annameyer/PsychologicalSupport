using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class Interests_Card_145Controller : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();

        [Authorize]
        public ActionResult Index()
        {
            var interests_Card_145 = db.Interests_Card_145.Include(i => i.Student);
            return View(interests_Card_145.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var interests_Card_145 = db.Interests_Card_145.Find(id);
            if (interests_Card_145 == null)
            {
                return HttpNotFound();
            }
            return View(interests_Card_145);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,Biology,Geography,Geology,TheMedicine,LightAndFoodIndustry,Physics,Chemistry,EngineeringMechanics,ElectricalEngineeringRadioEngineering,MaterialHandling,InformationTechnology,Psychology,Building,Tranport,MilitarySpecialties,Story,Literature,Journalism,Sociology,Pedagogy,Right,ServiceSector,Maths,Economy,ForeignLanguages,Art,Music,Sport")] Interests_Card_145 interests_Card_145)
        {
            if (ModelState.IsValid)
            {
                db.Interests_Card_145.Add(interests_Card_145);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", interests_Card_145.StudentID);
            return View(interests_Card_145);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var interests_Card_145 = db.Interests_Card_145.Find(id);
            if (interests_Card_145 == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", interests_Card_145.StudentID);
            return View(interests_Card_145);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,Biology,Geography,Geology,TheMedicine,LightAndFoodIndustry,Physics,Chemistry,EngineeringMechanics,ElectricalEngineeringRadioEngineering,MaterialHandling,InformationTechnology,Psychology,Building,Tranport,MilitarySpecialties,Story,Literature,Journalism,Sociology,Pedagogy,Right,ServiceSector,Maths,Economy,ForeignLanguages,Art,Music,Sport")] Interests_Card_145 interests_Card_145)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interests_Card_145).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", interests_Card_145.StudentID);
            return View(interests_Card_145);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var interests_Card_145 = db.Interests_Card_145.Find(id);
            if (interests_Card_145 == null)
            {
                return HttpNotFound();
            }
            return View(interests_Card_145);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var interests_Card_145 = db.Interests_Card_145.Find(id);
            db.Interests_Card_145.Remove(interests_Card_145);
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
