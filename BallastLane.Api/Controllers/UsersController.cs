using BallastLane.Api.Controllers.Core;
using BallastLane.Business.Services;
using BallastLane.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace BallastLane.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<User, IUserService>
    {
        private IUserService _userService;
        public UsersController(IUserService service) : base(service)
        {
            _userService = service;
        }

        [HttpGet("GetUserWithNotes/{id}")]
        public async Task<IActionResult> GetUserWithNotes(int id)
        {
            if (id > 0)
            {
                var result = await _userService.GetUserWithNotes(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NoContent();
            }
            return BadRequest();
        }
    }
}
