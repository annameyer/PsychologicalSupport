using System.Data.Entity;
using System.Threading.Tasks;

namespace PsychologicalSupports.Models.Dependencies
{
     public interface IPsychologicalSupportsContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        DbSet<Student> Students { get; set; }
    }
}
