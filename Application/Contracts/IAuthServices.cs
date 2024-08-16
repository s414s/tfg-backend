using Application.DTO;

namespace Application.Contracts;

public interface IAuthServices
{
    LoginResponseDTO Login(string email, string password);
    void SignUp(string email, string password, string passwordRepeat);
}
