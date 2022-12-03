using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetPal_DataAccess.Data;
using PetPal_DataAccess.Models;

namespace PetPal_Api.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly ApplicationDbContext _context;
        public BuggyController(ApplicationDbContext context) 
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _context.AppUsers.Find(-1);

            if (thing == null) return NotFound();

            return thing;
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {

            var thing = _context.AppUsers.Find(-1);

            var thingToReturn = thing.ToString();

            return thingToReturn;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }
    }
}
