using Microsoft.AspNet.Identity.EntityFramework;
using PsychologicalSupports.Models;
using System.Data.Entity;

namespace PsychologicalSupports.Infrastructure
{
    public interface IAppIdentityDbContext
    {
        IDbSet<AppUser> Users { get; set; }
    }
    public class AppIdentityDbContext : IdentityDbContext<AppUser>,IAppIdentityDbContext
    {
        public AppIdentityDbContext() : base("name=PsychologicalSupport") { }
        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }
}