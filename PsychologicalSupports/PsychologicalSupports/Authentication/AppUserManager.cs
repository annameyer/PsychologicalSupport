using Microsoft.AspNet.Identity;
using PsychologicalSupports.Authentication.Interface;
using PsychologicalSupports.Models;

namespace PsychologicalSupports.Infrastructure
{
    public class AppUserManager : UserManager<AppUser>,IAppUserManager
    {
        public AppUserManager(IUserStore<AppUser> store): base(store){}
    }
}