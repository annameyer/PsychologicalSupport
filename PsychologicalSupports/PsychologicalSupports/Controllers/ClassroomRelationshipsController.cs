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
    public class ClassroomRelationshipsController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();
        [Authorize]
        // GET: ClassroomRelationships
        public ActionResult Index()
        {
            var classroomRelationships = db.ClassroomRelationships.Include(c => c.Student);
            return View(classroomRelationships.ToList());
        }

        // GET: ClassroomRelationships/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassroomRelationship classroomRelationship = db.ClassroomRelationships.Find(id);
            if (classroomRelationship == null)
            {
                return HttpNotFound();
            }
            return View(classroomRelationship);
        }

        // GET: ClassroomRelationships/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        // POST: ClassroomRelationships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,IGS_Sishora,Sociometry")] ClassroomRelationship classroomRelationship)
        {
            if (ModelState.IsValid)
            {
                db.ClassroomRelationships.Add(classroomRelationship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", classroomRelationship.StudentID);
            return View(classroomRelationship);
        }

        // GET: ClassroomRelationships/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassroomRelationship classroomRelationship = db.ClassroomRelationships.Find(id);
            if (classroomRelationship == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", classroomRelationship.StudentID);
            return View(classroomRelationship);
        }

        // POST: ClassroomRelationships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,IGS_Sishora,Sociometry")] ClassroomRelationship classroomRelationship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classroomRelationship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", classroomRelationship.StudentID);
            return View(classroomRelationship);
        }

        // GET: ClassroomRelationships/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassroomRelationship classroomRelationship = db.ClassroomRelationships.Find(id);
            if (classroomRelationship == null)
            {
                return HttpNotFound();
            }
            return View(classroomRelationship);
        }

        // POST: ClassroomRelationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ClassroomRelationship classroomRelationship = db.ClassroomRelationships.Find(id);
            db.ClassroomRelationships.Remove(classroomRelationship);
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
