using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Controllers
{
    public class SchoolMotivationsController : Controller
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        private IRepository<SchoolMotivation> _repository;

        public SchoolMotivationsController(IRepository<SchoolMotivation> repository, IPsychologicalSupportsContext context)
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

            var PersonaAnxietyScale = _repository.Get(id);
            if (PersonaAnxietyScale == null)
            {
                return HttpNotFound();
            }

            return View(PersonaAnxietyScale);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(_psychologicalSupportsContext.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create(SchoolMotivation SchoolMotivation)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(SchoolMotivation);
                return RedirectToAction("Index");
            }

            return View(SchoolMotivation);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var PersonaAnxietyScale = _repository.Get(id);
            if (PersonaAnxietyScale == null)
            {
                return HttpNotFound();
            }

            return View(PersonaAnxietyScale);
        }

        [HttpPost]
        public ActionResult Edit(SchoolMotivation SchoolMotivation)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(SchoolMotivation);
                return RedirectToAction("Index");
            }

            return View(SchoolMotivation);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var PersonaAnxietyScale = _repository.Get(id);
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
