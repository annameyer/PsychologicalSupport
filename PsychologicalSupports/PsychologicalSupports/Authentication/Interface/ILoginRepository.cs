
using Microsoft.Owin.Security;
using PsychologicalSupports.Models;
using System.Threading.Tasks;

namespace PsychologicalSupports.Authentication.Interface
{
    public interface ILoginRepository
    {
        Task<bool> Login(Administrator detalis);
        void SignOut(IAuthenticationManager iManager);
        Task<bool> Create(Administrator detalis);

    }
}
