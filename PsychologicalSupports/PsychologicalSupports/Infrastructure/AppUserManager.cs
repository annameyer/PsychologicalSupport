using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using PsychologicalSupports.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PsychologicalSupports.Infrastructure
{
    public interface IAppUserManager
    {
        Task<ClaimsIdentity> CreateIdentityAsync(AppUser user, string authenticationType);
        Task<AppUser> FindAsync(string userName, string password);
        Task<IdentityResult> CreateAsync(AppUser user, string password);
    }
    public class AppUserManager : UserManager<AppUser>,IAppUserManager
    {
        public AppUserManager(IUserStore<AppUser> store): base(store){}

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options,
            IOwinContext context)
        {
            var db = context.Get<AppIdentityDbContext>();
            var manager = new AppUserManager(new UserStore<AppUser>(db));
            return manager;
        }
    }
}