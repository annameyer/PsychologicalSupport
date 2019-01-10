using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Controllers
{
    public class Interests_Card_145Controller : Controller
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        private IRepository<Interests_Card_145> _repository;

        public Interests_Card_145Controller(IRepository<Interests_Card_145> repository, IPsychologicalSupportsContext context)
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

            var Interests_Card_145 = _repository.Get(id);
            if (Interests_Card_145 == null)
            {
                return HttpNotFound();
            }

            return View(Interests_Card_145);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(_psychologicalSupportsContext.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Interests_Card_145 Interests_Card_145)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(Interests_Card_145);
                return RedirectToAction("Index");
            }

            return View(Interests_Card_145);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Interests_Card_145 = _repository.Get(id);
            if (Interests_Card_145 == null)
            {
                return HttpNotFound();
            }

            return View(Interests_Card_145);
        }

        [HttpPost]
        public ActionResult Edit(Interests_Card_145 Interests_Card_145)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(Interests_Card_145);
                return RedirectToAction("Index");
            }

            return View(Interests_Card_145);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Interests_Card_145 = _repository.Get(id);
            if (Interests_Card_145 == null)
            {
                return HttpNotFound();
            }
            return View(Interests_Card_145);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
