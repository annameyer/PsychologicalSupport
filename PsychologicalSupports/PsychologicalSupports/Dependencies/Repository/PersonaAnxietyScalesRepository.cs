using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class PersonaAnxietyScalesRepository : IRepository<PersonaAnxietyScale>
    {
        private readonly IPsychologicalSupportsContext _context;

        public PersonaAnxietyScalesRepository(IPsychologicalSupportsContext context)
        {
            _context = context;
        }

        public IEnumerable<PersonaAnxietyScale> List()
        {
            return _context.PersonaAnxietyScales;
        }

        public PersonaAnxietyScale Get(int? id)
        {
            return _context.PersonaAnxietyScales.Find(id);
        }

        public void Create(PersonaAnxietyScale PersonaAnxietyScale)
        {
            _context.PersonaAnxietyScales.Add(PersonaAnxietyScale);
            _context.SaveChanges();
        }

        public void Edit(PersonaAnxietyScale PersonaAnxietyScale)
        {
            _context.PersonaAnxietyScales.AddOrUpdate(PersonaAnxietyScale);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.PersonaAnxietyScales.Find(id);
            _context.PersonaAnxietyScales.Remove(student);
            _context.SaveChanges();
        }
    }
}