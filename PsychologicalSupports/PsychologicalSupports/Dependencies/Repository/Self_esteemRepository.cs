using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class Self_esteemRepository : IRepository<Self_esteem>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;

        public Self_esteemRepository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }

        public IEnumerable<Self_esteem> List()
        {
            return _psychologicalSupportsContext.Self_esteem.Include(x => x.Student).ToList();
        }

        public Self_esteem Get(long? id)
        {
            return _psychologicalSupportsContext.Self_esteem.Find(id);
        }

        public void Create(Self_esteem Self_esteem)
        {
            _psychologicalSupportsContext.Self_esteem.Add(Self_esteem);
            _psychologicalSupportsContext.SaveChanges();
        }

        public void Edit(Self_esteem Self_esteem)
        {
            _psychologicalSupportsContext.Self_esteem.AddOrUpdate(Self_esteem);
            _psychologicalSupportsContext.SaveChanges();
        }

        public void Delete(long id)
        {
            Self_esteem student = _psychologicalSupportsContext.Self_esteem.Find(id);
            _psychologicalSupportsContext.Self_esteem.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}