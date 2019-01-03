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
    public class ClassTeacheInformationsController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();
        [Authorize]
        // GET: ClassTeacheInformations
        public ActionResult Index()
        {
            var classTeacheInformations = db.ClassTeacheInformations.Include(c => c.Student);
            return View(classTeacheInformations.ToList());
        }

        // GET: ClassTeacheInformations/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTeacheInformation classTeacheInformation = db.ClassTeacheInformations.Find(id);
            if (classTeacheInformation == null)
            {
                return HttpNotFound();
            }
            return View(classTeacheInformation);
        }

        // GET: ClassTeacheInformations/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        // POST: ClassTeacheInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: ClassTeacheInformations/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTeacheInformation classTeacheInformation = db.ClassTeacheInformations.Find(id);
            if (classTeacheInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", classTeacheInformation.StudentID);
            return View(classTeacheInformation);
        }

        // POST: ClassTeacheInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: ClassTeacheInformations/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTeacheInformation classTeacheInformation = db.ClassTeacheInformations.Find(id);
            if (classTeacheInformation == null)
            {
                return HttpNotFound();
            }
            return View(classTeacheInformation);
        }

        // POST: ClassTeacheInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ClassTeacheInformation classTeacheInformation = db.ClassTeacheInformations.Find(id);
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
