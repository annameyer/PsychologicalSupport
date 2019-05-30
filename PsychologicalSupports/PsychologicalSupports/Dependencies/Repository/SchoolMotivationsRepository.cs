using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class SchoolMotivationsRepository : IRepository<SchoolMotivation>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;

        public SchoolMotivationsRepository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }

        public IEnumerable<SchoolMotivation> List()
        {
            return _psychologicalSupportsContext.SchoolMotivations.Include(x => x.Student).ToList();
        }

        public SchoolMotivation Get(long? id)
        {
            return _psychologicalSupportsContext.SchoolMotivations.Find(id);
        }

        public void Create(SchoolMotivation SchoolMotivation)
        {
            _psychologicalSupportsContext.SchoolMotivations.Add(SchoolMotivation);
            _psychologicalSupportsContext.SaveChanges();
        }

        public void Edit(SchoolMotivation SchoolMotivation)
        {
            _psychologicalSupportsContext.SchoolMotivations.AddOrUpdate(SchoolMotivation);
            _psychologicalSupportsContext.SaveChanges();
        }

        public void Delete(long id)
        {
            SchoolMotivation student = _psychologicalSupportsContext.SchoolMotivations.Find(id);
            _psychologicalSupportsContext.SchoolMotivations.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}