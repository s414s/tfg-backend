using Application.DTO;
using Domain.Contracts;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application.Services;

public class UserInfoService : IUserInfo
{
    private readonly IHttpContextAccessor _httpContext;

    public UserInfoService(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
    }

    public T GetUserInfo<T>() where T : class, new()
    {
        ClaimsPrincipal claimsPrincipal = _httpContext.HttpContext?.User
            ?? throw new Exception();

        if (typeof(T) != typeof(UserDTO))
            throw new NotSupportedException($"User info mapping not supported for type {typeof(T)}");

        var id = claimsPrincipal.Claims.First(x => x.Type == "id").Value;
        var name = claimsPrincipal.Claims.First(x => x.Type == ClaimTypes.Name).Value;
        var surname = claimsPrincipal.Claims.First(x => x.Type == ClaimTypes.Surname).Value;
        var email = claimsPrincipal.Claims.First(x => x.Type == ClaimTypes.Email).Value;
        var role = claimsPrincipal.Claims.First(x => x.Type == ClaimTypes.Role).Value;

        return (T)(object)new UserDTO
        {
            Id = long.Parse(id),
            Name = name,
            Surname = surname,
            Email = email,
            Role = Enum.Parse<UserRoles>(role),
        };
    }
}
