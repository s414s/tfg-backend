using Domain.Enums;

namespace Application.DTO;

public record UserDTO(string Name, string Surname, UserRoles Role);