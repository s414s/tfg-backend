using Domain.Enums;

namespace Domain.Entities;

public record ActiveUserInfo
{
    public required long Id { get; init; }
    public required string Name { get; init; }
    public required string Surname { get; init; }
    public required string Email { get; init; }
    public required UserRoles Role { get; init; }
}
