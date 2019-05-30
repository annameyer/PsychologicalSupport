using PsychologicalSupports.Enum;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Net;
using System.Web.Mvc;

namespace PsychologicalSupports.Controllers
{
    public class Self_esteemController : Controller
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        private IRepository<Self_esteem> _repository;

        public Self_esteemController(IRepository<Self_esteem> repository, IPsychologicalSupportsContext context)
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

            Self_esteem PersonaAnxietyScale = _repository.Get(id);
            if (PersonaAnxietyScale == null)
            {
                return HttpNotFound();
            }

            return View(PersonaAnxietyScale);
        }

        public ActionResult Create(int Id)
        {
            GetCurrentStudent studentName = new GetCurrentStudent();
            ViewBag.StudentName = studentName.GetStudentId(Id);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Self_esteem Self_esteem, int Id)
        {
            Self_esteem.StudentID = Id;
            if (ModelState.IsValid)
            {
                _repository.Create(Self_esteem);
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(_psychologicalSupportsContext.Students, "StudentID", "FIO", Self_esteem.StudentID);
            return View(Self_esteem);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Self_esteem PersonaAnxietyScale = _repository.Get(id);
            if (PersonaAnxietyScale == null)
            {
                return HttpNotFound();
            }

            ViewBag.StudentID = new SelectList(_psychologicalSupportsContext.Students, "StudentID", "FIO", PersonaAnxietyScale.StudentID);
            return View(PersonaAnxietyScale);
        }

        [HttpPost]
        public ActionResult Edit(Self_esteem Self_esteem)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(Self_esteem);
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(_psychologicalSupportsContext.Students, "StudentID", "FIO", Self_esteem.StudentID);
            return View(Self_esteem);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Self_esteem PersonaAnxietyScale = _repository.Get(id);
            if (PersonaAnxietyScale == null)
            {
                return HttpNotFound();
            }

            return View(PersonaAnxietyScale);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
