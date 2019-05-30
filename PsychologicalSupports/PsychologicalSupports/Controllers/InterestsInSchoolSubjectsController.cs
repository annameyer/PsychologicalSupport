using PsychologicalSupports.Enum;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Net;
using System.Web.Mvc;

namespace PsychologicalSupports.Controllers
{
    public class InterestsInSchoolSubjectsController : Controller
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        private IRepository<InterestsInSchoolSubject> _repository;

        public InterestsInSchoolSubjectsController(IRepository<InterestsInSchoolSubject> repository, IPsychologicalSupportsContext context)
        {
            _psychologicalSupportsContext = context;
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

            InterestsInSchoolSubject InterestsInSchoolSubject = _repository.Get(id);
            if (InterestsInSchoolSubject == null)
            {
                return HttpNotFound();
            }

            return View(InterestsInSchoolSubject);
        }

        public ActionResult Create(int Id)
        {
            GetCurrentStudent studentName = new GetCurrentStudent();
            ViewBag.StudentName = studentName.GetStudentId(Id);
            return View();
        }

        [HttpPost]
        public ActionResult Create(InterestsInSchoolSubject InterestsInSchoolSubject, int Id)
        {
            InterestsInSchoolSubject.StudentID = Id;
            if (ModelState.IsValid)
            {
                _repository.Create(InterestsInSchoolSubject);
                return RedirectToAction("Index");
            }

            return View(InterestsInSchoolSubject);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            InterestsInSchoolSubject InterestsInSchoolSubject = _repository.Get(id);
            if (InterestsInSchoolSubject == null)
            {
                return HttpNotFound();
            }

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

            return View(InterestsInSchoolSubject);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            InterestsInSchoolSubject InterestsInSchoolSubject = _repository.Get(id);
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
