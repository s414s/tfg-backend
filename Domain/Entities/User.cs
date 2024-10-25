using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class User : EntityBase
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    public UserRoles Role { get; set; }
    public DateOnly BirthDay { get; set; } = new DateOnly();
    public DateTime CreatedAT { get; set; }
}
