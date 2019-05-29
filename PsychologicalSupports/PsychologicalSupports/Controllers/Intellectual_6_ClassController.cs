using PsychologicalSupports.Enum;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Net;
using System.Web.Mvc;

namespace PsychologicalSupports.Controllers
{
    public class Intellectual_6_ClassController : Controller
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        private IRepository<Intellectual_6_Class> _repository;

        public Intellectual_6_ClassController(IRepository<Intellectual_6_Class> repository, IPsychologicalSupportsContext context)
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

            Intellectual_6_Class intellectual_6_Class = _repository.Get(id);
            if (intellectual_6_Class == null)
            {
                return HttpNotFound();
            }

            return View(intellectual_6_Class);
        }

        public ActionResult Create(int Id)
        {
            GetCurrentStudent studentName = new GetCurrentStudent();
            ViewBag.StudentName = studentName.GetStudentId(Id);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Intellectual_6_Class intellectual_6_Class)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(intellectual_6_Class);
                return RedirectToAction("Index");
            }

            return View(intellectual_6_Class);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Intellectual_6_Class intellectual_6_Class = _repository.Get(id);
            if (intellectual_6_Class == null)
            {
                return HttpNotFound();
            }

            return View(intellectual_6_Class);
        }

        [HttpPost]
        public ActionResult Edit(Intellectual_6_Class intellectual_6_Class)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(intellectual_6_Class);
                return RedirectToAction("Index");
            }

            return View(intellectual_6_Class);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Intellectual_6_Class intellectual_6_Class = _repository.Get(id);
            if (intellectual_6_Class == null)
            {
                return HttpNotFound();
            }

            return View(intellectual_6_Class);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
