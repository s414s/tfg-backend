using Domain.Entities;

namespace Domain.Contracts;

//public interface IUserInfo<T> where T : class, new()
public interface IUserInfo
{
    ActiveUserInfo User { get; }
    //T Get();
    //T Get<T>() where T : class, new();
}
