using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class Self_esteemController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();

        // GET: Self_esteem
        public ActionResult Index()
        {
            var self_esteem = db.Self_esteem.Include(s => s.Student);
            return View(self_esteem.ToList());
        }

        // GET: Self_esteem/Details/5
        public ActionResult Details(long? id, long? id2)
        {
            if (id == null && id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Self_esteem self_esteem = db.Self_esteem.Find(id, id2);
            if (self_esteem == null)
            {
                return HttpNotFound();
            }
            return View(self_esteem);
        }

        // GET: Self_esteem/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO");
            return View();
        }

        // POST: Self_esteem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Self_esteemID,StudentID,Indicator")] Self_esteem self_esteem)
        {
            if (ModelState.IsValid)
            {
                db.Self_esteem.Add(self_esteem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", self_esteem.StudentID);
            return View(self_esteem);
        }

        // GET: Self_esteem/Edit/5
        public ActionResult Edit(long? id, long? id2)
        {
            if (id == null && id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Self_esteem self_esteem = db.Self_esteem.Find(id, id2);
            if (self_esteem == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", self_esteem.StudentID);
            return View(self_esteem);
        }

        // POST: Self_esteem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Self_esteemID,StudentID,Indicator")] Self_esteem self_esteem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(self_esteem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FIO", self_esteem.StudentID);
            return View(self_esteem);
        }

        // GET: Self_esteem/Delete/5
        public ActionResult Delete(long? id, long? id2)
        {
            if (id == null && id2==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Self_esteem self_esteem = db.Self_esteem.Find(id,id2);
            if (self_esteem == null)
            {
                return HttpNotFound();
            }
            return View(self_esteem);
        }

        // POST: Self_esteem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long? id, long? id2)
        {
            Self_esteem self_esteem = db.Self_esteem.Find(id, id2);
            db.Self_esteem.Remove(self_esteem);
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
