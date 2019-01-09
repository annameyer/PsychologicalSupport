using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Controllers
{
    public class Interests_Card_50Controller : Controller
    {
        private readonly IPsychologicalSupportsContext _context;
        private IRepository<Interests_Card_50> _repository;
        public Interests_Card_50Controller(IRepository<Interests_Card_50> repository, IPsychologicalSupportsContext context)
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
            var Interests_Card_50 = _repository.Get(id);
            if (Interests_Card_50 == null)
            {
                return HttpNotFound();
            }
            return View(Interests_Card_50);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Interests_Card_50 Interests_Card_50)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(Interests_Card_50);
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO", Interests_Card_50.StudentID);
            return View(Interests_Card_50);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Interests_Card_50 = _repository.Get(id);
            if (Interests_Card_50 == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO", Interests_Card_50.StudentID);
            return View(Interests_Card_50);
        }

        [HttpPost]
        public ActionResult Edit(Interests_Card_50 Interests_Card_50)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(Interests_Card_50);
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO", Interests_Card_50.StudentID);
            return View(Interests_Card_50);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Interests_Card_50 = _repository.Get(id);
            if (Interests_Card_50 == null)
            {
                return HttpNotFound();
            }
            return View(Interests_Card_50);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
