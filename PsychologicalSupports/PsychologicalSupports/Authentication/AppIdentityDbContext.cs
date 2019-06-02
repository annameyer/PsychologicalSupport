using Microsoft.AspNet.Identity.EntityFramework;
using PsychologicalSupports.Authentication.Interface;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Infrastructure
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>, IAppIdentityDbContext
    {
        public AppIdentityDbContext() : base("name=PsychologicalSupport") { }
    }
}