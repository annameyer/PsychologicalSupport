using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalSupports.Models.Dependencies
{
    interface IContext
    {
        int SaveChanges();
       
        DbSet<Student> Students { get; set; }
    }
}
