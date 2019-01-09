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
        private readonly IPsychologicalSupportsContext __context;
        public Intellectual_7_ClassRepository(IPsychologicalSupportsContext context)
        {
            __context = context;
        }
        public IEnumerable<Intellectual_7_Class> List()
        {
            return __context.Intellectual_7_Class;
        }
        public Intellectual_7_Class Get(int? id)
        {
            return __context.Intellectual_7_Class.Find(id);
        }
        public void Create(Intellectual_7_Class Intellectual_7_Class)
        {
            __context.Intellectual_7_Class.Add(Intellectual_7_Class);
            __context.SaveChanges();
        }
        public void Edit(Intellectual_7_Class Intellectual_7_Class)
        {
            __context.Intellectual_7_Class.AddOrUpdate(Intellectual_7_Class);
            __context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = __context.Intellectual_7_Class.Find(id);
            __context.Intellectual_7_Class.Remove(student);
            __context.SaveChanges();
        }
    }
}