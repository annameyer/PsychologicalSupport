using System.Data.Entity;

namespace PsychologicalSupports.Models.Dependencies
{
     public interface IPsychologicalSupportsContext
    {
        int SaveChanges();
        DbSet<Student> Students { get; set; }
    }
}
