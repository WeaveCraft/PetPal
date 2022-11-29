using Microsoft.AspNetCore.Mvc;
using PetPal_DataAccess.Data;
using PetPal_DataAccess.Models;
using System.Security.Cryptography;
using System.Text;

namespace PetPal_Api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")] // POST: api/account/register?username=dave&password=pwd
        public async Task<ActionResult<AppUser>> Register(string username, string password)
        {
            using var hmac = new HMACSHA512(); //Password Salt

            var user = new AppUser
            {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };
            
            _context.AppUsers.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
