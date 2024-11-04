using Domain.Enums;

namespace Application.DTO;

public record UserDTO
{
    public long Id { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public UserRoles Role { get; init; }
};