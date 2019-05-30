using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class EmotioTestsRepository : IRepository<EmotioTest>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        public EmotioTestsRepository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }
        public IEnumerable<EmotioTest> List()
        {
            return _psychologicalSupportsContext.EmotioTests.Include(x => x.Student).ToList(); ;
        }
        public EmotioTest Get(long? id)
        {
            return _psychologicalSupportsContext.EmotioTests.Find(id);
        }
        public void Create(EmotioTest emotioTest)
        {
            _psychologicalSupportsContext.EmotioTests.Add(emotioTest);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Edit(EmotioTest emotioTest)
        {
            _psychologicalSupportsContext.EmotioTests.AddOrUpdate(emotioTest);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Delete(long id)
        {
            EmotioTest student = _psychologicalSupportsContext.EmotioTests.Find(id);
            _psychologicalSupportsContext.EmotioTests.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}