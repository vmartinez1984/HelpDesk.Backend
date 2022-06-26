using System.Security.Claims;
using System.Security.Principal;

namespace Helpdesk.Mvc.Helpers
{
    public class SessionHelper
    {
        public static string GetValue(IPrincipal User, string Property)
        {
            var r = ((ClaimsIdentity)User.Identity).FindFirst(Property);
            return r == null ? "" : r.Value;
        }

        public static int GetNameIdentifier(IPrincipal User)
        {
            var r = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier);
            return r == null ? 0 : Convert.ToInt32(r.Value);
        }

        public static string GetName(IPrincipal User)
        {
            var r = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name);
            return r == null ? "" : r.Value;
        }
    }
}