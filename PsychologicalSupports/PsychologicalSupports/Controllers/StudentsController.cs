using OfficeOpenXml;
using PagedList;
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
                                FIO = workSheet.Cells[rowIterator, 1].Value.ToString(),
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
            ExcelPackage package = ExcelFile.GenerateExcelFile(students);

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
