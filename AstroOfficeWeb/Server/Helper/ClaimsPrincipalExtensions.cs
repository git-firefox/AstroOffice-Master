using System.Security.Claims;

namespace AstroOfficeWeb.Server.Helper
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetUserFullName(this ClaimsPrincipal claimsPrincipal)
        {
            var fullNameClaim = claimsPrincipal.FindFirst(ClaimTypes.Name);
            return fullNameClaim?.Value;
        }

        public static long GetUserSno(this ClaimsPrincipal claimsPrincipal)
        {
            var nameIdentifierClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
            var aUserSno = Convert.ToInt64(nameIdentifierClaim?.Value);
            return aUserSno;
        }
    }
}
