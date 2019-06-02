using OfficeOpenXml;
using PsychologicalSupports.Enum;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Net;
using System.Web.Mvc;

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

         
        public ActionResult Index()
        {
            return View(_repository.List());
        }

        public FileContentResult Download()
        {

            string fileDownloadName = string.Format("Семейная тревожность.xlsx");
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";


            ExcelPackage package = ExcelFile.GenerateExcelFile(_repository.List());

            FileContentResult fsr = new FileContentResult(package.GetAsByteArray(), contentType)
            {
                FileDownloadName = fileDownloadName
            };

            return fsr;
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FamilyAlarmAnalysi familyAlarmAnalysi = _repository.Get(id);
            if (familyAlarmAnalysi == null)
            {
                return HttpNotFound();
            }

            return View(familyAlarmAnalysi);
        }

        public ActionResult Create(int Id)
        {
            GetCurrentStudent studentName = new GetCurrentStudent();
            ViewBag.StudentName = studentName.GetStudentId(Id);
            return View();
        }

        [HttpPost]
        public ActionResult Create(FamilyAlarmAnalysi familyAlarmAnalysi, int Id)
        {
            familyAlarmAnalysi.StudentID = Id;
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

            FamilyAlarmAnalysi familyAlarmAnalysi = _repository.Get(id);
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

            FamilyAlarmAnalysi familyAlarmAnalysi = _repository.Get(id);
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
