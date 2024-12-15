using Domain.Enums;

namespace Infrastructure.DTO;

public record UserInfoDTO(
    long Id,
    string Name,
    string Surname,
    string Email,
    UserRoles Role);