using PetPal_Model.DTOs;
using PetPal_Model.Models;

namespace PetPal_Business.Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        void Update(Animal animal);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Animal>> GetAnimalsAsync();
        Task<Animal> GetAnimalByIdAsync(int id);
        Task<Animal> GetAnimalByNameAsync(string name);
        Task<IEnumerable<AnimalDto>> GetPetsAsync();
        Task<AnimalDto> GetPetsAsync(string name);
    }
}
