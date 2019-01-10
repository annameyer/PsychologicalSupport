using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Controllers
{
    public class FamilyAlarmAnalysisController : Controller
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        private IRepository<FamilyAlarmAnalysi> _repository;

        public FamilyAlarmAnalysisController(IRepository<FamilyAlarmAnalysi> repository, IPsychologicalSupportsContext context)
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

            var familyAlarmAnalysi = _repository.Get(id);
            if (familyAlarmAnalysi == null)
            {
                return HttpNotFound();
            }

            return View(familyAlarmAnalysi);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(_psychologicalSupportsContext.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create(FamilyAlarmAnalysi familyAlarmAnalysi)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(familyAlarmAnalysi);
                return RedirectToAction("Index");
            }

            return View(familyAlarmAnalysi);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var familyAlarmAnalysi = _repository.Get(id);
            if (familyAlarmAnalysi == null)
            {
                return HttpNotFound();
            }

            return View(familyAlarmAnalysi);
        }

        [HttpPost]
        public ActionResult Edit(FamilyAlarmAnalysi familyAlarmAnalysi)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(familyAlarmAnalysi);
                return RedirectToAction("Index");
            }

            return View(familyAlarmAnalysi);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var familyAlarmAnalysi = _repository.Get(id);
            if (familyAlarmAnalysi == null)
            {
                return HttpNotFound();
            }

            return View(familyAlarmAnalysi);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
