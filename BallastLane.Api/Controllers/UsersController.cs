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
        public UsersController(IUserService service) : base(service)
        {
        }
    }
}
