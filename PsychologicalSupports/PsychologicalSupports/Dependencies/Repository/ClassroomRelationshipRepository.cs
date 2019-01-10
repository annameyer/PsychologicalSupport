using System.Collections.Generic;
using System.Data.Entity.Migrations;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class ClassroomRelationshipRepository:IRepository<ClassroomRelationship>
    {
        private readonly IPsychologicalSupportsContext _context;
        public ClassroomRelationshipRepository(IPsychologicalSupportsContext context)
        {
            _context = context;
        }
        public IEnumerable<ClassroomRelationship> List()
        {
            return _context.ClassroomRelationships;
        }
        public ClassroomRelationship Get(int? id)
        {
            return _context.ClassroomRelationships.Find(id);
        }
        public void Create(ClassroomRelationship classroomRelationship)
        {
            _context.ClassroomRelationships.Add(classroomRelationship);
            _context.SaveChanges();
        }
        public void Edit(ClassroomRelationship classroomRelationship)
        {
            _context.ClassroomRelationships.AddOrUpdate(classroomRelationship);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = _context.ClassroomRelationships.Find(id);
            _context.ClassroomRelationships.Remove(student);
            _context.SaveChanges();
        }
    }
}