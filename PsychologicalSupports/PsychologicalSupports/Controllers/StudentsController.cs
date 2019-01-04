using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Controllers
{
    public class StudentsController : Controller
    {
        private PsychologicalSupportsEntities db = new PsychologicalSupportsEntities();

        [Authorize]
        public ActionResult Index(int? number, string classed)
        {
            var studentnumberclass = db.Students.GroupBy(t => t.NumberClass).Select(g => new { NumberClass = g.Key });
            ViewBag.NumberClass = new SelectList(studentnumberclass, "NumberClass", "NumberClass");
            var studentclass = db.Students.GroupBy(t => t.Class).Select(g => new { Class = g.Key });
            ViewBag.Class = new SelectList(studentclass, "Class", "Class");

            var students = db.Students.Include(s => s.AveragePoint).
                Include(s => s.ClassroomRelationship)
                .Include(s => s.ClassTeacheInformation)
                .Include(s => s.EmotioTest).Include(s => s.FamilyAlarmAnalysi)
                .Include(s => s.Intellectual_6_Class)
                .Include(s => s.Intellectual_7_Class)
                .Include(s => s.Intellectual_8_Class)
                .Include(s => s.Intellectual_9_Class)
                .Include(s => s.Interests_Card_145)
                .Include(s => s.Interests_Card_50)
                .Include(s => s.InterestsInSchoolSubject)
                .Include(s => s.Mindset).Include(s => s.PersonaAnxietyScale)
                .Include(s => s.PersonalProtagonistAizenko)
                .Include(s => s.SchoolMotivation)
                .Include(s => s.Self_esteem);
            //if (number != null && classed != null)
            //{
            //    return View(students.Where(s => s.NumberClass == number && s.Class == classed));
            //}
            //else if (number != null && classed == null)
            //{
            //    return View(students.Where(s => s.NumberClass == number));
            //}
            //else if (number == null && classed != null)
            //{
            //    return View(students.Where(s => s.Class == classed));
            //}
            //else
               
                return View(students);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var student = db.Students.Find(id);
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
        public ActionResult Create([Bind(Include = "StudentID,FIO,NumberClass,Class,AdmissionDate,BeingTrained")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
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
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        
        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,FIO,NumberClass,Class,AdmissionDate,BeingTrained")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
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
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
