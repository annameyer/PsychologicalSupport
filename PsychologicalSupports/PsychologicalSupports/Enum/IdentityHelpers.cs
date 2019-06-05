using Microsoft.AspNet.Identity.Owin;
using PsychologicalSupports.Infrastructure;
using System.Web;
using System.Web.Mvc;

namespace PsychologicalSupports.Enum
{
    public static class IdentityHelpers
    {
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            AppUserManager mgr = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            return new MvcHtmlString(mgr.FindByIdAsync(id).Result.UserName);
        }
    }
}