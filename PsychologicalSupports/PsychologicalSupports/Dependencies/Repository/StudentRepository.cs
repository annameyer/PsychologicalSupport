using System.Collections.Generic;

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
            return _psychologicalSupportsContext.Students;
        }
        public Student Get(int? id)
        {
            return _psychologicalSupportsContext.Students.Find(id);
        }
        public void Create(Student student)
        {
            _psychologicalSupportsContext.Students.Add(student);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Edit(Student student)
        {
            _psychologicalSupportsContext.Entry(student).State = student.Modified;
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Student student = _psychologicalSupportsContext.Students.Find(id);
            _psychologicalSupportsContext.Students.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}