using System.Security.Claims;

namespace PetPal_Business.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUsername(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.Name);
        }

        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var userIdValue = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(userIdValue);
        }
    }
}
