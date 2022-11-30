using PetPal_DataAccess.Models;

namespace PetPal_Business.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
