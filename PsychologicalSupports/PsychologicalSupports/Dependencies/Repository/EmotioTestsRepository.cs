using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class EmotioTestsRepository : IRepository<EmotioTest>
    {
        private readonly IPsychologicalSupportsContext _context;
        public EmotioTestsRepository(IPsychologicalSupportsContext context)
        {
            _context = context;
        }
        public IEnumerable<EmotioTest> List()
        {
            return _context.EmotioTests;
        }
        public EmotioTest Get(int? id)
        {
            return _context.EmotioTests.Find(id);
        }
        public void Create(EmotioTest emotioTest)
        {
            _context.EmotioTests.Add(emotioTest);
            _context.SaveChanges();
        }
        public void Edit(EmotioTest emotioTest)
        {
            _context.EmotioTests.AddOrUpdate(emotioTest);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = _context.EmotioTests.Find(id);
            _context.EmotioTests.Remove(student);
            _context.SaveChanges();
        }
    }
}