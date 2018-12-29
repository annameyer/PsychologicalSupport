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
    public class Interests_Card_145Controller : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();

        // GET: Interests_Card_145
        public ActionResult Index()
        {
            var interests_Card_145 = db.Interests_Card_145.Include(i => i.Student);
            return View(interests_Card_145.ToList());
        }

        // GET: Interests_Card_145/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interests_Card_145 interests_Card_145 = db.Interests_Card_145.Find(id);
            if (interests_Card_145 == null)
            {
                return HttpNotFound();
            }
            return View(interests_Card_145);
        }

        // GET: Interests_Card_145/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        // POST: Interests_Card_145/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,Biology,Geography,Geology,TheMedicine,LightAndFoodIndustry,Physics,Chemistry,EngineeringMechanics,ElectricalEngineeringRadioEngineering,MaterialHandling,InformationTechnology,Psychology,Building,Tranport,MilitarySpecialties,Story,Literature,Journalism,Sociology,Pedagogy,Right,ServiceSector,Maths,Economy,ForeignLanguages,Art,Music,Sport")] Interests_Card_145 interests_Card_145)
        {
            if (ModelState.IsValid)
            {
                db.Interests_Card_145.Add(interests_Card_145);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", interests_Card_145.StudentID);
            return View(interests_Card_145);
        }

        // GET: Interests_Card_145/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interests_Card_145 interests_Card_145 = db.Interests_Card_145.Find(id);
            if (interests_Card_145 == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", interests_Card_145.StudentID);
            return View(interests_Card_145);
        }

        // POST: Interests_Card_145/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,Biology,Geography,Geology,TheMedicine,LightAndFoodIndustry,Physics,Chemistry,EngineeringMechanics,ElectricalEngineeringRadioEngineering,MaterialHandling,InformationTechnology,Psychology,Building,Tranport,MilitarySpecialties,Story,Literature,Journalism,Sociology,Pedagogy,Right,ServiceSector,Maths,Economy,ForeignLanguages,Art,Music,Sport")] Interests_Card_145 interests_Card_145)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interests_Card_145).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", interests_Card_145.StudentID);
            return View(interests_Card_145);
        }

        // GET: Interests_Card_145/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interests_Card_145 interests_Card_145 = db.Interests_Card_145.Find(id);
            if (interests_Card_145 == null)
            {
                return HttpNotFound();
            }
            return View(interests_Card_145);
        }

        // POST: Interests_Card_145/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Interests_Card_145 interests_Card_145 = db.Interests_Card_145.Find(id);
            db.Interests_Card_145.Remove(interests_Card_145);
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
