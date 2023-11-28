using BallastLane.Business.Services.Core;
using BallastLane.Infrastructure.Models;
using BallastLane.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BallastLane.Business.Services
{
    public interface IUserService: IBaseService<User>
    {
        Task<User?> GetUserWithNotes(int id);
    }

    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserWithNotes(int id)
        {
            var user  = await _userRepository.GetQueryable().Include(x=> x.Notes).FirstOrDefaultAsync(x=> x.Id == id);
            return user;
        }
    }
}
