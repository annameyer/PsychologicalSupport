using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace PsychologicalSupports.Models.Dependencies
{
   
    public class StudentRepository:IRepository<Student>
    {
        private readonly IPsychologicalSupportsContext _context;
        public StudentRepository(IPsychologicalSupportsContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> List()
        {
            return _context.Students;
        }
        public Student Get(int? id)
        {
            return _context.Students.Find(id);
        }
        public void Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public void Edit(Student student)
        {
            //_context.Entry(student).State = student.Modified;
            _context.Students.Attach(student);
             _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }        
    }
}