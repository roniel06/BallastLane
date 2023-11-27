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
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) : base(userRepository)
        {
        }
    }
}
