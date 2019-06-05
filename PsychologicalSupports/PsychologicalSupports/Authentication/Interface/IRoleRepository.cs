using PsychologicalSupports.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PsychologicalSupports.Authentication.Interface
{
    public interface IRoleRepository
    {
        Task<bool> Create(CreateRoleModel model);
        IEnumerable<AppRole> Get();
    }
}
