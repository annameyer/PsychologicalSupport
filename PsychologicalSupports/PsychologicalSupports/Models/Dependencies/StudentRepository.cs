using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PsychologicalSupports.Models.Dependencies
{
    public class StudentRepository:IRepository<Student>
    {
        private readonly IContext __context;
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

        public void Edit(Student student)
        {
            __context.Students.Add(student);
            __context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = __context.Students.Find(id);
            __context.Students.Remove(student);
            __context.SaveChanges();
        }        
    }
}