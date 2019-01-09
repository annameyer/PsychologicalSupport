using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class InterestsInSchoolSubjectsRepository:IRepository<InterestsInSchoolSubject>
    {
        private readonly IPsychologicalSupportsContext __context;

        public InterestsInSchoolSubjectsRepository(IPsychologicalSupportsContext context)
        {
            __context = context;
        }

        public IEnumerable<InterestsInSchoolSubject> List()
        {
            return __context.InterestsInSchoolSubjects;
        }

        public InterestsInSchoolSubject Get(int? id)
        {
            return __context.InterestsInSchoolSubjects.Find(id);
        }

        public void Create(InterestsInSchoolSubject InterestsInSchoolSubject)
        {
            __context.InterestsInSchoolSubjects.Add(InterestsInSchoolSubject);
            __context.SaveChanges();
        }

        public void Edit(InterestsInSchoolSubject InterestsInSchoolSubject)
        {
            __context.InterestsInSchoolSubjects.AddOrUpdate(InterestsInSchoolSubject);
            __context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = __context.InterestsInSchoolSubjects.Find(id);
            __context.InterestsInSchoolSubjects.Remove(student);
            __context.SaveChanges();
        }
    }
}