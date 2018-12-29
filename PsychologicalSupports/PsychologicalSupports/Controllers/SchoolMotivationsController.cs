using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class SchoolMotivationsController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();

        // GET: SchoolMotivations
        public ActionResult Index()
        {
            var schoolMotivations = db.SchoolMotivations.Include(s => s.Student);
            return View(schoolMotivations.ToList());
        }

        // GET: SchoolMotivations/Details/5
        public ActionResult Details(long? id)
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

        // GET: SchoolMotivations/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        // POST: SchoolMotivations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: SchoolMotivations/Edit/5
        public ActionResult Edit(long? id)
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
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", schoolMotivation.StudentID);
            return View(schoolMotivation);
        }

        // POST: SchoolMotivations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: SchoolMotivations/Delete/5
        public ActionResult Delete(long? id)
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

        // POST: SchoolMotivations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            SchoolMotivation schoolMotivation = db.SchoolMotivations.Find(id);
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
