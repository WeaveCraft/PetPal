using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetPal_Business.Extensions;
using PetPal_Business.Repositories.Interfaces;
using PetPal_Business.Services.Interfaces;
using PetPal_Model.DTOs;
using PetPal_Model.Models;

namespace PetPal_Api.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        public UsersController(IUserRepository userRepository, IMapper mapper, IPhotoService photoService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _photoService = photoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _userRepository.GetMembersAsync();

            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await _userRepository.GetMemberAsync(username);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetAnimalName());

            if (user == null) return NotFound();

            _mapper.Map(memberUpdateDto, user);

            if (await _userRepository.SaveAllAsync()) 
               return NoContent();

            return BadRequest("Error in updating member!");
        }

        //[HttpPost("add-photo")]
        //public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
        //{
        //    var user = await _userRepository.GetUserByUsernameAsync(User.GetUserName());

        //    if(user == null) return NotFound();

        //    var result = await _photoService.AddPhotoAsync(file); 

        //    if(result.Error != null) return BadRequest(result.Error.Message);

        //    var photo = new Photo
        //    {
        //        Url = result.SecureUrl.AbsoluteUri,
        //        PublicId = result.PublicId
        //    };

        //    if (user.Photos.Count == 0) photo.IsMain = true;

        //    user.Photos.Add(photo);
        //}
    }
}
