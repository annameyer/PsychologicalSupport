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
        private readonly IPsychologicalSupportsContext _context;
        public FamilyAlarmAnalysisRepository(IPsychologicalSupportsContext context)
        {
            _context = context;
        }
        public IEnumerable<FamilyAlarmAnalysi> List()
        {
            return _context.FamilyAlarmAnalysis;
        }
        public FamilyAlarmAnalysi Get(int? id)
        {
            return _context.FamilyAlarmAnalysis.Find(id);
        }
        public void Create(FamilyAlarmAnalysi FamilyAlarmAnalysi)
        {
            _context.FamilyAlarmAnalysis.Add(FamilyAlarmAnalysi);
            _context.SaveChanges();
        }
        public void Edit(FamilyAlarmAnalysi FamilyAlarmAnalysi)
        {
            _context.FamilyAlarmAnalysis.AddOrUpdate(FamilyAlarmAnalysi);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = _context.FamilyAlarmAnalysis.Find(id);
            _context.FamilyAlarmAnalysis.Remove(student);
            _context.SaveChanges();
        }
    }
}