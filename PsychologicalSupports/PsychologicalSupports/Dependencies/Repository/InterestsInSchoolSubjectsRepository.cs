using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class InterestsInSchoolSubjectsRepository : IRepository<InterestsInSchoolSubject>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;

        public InterestsInSchoolSubjectsRepository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }

        public IEnumerable<InterestsInSchoolSubject> List()
        {
            return _psychologicalSupportsContext.InterestsInSchoolSubjects.Include(x => x.Student).ToList();
        }

        public InterestsInSchoolSubject Get(long? id)
        {
            return _psychologicalSupportsContext.InterestsInSchoolSubjects.Find(id);
        }

        public void Create(InterestsInSchoolSubject InterestsInSchoolSubject)
        {
            _psychologicalSupportsContext.InterestsInSchoolSubjects.Add(InterestsInSchoolSubject);
            _psychologicalSupportsContext.SaveChanges();
        }

        public void Edit(InterestsInSchoolSubject InterestsInSchoolSubject)
        {
            _psychologicalSupportsContext.InterestsInSchoolSubjects.AddOrUpdate(InterestsInSchoolSubject);
            _psychologicalSupportsContext.SaveChanges();
        }

        public void Delete(long id)
        {
            InterestsInSchoolSubject student = _psychologicalSupportsContext.InterestsInSchoolSubjects.Find(id);
            _psychologicalSupportsContext.InterestsInSchoolSubjects.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}