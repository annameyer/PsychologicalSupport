using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Controllers
{
    public class MindsetsController : Controller
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        private IRepository<Mindset> _repository;

        public MindsetsController(IRepository<Mindset> repository, IPsychologicalSupportsContext context)
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

            var Mindset = _repository.Get(id);
            if (Mindset == null)
            {
                return HttpNotFound();
            }

            return View(Mindset);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(_psychologicalSupportsContext.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Mindset Mindset)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(Mindset);
                return RedirectToAction("Index");
            }

            return View(Mindset);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Mindset = _repository.Get(id);
            if (Mindset == null)
            {
                return HttpNotFound();
            }

            return View(Mindset);
        }

        [HttpPost]
        public ActionResult Edit(Mindset Mindset)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(Mindset);
                return RedirectToAction("Index");
            }

            return View(Mindset);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Mindset = _repository.Get(id);
            if (Mindset == null)
            {
                return HttpNotFound();
            }

            return View(Mindset);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
