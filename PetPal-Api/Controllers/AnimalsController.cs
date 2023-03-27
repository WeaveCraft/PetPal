using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetPal_Business.Extensions;
using PetPal_Business.Repositories.Interfaces;
using PetPal_Business.Services.Interfaces;
using PetPal_Model.DTOs;
using PetPal_Model.Models;

namespace PetPal_Api.Controllers
{
    public class AnimalsController : BaseApiController
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        public AnimalsController(IAnimalRepository animalRepository, IMapper mapper, IPhotoService photoService)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
            _photoService = photoService;
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

        //[HttpPut]
        //public async Task<ActionResult> UpdateAnimal(AnimalUpdateDto animalUpdateDto)
        //{
        //    var animal = await _animalRepository.GetAnimalByNameAsync(User.GetUserName());

        //    if (animal == null) return NotFound();

        //    _mapper.Map(animalUpdateDto, animal);

        //    if (await _animalRepository.SaveAllAsync())
        //        return NoContent();

        //    return BadRequest("Error in updating member!");
        //}

        //[HttpPost("add-photo")]
        //public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
        //{
        //    var animal = await _animalRepository.GetAnimalByNameAsync(User.GetAnimalName());

        //    if (animal == null) return NotFound();

        //    var result = await _photoService.AddPhotoAsync(file);

        //    if (result.Error != null) return BadRequest(result.Error.Message);

        //    var photo = new Photo
        //    {
        //        Url = result.SecureUrl.AbsoluteUri,
        //        PublicId = result.PublicId
        //    };

        //    if (animal.Photos.Count == 0) photo.IsMain = true;

        //    animal.Photos.Add(photo);

        //    if (await _animalRepository.SaveAllAsync()) return _mapper.Map<PhotoDto>(photo);

        //    return BadRequest("There was a problem adding the photo");
        //}
    }
}
