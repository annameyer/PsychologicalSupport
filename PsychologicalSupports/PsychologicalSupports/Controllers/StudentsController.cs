using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IRepository<Student> __repo;
        public StudentsController(IRepository<Student> student)
        {
            __repo = student;
        }
        [Authorize]
        public ActionResult Index()
        {

                return View(__repo.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var student = __repo.Get(id);
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
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                __repo.Create(student);
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
            var student = __repo.Get(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                __repo.Edit(student);
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
            var student = __repo.Get(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            __repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
