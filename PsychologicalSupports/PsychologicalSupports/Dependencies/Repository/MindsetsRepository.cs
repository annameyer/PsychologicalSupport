using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class MindsetsRepository : IRepository<Mindset>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;

        public MindsetsRepository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }

        public IEnumerable<Mindset> List()
        {
            return _psychologicalSupportsContext.Mindsets;
        }

        public Mindset Get(int? id)
        {
            return _psychologicalSupportsContext.Mindsets.Find(id);
        }

        public void Create(Mindset Mindset)
        {
            _psychologicalSupportsContext.Mindsets.Add(Mindset);
            _psychologicalSupportsContext.SaveChanges();
        }

        public void Edit(Mindset Mindset)
        {
            _psychologicalSupportsContext.Mindsets.AddOrUpdate(Mindset);
            _psychologicalSupportsContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _psychologicalSupportsContext.Mindsets.Find(id);
            _psychologicalSupportsContext.Mindsets.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}