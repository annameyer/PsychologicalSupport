using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class Intellectual_8_ClassRepository : IRepository<Intellectual_8_Class>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        public Intellectual_8_ClassRepository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }
        public IEnumerable<Intellectual_8_Class> List()
        {
            return _psychologicalSupportsContext.Intellectual_8_Class;
        }
        public Intellectual_8_Class Get(long? id)
        {
            return _psychologicalSupportsContext.Intellectual_8_Class.Find(id);
        }
        public void Create(Intellectual_8_Class Intellectual_8_Class)
        {
            _psychologicalSupportsContext.Intellectual_8_Class.Add(Intellectual_8_Class);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Edit(Intellectual_8_Class Intellectual_8_Class)
        {
            _psychologicalSupportsContext.Intellectual_8_Class.AddOrUpdate(Intellectual_8_Class);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Delete(long id)
        {
            var student = _psychologicalSupportsContext.Intellectual_8_Class.Find(id);
            _psychologicalSupportsContext.Intellectual_8_Class.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}