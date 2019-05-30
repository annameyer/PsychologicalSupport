using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
namespace PsychologicalSupports.Dependencies.Repository
{
    public class Intellectual_7_ClassRepository : IRepository<Intellectual_7_Class>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        public Intellectual_7_ClassRepository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }
        public IEnumerable<Intellectual_7_Class> List()
        {
            return _psychologicalSupportsContext.Intellectual_7_Class.Include(x => x.Student).ToList();
        }
        public Intellectual_7_Class Get(long? id)
        {
            return _psychologicalSupportsContext.Intellectual_7_Class.Find(id);
        }
        public void Create(Intellectual_7_Class Intellectual_7_Class)
        {
            _psychologicalSupportsContext.Intellectual_7_Class.Add(Intellectual_7_Class);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Edit(Intellectual_7_Class Intellectual_7_Class)
        {
            _psychologicalSupportsContext.Intellectual_7_Class.AddOrUpdate(Intellectual_7_Class);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Delete(long id)
        {
            Intellectual_7_Class student = _psychologicalSupportsContext.Intellectual_7_Class.Find(id);
            _psychologicalSupportsContext.Intellectual_7_Class.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}