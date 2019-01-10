using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class MindsetsRepository : IRepository<Mindset>
    {
        private readonly IPsychologicalSupportsContext _context;

        public MindsetsRepository(IPsychologicalSupportsContext context)
        {
            _context = context;
        }

        public IEnumerable<Mindset> List()
        {
            return _context.Mindsets;
        }

        public Mindset Get(int? id)
        {
            return _context.Mindsets.Find(id);
        }

        public void Create(Mindset Mindset)
        {
            _context.Mindsets.Add(Mindset);
            _context.SaveChanges();
        }

        public void Edit(Mindset Mindset)
        {
            _context.Mindsets.AddOrUpdate(Mindset);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.Mindsets.Find(id);
            _context.Mindsets.Remove(student);
            _context.SaveChanges();
        }
    }
}