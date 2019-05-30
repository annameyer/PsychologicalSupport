using PsychologicalSupports.Enum;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Net;
using System.Web.Mvc;

namespace PsychologicalSupports.Controllers
{
    public class PersonaAnxietyScalesController : Controller
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        private IRepository<PersonaAnxietyScale> _repository;

        public PersonaAnxietyScalesController(IRepository<PersonaAnxietyScale> repository, IPsychologicalSupportsContext context)
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

            PersonaAnxietyScale PersonaAnxietyScale = _repository.Get(id);
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
        public ActionResult Create(PersonaAnxietyScale PersonaAnxietyScale, int Id)
        {
            PersonaAnxietyScale.StudentID = Id;
            if (ModelState.IsValid)
            {
                _repository.Create(PersonaAnxietyScale);
                return RedirectToAction("Index");
            }

            return View(PersonaAnxietyScale);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PersonaAnxietyScale PersonaAnxietyScale = _repository.Get(id);
            if (PersonaAnxietyScale == null)
            {
                return HttpNotFound();
            }

            return View(PersonaAnxietyScale);
        }

        [HttpPost]
        public ActionResult Edit(PersonaAnxietyScale PersonaAnxietyScale)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(PersonaAnxietyScale);
                return RedirectToAction("Index");
            }

            return View(PersonaAnxietyScale);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PersonaAnxietyScale PersonaAnxietyScale = _repository.Get(id);
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
