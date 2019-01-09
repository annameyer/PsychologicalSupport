using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Dependencies.Repository
{
    public class Self_esteemRepository : IRepository<Self_esteem>
    {
        private readonly IPsychologicalSupportsContext __context;

        public Self_esteemRepository(IPsychologicalSupportsContext context)
        {
            __context = context;
        }

        public IEnumerable<Self_esteem> List()
        {
            return __context.Self_esteem;
        }

        public Self_esteem Get(int? id)
        {
            return __context.Self_esteem.Find(id);
        }

        public void Create(Self_esteem Self_esteem)
        {
            __context.Self_esteem.Add(Self_esteem);
            __context.SaveChanges();
        }

        public void Edit(Self_esteem Self_esteem)
        {
            __context.Self_esteem.AddOrUpdate(Self_esteem);
            __context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = __context.Self_esteem.Find(id);
            __context.Self_esteem.Remove(student);
            __context.SaveChanges();
        }
    }
}