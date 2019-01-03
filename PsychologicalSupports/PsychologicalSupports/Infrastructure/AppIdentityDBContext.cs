using Microsoft.AspNet.Identity.EntityFramework;
using PsychologicalSupports.Models;
using System.Data.Entity;

namespace PsychologicalSupports.Infrastructure
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() : base("name=PsychologicalSupport") { }

        

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }
}