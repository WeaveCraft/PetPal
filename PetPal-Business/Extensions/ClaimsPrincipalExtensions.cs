using System.Security.Claims;

namespace PetPal_Business.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserName(this ClaimsPrincipal member)
        {
            return member.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
