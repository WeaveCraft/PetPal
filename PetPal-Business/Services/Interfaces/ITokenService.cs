using PetPal_Model.Models;

namespace PetPal_Business.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
