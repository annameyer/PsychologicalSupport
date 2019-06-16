using Microsoft.AspNet.Identity;

namespace PsychologicalSupports.Authentication
{
    public class AppRoleManager : RoleManager<AppRole>, IAppRoleManager
    {
        public AppRoleManager(IRoleStore<AppRole, string> store)
            : base(store){ }
    }
}