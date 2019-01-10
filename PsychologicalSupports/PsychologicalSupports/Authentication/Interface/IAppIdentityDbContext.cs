using PsychologicalSupports.Models;
using System.Data.Entity;

namespace PsychologicalSupports.Authentication.Interface
{
    public interface IAppIdentityDbContext
    {
        IDbSet<AppUser> Users { get; set; }
    }
}
