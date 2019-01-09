using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class MindsetsRepository : IRepository<Mindset>
    {
        private readonly IPsychologicalSupportsContext __context;

        public MindsetsRepository(IPsychologicalSupportsContext context)
        {
            __context = context;
        }

        public IEnumerable<Mindset> List()
        {
            return __context.Mindsets;
        }

        public Mindset Get(int? id)
        {
            return __context.Mindsets.Find(id);
        }

        public void Create(Mindset Mindset)
        {
            __context.Mindsets.Add(Mindset);
            __context.SaveChanges();
        }

        public void Edit(Mindset Mindset)
        {
            __context.Mindsets.AddOrUpdate(Mindset);
            __context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = __context.Mindsets.Find(id);
            __context.Mindsets.Remove(student);
            __context.SaveChanges();
        }
    }
}