using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetPal_DataAccess.Data;
using PetPal_Model.Models;

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

        [HttpGet("not-found")] //404
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _context.AppUsers.Find(-1);

            if (thing == null) return NotFound();

            return thing;
        }

        [HttpGet("server-error")] //500
        public ActionResult<string> GetServerError()
        {

            var thing = _context.AppUsers.Find(-1);

            var thingToReturn = thing.ToString();

            return thingToReturn;
        }

        [HttpGet("bad-request")] //401
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }
    }
}
