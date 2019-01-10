using PsychologicalSupports.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PsychologicalSupports.Authentication.Interface
{
    public interface IAppUserManager
    {
        Task<ClaimsIdentity> CreateIdentityAsync(AppUser user, string authenticationType);
        Task<AppUser> FindAsync(string userName, string password);
    }
}
