using Domain.Entities;

namespace Domain.Contracts;

public interface IUsersRepository
{
    User? GetUserByUsername(string username);
}
