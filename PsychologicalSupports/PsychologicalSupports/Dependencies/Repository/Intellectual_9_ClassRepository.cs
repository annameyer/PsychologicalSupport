using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class Intellectual_9_ClassRepository : IRepository<Intellectual_9_Class>
    {
        private readonly IPsychologicalSupportsContext _context;
        public Intellectual_9_ClassRepository(IPsychologicalSupportsContext context)
        {
            _context = context;
        }
        public IEnumerable<Intellectual_9_Class> List()
        {
            return _context.Intellectual_9_Class;
        }
        public Intellectual_9_Class Get(int? id)
        {
            return _context.Intellectual_9_Class.Find(id);
        }
        public void Create(Intellectual_9_Class Intellectual_9_Class)
        {
            _context.Intellectual_9_Class.Add(Intellectual_9_Class);
            _context.SaveChanges();
        }
        public void Edit(Intellectual_9_Class Intellectual_9_Class)
        {
            _context.Intellectual_9_Class.AddOrUpdate(Intellectual_9_Class);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = _context.Intellectual_9_Class.Find(id);
            _context.Intellectual_9_Class.Remove(student);
            _context.SaveChanges();
        }
    }
}