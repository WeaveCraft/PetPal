using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetPal_Business.Interfaces;
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

        public AccountController(ApplicationDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")] // POST: api/account/register?username=dave&password=pwd
        public async Task<ActionResult<UserDto>> Register(RegisterDTO registerDto)
        {
            if(await UserExists(registerDto.Username)) return BadRequest("Username is Taken");

            using var hmac = new HMACSHA512(); //Password Salt

            var user = new AppUser
            {
                Username = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            
            _context.AppUsers.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.AppUsers.SingleOrDefaultAsync(x => x.Username == loginDto.Username);

            if (user == null) return Unauthorized();

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }

            return new UserDto
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.AppUsers.AnyAsync(x => x.Username == username.ToLower());
        }
    }
}
