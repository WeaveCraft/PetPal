using PetPal_Model.Models;

namespace PetPal_Business.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
