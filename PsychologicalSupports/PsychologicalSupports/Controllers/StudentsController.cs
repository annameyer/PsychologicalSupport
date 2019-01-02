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

        // GET: Students
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
            if (number != null && classed != null)
            {
                return View(students.Where(s => s.NumberClass == number && s.Class == classed));
            }
            else if (number != null && classed == null)
            {
                return View(students.Where(s => s.NumberClass == number));
            }
            else if (number == null && classed != null)
            {
                return View(students.Where(s => s.Class == classed));
            }
            else
               
                return View(students);
        }

        // GET: Students/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.AveragePoints, "AveragePointID", "AveragePointID");
            ViewBag.StudentID = new SelectList(db.ClassroomRelationships, "ClassroomRelationshipsID", "IGS_Sishora");
            ViewBag.StudentID = new SelectList(db.ClassTeacheInformations, "ClassTeacheInformationID", "Self_harmingBehavior");
            ViewBag.StudentID = new SelectList(db.EmotioTests, "EmotioTestID", "PhysicalAggression");
            ViewBag.StudentID = new SelectList(db.FamilyAlarmAnalysis, "FamilyAlarmAnalysisID", "Fault");
            ViewBag.StudentID = new SelectList(db.Intellectual_6_Class, "Intellectual_6_ClassID", "TestLevel");
            ViewBag.StudentID = new SelectList(db.Intellectual_7_Class, "Intellectual_7_ClassID", "Level");
            ViewBag.StudentID = new SelectList(db.Intellectual_8_Class, "Intellectual_8_ClassID", "InterestMap");
            ViewBag.StudentID = new SelectList(db.Intellectual_9_Class, "Intellectual_9_ClassID", "Profile");
            ViewBag.StudentID = new SelectList(db.Interests_Card_145, "Interests_Card_145ID", "Biology");
            ViewBag.StudentID = new SelectList(db.Interests_Card_50, "Interests_Card_50ID", "PhysicsMathematics");
            ViewBag.StudentID = new SelectList(db.InterestsInSchoolSubjects, "InterestsInSchoolSubjectsID", "Russian");
            ViewBag.StudentID = new SelectList(db.Mindsets, "MindsetID", "Subject_Effective");
            ViewBag.StudentID = new SelectList(db.PersonaAnxietyScales, "PersonaAnxietyScaleID", "School");
            ViewBag.StudentID = new SelectList(db.PersonalProtagonistAizenkoes, "PersonaAnxietyScaleID", "Temperament");
            ViewBag.StudentID = new SelectList(db.SchoolMotivations, "SchoolMotivationID", "StudyInClass");
            ViewBag.StudentID = new SelectList(db.Self_esteem, "Self_esteemID", "Indicator");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FIO,NumberClass,Class,AdmissionDate,BeingTrained")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.AveragePoints, "AveragePointID", "AveragePointID", student.StudentID);
            ViewBag.StudentID = new SelectList(db.ClassroomRelationships, "ClassroomRelationshipsID", "IGS_Sishora", student.StudentID);
            ViewBag.StudentID = new SelectList(db.ClassTeacheInformations, "ClassTeacheInformationID", "Self_harmingBehavior", student.StudentID);
            ViewBag.StudentID = new SelectList(db.EmotioTests, "EmotioTestID", "PhysicalAggression", student.StudentID);
            ViewBag.StudentID = new SelectList(db.FamilyAlarmAnalysis, "FamilyAlarmAnalysisID", "Fault", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Intellectual_6_Class, "Intellectual_6_ClassID", "TestLevel", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Intellectual_7_Class, "Intellectual_7_ClassID", "Level", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Intellectual_8_Class, "Intellectual_8_ClassID", "InterestMap", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Intellectual_9_Class, "Intellectual_9_ClassID", "Profile", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Interests_Card_145, "Interests_Card_145ID", "Biology", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Interests_Card_50, "Interests_Card_50ID", "PhysicsMathematics", student.StudentID);
            ViewBag.StudentID = new SelectList(db.InterestsInSchoolSubjects, "InterestsInSchoolSubjectsID", "Russian", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Mindsets, "MindsetID", "Subject_Effective", student.StudentID);
            ViewBag.StudentID = new SelectList(db.PersonaAnxietyScales, "PersonaAnxietyScaleID", "School", student.StudentID);
            ViewBag.StudentID = new SelectList(db.PersonalProtagonistAizenkoes, "PersonaAnxietyScaleID", "Temperament", student.StudentID);
            ViewBag.StudentID = new SelectList(db.SchoolMotivations, "SchoolMotivationID", "StudyInClass", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Self_esteem, "Self_esteemID", "Indicator", student.StudentID);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.AveragePoints, "AveragePointID", "AveragePointID", student.StudentID);
            ViewBag.StudentID = new SelectList(db.ClassroomRelationships, "ClassroomRelationshipsID", "IGS_Sishora", student.StudentID);
            ViewBag.StudentID = new SelectList(db.ClassTeacheInformations, "ClassTeacheInformationID", "Self_harmingBehavior", student.StudentID);
            ViewBag.StudentID = new SelectList(db.EmotioTests, "EmotioTestID", "PhysicalAggression", student.StudentID);
            ViewBag.StudentID = new SelectList(db.FamilyAlarmAnalysis, "FamilyAlarmAnalysisID", "Fault", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Intellectual_6_Class, "Intellectual_6_ClassID", "TestLevel", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Intellectual_7_Class, "Intellectual_7_ClassID", "Level", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Intellectual_8_Class, "Intellectual_8_ClassID", "InterestMap", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Intellectual_9_Class, "Intellectual_9_ClassID", "Profile", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Interests_Card_145, "Interests_Card_145ID", "Biology", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Interests_Card_50, "Interests_Card_50ID", "PhysicsMathematics", student.StudentID);
            ViewBag.StudentID = new SelectList(db.InterestsInSchoolSubjects, "InterestsInSchoolSubjectsID", "Russian", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Mindsets, "MindsetID", "Subject_Effective", student.StudentID);
            ViewBag.StudentID = new SelectList(db.PersonaAnxietyScales, "PersonaAnxietyScaleID", "School", student.StudentID);
            ViewBag.StudentID = new SelectList(db.PersonalProtagonistAizenkoes, "PersonaAnxietyScaleID", "Temperament", student.StudentID);
            ViewBag.StudentID = new SelectList(db.SchoolMotivations, "SchoolMotivationID", "StudyInClass", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Self_esteem, "Self_esteemID", "Indicator", student.StudentID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FIO,NumberClass,Class,AdmissionDate,BeingTrained")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.AveragePoints, "AveragePointID", "AveragePointID", student.StudentID);
            ViewBag.StudentID = new SelectList(db.ClassroomRelationships, "ClassroomRelationshipsID", "IGS_Sishora", student.StudentID);
            ViewBag.StudentID = new SelectList(db.ClassTeacheInformations, "ClassTeacheInformationID", "Self_harmingBehavior", student.StudentID);
            ViewBag.StudentID = new SelectList(db.EmotioTests, "EmotioTestID", "PhysicalAggression", student.StudentID);
            ViewBag.StudentID = new SelectList(db.FamilyAlarmAnalysis, "FamilyAlarmAnalysisID", "Fault", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Intellectual_6_Class, "Intellectual_6_ClassID", "TestLevel", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Intellectual_7_Class, "Intellectual_7_ClassID", "Level", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Intellectual_8_Class, "Intellectual_8_ClassID", "InterestMap", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Intellectual_9_Class, "Intellectual_9_ClassID", "Profile", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Interests_Card_145, "Interests_Card_145ID", "Biology", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Interests_Card_50, "Interests_Card_50ID", "PhysicsMathematics", student.StudentID);
            ViewBag.StudentID = new SelectList(db.InterestsInSchoolSubjects, "InterestsInSchoolSubjectsID", "Russian", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Mindsets, "MindsetID", "Subject_Effective", student.StudentID);
            ViewBag.StudentID = new SelectList(db.PersonaAnxietyScales, "PersonaAnxietyScaleID", "School", student.StudentID);
            ViewBag.StudentID = new SelectList(db.PersonalProtagonistAizenkoes, "PersonaAnxietyScaleID", "Temperament", student.StudentID);
            ViewBag.StudentID = new SelectList(db.SchoolMotivations, "SchoolMotivationID", "StudyInClass", student.StudentID);
            ViewBag.StudentID = new SelectList(db.Self_esteem, "Self_esteemID", "Indicator", student.StudentID);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Student student = db.Students.Find(id);
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
