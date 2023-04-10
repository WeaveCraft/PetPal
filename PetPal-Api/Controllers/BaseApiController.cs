using Microsoft.AspNetCore.Mvc;
using PetPal_Business.Helpers;

namespace PetPal_Api.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))] //updates "LastActive" column in DB for user.
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {

    }
}
