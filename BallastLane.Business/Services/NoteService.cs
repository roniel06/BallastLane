using BallastLane.Business.Services.Core;
using BallastLane.Infrastructure.Models;
using BallastLane.Infrastructure.Repositories;

namespace BallastLane.Business.Services
{

    public interface INoteService : IBaseService<Note> { }
    public class NoteService : BaseService<Note>, INoteService
    {
        public NoteService(INoteRepository repository) : base(repository)
        {
        }
    }
}
