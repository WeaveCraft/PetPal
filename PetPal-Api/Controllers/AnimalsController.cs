using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetPal_Business.Repositories.Interfaces;
using PetPal_Model.DTOs;

namespace PetPal_Api.Controllers
{
    public class AnimalsController : BaseApiController
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public AnimalsController(IAnimalRepository animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAnimals()
        {
            var animals = await _animalRepository.GetPetsAsync();

            return Ok(animals);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<AnimalDto>> GetAnimal(string name)
        {
            return await _animalRepository.GetPetsAsync(name);
        }
    }
}
