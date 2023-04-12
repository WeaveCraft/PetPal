using System.Security.Claims;

namespace PetPal_Business.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUsername(this ClaimsPrincipal member)
        {
            return member.FindFirst(ClaimTypes.Name)?.Value;
        }
        public static int GetUserId(this ClaimsPrincipal member)
        {
            return int.Parse(member.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
