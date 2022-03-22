using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProHub.Core.Helpers
{
    public static class UserHelper
    {
        public static string UserEmail(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Name);
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string UserMobile(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.MobilePhone);
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string UserId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.NameIdentifier);
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string UserToken(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ConstantHelper.TokenClaim);
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
