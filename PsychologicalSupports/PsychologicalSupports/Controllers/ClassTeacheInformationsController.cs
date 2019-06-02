using PsychologicalSupports.Enum;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Net;
using System.Web.Mvc;

namespace PsychologicalSupports.Controllers
{
    public class ClassTeacheInformationsController : Controller
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        private IRepository<ClassTeacheInformation> _repository;

        public ClassTeacheInformationsController(IRepository<ClassTeacheInformation> repository, IPsychologicalSupportsContext context)
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

            ClassTeacheInformation classTeacheInformation = _repository.Get(id);
            if (classTeacheInformation == null)
            {
                return HttpNotFound();
            }

            return View(classTeacheInformation);
        }


        public ActionResult Create(int Id)
        {
            GetCurrentStudent studentName = new GetCurrentStudent();
            ViewBag.StudentName = studentName.GetStudentId(Id);
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClassTeacheInformation classTeacheInformation, int Id)
        {
            classTeacheInformation.StudentID = Id;
            if (ModelState.IsValid)
            {
                _repository.Create(classTeacheInformation);
                return RedirectToAction("Index");
            }

            return View(classTeacheInformation);
        }

        public ActionResult Edit(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GetCurrentStudent studentName = new GetCurrentStudent();
            ViewBag.StudentName = studentName.GetStudentId(id.Value);
            ClassTeacheInformation classTeacheInformation = _repository.Get(id);
            if (classTeacheInformation == null)
            {
                return HttpNotFound();
            }

            return View(classTeacheInformation);
        }

        [HttpPost]
        public ActionResult Edit(ClassTeacheInformation classTeacheInformation)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(classTeacheInformation);
                return RedirectToAction("Index");
            }

            return View(classTeacheInformation);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClassTeacheInformation classTeacheInformation = _repository.Get(id); ;
            if (classTeacheInformation == null)
            {
                return HttpNotFound();
            }

            return View(classTeacheInformation);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
