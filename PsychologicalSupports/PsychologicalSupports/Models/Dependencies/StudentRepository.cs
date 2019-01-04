using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;

namespace PsychologicalSupports.Models.Dependencies
{
    public class StudentRepository:IDisposable
    {
        private PsychologicalSupportsEntities db=new PsychologicalSupportsEntities();

        public IEnumerable<Student> List()
        {
            return db.Students;
        }

        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        public void Create([Bind(Include = "StudentID,FIO,NumberClass,Class,AdmissionDate,BeingTrained")] Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public void Edit([Bind(Include = "StudentID,FIO,NumberClass,Class,AdmissionDate,BeingTrained")] Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}