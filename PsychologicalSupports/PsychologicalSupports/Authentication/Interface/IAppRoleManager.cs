using Microsoft.AspNet.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace PsychologicalSupports.Authentication
{
    public interface IAppRoleManager
    {
        IQueryable<AppRole> Roles { get; }
        Task<IdentityResult> CreateAsync(AppRole role);
    }
}