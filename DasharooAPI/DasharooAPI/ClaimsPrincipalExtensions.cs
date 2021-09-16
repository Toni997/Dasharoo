using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DasharooAPI
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("email");
        }

        public static string GetUserId(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("id");
        }

        public static string GetUserName(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("userName");
        }

        public static bool IsCurrentUser(this ClaimsPrincipal principal, string id)
        {
            var currentUserId = GetUserId(principal);

            return string.Equals(currentUserId, id, StringComparison.OrdinalIgnoreCase);
        }
    }
}