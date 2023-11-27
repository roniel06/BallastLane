using BallastLane.Infrastructure.Context;
using BallastLane.Infrastructure.Models.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BallastLane.Infrastructure.Repositories.Core;

public class Repository<T> : IRepository<T> where T : BaseModel, new()
{
    private readonly ProjectDbContext _dbContext;
    private DbSet<T> _dbSet;
    private ILogger<Repository<T>> _logger;

    public Repository(ProjectDbContext context, ILogger<Repository<T>> logger)
    {
        _dbContext = context;
        _dbSet = _dbContext.Set<T>();
        _logger = logger;
    }

    ///<inheritdoc/>
    public async Task<T?> CreateAsync(T model)
    {
        try
        {
            await _dbContext.AddAsync(model);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return model;
            }
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw;
        }
    }

    ///<inheritdoc/>
    public async Task<bool> DeleteAsync(int id)
    {
        var record = await _dbSet.FindAsync(id);
        if (record != null)
        {
            try
            {
                record.IsDeleted = true;
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }
        _logger.LogInformation($"No record was found with id:{id}");
        return false;
    }

    ///<inheritdoc/>
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    ///<inheritdoc/>
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    ///<inheritdoc/>
    public IQueryable<T> GetQueryable()
    {
        return _dbSet.AsQueryable();
    }

    ///<inheritdoc/>
    public async Task<T?> UpdateAsync(T model)
    {
        try
        {
            _dbSet.Update(model);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return model;
            }
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }
    }
}
