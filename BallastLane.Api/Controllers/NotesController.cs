using BallastLane.Api.Controllers.Core;
using BallastLane.Business.Services;
using BallastLane.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BallastLane.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : BaseController<Note, INoteService>
    {
        public NotesController(INoteService service) : base(service)
        {
        }
    }
}
