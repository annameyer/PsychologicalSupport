using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class PersonalProtagonistAizenkoesRepository : IRepository<PersonalProtagonistAizenko>
    {
        private readonly IPsychologicalSupportsContext _context;

        public PersonalProtagonistAizenkoesRepository(IPsychologicalSupportsContext context)
        {
            _context = context;
        }

        public IEnumerable<PersonalProtagonistAizenko> List()
        {
            return _context.PersonalProtagonistAizenkoes;
        }

        public PersonalProtagonistAizenko Get(int? id)
        {
            return _context.PersonalProtagonistAizenkoes.Find(id);
        }

        public void Create(PersonalProtagonistAizenko PersonalProtagonistAizenko)
        {
            _context.PersonalProtagonistAizenkoes.Add(PersonalProtagonistAizenko);
            _context.SaveChanges();
        }

        public void Edit(PersonalProtagonistAizenko PersonalProtagonistAizenko)
        {
            _context.PersonalProtagonistAizenkoes.AddOrUpdate(PersonalProtagonistAizenko);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.PersonalProtagonistAizenkoes.Find(id);
            _context.PersonalProtagonistAizenkoes.Remove(student);
            _context.SaveChanges();
        }
    }
}