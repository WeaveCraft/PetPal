using Microsoft.AspNetCore.Mvc;
using PetPal_DataAccess.Data;
using PetPal_DataAccess.Models;

namespace PetPal_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // /api/users
    public class UsersController
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            var users = _context.AppUsers.ToList();

            return users;
        }

        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            var user = _context.AppUsers.Find(id);

            return user;
        }
    }
}
