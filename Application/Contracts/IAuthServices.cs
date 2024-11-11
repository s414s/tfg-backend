using Application.DTO;

namespace Application.Contracts;

public interface IAuthServices
{
    string GenerateJWT(UserDTO userInf0);
    void SignUp(string email, string password, string passwordRepeat);
    UserDTO GetUserInfo();
}
