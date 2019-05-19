using OfficeOpenXml;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PsychologicalSupports.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IRepository<Student> _repository;

        public StudentsController(IRepository<Student> student)
        {
            _repository = student;
        }



        public FileContentResult Download()
        {

            string fileDownloadName = string.Format("Студенты.xlsx");
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";


            ExcelPackage package = ExcelFile.GenerateExcelFile(_repository.List());

            FileContentResult fsr = new FileContentResult(package.GetAsByteArray(), contentType)
            {
                FileDownloadName = fileDownloadName
            };

            return fsr;
        }

        [Authorize]
        public ActionResult Index(string search)
        {
            System.Collections.Generic.IEnumerable<Student> recipes = _repository.List().Where(x => x.BeingTrained == true);
            if (search != null)
            {
                recipes = recipes.Where(x => x.FIO.Contains(search));
            }

            return View(recipes);
        }

        [Authorize]
        public ActionResult Archive(string search, string Class, int? NumberClass)
        {
            System.Collections.Generic.IEnumerable<Student> recipes = _repository.List().Where(x => x.BeingTrained == false);
            if (search != null)
            {
                recipes = recipes.Where(x => x.FIO.Contains(search));
            }

            if (Class != null)
            {
                recipes = recipes.Where(x => x.Class.Contains(Class));
            }

            if (NumberClass != null)
            {
                recipes = recipes.Where(x => x.NumberClass.Equals(NumberClass));
            }

            return View(recipes);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = _repository.Get(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = _repository.Get(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = _repository.Get(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
