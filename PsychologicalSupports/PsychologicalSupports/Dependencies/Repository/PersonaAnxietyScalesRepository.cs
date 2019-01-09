using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class PersonaAnxietyScalesRepository : IRepository<PersonaAnxietyScale>
    {
        private readonly IPsychologicalSupportsContext __context;

        public PersonaAnxietyScalesRepository(IPsychologicalSupportsContext context)
        {
            __context = context;
        }

        public IEnumerable<PersonaAnxietyScale> List()
        {
            return __context.PersonaAnxietyScales;
        }

        public PersonaAnxietyScale Get(int? id)
        {
            return __context.PersonaAnxietyScales.Find(id);
        }

        public void Create(PersonaAnxietyScale PersonaAnxietyScale)
        {
            __context.PersonaAnxietyScales.Add(PersonaAnxietyScale);
            __context.SaveChanges();
        }

        public void Edit(PersonaAnxietyScale PersonaAnxietyScale)
        {
            __context.PersonaAnxietyScales.AddOrUpdate(PersonaAnxietyScale);
            __context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = __context.PersonaAnxietyScales.Find(id);
            __context.PersonaAnxietyScales.Remove(student);
            __context.SaveChanges();
        }
    }
}