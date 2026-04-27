using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Abstractions.Repositories;

public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
    where TEntity : class
    where TContext : DbContext
{
    protected readonly TContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(TContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync([id], cancellationToken);
    }

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public virtual async Task SoftDeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity != null)
        {
            var activeProp = entity.GetType().GetProperty("Active", BindingFlags.Public | BindingFlags.Instance);
            if (activeProp != null && activeProp.PropertyType == typeof(bool))
            {
                activeProp.SetValue(entity, false);
                _dbSet.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
