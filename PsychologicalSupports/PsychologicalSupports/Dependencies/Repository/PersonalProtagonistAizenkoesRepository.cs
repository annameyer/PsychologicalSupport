using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class PersonalProtagonistAizenkoesRepository : IRepository<PersonalProtagonistAizenko>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;

        public PersonalProtagonistAizenkoesRepository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }

        public IEnumerable<PersonalProtagonistAizenko> List()
        {
            return _psychologicalSupportsContext.PersonalProtagonistAizenkoes.Include(x => x.Student).ToList();
        }

        public PersonalProtagonistAizenko Get(long? id)
        {
            return _psychologicalSupportsContext.PersonalProtagonistAizenkoes.Find(id);
        }

        public void Create(PersonalProtagonistAizenko PersonalProtagonistAizenko)
        {
            _psychologicalSupportsContext.PersonalProtagonistAizenkoes.Add(PersonalProtagonistAizenko);
            _psychologicalSupportsContext.SaveChanges();
        }

        public void Edit(PersonalProtagonistAizenko PersonalProtagonistAizenko)
        {
            _psychologicalSupportsContext.PersonalProtagonistAizenkoes.AddOrUpdate(PersonalProtagonistAizenko);
            _psychologicalSupportsContext.SaveChanges();
        }

        public void Delete(long id)
        {
            PersonalProtagonistAizenko student = _psychologicalSupportsContext.PersonalProtagonistAizenkoes.Find(id);
            _psychologicalSupportsContext.PersonalProtagonistAizenkoes.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}