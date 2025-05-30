using Domain.Contracts;
using Domain.Entities.Base;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Persistence.Implementations.Base;

public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase
{
    protected readonly DatabaseContext _dbContext;
    protected DbSet<TEntity> DbSetEntity { get; set; }

    public virtual IQueryable<TEntity> Query => _dbContext.Set<TEntity>();

    public RepositoryBase(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
        DbSetEntity = _dbContext.Set<TEntity>();
    }

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

    public virtual async Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return (await DbSetEntity.AddAsync(entity, cancellationToken)).State == EntityState.Added;
    }

    public virtual async Task<bool> RemoveAsync(long entityId, CancellationToken cancellationToken = default)
    {
        return (await DbSetEntity.Where(x => x.Id == entityId)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken)) > 0;
    }

    public virtual async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return (await _dbContext.SaveChangesAsync(cancellationToken)) > 0;
    }

    public virtual async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return await Task.FromResult(DbSetEntity.Update(entity).State == EntityState.Modified);
    }
}
