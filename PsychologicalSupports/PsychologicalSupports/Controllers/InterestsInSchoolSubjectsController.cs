using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Controllers
{
    public class InterestsInSchoolSubjectsController : Controller
    {
        private readonly IPsychologicalSupportsContext _context;
        private IRepository<InterestsInSchoolSubject> _repository;
        public InterestsInSchoolSubjectsController(IRepository<InterestsInSchoolSubject> repository, IPsychologicalSupportsContext context)
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
            var InterestsInSchoolSubject = _repository.Get(id);
            if (InterestsInSchoolSubject == null)
            {
                return HttpNotFound();
            }
            return View(InterestsInSchoolSubject);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create(InterestsInSchoolSubject InterestsInSchoolSubject)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(InterestsInSchoolSubject);
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO", InterestsInSchoolSubject.StudentID);
            return View(InterestsInSchoolSubject);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var InterestsInSchoolSubject = _repository.Get(id);
            if (InterestsInSchoolSubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO", InterestsInSchoolSubject.StudentID);
            return View(InterestsInSchoolSubject);
        }

        [HttpPost]
        public ActionResult Edit(InterestsInSchoolSubject InterestsInSchoolSubject)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(InterestsInSchoolSubject);
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO", InterestsInSchoolSubject.StudentID);
            return View(InterestsInSchoolSubject);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var InterestsInSchoolSubject = _repository.Get(id);
            if (InterestsInSchoolSubject == null)
            {
                return HttpNotFound();
            }
            return View(InterestsInSchoolSubject);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
