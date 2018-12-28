using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class MindsetsController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();

        // GET: Mindsets
        public ActionResult Index()
        {
            var mindsets = db.Mindsets.Include(m => m.Student);
            return View(mindsets.ToList());
        }

        // GET: Mindsets/Details/5
        public ActionResult Details(long? id,long? id2)
        {
            if (id == null && id2==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mindset mindset = db.Mindsets.Find(id,id2);
            if (mindset == null)
            {
                return HttpNotFound();
            }
            return View(mindset);
        }

        // GET: Mindsets/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        // POST: Mindsets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MindsetID,StudentID,Subject_Effective,AbstractSymbolic,Verbal_Logical,Visually_Shaped,Creativity")] Mindset mindset)
        {
            if (ModelState.IsValid)
            {
                db.Mindsets.Add(mindset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", mindset.StudentID);
            return View(mindset);
        }

        // GET: Mindsets/Edit/5
        public ActionResult Edit(long? id,long? id2)
        {
            if (id == null && id2==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mindset mindset = db.Mindsets.Find(id,id2);
            if (mindset == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", mindset.StudentID);
            return View(mindset);
        }

        // POST: Mindsets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MindsetID,StudentID,Subject_Effective,AbstractSymbolic,Verbal_Logical,Visually_Shaped,Creativity")] Mindset mindset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mindset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", mindset.StudentID);
            return View(mindset);
        }

        // GET: Mindsets/Delete/5
        public ActionResult Delete(long? id,long? id2)
        {
            if (id == null && id2==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mindset mindset = db.Mindsets.Find(id,id2);
            if (mindset == null)
            {
                return HttpNotFound();
            }
            return View(mindset);
        }

        // POST: Mindsets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id,long id2)
        {
            Mindset mindset = db.Mindsets.Find(id,id2);
            db.Mindsets.Remove(mindset);
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
