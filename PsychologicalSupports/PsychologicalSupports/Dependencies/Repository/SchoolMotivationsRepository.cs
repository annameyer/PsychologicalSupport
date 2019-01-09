using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class SchoolMotivationsRepository : IRepository<SchoolMotivation>
    {
        private readonly IPsychologicalSupportsContext __context;

        public SchoolMotivationsRepository(IPsychologicalSupportsContext context)
        {
            __context = context;
        }

        public IEnumerable<SchoolMotivation> List()
        {
            return __context.SchoolMotivations;
        }

        public SchoolMotivation Get(int? id)
        {
            return __context.SchoolMotivations.Find(id);
        }

        public void Create(SchoolMotivation SchoolMotivation)
        {
            __context.SchoolMotivations.Add(SchoolMotivation);
            __context.SaveChanges();
        }

        public void Edit(SchoolMotivation SchoolMotivation)
        {
            __context.SchoolMotivations.AddOrUpdate(SchoolMotivation);
            __context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = __context.SchoolMotivations.Find(id);
            __context.SchoolMotivations.Remove(student);
            __context.SaveChanges();
        }
    }
}