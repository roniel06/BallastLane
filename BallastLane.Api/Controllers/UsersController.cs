using BallastLane.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace BallastLane.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(new List<User>());
        }

    }
}
