using Ninject.Modules;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Student>>().To<StudentRepository>();
        }
    }
}