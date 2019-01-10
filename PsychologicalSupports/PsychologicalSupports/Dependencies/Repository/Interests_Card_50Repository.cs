using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Controllers
{
    public class Interests_Card_50Repository : IRepository<Interests_Card_50>
    {
        private readonly IPsychologicalSupportsContext _context;

        public Interests_Card_50Repository(IPsychologicalSupportsContext context)
        {
            _context = context;
        }

        public IEnumerable<Interests_Card_50> List()
        {
            return _context.Interests_Card_50;
        }

        public Interests_Card_50 Get(int? id)
        {
            return _context.Interests_Card_50.Find(id);
        }

        public void Create(Interests_Card_50 Interests_Card_50)
        {
            _context.Interests_Card_50.Add(Interests_Card_50);
            _context.SaveChanges();
        }

        public void Edit(Interests_Card_50 Interests_Card_50)
        {
            _context.Interests_Card_50.AddOrUpdate(Interests_Card_50);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.Interests_Card_50.Find(id);
            _context.Interests_Card_50.Remove(student);
            _context.SaveChanges();
        }
    }
}