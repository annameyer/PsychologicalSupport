using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class Interests_Card_145Repository : IRepository<Interests_Card_145>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        public Interests_Card_145Repository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }
        public IEnumerable<Interests_Card_145> List()
        {
            return _psychologicalSupportsContext.Interests_Card_145;
        }
        public Interests_Card_145 Get(int? id)
        {
            return _psychologicalSupportsContext.Interests_Card_145.Find(id);
        }
        public void Create(Interests_Card_145 Interests_Card_145)
        {
            _psychologicalSupportsContext.Interests_Card_145.Add(Interests_Card_145);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Edit(Interests_Card_145 Interests_Card_145)
        {
            _psychologicalSupportsContext.Interests_Card_145.AddOrUpdate(Interests_Card_145);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = _psychologicalSupportsContext.Interests_Card_145.Find(id);
            _psychologicalSupportsContext.Interests_Card_145.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}