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
    public class EmotioTestsController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();
        [Authorize]
        // GET: EmotioTests
        public ActionResult Index()
        {
            var emotioTests = db.EmotioTests.Include(e => e.Student);
            return View(emotioTests.ToList());
        }

        // GET: EmotioTests/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmotioTest emotioTest = db.EmotioTests.Find(id);
            if (emotioTest == null)
            {
                return HttpNotFound();
            }
            return View(emotioTest);
        }

        // GET: EmotioTests/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        // POST: EmotioTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,PhysicalAggression,IndirectAggression,Irritability,Negativism,Touchiness,Suspicion,VerbalAggression,Guilt")] EmotioTest emotioTest)
        {
            if (ModelState.IsValid)
            {
                db.EmotioTests.Add(emotioTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", emotioTest.StudentID);
            return View(emotioTest);
        }

        // GET: EmotioTests/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmotioTest emotioTest = db.EmotioTests.Find(id);
            if (emotioTest == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", emotioTest.StudentID);
            return View(emotioTest);
        }

        // POST: EmotioTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,PhysicalAggression,IndirectAggression,Irritability,Negativism,Touchiness,Suspicion,VerbalAggression,Guilt")] EmotioTest emotioTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emotioTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", emotioTest.StudentID);
            return View(emotioTest);
        }

        // GET: EmotioTests/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmotioTest emotioTest = db.EmotioTests.Find(id);
            if (emotioTest == null)
            {
                return HttpNotFound();
            }
            return View(emotioTest);
        }

        // POST: EmotioTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            EmotioTest emotioTest = db.EmotioTests.Find(id);
            db.EmotioTests.Remove(emotioTest);
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
