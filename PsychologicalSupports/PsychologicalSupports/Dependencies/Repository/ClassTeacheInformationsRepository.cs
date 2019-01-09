using System.Collections.Generic;
using System.Data.Entity.Migrations;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class ClassTeacheInformationsRepository:IRepository<ClassTeacheInformation>
    {
        private readonly IPsychologicalSupportsContext __context;
        public ClassTeacheInformationsRepository(IPsychologicalSupportsContext context)
        {
            __context = context;
        }
        public IEnumerable<ClassTeacheInformation> List()
        {
            return __context.ClassTeacheInformations;
        }
        public ClassTeacheInformation Get(int? id)
        {
            return __context.ClassTeacheInformations.Find(id);
        }
        public void Create(ClassTeacheInformation classroomRelationship)
        {
            __context.ClassTeacheInformations.Add(classroomRelationship);
            __context.SaveChanges();
        }
        public void Edit(ClassTeacheInformation classroomRelationship)
        {
            __context.ClassTeacheInformations.AddOrUpdate(classroomRelationship);
            __context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = __context.ClassTeacheInformations.Find(id);
            __context.ClassTeacheInformations.Remove(student);
            __context.SaveChanges();
        }
    }
}