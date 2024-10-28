using Domain.Entities;

namespace Domain.Contracts;

public interface IUsersRepository
{
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetByCredentials(string email, string password);
}
