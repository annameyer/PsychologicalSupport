using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class FamilyAlarmAnalysisRepository:IRepository<FamilyAlarmAnalysi>
    {
        private readonly IPsychologicalSupportsContext __context;
        public FamilyAlarmAnalysisRepository(IPsychologicalSupportsContext context)
        {
            __context = context;
        }
        public IEnumerable<FamilyAlarmAnalysi> List()
        {
            return __context.FamilyAlarmAnalysis;
        }
        public FamilyAlarmAnalysi Get(int? id)
        {
            return __context.FamilyAlarmAnalysis.Find(id);
        }
        public void Create(FamilyAlarmAnalysi FamilyAlarmAnalysi)
        {
            __context.FamilyAlarmAnalysis.Add(FamilyAlarmAnalysi);
            __context.SaveChanges();
        }
        public void Edit(FamilyAlarmAnalysi FamilyAlarmAnalysi)
        {
            __context.FamilyAlarmAnalysis.AddOrUpdate(FamilyAlarmAnalysi);
            __context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = __context.FamilyAlarmAnalysis.Find(id);
            __context.FamilyAlarmAnalysis.Remove(student);
            __context.SaveChanges();
        }
    }
}