using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace PsychologicalSupports.Models.Dependencies
{

    public class StudentRepository : IRepository<Student>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        public StudentRepository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }

        public IEnumerable<Student> List()
        {
            return _psychologicalSupportsContext.Students
                .Include(x => x.ClassroomRelationship)
                .Include(x => x.ClassTeacheInformation)
                .Include(x => x.EmotioTest)
                .Include(x => x.FamilyAlarmAnalysi)
                .Include(x => x.Intellectual_6_Class)
                .Include(x => x.Intellectual_7_Class)
                .Include(x => x.Intellectual_8_Class)
                .Include(x => x.Intellectual_9_Class)
                .Include(x => x.Interests_Card_145)
                .Include(x => x.Interests_Card_50)
                .Include(x => x.InterestsInSchoolSubject)
                .Include(x => x.PersonaAnxietyScale)
                .Include(x => x.PersonalProtagonistAizenko)
                .Include(x => x.SchoolMotivation)
                .Include(x => x.Self_esteem)
                .ToList();
        }

        public Student Get(long? id)
        {
            return _psychologicalSupportsContext.Students.Find(id);
        }

        public void Create(Student student)
        {
            _psychologicalSupportsContext.Students.AddOrUpdate(student);
            _psychologicalSupportsContext.SaveChanges();
        }

        public void Edit(Student student)
        {
            Student newStudent = Get(student.StudentID);

            if (newStudent != null)
            {
                newStudent.NumberClass = student.NumberClass;
                newStudent.FIO = student.FIO;
                newStudent.Class = student.Class;
                newStudent.AdmissionDate = student.AdmissionDate;
                newStudent.BeingTrained = student.BeingTrained;

                _psychologicalSupportsContext.Students.Attach(newStudent);
                _psychologicalSupportsContext.Entry(newStudent).State = System.Data.Entity.EntityState.Modified;
                _psychologicalSupportsContext.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            Student student = _psychologicalSupportsContext.Students.Find(id);
            _psychologicalSupportsContext.Students.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}