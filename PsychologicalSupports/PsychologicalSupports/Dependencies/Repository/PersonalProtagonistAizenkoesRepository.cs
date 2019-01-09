using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class PersonalProtagonistAizenkoesRepository : IRepository<PersonalProtagonistAizenko>
    {
        private readonly IPsychologicalSupportsContext __context;

        public PersonalProtagonistAizenkoesRepository(IPsychologicalSupportsContext context)
        {
            __context = context;
        }

        public IEnumerable<PersonalProtagonistAizenko> List()
        {
            return __context.PersonalProtagonistAizenkoes;
        }

        public PersonalProtagonistAizenko Get(int? id)
        {
            return __context.PersonalProtagonistAizenkoes.Find(id);
        }

        public void Create(PersonalProtagonistAizenko PersonalProtagonistAizenko)
        {
            __context.PersonalProtagonistAizenkoes.Add(PersonalProtagonistAizenko);
            __context.SaveChanges();
        }

        public void Edit(PersonalProtagonistAizenko PersonalProtagonistAizenko)
        {
            __context.PersonalProtagonistAizenkoes.AddOrUpdate(PersonalProtagonistAizenko);
            __context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = __context.PersonalProtagonistAizenkoes.Find(id);
            __context.PersonalProtagonistAizenkoes.Remove(student);
            __context.SaveChanges();
        }
    }
}