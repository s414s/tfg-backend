using Application.DTO;

namespace Application.Contracts;

public interface IAuthServices
{
    string GenerateJWT(UserDTO userInfo);
    UserDTO GetActiveUserInfo();
}
