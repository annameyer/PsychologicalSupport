using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class SchoolMotivationsRepository : IRepository<SchoolMotivation>
    {
        private readonly IPsychologicalSupportsContext _context;

        public SchoolMotivationsRepository(IPsychologicalSupportsContext context)
        {
            _context = context;
        }

        public IEnumerable<SchoolMotivation> List()
        {
            return _context.SchoolMotivations;
        }

        public SchoolMotivation Get(int? id)
        {
            return _context.SchoolMotivations.Find(id);
        }

        public void Create(SchoolMotivation SchoolMotivation)
        {
            _context.SchoolMotivations.Add(SchoolMotivation);
            _context.SaveChanges();
        }

        public void Edit(SchoolMotivation SchoolMotivation)
        {
            _context.SchoolMotivations.AddOrUpdate(SchoolMotivation);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.SchoolMotivations.Find(id);
            _context.SchoolMotivations.Remove(student);
            _context.SaveChanges();
        }
    }
}