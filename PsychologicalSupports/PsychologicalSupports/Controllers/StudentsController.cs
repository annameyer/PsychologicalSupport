using OfficeOpenXml;
using PagedList;
using PsychologicalSupports.Enum;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PsychologicalSupports.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly IRepository<Student> _repository;

        public StudentsController(IRepository<Student> student)
        {
            _repository = student;
        }

        public ActionResult CreateFromExcel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFromExcel(FormCollection formCollection, Student allIfo)
        {
            List<Student> studentsList = new List<Student>();
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    int data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    using (ExcelPackage package = new ExcelPackage(file.InputStream))
                    {
                        ExcelWorksheets currentSheet = package.Workbook.Worksheets;
                        ExcelWorksheet workSheet = currentSheet.First();
                        int noOfCol = workSheet.Dimension.End.Column;
                        int noOfRow = workSheet.Dimension.End.Row;
                        DateTime admissionDate = DateTime.Now;
                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            Student student = new Student
                            {
                                FIO = workSheet.Cells[rowIterator, 1].Value.ToString().Trim(),
                                Class = allIfo.Class,
                                NumberClass = allIfo.NumberClass,
                                AdmissionDate = allIfo.AdmissionDate,
                                BeingTrained = allIfo.BeingTrained
                            };
                            studentsList.Add(student);
                        }
                    }
                }
            }
            foreach (Student item in studentsList)
            {
                _repository.Create(item);
            }

            return RedirectToAction("Index");
        }

        public FileContentResult Download(string search, string Class, int? NumberClass, string Filter)
        {
            IEnumerable<Student> students = _repository.List().Where(x => x.BeingTrained == true).OrderBy(x => x.NumberClass).ToList();
            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(x => x.FIO.Contains(search));
            }

            if (!string.IsNullOrEmpty(Class))
            {
                students = students.Where(x => x.Class == Class);
            }

            if (NumberClass != null)
            {
                students = students.Where(x => x.NumberClass == NumberClass);
            }

            if (Filter == "FIO")
            {
                students = students.OrderBy(x => x.FIO);
            }

            if (Filter == "Сlass")
            {
                students = students.OrderBy(x => x.Class);
            }

            string fileDownloadName = string.Format("Студенты.xlsx");
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            ExcelPackage package = ExcelFile.GenerateExcelFile(students, students.Select(x => x.StudentID.ToString()).ToList());

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
            IEnumerable<Student> students = _repository.List().Where(x => x.BeingTrained == true).OrderBy(x => x.NumberClass).ToList();
            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(x => x.FIO.Contains(search));
                ViewBag.Search = search;
            }

            if (!string.IsNullOrEmpty(Class))
            {
                students = students.Where(x => x.Class == Class);
                ViewBag.Class = Class;
            }

            if (NumberClass != null)
            {
                students = students.Where(x => x.NumberClass == NumberClass);
                ViewBag.NumberClass = NumberClass;
            }

            if (Filter == "FIO")
            {
                students = students.OrderBy(x => x.FIO);
            }

            if (Filter == "Сlass")
            {
                students = students.OrderBy(x => x.Class);
            }
            ViewBag.Filter = Filter;

            return View(students.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Archive(string search, string Class, int? NumberClass, int? page, string Filter)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<Student> students = _repository.List().Where(x => x.BeingTrained == false).OrderBy(x => x.NumberClass).ToList();
            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(x => x.FIO.Contains(search));
                ViewBag.Search = search;
            }

            if (!string.IsNullOrEmpty(Class))
            {
                students = students.Where(x => x.Class == Class);
                ViewBag.Class = Class;
            }

            if (NumberClass != null)
            {
                students = students.Where(x => x.NumberClass == NumberClass);
                ViewBag.NumberClass = NumberClass;
            }

            if (Filter == "FIO")
            {
                students = students.OrderBy(x => x.FIO);
            }

            if (Filter == "Сlass")
            {
                students = students.OrderBy(x => x.Class);
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
                AveragePoint = student.AveragePoint != null ? "\u2718" : "\u2718",
                ClassroomRelationship = student.ClassroomRelationship != null ? "\u2714" : "\u2718",
                ClassTeacheInformation = student.ClassTeacheInformation != null ? "\u2714" :"\u2718",
                EmotioTest = student.EmotioTest != null ? "\u2714" :"\u2718",
                FamilyAlarmAnalysi = student.FamilyAlarmAnalysi != null ? "\u2714" :"\u2718",
                Intellectual_6_Class = student.Intellectual_6_Class != null ? "\u2714" :"\u2718",
                Intellectual_7_Class = student.Intellectual_7_Class != null ? "\u2714" :"\u2718",
                Intellectual_8_Class = student.Intellectual_8_Class != null ? "\u2714" :"\u2718",
                Intellectual_9_Class = student.Intellectual_9_Class != null ? "\u2714" :"\u2718",
                Interests_Card_145 = student.Interests_Card_145 != null ? "\u2714" :"\u2718",
                Interests_Card_50 = student.Interests_Card_50 != null ? "\u2714" :"\u2718",
                InterestsInSchoolSubject = student.InterestsInSchoolSubject != null ? "\u2714" :"\u2718",
                PersonaAnxietyScale = student.PersonaAnxietyScale != null ? "\u2714" :"\u2718",
                PersonalProtagonistAizenko = student.PersonalProtagonistAizenko != null ? "\u2714" :"\u2718",
                SchoolMotivation = student.SchoolMotivation != null ? "\u2714" :"\u2718",
                Self_esteem = student.Self_esteem != null ? "\u2714" :"\u2718"
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
            GetCurrentStudent studentName = new GetCurrentStudent();
            ViewBag.StudentName = studentName.GetStudentId(id.Value);
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

            StudentDetails newStudent = new StudentDetails
            {
                StudentID = student.StudentID,
                FIO = student.FIO,
                NumberClass = student.NumberClass,
                Class = student.Class,
                AdmissionDate = student.AdmissionDate,
                BeingTrained = student.BeingTrained.HasValue ? "Обучается" : "Не обучается",
                AveragePoint = student.AveragePoint != null ? "\u2718" : "\u2718",
                ClassroomRelationship = student.ClassroomRelationship != null ? "\u2714" : "\u2718",
                ClassTeacheInformation = student.ClassTeacheInformation != null ? "\u2714" : "\u2718",
                EmotioTest = student.EmotioTest != null ? "\u2714" : "\u2718",
                FamilyAlarmAnalysi = student.FamilyAlarmAnalysi != null ? "\u2714" : "\u2718",
                Intellectual_6_Class = student.Intellectual_6_Class != null ? "\u2714" : "\u2718",
                Intellectual_7_Class = student.Intellectual_7_Class != null ? "\u2714" : "\u2718",
                Intellectual_8_Class = student.Intellectual_8_Class != null ? "\u2714" : "\u2718",
                Intellectual_9_Class = student.Intellectual_9_Class != null ? "\u2714" : "\u2718",
                Interests_Card_145 = student.Interests_Card_145 != null ? "\u2714" : "\u2718",
                Interests_Card_50 = student.Interests_Card_50 != null ? "\u2714" : "\u2718",
                InterestsInSchoolSubject = student.InterestsInSchoolSubject != null ? "\u2714" : "\u2718",
                PersonaAnxietyScale = student.PersonaAnxietyScale != null ? "\u2714" : "\u2718",
                PersonalProtagonistAizenko = student.PersonalProtagonistAizenko != null ? "\u2714" : "\u2718",
                SchoolMotivation = student.SchoolMotivation != null ? "\u2714" : "\u2718",
                Self_esteem = student.Self_esteem != null ? "\u2714" : "\u2718"
            };

            return View(newStudent);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
