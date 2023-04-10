using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetPal_Business.Services.Interfaces;
using PetPal_DataAccess.Data;
using PetPal_Model.DTOs;
using PetPal_Model.Models;
using System.Security.Cryptography;
using System.Text;

namespace PetPal_Api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(ApplicationDbContext context, ITokenService tokenService, IMapper mapper)
        {
            _context = context;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("register")] // POST: api/account/register?username=dave&password=pwd
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if(await UserExists(registerDto.Username)) return BadRequest("Username is Taken");

            var user = _mapper.Map<AppUser>(registerDto);

            using var hmac = new HMACSHA512(); //Password Salt

            user.Username = registerDto.Username.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
            user.PasswordSalt = hmac.Key;
            
            _context.AppUsers.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                UserName = user.Username,
                Token = _tokenService.CreateToken(user),
                KnownAs = user.KnownAs
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.AppUsers
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.Username == loginDto.Username);

            if (user == null) return Unauthorized();

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }

            return new UserDto
            {
                UserName = user.Username,
                Token = _tokenService.CreateToken(user),
                PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain)?.Url,
                KnownAs = user.KnownAs
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.AppUsers.AnyAsync(x => x.Username == username.ToLower());
        }
    }
}
