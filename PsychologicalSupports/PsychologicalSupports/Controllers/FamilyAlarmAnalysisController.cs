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

        // GET: FamilyAlarmAnalysis
        public ActionResult Index()
        {
            var familyAlarmAnalysis = db.FamilyAlarmAnalysis.Include(f => f.Student);
            return View(familyAlarmAnalysis.ToList());
        }

        // GET: FamilyAlarmAnalysis/Details/5
        public ActionResult Details(long? id, long? id2)
        {
            if (id == null && id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyAlarmAnalysi familyAlarmAnalysi = db.FamilyAlarmAnalysis.Find(id, id2);
            if (familyAlarmAnalysi == null)
            {
                return HttpNotFound();
            }
            return View(familyAlarmAnalysi);
        }

        // GET: FamilyAlarmAnalysis/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        // POST: FamilyAlarmAnalysis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FamilyAlarmAnalysisID,StudentID,Fault,Anxiety,Stress,General")] FamilyAlarmAnalysi familyAlarmAnalysi)
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

        // GET: FamilyAlarmAnalysis/Edit/5
        public ActionResult Edit(long? id, long? id2)
        {
            if (id == null && id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyAlarmAnalysi familyAlarmAnalysi = db.FamilyAlarmAnalysis.Find(id, id2);
            if (familyAlarmAnalysi == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", familyAlarmAnalysi.StudentID);
            return View(familyAlarmAnalysi);
        }

        // POST: FamilyAlarmAnalysis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FamilyAlarmAnalysisID,StudentID,Fault,Anxiety,Stress,General")] FamilyAlarmAnalysi familyAlarmAnalysi)
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

        // GET: FamilyAlarmAnalysis/Delete/5
        public ActionResult Delete(long? id, long? id2)
        {
            if (id == null && id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyAlarmAnalysi familyAlarmAnalysi = db.FamilyAlarmAnalysis.Find(id,id2);
            if (familyAlarmAnalysi == null)
            {
                return HttpNotFound();
            }
            return View(familyAlarmAnalysi);
        }

        // POST: FamilyAlarmAnalysis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id, long id2)
        {
            FamilyAlarmAnalysi familyAlarmAnalysi = db.FamilyAlarmAnalysis.Find(id, id2);
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
