using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class ClassTeacheInformationsRepository : IRepository<ClassTeacheInformation>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        public ClassTeacheInformationsRepository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }
        public IEnumerable<ClassTeacheInformation> List()
        {
            return _psychologicalSupportsContext.ClassTeacheInformations;
        }
        public ClassTeacheInformation Get(long? id)
        {
            return _psychologicalSupportsContext.ClassTeacheInformations.Find(id);
        }
        public void Create(ClassTeacheInformation classroomRelationship)
        {
            _psychologicalSupportsContext.ClassTeacheInformations.Add(classroomRelationship);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Edit(ClassTeacheInformation classroomRelationship)
        {
            _psychologicalSupportsContext.ClassTeacheInformations.AddOrUpdate(classroomRelationship);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Delete(long id)
        {
            ClassTeacheInformation student = _psychologicalSupportsContext.ClassTeacheInformations.Find(id);
            _psychologicalSupportsContext.ClassTeacheInformations.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}