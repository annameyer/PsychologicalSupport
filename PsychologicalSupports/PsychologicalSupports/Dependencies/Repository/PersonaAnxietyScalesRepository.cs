using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class PersonaAnxietyScalesRepository : IRepository<PersonaAnxietyScale>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;

        public PersonaAnxietyScalesRepository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }

        public IEnumerable<PersonaAnxietyScale> List()
        {
            return _psychologicalSupportsContext.PersonaAnxietyScales;
        }

        public PersonaAnxietyScale Get(int? id)
        {
            return _psychologicalSupportsContext.PersonaAnxietyScales.Find(id);
        }

        public void Create(PersonaAnxietyScale PersonaAnxietyScale)
        {
            _psychologicalSupportsContext.PersonaAnxietyScales.Add(PersonaAnxietyScale);
            _psychologicalSupportsContext.SaveChanges();
        }

        public void Edit(PersonaAnxietyScale PersonaAnxietyScale)
        {
            _psychologicalSupportsContext.PersonaAnxietyScales.AddOrUpdate(PersonaAnxietyScale);
            _psychologicalSupportsContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _psychologicalSupportsContext.PersonaAnxietyScales.Find(id);
            _psychologicalSupportsContext.PersonaAnxietyScales.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}