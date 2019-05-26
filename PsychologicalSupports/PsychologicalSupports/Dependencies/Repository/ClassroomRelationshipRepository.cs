using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class ClassroomRelationshipRepository : IRepository<ClassroomRelationship>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        public ClassroomRelationshipRepository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }
        public IEnumerable<ClassroomRelationship> List()
        {
            return _psychologicalSupportsContext.ClassroomRelationships;
        }
        public ClassroomRelationship Get(long? id)
        {
            return _psychologicalSupportsContext.ClassroomRelationships.Find(id);
        }
        public void Create(ClassroomRelationship classroomRelationship)
        {
            _psychologicalSupportsContext.ClassroomRelationships.Add(classroomRelationship);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Edit(ClassroomRelationship classroomRelationship)
        {
            _psychologicalSupportsContext.ClassroomRelationships.AddOrUpdate(classroomRelationship);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Delete(long id)
        {
            ClassroomRelationship student = _psychologicalSupportsContext.ClassroomRelationships.Find(id);
            _psychologicalSupportsContext.ClassroomRelationships.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}