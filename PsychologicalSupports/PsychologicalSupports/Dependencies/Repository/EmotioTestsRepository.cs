using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class EmotioTestsRepository : IRepository<EmotioTest>
    {
        private readonly IPsychologicalSupportsContext __context;
        public EmotioTestsRepository(IPsychologicalSupportsContext context)
        {
            __context = context;
        }
        public IEnumerable<EmotioTest> List()
        {
            return __context.EmotioTests;
        }
        public EmotioTest Get(int? id)
        {
            return __context.EmotioTests.Find(id);
        }
        public void Create(EmotioTest emotioTest)
        {
            __context.EmotioTests.Add(emotioTest);
            __context.SaveChanges();
        }
        public void Edit(EmotioTest emotioTest)
        {
            __context.EmotioTests.AddOrUpdate(emotioTest);
            __context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = __context.EmotioTests.Find(id);
            __context.EmotioTests.Remove(student);
            __context.SaveChanges();
        }
    }
}