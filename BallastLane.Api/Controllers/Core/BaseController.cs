using BallastLane.Business.Services.Core;
using BallastLane.Infrastructure.Models.Core;
using Microsoft.AspNetCore.Mvc;

namespace BallastLane.Api.Controllers.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity, TService> : ControllerBase
        where TEntity : BaseModel, new()
        where TService : BaseService<TEntity>
    {

        private readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Create(TEntity entity)
        {
            return null;
        }
    }
}
