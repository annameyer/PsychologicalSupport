using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class AveragePointsRepository : IRepository<AveragePoint>
    {
        private readonly IPsychologicalSupportsContext _context;
        public AveragePointsRepository(IPsychologicalSupportsContext context)
        {
            _context = context;
        }
        public IEnumerable<AveragePoint> List()
        {
            return _context.AveragePoints;
        }
        public AveragePoint Get(int? id)
        {
            return _context.AveragePoints.Find(id);
        }
        public void Create(AveragePoint averagePoint)
        {
            _context.AveragePoints.Add(averagePoint);
            _context.SaveChanges();
        }
        public void Edit(AveragePoint averagePoint)
        {
            _context.AveragePoints.AddOrUpdate(averagePoint);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = _context.AveragePoints.Find(id);
            _context.AveragePoints.Remove(student);
            _context.SaveChanges();
        }
    }
}