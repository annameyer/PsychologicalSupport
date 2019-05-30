using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class FamilyAlarmAnalysisRepository : IRepository<FamilyAlarmAnalysi>
    {
        private readonly IPsychologicalSupportsContext _psychologicalSupportsContext;
        public FamilyAlarmAnalysisRepository(IPsychologicalSupportsContext psychologicalSupportsContext)
        {
            _psychologicalSupportsContext = psychologicalSupportsContext;
        }
        public IEnumerable<FamilyAlarmAnalysi> List()
        {
            return _psychologicalSupportsContext.FamilyAlarmAnalysis.Include(x => x.Student).ToList(); ;
        }
        public FamilyAlarmAnalysi Get(long? id)
        {
            return _psychologicalSupportsContext.FamilyAlarmAnalysis.Find(id);
        }
        public void Create(FamilyAlarmAnalysi FamilyAlarmAnalysi)
        {
            _psychologicalSupportsContext.FamilyAlarmAnalysis.Add(FamilyAlarmAnalysi);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Edit(FamilyAlarmAnalysi FamilyAlarmAnalysi)
        {
            _psychologicalSupportsContext.FamilyAlarmAnalysis.AddOrUpdate(FamilyAlarmAnalysi);
            _psychologicalSupportsContext.SaveChanges();
        }
        public void Delete(long id)
        {
            FamilyAlarmAnalysi student = _psychologicalSupportsContext.FamilyAlarmAnalysis.Find(id);
            _psychologicalSupportsContext.FamilyAlarmAnalysis.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}