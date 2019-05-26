using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class AveragePointsRepository : IRepository<AveragePoint>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        public AveragePointsRepository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }
        public IEnumerable<AveragePoint> List()
        {
            return _psychologicalSupportsContext.AveragePoints;
        }
        public AveragePoint Get(long? id)
        {
            return _psychologicalSupportsContext.AveragePoints.Find(id);
        }
        public void Create(AveragePoint averagePoint)
        {
            _psychologicalSupportsContext.AveragePoints.Add(averagePoint);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Edit(AveragePoint averagePoint)
        {
            _psychologicalSupportsContext.AveragePoints.AddOrUpdate(averagePoint);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Delete(long id)
        {
            var student = _psychologicalSupportsContext.AveragePoints.Find(id);
            _psychologicalSupportsContext.AveragePoints.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}