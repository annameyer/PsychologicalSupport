using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using PsychologicalSupports.Authentication.Interface;
using System.Threading.Tasks;

namespace PsychologicalSupports.Models.Dependencies
{

    public class LoginRepository:ILoginRepository
    {
        private readonly IAppUserManager _appUserManager;
        private readonly IAuthenticationManager _authenticationManager;

        public LoginRepository( IAuthenticationManager authenticationManager, IAppUserManager appUserManager)
        {
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

        public async Task<bool> Create(Administrator detalis)
        {
            var users = new AppUser { UserName = detalis.Login};
            var result = await _appUserManager.CreateAsync(users, detalis.Password);
            var user = await _appUserManager.AddToRoleAsync(users.Id, "User");
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SignOut(IAuthenticationManager authenticationManager)
        {
            authenticationManager.SignOut();
        }
    }
}