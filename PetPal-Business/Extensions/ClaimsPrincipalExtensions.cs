using System.Security.Claims;

namespace PetPal_Business.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetAnimalName(this ClaimsPrincipal animal)
        {
            return animal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
