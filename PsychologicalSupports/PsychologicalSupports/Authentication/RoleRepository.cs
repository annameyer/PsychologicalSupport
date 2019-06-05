using Microsoft.AspNet.Identity;
using PsychologicalSupports.Authentication.Interface;
using PsychologicalSupports.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PsychologicalSupports.Authentication
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IAppRoleManager _applicationRoleManager;
        public RoleRepository(IAppRoleManager roleManager)
        {
            _applicationRoleManager = roleManager;
        }

        public IEnumerable<AppRole> Get()
        {
            return _applicationRoleManager.Roles;
        }
        public async Task<bool> Create(CreateRoleModel model)
        {
            var role = new AppRole();
            role.Name = model.Name;
            IdentityResult result = await _applicationRoleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
