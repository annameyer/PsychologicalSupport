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
    public class Intellectual_6_ClassController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();

        // GET: Intellectual_6_Class
        public ActionResult Index()
        {
            var intellectual_6_Class = db.Intellectual_6_Class.Include(i => i.Student);
            return View(intellectual_6_Class.ToList());
        }

        // GET: Intellectual_6_Class/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intellectual_6_Class intellectual_6_Class = db.Intellectual_6_Class.Find(id);
            if (intellectual_6_Class == null)
            {
                return HttpNotFound();
            }
            return View(intellectual_6_Class);
        }

        // GET: Intellectual_6_Class/Create
        public ActionResult Create()
        {
            ViewBag.Intellectual_6_ClassID = new SelectList(db.Students, "StudentID", "LastName");
            return View();
        }

        // POST: Intellectual_6_Class/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Intellectual_6_ClassID,StudentID,TestResult,TestLevel,AveragePoint")] Intellectual_6_Class intellectual_6_Class)
        {
            if (ModelState.IsValid)
            {
                db.Intellectual_6_Class.Add(intellectual_6_Class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Intellectual_6_ClassID = new SelectList(db.Students, "StudentID", "LastName", intellectual_6_Class.Intellectual_6_ClassID);
            return View(intellectual_6_Class);
        }

        // GET: Intellectual_6_Class/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intellectual_6_Class intellectual_6_Class = db.Intellectual_6_Class.Find(id);
            if (intellectual_6_Class == null)
            {
                return HttpNotFound();
            }
            ViewBag.Intellectual_6_ClassID = new SelectList(db.Students, "StudentID", "LastName", intellectual_6_Class.Intellectual_6_ClassID);
            return View(intellectual_6_Class);
        }

        // POST: Intellectual_6_Class/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Intellectual_6_ClassID,StudentID,TestResult,TestLevel,AveragePoint")] Intellectual_6_Class intellectual_6_Class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intellectual_6_Class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Intellectual_6_ClassID = new SelectList(db.Students, "StudentID", "LastName", intellectual_6_Class.Intellectual_6_ClassID);
            return View(intellectual_6_Class);
        }

        // GET: Intellectual_6_Class/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intellectual_6_Class intellectual_6_Class = db.Intellectual_6_Class.Find(id);
            if (intellectual_6_Class == null)
            {
                return HttpNotFound();
            }
            return View(intellectual_6_Class);
        }

        // POST: Intellectual_6_Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Intellectual_6_Class intellectual_6_Class = db.Intellectual_6_Class.Find(id);
            db.Intellectual_6_Class.Remove(intellectual_6_Class);
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
