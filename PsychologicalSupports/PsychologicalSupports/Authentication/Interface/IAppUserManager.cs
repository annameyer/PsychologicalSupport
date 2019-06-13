using Microsoft.AspNet.Identity;
using PsychologicalSupports.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PsychologicalSupports.Authentication.Interface
{
    public interface IAppUserManager
    {
        Task<AppUser> FindAsync(string userName, string password);
        Task<ClaimsIdentity> CreateIdentityAsync(AppUser user, string authenticationType);
        Task<IdentityResult> CreateAsync(AppUser user, string passwords);
        Task<IdentityResult> AddToRoleAsync(string userId, string role);
        IQueryable<AppUser> Users { get; }
        Task<IdentityResult> DeleteAsync(AppUser user);
        Task<AppUser> FindByIdAsync(string userId);
    }
}
