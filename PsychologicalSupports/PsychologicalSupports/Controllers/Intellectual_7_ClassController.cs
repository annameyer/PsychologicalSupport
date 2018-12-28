using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class Intellectual_7_ClassController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();

        // GET: Intellectual_7_Class
        public ActionResult Index()
        {
            var intellectual_7_Class = db.Intellectual_7_Class.Include(i => i.Student);
            return View(intellectual_7_Class.ToList());
        }

        // GET: Intellectual_7_Class/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intellectual_7_Class intellectual_7_Class = db.Intellectual_7_Class.Find(id);
            if (intellectual_7_Class == null)
            {
                return HttpNotFound();
            }
            return View(intellectual_7_Class);
        }

        // GET: Intellectual_7_Class/Create
        public ActionResult Create()
        {
            ViewBag.Intellectual_7_ClassID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        // POST: Intellectual_7_Class/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Intellectual_7_ClassID,IQ,Level,AveragePointСommon,AveragePointMath")] Intellectual_7_Class intellectual_7_Class)
        {
            if (ModelState.IsValid)
            {
                db.Intellectual_7_Class.Add(intellectual_7_Class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Intellectual_7_ClassID = new SelectList(db.Students, "StudentID", "FIO", intellectual_7_Class.Intellectual_7_ClassID);
            return View(intellectual_7_Class);
        }

        // GET: Intellectual_7_Class/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intellectual_7_Class intellectual_7_Class = db.Intellectual_7_Class.Find(id);
            if (intellectual_7_Class == null)
            {
                return HttpNotFound();
            }
            ViewBag.Intellectual_7_ClassID = new SelectList(db.Students, "StudentID", "FIO", intellectual_7_Class.Intellectual_7_ClassID);
            return View(intellectual_7_Class);
        }

        // POST: Intellectual_7_Class/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Intellectual_7_ClassID,IQ,Level,AveragePointСommon,AveragePointMath")] Intellectual_7_Class intellectual_7_Class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intellectual_7_Class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Intellectual_7_ClassID = new SelectList(db.Students, "StudentID", "FIO", intellectual_7_Class.Intellectual_7_ClassID);
            return View(intellectual_7_Class);
        }

        // GET: Intellectual_7_Class/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intellectual_7_Class intellectual_7_Class = db.Intellectual_7_Class.Find(id);
            if (intellectual_7_Class == null)
            {
                return HttpNotFound();
            }
            return View(intellectual_7_Class);
        }

        // POST: Intellectual_7_Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Intellectual_7_Class intellectual_7_Class = db.Intellectual_7_Class.Find(id);
            db.Intellectual_7_Class.Remove(intellectual_7_Class);
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
