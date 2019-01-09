using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class AveragePointsRepository : IRepository<AveragePoint>
    {
        private readonly IPsychologicalSupportsContext __context;
        public AveragePointsRepository(IPsychologicalSupportsContext context)
        {
            __context = context;
        }
        public IEnumerable<AveragePoint> List()
        {
            return __context.AveragePoints;
        }
        public AveragePoint Get(int? id)
        {
            return __context.AveragePoints.Find(id);
        }
        public void Create(AveragePoint averagePoint)
        {
            __context.AveragePoints.Add(averagePoint);
            __context.SaveChanges();
        }
        public void Edit(AveragePoint averagePoint)
        {
            __context.AveragePoints.AddOrUpdate(averagePoint);
            __context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = __context.AveragePoints.Find(id);
            __context.AveragePoints.Remove(student);
            __context.SaveChanges();
        }
    }
}