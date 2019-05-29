using PsychologicalSupports.Enum;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Net;
using System.Web.Mvc;

namespace PsychologicalSupports.Controllers
{
    public class Intellectual_9_ClassController : Controller
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        private IRepository<Intellectual_9_Class> _repository;

        public Intellectual_9_ClassController(IRepository<Intellectual_9_Class> repository, IPsychologicalSupportsContext context)
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

            Intellectual_9_Class intellectual_9_Class = _repository.Get(id);
            if (intellectual_9_Class == null)
            {
                return HttpNotFound();
            }

            return View(intellectual_9_Class);
        }

        public ActionResult Create(int Id)
        {
            GetCurrentStudent studentName = new GetCurrentStudent();
            ViewBag.StudentName = studentName.GetStudentId(Id);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Intellectual_9_Class intellectual_9_Class)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(intellectual_9_Class);
                return RedirectToAction("Index");
            }

            return View(intellectual_9_Class);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Intellectual_9_Class intellectual_9_Class = _repository.Get(id);
            if (intellectual_9_Class == null)
            {
                return HttpNotFound();
            }

            return View(intellectual_9_Class);
        }

        [HttpPost]
        public ActionResult Edit(Intellectual_9_Class intellectual_9_Class)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(intellectual_9_Class);
                return RedirectToAction("Index");
            }

            return View(intellectual_9_Class);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Intellectual_9_Class intellectual_9_Class = _repository.Get(id);
            if (intellectual_9_Class == null)
            {
                return HttpNotFound();
            }

            return View(intellectual_9_Class);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
