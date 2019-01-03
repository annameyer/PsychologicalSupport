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
        [Authorize]
        // GET: Self_esteem
        public ActionResult Index()
        {
            var self_esteem = db.Self_esteem.Include(s => s.Student);
            return View(self_esteem.ToList());
        }

        // GET: Self_esteem/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Self_esteem self_esteem = db.Self_esteem.Find(id);
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
        public ActionResult Create([Bind(Include = "StudentID,Indicator")] Self_esteem self_esteem)
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
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Self_esteem self_esteem = db.Self_esteem.Find(id);
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
        public ActionResult Edit([Bind(Include = "StudentID,Indicator")] Self_esteem self_esteem)
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
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Self_esteem self_esteem = db.Self_esteem.Find(id);
            if (self_esteem == null)
            {
                return HttpNotFound();
            }
            return View(self_esteem);
        }

        // POST: Self_esteem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Self_esteem self_esteem = db.Self_esteem.Find(id);
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
