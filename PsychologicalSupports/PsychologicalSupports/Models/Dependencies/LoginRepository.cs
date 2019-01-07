using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using PsychologicalSupports.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PsychologicalSupports.Models.Dependencies
{
     interface ILoginRepository
    {
        Task<bool> Login(Administrator detalis);
        void SignOut(IAuthenticationManager iManager);

    }
    public class LoginRepository:ILoginRepository
    {
        private readonly IAppIdentityDbContext _context;
        private readonly IAppUserManager _appUserManager;
        private readonly IAuthenticationManager _iManager;
        public LoginRepository(IAppIdentityDbContext context, IAuthenticationManager iManager, IAppUserManager appUserManager)
        {
            _context = context;
            _iManager = iManager;
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
                _iManager.SignOut();
                _iManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false

                }, ident);
                return true;
            }
        }

        public void SignOut(IAuthenticationManager iManager)
        {
            iManager.SignOut();
        }
    }
}