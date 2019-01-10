using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Controllers
{
    public class ClassroomRelationshipsController : Controller
    {
        private readonly IPsychologicalSupportsContext _context;
        private IRepository<ClassroomRelationship> _repository;

        public ClassroomRelationshipsController(IRepository<ClassroomRelationship> repository, IPsychologicalSupportsContext context)
        {
            _context = context;
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

            var classroomRelationship = _repository.Get(id);
            if (classroomRelationship == null)
            {
                return HttpNotFound();
            }

            return View(classroomRelationship);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClassroomRelationship classroomRelationship)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(classroomRelationship);
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO", classroomRelationship.StudentID);
            return View(classroomRelationship);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var classroomRelationship = _repository.Get(id);
            if (classroomRelationship == null)
            {
                return HttpNotFound();
            }

            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO", classroomRelationship.StudentID);
            return View(classroomRelationship);
        }

        [HttpPost]
        public ActionResult Edit(ClassroomRelationship classroomRelationship)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(classroomRelationship);
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO", classroomRelationship.StudentID);
            return View(classroomRelationship);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var classroomRelationship = _repository.Get(id);
            if (classroomRelationship == null)
            {
                return HttpNotFound();
            }

            return View(classroomRelationship);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
