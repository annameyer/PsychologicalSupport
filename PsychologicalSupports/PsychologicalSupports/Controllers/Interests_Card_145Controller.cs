using PagedList;
using PsychologicalSupports.Enum;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PsychologicalSupports.Controllers
{
    [Authorize]
    public class Interests_Card_145Controller : Controller
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        private IRepository<Interests_Card_145> _repository;

        public Interests_Card_145Controller(IRepository<Interests_Card_145> repository, IPsychologicalSupportsContext context)
        {
            _psychologicalSupportsContext = context;
            _repository = repository;
        }

        public FileContentResult Download(string search, string Class, int? NumberClass, string Filter)
        {
            var students = _repository.List().Join(_psychologicalSupportsContext.Students, p => p.StudentID, x => x.StudentID, (p, x) => p).Where(x => x.Student.BeingTrained == true);
            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(x => x.Student.FIO.Contains(search));
            }

            if (!string.IsNullOrEmpty(Class))
            {
                students = students.Where(x => x.Student.Class == Class);
            }

            if (NumberClass != null)
            {
                students = students.Where(x => x.Student.NumberClass == NumberClass);
            }

            if (Filter == "FIO")
            {
                students = students.OrderBy(x => x.Student.FIO);
            }

            if (Filter == "Сlass")
            {
                students = students.OrderBy(x => x.Student.Class);
            }

            string fileDownloadName = string.Format("Карта интересов 145.xlsx");
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fio = students.Select(x => x.Student.FIO).ToList();
            var package = ExcelFile.GenerateExcelFile(students, fio);

            FileContentResult fsr = new FileContentResult(package.GetAsByteArray(), contentType)
            {
                FileDownloadName = fileDownloadName
            };

            return fsr;
        }

        public ActionResult Index(string search, string Class, int? NumberClass, int? page, string Filter)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var students = _repository.List().Join(_psychologicalSupportsContext.Students, p => p.StudentID, x => x.StudentID, (p, x) => p).Where(x => x.Student.BeingTrained == true);
            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(x => x.Student.FIO.Contains(search));
                ViewBag.Search = search;
            }

            if (!string.IsNullOrEmpty(Class))
            {
                students = students.Where(x => x.Student.Class == Class);
                ViewBag.Class = Class;
            }

            if (NumberClass != null)
            {
                students = students.Where(x => x.Student.NumberClass == NumberClass);
                ViewBag.NumberClass = NumberClass;
            }

            if (Filter == "FIO")
            {
                students = students.OrderBy(x => x.Student.FIO);
            }

            if (Filter == "Сlass")
            {
                students = students.OrderBy(x => x.Student.Class);
            }
            ViewBag.Filter = Filter;

            return View(students.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Interests_Card_145 Interests_Card_145 = _repository.Get(id);
            if (Interests_Card_145 == null)
            {
                return HttpNotFound();
            }

            return View(Interests_Card_145);
        }

        public ActionResult Create(int Id)
        {
            GetCurrentStudent studentName = new GetCurrentStudent();
            ViewBag.StudentName = studentName.GetStudentId(Id);
            ViewBag.StudentID = Id;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Interests_Card_145 Interests_Card_145, int Id)
        {
            Interests_Card_145.StudentID = Id;
            if (ModelState.IsValid)
            {
                _repository.Create(Interests_Card_145);
                return RedirectToAction("Index");
            }
            GetCurrentStudent studentName = new GetCurrentStudent();
            ViewBag.StudentName = studentName.GetStudentId(Id);

            return View(Interests_Card_145);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GetCurrentStudent studentName = new GetCurrentStudent();
            ViewBag.StudentName = studentName.GetStudentId(id.Value);
            Interests_Card_145 Interests_Card_145 = _repository.Get(id);
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

            Interests_Card_145 Interests_Card_145 = _repository.Get(id);
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
