using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Infrastructure
{
    public class AppRepository
    {
        private readonly IAppIdentityDbContext _dbContext=new AppIdentityDbContext();
        public AppIdentityDbContext AppIdentityDbContextCreate()
        {
            return new AppIdentityDbContext();
        }
        public AppUserManager AppUserManagerCreate(IdentityFactoryOptions<AppUserManager> options,IOwinContext context)
        {
            AppIdentityDbContext db = context.Get<AppIdentityDbContext>();
            AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db));
            return manager;
        }
        public void Config(IAppBuilder app)
        { 
        app.CreatePerOwinContext<AppIdentityDbContext>(AppIdentityDbContextCreate);
        app.CreatePerOwinContext<AppUserManager>(AppUserManagerCreate);
        }
    }
}