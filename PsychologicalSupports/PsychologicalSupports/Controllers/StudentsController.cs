using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Controllers
{
    public class StudentsController : Controller
    {
        IRepository<Student> repo;
        public StudentsController()
        {
            repo = new StudentRepository();
        }
        [Authorize]
        public ActionResult Index()
        {
                return View(repo.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var student = repo.Get(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,FIO,NumberClass,Class,AdmissionDate,BeingTrained")] Student student)
        {
            if (ModelState.IsValid)
            {
                repo.Create(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var student = repo.Get(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        
        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,FIO,NumberClass,Class,AdmissionDate,BeingTrained")] Student student)
        {
            if (ModelState.IsValid)
            {
                repo.Edit(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var student = repo.Get(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
