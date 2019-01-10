using System.Collections.Generic;
using System.Data.Entity.Migrations;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class ClassTeacheInformationsRepository:IRepository<ClassTeacheInformation>
    {
        private readonly IPsychologicalSupportsContext _context;
        public ClassTeacheInformationsRepository(IPsychologicalSupportsContext context)
        {
            _context = context;
        }
        public IEnumerable<ClassTeacheInformation> List()
        {
            return _context.ClassTeacheInformations;
        }
        public ClassTeacheInformation Get(int? id)
        {
            return _context.ClassTeacheInformations.Find(id);
        }
        public void Create(ClassTeacheInformation classroomRelationship)
        {
            _context.ClassTeacheInformations.Add(classroomRelationship);
            _context.SaveChanges();
        }
        public void Edit(ClassTeacheInformation classroomRelationship)
        {
            _context.ClassTeacheInformations.AddOrUpdate(classroomRelationship);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = _context.ClassTeacheInformations.Find(id);
            _context.ClassTeacheInformations.Remove(student);
            _context.SaveChanges();
        }
    }
}