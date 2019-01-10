using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class Self_esteemRepository : IRepository<Self_esteem>
    {
        private readonly IPsychologicalSupportsContext _context;

        public Self_esteemRepository(IPsychologicalSupportsContext context)
        {
            _context = context;
        }

        public IEnumerable<Self_esteem> List()
        {
            return _context.Self_esteem;
        }

        public Self_esteem Get(int? id)
        {
            return _context.Self_esteem.Find(id);
        }

        public void Create(Self_esteem Self_esteem)
        {
            _context.Self_esteem.Add(Self_esteem);
            _context.SaveChanges();
        }

        public void Edit(Self_esteem Self_esteem)
        {
            _context.Self_esteem.AddOrUpdate(Self_esteem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.Self_esteem.Find(id);
            _context.Self_esteem.Remove(student);
            _context.SaveChanges();
        }
    }
}