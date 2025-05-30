using Domain.Entities;

namespace Application.Contracts;

public interface IAuthServices
{
    string GenerateJWT(ActiveUserInfo userInfo);
}
