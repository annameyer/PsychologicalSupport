using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

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
            return _psychologicalSupportsContext.EmotioTests;
        }
        public EmotioTest Get(int? id)
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
        public void Delete(int id)
        {
            var student = _psychologicalSupportsContext.EmotioTests.Find(id);
            _psychologicalSupportsContext.EmotioTests.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}