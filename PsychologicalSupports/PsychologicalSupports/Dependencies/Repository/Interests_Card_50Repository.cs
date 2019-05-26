using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Controllers
{
    public class Interests_Card_50Repository : IRepository<Interests_Card_50>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;

        public Interests_Card_50Repository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }

        public IEnumerable<Interests_Card_50> List()
        {
            return _psychologicalSupportsContext.Interests_Card_50;
        }

        public Interests_Card_50 Get(long? id)
        {
            return _psychologicalSupportsContext.Interests_Card_50.Find(id);
        }

        public void Create(Interests_Card_50 Interests_Card_50)
        {
            _psychologicalSupportsContext.Interests_Card_50.Add(Interests_Card_50);
            _psychologicalSupportsContext.SaveChanges();
        }

        public void Edit(Interests_Card_50 Interests_Card_50)
        {
            _psychologicalSupportsContext.Interests_Card_50.AddOrUpdate(Interests_Card_50);
            _psychologicalSupportsContext.SaveChanges();
        }

        public void Delete(long id)
        {
            Interests_Card_50 student = _psychologicalSupportsContext.Interests_Card_50.Find(id);
            _psychologicalSupportsContext.Interests_Card_50.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}