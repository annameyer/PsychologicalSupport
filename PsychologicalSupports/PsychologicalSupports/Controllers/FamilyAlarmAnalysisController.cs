using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class FamilyAlarmAnalysisController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();
        [Authorize]
        public ActionResult Index()
        {
            var familyAlarmAnalysis = db.FamilyAlarmAnalysis.Include(f => f.Student);
            return View(familyAlarmAnalysis.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var familyAlarmAnalysi = db.FamilyAlarmAnalysis.Find(id);
            if (familyAlarmAnalysi == null)
            {
                return HttpNotFound();
            }
            return View(familyAlarmAnalysi);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,Fault,Anxiety,Stress,General")] FamilyAlarmAnalysi familyAlarmAnalysi)
        {
            if (ModelState.IsValid)
            {
                db.FamilyAlarmAnalysis.Add(familyAlarmAnalysi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", familyAlarmAnalysi.StudentID);
            return View(familyAlarmAnalysi);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var familyAlarmAnalysi = db.FamilyAlarmAnalysis.Find(id);
            if (familyAlarmAnalysi == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", familyAlarmAnalysi.StudentID);
            return View(familyAlarmAnalysi);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,Fault,Anxiety,Stress,General")] FamilyAlarmAnalysi familyAlarmAnalysi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familyAlarmAnalysi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", familyAlarmAnalysi.StudentID);
            return View(familyAlarmAnalysi);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var familyAlarmAnalysi = db.FamilyAlarmAnalysis.Find(id);
            if (familyAlarmAnalysi == null)
            {
                return HttpNotFound();
            }
            return View(familyAlarmAnalysi);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var familyAlarmAnalysi = db.FamilyAlarmAnalysis.Find(id);
            db.FamilyAlarmAnalysis.Remove(familyAlarmAnalysi);
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
