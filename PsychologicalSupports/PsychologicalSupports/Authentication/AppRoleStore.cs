using Microsoft.AspNet.Identity.EntityFramework;
using PsychologicalSupports.Infrastructure;
using System.Data.Entity;

namespace PsychologicalSupports.Authentication
{
    public class AppRoleStore : RoleStore<AppRole>
    {
        public AppRoleStore(AppIdentityDbContext db) : base((DbContext)db) { }
    }
}