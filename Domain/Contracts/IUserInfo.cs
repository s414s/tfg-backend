namespace Domain.Contracts;

public interface IUserInfo
{
    T GetUserInfo<T>() where T : class, new();
}
