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
    public class Intellectual_8_ClassController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();

        // GET: Intellectual_8_Class
        public ActionResult Index()
        {
            var intellectual_8_Class = db.Intellectual_8_Class.Include(i => i.Student);
            return View(intellectual_8_Class.ToList());
        }

        // GET: Intellectual_8_Class/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intellectual_8_Class intellectual_8_Class = db.Intellectual_8_Class.Find(id);
            if (intellectual_8_Class == null)
            {
                return HttpNotFound();
            }
            return View(intellectual_8_Class);
        }

        // GET: Intellectual_8_Class/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName");
            return View();
        }

        // POST: Intellectual_8_Class/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Intellectual_8_Class1,StudentID,InterestMap,RecommendedProfile")] Intellectual_8_Class intellectual_8_Class)
        {
            if (ModelState.IsValid)
            {
                db.Intellectual_8_Class.Add(intellectual_8_Class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", intellectual_8_Class.StudentID);
            return View(intellectual_8_Class);
        }

        // GET: Intellectual_8_Class/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intellectual_8_Class intellectual_8_Class = db.Intellectual_8_Class.Find(id);
            if (intellectual_8_Class == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", intellectual_8_Class.StudentID);
            return View(intellectual_8_Class);
        }

        // POST: Intellectual_8_Class/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Intellectual_8_Class1,StudentID,InterestMap,RecommendedProfile")] Intellectual_8_Class intellectual_8_Class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intellectual_8_Class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", intellectual_8_Class.StudentID);
            return View(intellectual_8_Class);
        }

        // GET: Intellectual_8_Class/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intellectual_8_Class intellectual_8_Class = db.Intellectual_8_Class.Find(id);
            if (intellectual_8_Class == null)
            {
                return HttpNotFound();
            }
            return View(intellectual_8_Class);
        }

        // POST: Intellectual_8_Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Intellectual_8_Class intellectual_8_Class = db.Intellectual_8_Class.Find(id);
            db.Intellectual_8_Class.Remove(intellectual_8_Class);
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
