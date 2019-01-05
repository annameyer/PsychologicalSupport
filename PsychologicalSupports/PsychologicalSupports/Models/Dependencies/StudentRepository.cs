using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PsychologicalSupports.Models.Dependencies
{
    public class StudentRepository:IRepository<Student>
    {
        private readonly IContext db;

        public IEnumerable<Student> List()
        {
            return db.Students;
        }
        public Student Get(int? id)
        {
            return db.Students.Find(id);
        }
        public void Create(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public void Edit(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
        }        
    }
}