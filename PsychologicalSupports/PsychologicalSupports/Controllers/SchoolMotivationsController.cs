using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class SchoolMotivationsController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();

        [Authorize]
        public ActionResult Index()
        {
            var schoolMotivations = db.SchoolMotivations.Include(s => s.Student);
            return View(schoolMotivations.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolMotivation schoolMotivation = db.SchoolMotivations.Find(id);
            if (schoolMotivation == null)
            {
                return HttpNotFound();
            }
            return View(schoolMotivation);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,StudyInClass,TestFamilyStudiesLevel,CognitiveInterest,TesMotivationAchievementstLevel,Classmates,Pedagogues,ByParents,FromTheSideOfTheSchool,FromTheSideOfTheFamily,AwarenessOfSocialNecessity,CommunicationMotif,ExtracurricularSchoolMotivation,TheMotiveOfSelf_Realization")] SchoolMotivation schoolMotivation)
        {
            if (ModelState.IsValid)
            {
                db.SchoolMotivations.Add(schoolMotivation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", schoolMotivation.StudentID);
            return View(schoolMotivation);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var schoolMotivation = db.SchoolMotivations.Find(id);
            if (schoolMotivation == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", schoolMotivation.StudentID);
            return View(schoolMotivation);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,StudyInClass,TestFamilyStudiesLevel,CognitiveInterest,TesMotivationAchievementstLevel,Classmates,Pedagogues,ByParents,FromTheSideOfTheSchool,FromTheSideOfTheFamily,AwarenessOfSocialNecessity,CommunicationMotif,ExtracurricularSchoolMotivation,TheMotiveOfSelf_Realization")] SchoolMotivation schoolMotivation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schoolMotivation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", schoolMotivation.StudentID);
            return View(schoolMotivation);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var schoolMotivation = db.SchoolMotivations.Find(id);
            if (schoolMotivation == null)
            {
                return HttpNotFound();
            }
            return View(schoolMotivation);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var schoolMotivation = db.SchoolMotivations.Find(id);
            db.SchoolMotivations.Remove(schoolMotivation);
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
