using BallastLane.Business.Services.Core;
using BallastLane.Infrastructure.Models;
using BallastLane.Infrastructure.Repositories;

namespace BallastLane.Business.Services
{
    public interface IUserService: IBaseService<User>
    {

    }

    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUserRepository userRepository) : base(userRepository)
        {
        }
    }
}
