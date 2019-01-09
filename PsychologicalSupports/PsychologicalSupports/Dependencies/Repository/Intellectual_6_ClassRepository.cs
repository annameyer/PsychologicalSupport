using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class Intellectual_6_ClassRepository:IRepository<Intellectual_6_Class>
    {
        private readonly IPsychologicalSupportsContext __context;
        public Intellectual_6_ClassRepository(IPsychologicalSupportsContext context)
        {
            __context = context;
        }
        public IEnumerable<Intellectual_6_Class> List()
        {
            return __context.Intellectual_6_Class;
        }
        public Intellectual_6_Class Get(int? id)
        {
            return __context.Intellectual_6_Class.Find(id);
        }
        public void Create(Intellectual_6_Class Intellectual_6_Class)
        {
            __context.Intellectual_6_Class.Add(Intellectual_6_Class);
            __context.SaveChanges();
        }
        public void Edit(Intellectual_6_Class Intellectual_6_Class)
        {
            __context.Intellectual_6_Class.AddOrUpdate(Intellectual_6_Class);
            __context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = __context.Intellectual_6_Class.Find(id);
            __context.Intellectual_6_Class.Remove(student);
            __context.SaveChanges();
        }
    }
}