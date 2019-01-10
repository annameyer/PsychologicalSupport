using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class InterestsInSchoolSubjectsRepository:IRepository<InterestsInSchoolSubject>
    {
        private readonly IPsychologicalSupportsContext _context;

        public InterestsInSchoolSubjectsRepository(IPsychologicalSupportsContext context)
        {
            _context = context;
        }

        public IEnumerable<InterestsInSchoolSubject> List()
        {
            return _context.InterestsInSchoolSubjects;
        }

        public InterestsInSchoolSubject Get(int? id)
        {
            return _context.InterestsInSchoolSubjects.Find(id);
        }

        public void Create(InterestsInSchoolSubject InterestsInSchoolSubject)
        {
            _context.InterestsInSchoolSubjects.Add(InterestsInSchoolSubject);
            _context.SaveChanges();
        }

        public void Edit(InterestsInSchoolSubject InterestsInSchoolSubject)
        {
            _context.InterestsInSchoolSubjects.AddOrUpdate(InterestsInSchoolSubject);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.InterestsInSchoolSubjects.Find(id);
            _context.InterestsInSchoolSubjects.Remove(student);
            _context.SaveChanges();
        }
    }
}