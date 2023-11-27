using BallastLane.Infrastructure.Models.Core;
using BallastLane.Infrastructure.Repositories.Core;

namespace BallastLane.Business.Services.Core
{
    /// <summary>
    /// Base service for service implementations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T> : IBaseService<T>
        where T : BaseModel, new()
    {

        private readonly IRepository<T> _repository;
        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<T?> CreateAsync(T model)
        {
            return await _repository.CreateAsync(model);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<T?> UpdateAsync(T model)
        {
            return await _repository.UpdateAsync(model);
        }
    }
}
