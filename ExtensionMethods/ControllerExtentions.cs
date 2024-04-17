using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace HouseholdManagerApi.ExtensionMethods
{
    public static class ControllerExtentions
    {
        public static string GetUserIdFromJwtToken(this ControllerBase controller)
        {
            // Cast to ClaimsIdentity.
            var identity = controller.HttpContext.User.Identity as ClaimsIdentity;

            // Gets list of claims.
            IEnumerable<Claim> claim = identity.Claims;

            // Gets name from claims. Generally it's an email address.
            var userId = claim
                .Where(x => x.Type == "userId")
                .FirstOrDefault();

            return userId.Value;
        }
    }
}
