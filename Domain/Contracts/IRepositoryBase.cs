using Domain.Entities.Base;

namespace Domain.Contracts;

public interface IRepository<TEntity> where TEntity : EntityBase
{
    IQueryable<TEntity> Query { get; }
    //IUnitOfWork UnitOfWork { get; }
    Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<long> AddAndSaveChangesAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<bool> RemoveAsync(long entityId, CancellationToken cancellationToken = default);
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
}
