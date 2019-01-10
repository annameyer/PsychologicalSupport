using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Controllers
{
    public class EmotioTestsController : Controller
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        private IRepository<EmotioTest> _repository;

        public EmotioTestsController(IRepository<EmotioTest> repository, IPsychologicalSupportsContext context)
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

            var emotioTest = _repository.Get(id);
            if (emotioTest == null)
            {
                return HttpNotFound();
            }

            return View(emotioTest);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(_psychologicalSupportsContext.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create( EmotioTest emotioTest)
        {
            if (ModelState.IsValid)
            {
               _repository.Create(emotioTest);
                return RedirectToAction("Index");
            }

            return View(emotioTest);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var emotioTest = _repository.Get(id);
            if (emotioTest == null)
            {
                return HttpNotFound();
            }

            return View(emotioTest);
        }

        [HttpPost]
        public ActionResult Edit(EmotioTest emotioTest)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(emotioTest);
                return RedirectToAction("Index");
            }

            return View(emotioTest);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var emotioTest = _repository.Get(id);
            if (emotioTest == null)
            {
                return HttpNotFound();
            }

            return View(emotioTest);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
