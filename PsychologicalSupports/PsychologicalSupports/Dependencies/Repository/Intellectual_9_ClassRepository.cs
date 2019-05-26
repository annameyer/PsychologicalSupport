using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class Intellectual_9_ClassRepository : IRepository<Intellectual_9_Class>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        public Intellectual_9_ClassRepository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }
        public IEnumerable<Intellectual_9_Class> List()
        {
            return _psychologicalSupportsContext.Intellectual_9_Class;
        }
        public Intellectual_9_Class Get(long? id)
        {
            return _psychologicalSupportsContext.Intellectual_9_Class.Find(id);
        }
        public void Create(Intellectual_9_Class Intellectual_9_Class)
        {
            _psychologicalSupportsContext.Intellectual_9_Class.Add(Intellectual_9_Class);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Edit(Intellectual_9_Class Intellectual_9_Class)
        {
            _psychologicalSupportsContext.Intellectual_9_Class.AddOrUpdate(Intellectual_9_Class);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Delete(long id)
        {
            var student = _psychologicalSupportsContext.Intellectual_9_Class.Find(id);
            _psychologicalSupportsContext.Intellectual_9_Class.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}