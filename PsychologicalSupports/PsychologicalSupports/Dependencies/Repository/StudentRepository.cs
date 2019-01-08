using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace PsychologicalSupports.Models.Dependencies
{
    public class StudentRepository:IRepository<Student>
    {
        private readonly IPsychologicalSupportsContext __context;
        private PsychologicalSupportsEntities db=new PsychologicalSupportsEntities();

        public StudentRepository(IPsychologicalSupportsContext context)
        {
            __context = context;
        }
        public IEnumerable<Student> List()
        {
            return __context.Students;
        }
        public Student Get(int? id)
        {
            return __context.Students.Find(id);
        }
        public void Create(Student student)
        {
            __context.Students.Add(student);
            __context.SaveChanges();
        }

        public async Task Edit(Student student)
        {
            __context.Students.AddOrUpdate(student);
            await __context.SaveChangesAsync();
        }
        public void Delete(int id)
        {
            var student = __context.Students.Find(id);
            __context.Students.Remove(student);
            __context.SaveChanges();
        }        
    }
}