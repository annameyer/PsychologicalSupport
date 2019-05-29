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
        public ActionResult Index(string search, string Class, int? NumberClass)
        {
            System.Collections.Generic.IEnumerable<Student> students = _repository.List().Where(x => x.BeingTrained == true);
            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(x => x.FIO.Contains(search));
            }

            //if (!string.IsNullOrEmpty(Class))
            //{
            //    students = students.Where(x => x.Class == Class);
            //}

            if (NumberClass != null)
            {
                students = students.Where(x => x.NumberClass == NumberClass);
            }

            return View(students);
        }

        [Authorize]
        public ActionResult Archive(string search, string Class, int? NumberClass)
        {
            System.Collections.Generic.IEnumerable<Student> students = _repository.List().Where(x => x.BeingTrained == false);
            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(x => x.FIO.Contains(search));
            }

            if (!string.IsNullOrEmpty(Class))
            {
                students = students.Where(x => x.Class.Contains(Class));
            }

            if (NumberClass != null)
            {
                students = students.Where(x => x.NumberClass.Equals(NumberClass));
            }

            return View(students);
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

            StudentDetails newStudent = new StudentDetails
            {
                StudentID = student.StudentID,
                FIO = student.FIO,
                NumberClass = student.NumberClass,
                Class = student.Class,
                AdmissionDate = student.AdmissionDate,
                BeingTrained = student.BeingTrained.HasValue ? "Обучается" : "Не обучается",
                AveragePoint = student.AveragePoint != null ? "1" : string.Empty,
                ClassroomRelationship = student.ClassroomRelationship != null ? "1" : string.Empty,
                ClassTeacheInformation = student.ClassTeacheInformation != null ? "1" : string.Empty,
                EmotioTest = student.EmotioTest != null ? "1" : string.Empty,
                FamilyAlarmAnalysi = student.FamilyAlarmAnalysi != null ? "1" : string.Empty,
                Intellectual_6_Class = student.Intellectual_6_Class != null ? "1" : string.Empty,
                Intellectual_7_Class = student.Intellectual_7_Class != null ? "1" : string.Empty,
                Intellectual_8_Class = student.Intellectual_8_Class != null ? "1" : string.Empty,
                Intellectual_9_Class = student.Intellectual_9_Class != null ? "1" : string.Empty,
                Interests_Card_145 = student.Interests_Card_145 != null ? "1" : string.Empty,
                Interests_Card_50 = student.Interests_Card_50 != null ? "1" : string.Empty,
                InterestsInSchoolSubject = student.InterestsInSchoolSubject != null ? "1" : string.Empty,
                PersonaAnxietyScale = student.PersonaAnxietyScale != null ? "1" : string.Empty,
                PersonalProtagonistAizenko = student.PersonalProtagonistAizenko != null ? "1" : string.Empty,
                SchoolMotivation = student.SchoolMotivation != null ? "1" : string.Empty,
                Self_esteem = student.Self_esteem != null ? "1" : string.Empty
            };

            return View(newStudent);
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
