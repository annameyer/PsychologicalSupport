using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Controllers
{
    public class Intellectual_7_ClassController : Controller
    {
        private readonly IPsychologicalSupportsContext _context;
        private IRepository<Intellectual_7_Class> _repository;

        public Intellectual_7_ClassController(IRepository<Intellectual_7_Class> repository, IPsychologicalSupportsContext context)
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

            var intellectual_7_Class = _repository.Get(id);
            if (intellectual_7_Class == null)
            {
                return HttpNotFound();
            }

            return View(intellectual_7_Class);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Intellectual_7_Class intellectual_7_Class)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(intellectual_7_Class);
                return RedirectToAction("Index");
            }

            return View(intellectual_7_Class);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var intellectual_7_Class = _repository.Get(id);
            if (intellectual_7_Class == null)
            {
                return HttpNotFound();
            }

            return View(intellectual_7_Class);
        }

        [HttpPost]
        public ActionResult Edit(Intellectual_7_Class intellectual_7_Class)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(intellectual_7_Class);
                return RedirectToAction("Index");
            }

            return View(intellectual_7_Class);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var intellectual_7_Class = _repository.Get(id);
            if (intellectual_7_Class == null)
            {
                return HttpNotFound();
            }

            return View(intellectual_7_Class);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
