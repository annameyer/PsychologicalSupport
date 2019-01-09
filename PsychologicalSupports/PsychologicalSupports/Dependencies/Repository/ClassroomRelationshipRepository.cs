using System.Collections.Generic;
using System.Data.Entity.Migrations;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class ClassroomRelationshipRepository:IRepository<ClassroomRelationship>
    {
        private readonly IPsychologicalSupportsContext __context;
        public ClassroomRelationshipRepository(IPsychologicalSupportsContext context)
        {
            __context = context;
        }
        public IEnumerable<ClassroomRelationship> List()
        {
            return __context.ClassroomRelationships;
        }
        public ClassroomRelationship Get(int? id)
        {
            return __context.ClassroomRelationships.Find(id);
        }
        public void Create(ClassroomRelationship classroomRelationship)
        {
            __context.ClassroomRelationships.Add(classroomRelationship);
            __context.SaveChanges();
        }
        public void Edit(ClassroomRelationship classroomRelationship)
        {
            __context.ClassroomRelationships.AddOrUpdate(classroomRelationship);
            __context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = __context.ClassroomRelationships.Find(id);
            __context.ClassroomRelationships.Remove(student);
            __context.SaveChanges();
        }
    }
}