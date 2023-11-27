using BallastLane.Infrastructure.Context;
using BallastLane.Infrastructure.Models;
using BallastLane.Infrastructure.Repositories.Core;
using Microsoft.Extensions.Logging;

namespace BallastLane.Infrastructure.Repositories
{
    public interface INoteRepository : IRepository<Note> { }
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(ProjectDbContext context, ILogger<Repository<Note>> logger) : base(context, logger)
        {
        }
    }
}
