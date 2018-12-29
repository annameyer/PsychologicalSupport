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
    public class Intellectual_9_ClassController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();

        // GET: Intellectual_9_Class
        public ActionResult Index()
        {
            var intellectual_9_Class = db.Intellectual_9_Class.Include(i => i.Student);
            return View(intellectual_9_Class.ToList());
        }

        // GET: Intellectual_9_Class/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intellectual_9_Class intellectual_9_Class = db.Intellectual_9_Class.Find(id);
            if (intellectual_9_Class == null)
            {
                return HttpNotFound();
            }
            return View(intellectual_9_Class);
        }

        // GET: Intellectual_9_Class/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        // POST: Intellectual_9_Class/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,Profile")] Intellectual_9_Class intellectual_9_Class)
        {
            if (ModelState.IsValid)
            {
                db.Intellectual_9_Class.Add(intellectual_9_Class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", intellectual_9_Class.StudentID);
            return View(intellectual_9_Class);
        }

        // GET: Intellectual_9_Class/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intellectual_9_Class intellectual_9_Class = db.Intellectual_9_Class.Find(id);
            if (intellectual_9_Class == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", intellectual_9_Class.StudentID);
            return View(intellectual_9_Class);
        }

        // POST: Intellectual_9_Class/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,Profile")] Intellectual_9_Class intellectual_9_Class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intellectual_9_Class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", intellectual_9_Class.StudentID);
            return View(intellectual_9_Class);
        }

        // GET: Intellectual_9_Class/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intellectual_9_Class intellectual_9_Class = db.Intellectual_9_Class.Find(id);
            if (intellectual_9_Class == null)
            {
                return HttpNotFound();
            }
            return View(intellectual_9_Class);
        }

        // POST: Intellectual_9_Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Intellectual_9_Class intellectual_9_Class = db.Intellectual_9_Class.Find(id);
            db.Intellectual_9_Class.Remove(intellectual_9_Class);
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
