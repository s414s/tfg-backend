using Domain.Contracts;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Implementations.Base;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
{
    private readonly DbContext _dbContext;
    protected DbSet<TEntity> DbSetEntity { get; set; }

    public virtual IQueryable<TEntity> Query => _dbContext.Set<TEntity>();
    public virtual IQueryable<TEntity> QueryWithDeleted => _dbContext.Set<TEntity>();


    public IUnitOfWork UnitOfWork => throw new NotImplementedException();

    public virtual async Task<long> AddAndSaveChangesAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        EntityEntry<TEntity> entityAdded = await DbSetEntity.AddAsync(entity, cancellationToken);
        long key = 0;
        if (await SaveChangesAsync(cancellationToken) && entityAdded.IsKeySet)
        {
            object? obj = entity.GetType().GetProperty(nameof(EntityBase.Id))?.GetValue(entity, null);
            if (obj is not null)
            {
                key = (long)obj;
            }
        }
        return key;
    }

    public async Task<long> AddAndSaveChangesAsync(TEntity entity, bool withDetachedProtection, bool clearTracker = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Add an entity
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The number of entites added</returns>
    public async Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return (await DbSetEntity.AddAsync(entity, cancellationToken)).State == EntityState.Added;
    }

    public virtual async Task AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await DbSetEntity.AddRangeAsync(entities, cancellationToken);
    }

    public Task<TEntity> GetByIdAsync(long entityId, bool queryWithDelted = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Remove(Expression<Func<TEntity, bool>> where)
    {
        IQueryable<TEntity> queryable = DbSetEntity.Where(where);
        if (typeof(SoftDeleteEntity).IsAssignableFrom(DbSetEntity.EntityType.ClrType))
        {
            List<TEntity> list = queryable.ToList();
            list.ForEach(delegate (TEntity entity)
            {
                (entity as SoftDeleteEntity).IsDeleted = true;
            });
            DbSetEntity.UpdateRange(list);
        }
        else
        {
            DbSetEntity.RemoveRange(queryable);
        }
    }

    public virtual async Task<bool> RemoveAsync(long entityId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<bool> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity is null)
        {
            return false;
        }

        if (entity is SoftDeleteEntity sE)
        {
            sE.IsDeleted = true;
            return await Task.FromResult(DbSetEntity.Update(entity).State == EntityState.Modified);
        }

        return await Task.FromResult(DbSetEntity.Remove(entity).State == EntityState.Deleted);
    }

    public Task<int> SaveChangesAndClearTrackerAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        int num = await _dbContext.SaveChangesAsync(cancellationToken);
        return num > 0;
    }

    public Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }
}
