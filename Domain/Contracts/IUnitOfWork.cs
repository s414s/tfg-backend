namespace Domain.Contracts;

public interface IUnitOfWork
{
    bool HasActiveTransaction { get; }
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RoolbackTransactionAsync();
}
