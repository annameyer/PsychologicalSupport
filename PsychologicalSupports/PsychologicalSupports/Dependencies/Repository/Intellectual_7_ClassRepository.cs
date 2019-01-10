using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class Intellectual_7_ClassRepository : IRepository<Intellectual_7_Class>
    {
        private readonly IPsychologicalSupportsContext _context;
        public Intellectual_7_ClassRepository(IPsychologicalSupportsContext context)
        {
            _context = context;
        }
        public IEnumerable<Intellectual_7_Class> List()
        {
            return _context.Intellectual_7_Class;
        }
        public Intellectual_7_Class Get(int? id)
        {
            return _context.Intellectual_7_Class.Find(id);
        }
        public void Create(Intellectual_7_Class Intellectual_7_Class)
        {
            _context.Intellectual_7_Class.Add(Intellectual_7_Class);
            _context.SaveChanges();
        }
        public void Edit(Intellectual_7_Class Intellectual_7_Class)
        {
            _context.Intellectual_7_Class.AddOrUpdate(Intellectual_7_Class);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = _context.Intellectual_7_Class.Find(id);
            _context.Intellectual_7_Class.Remove(student);
            _context.SaveChanges();
        }
    }
}