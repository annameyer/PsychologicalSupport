using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class Intellectual_9_ClassRepository : IRepository<Intellectual_9_Class>
    {
        private readonly IPsychologicalSupportsContext __context;
        public Intellectual_9_ClassRepository(IPsychologicalSupportsContext context)
        {
            __context = context;
        }
        public IEnumerable<Intellectual_9_Class> List()
        {
            return __context.Intellectual_9_Class;
        }
        public Intellectual_9_Class Get(int? id)
        {
            return __context.Intellectual_9_Class.Find(id);
        }
        public void Create(Intellectual_9_Class Intellectual_9_Class)
        {
            __context.Intellectual_9_Class.Add(Intellectual_9_Class);
            __context.SaveChanges();
        }
        public void Edit(Intellectual_9_Class Intellectual_9_Class)
        {
            __context.Intellectual_9_Class.AddOrUpdate(Intellectual_9_Class);
            __context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = __context.Intellectual_9_Class.Find(id);
            __context.Intellectual_9_Class.Remove(student);
            __context.SaveChanges();
        }
    }
}