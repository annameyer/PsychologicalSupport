using PsychologicalSupports.Enum;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Net;
using System.Web.Mvc;

namespace PsychologicalSupports.Controllers
{
    public class AveragePointsController : Controller
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        private IRepository<AveragePoint> _repository;

        public AveragePointsController(IRepository<AveragePoint> repository, IPsychologicalSupportsContext context)
        {
            _psychologicalSupportsContext = context;
            _repository = repository;
        }

         
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

            AveragePoint averagePoint = _repository.Get(id);
            if (averagePoint == null)
            {
                return HttpNotFound();
            }

            return View(averagePoint);
        }

        public ActionResult Create(int Id)
        {
            GetCurrentStudent studentName = new GetCurrentStudent();
            ViewBag.StudentID = studentName.GetStudentId(Id);
            return View();
        }

        [HttpPost]
        public ActionResult Create(AveragePoint averagePoint)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(averagePoint);
                return RedirectToAction("Index");
            }

            return View(averagePoint);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AveragePoint averagePoint = _repository.Get(id);
            if (averagePoint == null)
            {
                return HttpNotFound();
            }

            return View(averagePoint);
        }

        [HttpPost]
        public ActionResult Edit(AveragePoint averagePoint)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(averagePoint);
                return RedirectToAction("Index");
            }

            return View(averagePoint);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AveragePoint averagePoint = _repository.Get(id);
            if (averagePoint == null)
            {
                return HttpNotFound();
            }
            return View(averagePoint);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
