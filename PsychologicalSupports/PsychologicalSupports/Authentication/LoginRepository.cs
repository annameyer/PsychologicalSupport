using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using PsychologicalSupports.Authentication.Interface;
using System.Threading.Tasks;

namespace PsychologicalSupports.Models.Dependencies
{
    
    public class LoginRepository:ILoginRepository
    {
        private readonly IAppIdentityDbContext _AppIdentityDbContext;
        private readonly IAppUserManager _appUserManager;
        private readonly IAuthenticationManager _authenticationManager;

        public LoginRepository(IAppIdentityDbContext AppIdentityDbContext, IAuthenticationManager authenticationManager, IAppUserManager appUserManager)
        {
            _AppIdentityDbContext = AppIdentityDbContext;
            _authenticationManager = authenticationManager;
            _appUserManager = appUserManager;
        }

        public async Task<bool> Login(Administrator detalis)
        {
            var user = await _appUserManager.FindAsync(detalis.Login, detalis.Password);
            if (user == null)
            {
                return false;
            }
            else
            {
                var ident = await _appUserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                _authenticationManager.SignOut();
                _authenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false

                }, ident);
                return true;
            }
        }

        public void SignOut(IAuthenticationManager authenticationManager)
        {
            authenticationManager.SignOut();
        }
    }
}