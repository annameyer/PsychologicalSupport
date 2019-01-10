using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

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
            return _psychologicalSupportsContext.FamilyAlarmAnalysis;
        }
        public FamilyAlarmAnalysi Get(int? id)
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
        public void Delete(int id)
        {
            var student = _psychologicalSupportsContext.FamilyAlarmAnalysis.Find(id);
            _psychologicalSupportsContext.FamilyAlarmAnalysis.Remove(student);
            _psychologicalSupportsContext.SaveChanges();
        }
    }
}