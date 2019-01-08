using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Ninject.Modules;
using PsychologicalSupports.Infrastructure;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Web;

namespace PsychologicalSupports.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Student>>().To<StudentRepository>();
            Bind<IPsychologicalSupportsContext>().To<PsychologicalSupportsEntities>();
            Bind<IAppIdentityDbContext>().To<AppIdentityDbContext>();
            Bind<ILoginRepository>().To<LoginRepository>();
            Bind<IAppUserManager>().ToMethod(c =>HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>());
            Bind<IAuthenticationManager>().ToMethod(c => HttpContext.Current.GetOwinContext().Authentication);
        }
    }
}