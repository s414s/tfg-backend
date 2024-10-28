using Domain.Entities.Base;
using System.Linq.Expressions;

namespace Domain.Contracts;

public interface IRepositoryBase<TEntity> where TEntity : EntityBase
{
    IQueryable<TEntity> Query { get; }
    IQueryable<TEntity> QueryWithDeleted { get; }
    IUnitOfWork UnitOfWork { get; }
    Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    Task<long> AddAndSaveChangesAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    Task AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
    Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    void UpdateRange(IEnumerable<TEntity> entities);
    Task<bool> RemoveAsync(long entityId, CancellationToken cancellationToken = default(CancellationToken));
    Task<bool> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    void Remove(Expression<Func<TEntity, bool>> where);
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    Task<int> SaveChangesAndClearTrackerAsync(CancellationToken cancellationToken = default(CancellationToken));
    Task<long> AddAndSaveChangesAsync(TEntity entity, bool withDetachedProtection, bool clearTracker = false, CancellationToken cancellationToken = default(CancellationToken));
    Task<TEntity> GetByIdAsync(long entityId, bool queryWithDelted = false, CancellationToken cancellationToken = default(CancellationToken));
}
