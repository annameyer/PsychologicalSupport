using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class Interests_Card_145Repository : IRepository<Interests_Card_145>
    {
        private readonly IPsychologicalSupportsContext _context;
        public Interests_Card_145Repository(IPsychologicalSupportsContext context)
        {
            _context = context;
        }
        public IEnumerable<Interests_Card_145> List()
        {
            return _context.Interests_Card_145;
        }
        public Interests_Card_145 Get(int? id)
        {
            return _context.Interests_Card_145.Find(id);
        }
        public void Create(Interests_Card_145 Interests_Card_145)
        {
            _context.Interests_Card_145.Add(Interests_Card_145);
            _context.SaveChanges();
        }
        public void Edit(Interests_Card_145 Interests_Card_145)
        {
            _context.Interests_Card_145.AddOrUpdate(Interests_Card_145);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = _context.Interests_Card_145.Find(id);
            _context.Interests_Card_145.Remove(student);
            _context.SaveChanges();
        }
    }
}