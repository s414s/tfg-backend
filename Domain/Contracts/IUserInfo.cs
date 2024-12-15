namespace Domain.Contracts;

public interface IUserInfo
{
    T Get<T>() where T : class, new();
}
