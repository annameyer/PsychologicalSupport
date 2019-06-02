using PsychologicalSupports.Enum;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Net;
using System.Web.Mvc;

namespace PsychologicalSupports.Controllers
{
    public class EmotioTestsController : Controller
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        private IRepository<EmotioTest> _repository;

        public EmotioTestsController(IRepository<EmotioTest> repository, IPsychologicalSupportsContext context)
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

            EmotioTest emotioTest = _repository.Get(id);
            if (emotioTest == null)
            {
                return HttpNotFound();
            }

            return View(emotioTest);
        }

        public ActionResult Create(int Id)
        {
            GetCurrentStudent studentName = new GetCurrentStudent();
            ViewBag.StudentName = studentName.GetStudentId(Id);
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmotioTest emotioTest, int Id)
        {
            emotioTest.StudentID = Id;
            if (ModelState.IsValid)
            {
                _repository.Create(emotioTest);
                return RedirectToAction("Index");
            }

            return View(emotioTest);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmotioTest emotioTest = _repository.Get(id);
            if (emotioTest == null)
            {
                return HttpNotFound();
            }

            return View(emotioTest);
        }

        [HttpPost]
        public ActionResult Edit(EmotioTest emotioTest)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(emotioTest);
                return RedirectToAction("Index");
            }

            return View(emotioTest);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmotioTest emotioTest = _repository.Get(id);
            if (emotioTest == null)
            {
                return HttpNotFound();
            }

            return View(emotioTest);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
