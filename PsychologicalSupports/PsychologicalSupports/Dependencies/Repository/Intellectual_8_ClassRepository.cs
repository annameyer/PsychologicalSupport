using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class Intellectual_8_ClassRepository : IRepository<Intellectual_8_Class>
    {
        private readonly IPsychologicalSupportsContext __context;
        public Intellectual_8_ClassRepository(IPsychologicalSupportsContext context)
        {
            __context = context;
        }
        public IEnumerable<Intellectual_8_Class> List()
        {
            return __context.Intellectual_8_Class;
        }
        public Intellectual_8_Class Get(int? id)
        {
            return __context.Intellectual_8_Class.Find(id);
        }
        public void Create(Intellectual_8_Class Intellectual_8_Class)
        {
            __context.Intellectual_8_Class.Add(Intellectual_8_Class);
            __context.SaveChanges();
        }
        public void Edit(Intellectual_8_Class Intellectual_8_Class)
        {
            __context.Intellectual_8_Class.AddOrUpdate(Intellectual_8_Class);
            __context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = __context.Intellectual_8_Class.Find(id);
            __context.Intellectual_8_Class.Remove(student);
            __context.SaveChanges();
        }
    }
}