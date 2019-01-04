using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class ClassTeacheInformationsController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();

        [Authorize]
        public ActionResult Index()
        {
            var classTeacheInformations = db.ClassTeacheInformations.Include(c => c.Student);
            return View(classTeacheInformations.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var classTeacheInformation = db.ClassTeacheInformations.Find(id);
            if (classTeacheInformation == null)
            {
                return HttpNotFound();
            }
            return View(classTeacheInformation);
        }


        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,Self_harmingBehavior,Isolation,Aggression,AvoidPhysicalContact,AfraidToGoHome,RunningAwayFromHome,WearBodyHidingClothes,DefiantBehavior,LowSelf_esteem,PoorPeerRelations,SharpWeightChange,HystericalEmotionalImbalance,ExceptionallyGoodSexKnowledge")] ClassTeacheInformation classTeacheInformation)
        {
            if (ModelState.IsValid)
            {
                db.ClassTeacheInformations.Add(classTeacheInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", classTeacheInformation.StudentID);
            return View(classTeacheInformation);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var classTeacheInformation = db.ClassTeacheInformations.Find(id);
            if (classTeacheInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", classTeacheInformation.StudentID);
            return View(classTeacheInformation);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,Self_harmingBehavior,Isolation,Aggression,AvoidPhysicalContact,AfraidToGoHome,RunningAwayFromHome,WearBodyHidingClothes,DefiantBehavior,LowSelf_esteem,PoorPeerRelations,SharpWeightChange,HystericalEmotionalImbalance,ExceptionallyGoodSexKnowledge")] ClassTeacheInformation classTeacheInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classTeacheInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", classTeacheInformation.StudentID);
            return View(classTeacheInformation);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var classTeacheInformation = db.ClassTeacheInformations.Find(id);
            if (classTeacheInformation == null)
            {
                return HttpNotFound();
            }
            return View(classTeacheInformation);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var classTeacheInformation = db.ClassTeacheInformations.Find(id);
            db.ClassTeacheInformations.Remove(classTeacheInformation);
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
