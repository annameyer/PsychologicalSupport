using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Controllers
{
    public class ClassTeacheInformationsController : Controller
    {
        private readonly IPsychologicalSupportsContext __context;
        private IRepository<ClassTeacheInformation> _repository;
        public ClassTeacheInformationsController(IRepository<ClassTeacheInformation> repository, IPsychologicalSupportsContext context)
        {
            __context = context;
            _repository = repository;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View(_repository.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var classTeacheInformation = _repository.Get(id);
            if (classTeacheInformation == null)
            {
                return HttpNotFound();
            }
            return View(classTeacheInformation);
        }


        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(__context.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClassTeacheInformation classTeacheInformation)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(classTeacheInformation);
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(__context.Students, "StudentID", "FIO", classTeacheInformation.StudentID);
            return View(classTeacheInformation);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var classTeacheInformation = _repository.Get(id);
            if (classTeacheInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(__context.Students, "StudentID", "FIO", classTeacheInformation.StudentID);
            return View(classTeacheInformation);
        }

        [HttpPost]
        public ActionResult Edit(ClassTeacheInformation classTeacheInformation)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(classTeacheInformation);
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(__context.Students, "StudentID", "FIO", classTeacheInformation.StudentID);
            return View(classTeacheInformation);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var classTeacheInformation = _repository.Get(id); ;
            if (classTeacheInformation == null)
            {
                return HttpNotFound();
            }
            return View(classTeacheInformation);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
