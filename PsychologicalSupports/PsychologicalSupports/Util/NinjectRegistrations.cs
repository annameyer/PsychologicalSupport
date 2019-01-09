using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Ninject.Modules;
using PsychologicalSupports.Infrastructure;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using PsychologicalSupports.Controllers;
using PsychologicalSupports.Dependencies.Repository;

namespace PsychologicalSupports.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Student>>().To<StudentRepository>();
            Bind<IRepository<AveragePoint>>().To<AveragePointsRepository>();
            Bind<IRepository<ClassroomRelationship>>().To<ClassroomRelationshipRepository>();
            Bind<IRepository<ClassTeacheInformation>>().To<ClassTeacheInformationsRepository>();
            Bind<IRepository<EmotioTest>>().To<EmotioTestsRepository>();
            Bind<IRepository<FamilyAlarmAnalysi>>().To<FamilyAlarmAnalysisRepository>();
            Bind<IRepository<Intellectual_6_Class>>().To<Intellectual_6_ClassRepository>();
            Bind<IRepository<Intellectual_7_Class>>().To<Intellectual_7_ClassRepository>();
            Bind<IRepository<Intellectual_8_Class>>().To<Intellectual_8_ClassRepository>();
            Bind<IRepository<Intellectual_9_Class>>().To<Intellectual_9_ClassRepository>();
            Bind<IRepository<Interests_Card_145>>().To<Interests_Card_145Repository>();
            Bind<IRepository<Interests_Card_50>>().To<Interests_Card_50Repository>();
            Bind<IRepository<InterestsInSchoolSubject>>().To<InterestsInSchoolSubjectsRepository>();
            Bind<IRepository<Mindset>>().To<MindsetsRepository>();
            Bind<IRepository<PersonaAnxietyScale>>().To<PersonaAnxietyScalesRepository>();
            Bind<IRepository<PersonalProtagonistAizenko>>().To<PersonalProtagonistAizenkoesRepository>();
            Bind<IRepository<SchoolMotivation>>().To<SchoolMotivationsRepository>();
            Bind<IRepository<Self_esteem>>().To<Self_esteemRepository>();

            Bind<IPsychologicalSupportsContext>().To<PsychologicalSupportsEntities>();
            Bind<IAppIdentityDbContext>().To<AppIdentityDbContext>();
            Bind<ILoginRepository>().To<LoginRepository>();
            Bind<IAppUserManager>().To<AppUserManager>();
            Bind<IUserStore<AppUser>>().To<AppUserStore>();
            Bind<IAuthenticationManager>().ToMethod(c => HttpContext.Current.GetOwinContext().Authentication);
        }
    }
}