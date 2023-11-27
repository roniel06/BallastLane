using BallastLane.Infrastructure.Context;
using BallastLane.Infrastructure.Models;
using BallastLane.Infrastructure.Repositories.Core;
using Microsoft.Extensions.Logging;

namespace BallastLane.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository<User>
    {

    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ProjectDbContext context, ILogger<Repository<User>> logger) : base(context, logger)
        {
        }
    }
}
