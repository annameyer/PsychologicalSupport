using Microsoft.AspNet.Identity.EntityFramework;
using PsychologicalSupports.Models;
using System.Data.Entity;

namespace PsychologicalSupports.Infrastructure
{
    public class AppUserStore : UserStore<AppUser>
    {
        public AppUserStore(IAppIdentityDbContext db) : base((DbContext)db)
        {
        }
    }
}